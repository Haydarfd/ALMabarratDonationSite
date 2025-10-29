//using AlMabarratDonationWebApp.Core.Repositories.Base;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace AlMabarratDonationWebApp.Core.Repositories
//{
//    public interface INotificationRepository : IRepository<Notification>
//    {
//    }
//}


// 1. Get Notifications by User (Donor/Staff/Admin)
//List<Notification> GetNotificationsByUserId(string userId, int limit = 50);

// 3. Mark as Read/Unread
//void MarkAsRead(int notificationId);
// 4. Filter by Type (e.g., "Donation", "Sponsorship", "System")
//List<Notification> GetNotificationsByType(string userId, string type);

// 5. Create Notification (with templating support)
//void CreateNotification(string userId, string title, string message,
//                      string type = "System", string relatedEntityId = null);

// 6. Delete Old Notifications (auto-cleanup)
//void DeleteOldNotifications(int daysToKeep = 30);

// 7. Priority Notifications (e.g., urgent alerts)
//List<Notification> GetPriorityNotifications(string userId);


//--------------------------------FYP FEATURE-------------------------------------