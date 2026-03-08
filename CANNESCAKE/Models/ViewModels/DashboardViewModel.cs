using System.Collections.Generic;
using CANNESCAKE.Models;

namespace CANNESCAKE.Models.ViewModels
{
    public class DashboardViewModel
    {
        public int CategoriesCount { get; set; }
        public int CakesCount { get; set; }
        public int OrdersCount { get; set; }
        public int SubscribersCount { get; set; }
        public int TestimonialsCount { get; set; }
        public int MessagesCount { get; set; }
        public List<Order> RecentOrders { get; set; }
        public List<ContactMessage> RecentMessages { get; set; }
    }
}
