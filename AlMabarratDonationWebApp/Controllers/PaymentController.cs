using AlMabarratDonationWebApp.Application.DTO;
using AlMabarratDonationWebApp.Core.Entities;
using AlMabarratDonationWebApp.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;
using Stripe;
using System.Data.Entity;
using AlMabarratDonationWebApp.Application.Interfaces;

[ApiController]
[Route("api/[controller]")]
public class PaymentController : ControllerBase
{
    private readonly AppDbContext _dbContext;

    public PaymentController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost("create-checkout-session")]
    public IActionResult CreateCheckoutSession([FromBody] PaymentRequest request)
    {
        StripeConfiguration.ApiKey = "sk_test_YOUR_KEY_HERE";

        var options = new SessionCreateOptions
        {
            PaymentMethodTypes = new List<string> { "card" },
            LineItems = new List<SessionLineItemOptions>
            {
                new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        Currency = "usd",
                        UnitAmount = (long)(request.Amount * 100),
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = request.PaymentName
                        }
                    },
                    Quantity = 1
                }
            },
            Mode = "payment",
            SuccessUrl = "https://539c-194-126-31-101.ngrok-free.app/PaymentView/payment-success?session_id={CHECKOUT_SESSION_ID}",
            CancelUrl = "https://539c-194-126-31-101.ngrok-free.app/PaymentView/payment-cancelled",




            Metadata = new Dictionary<string, string>
            {
                { "PaymentName", request.PaymentName }
            }
        };

        var service = new SessionService();
        Session session = service.Create(options);

        return Ok(new { url = session.Url });
    }

    [HttpGet("payment-success")]
    public async Task<IActionResult> PaymentSuccess([FromQuery] string session_id, [FromServices] IPaymentService paymentService)
    {
        var service = new SessionService();
        var session = service.Get(session_id);

        if (session == null || session.Metadata == null || !session.Metadata.ContainsKey("PaymentName"))
            return BadRequest(new { message = "Invalid session or missing metadata." });

        string paymentName = session.Metadata["PaymentName"];
        decimal amount = session.AmountTotal.HasValue ? session.AmountTotal.Value / 100m : 0;

        try
        {
            var response = await paymentService.ProcessSuccessfulPaymentAsync(paymentName, amount);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }


    public class PaymentRequest
    {
        public string PaymentName { get; set; }
        public decimal Amount { get; set; }
    }
}