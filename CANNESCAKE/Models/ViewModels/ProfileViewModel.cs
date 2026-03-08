using CANNESCAKE.Models;
using System.Collections.Generic;

namespace CANNESCAKE.Models.ViewModels
{
    public class ProfileViewModel
    {
        public AppUser User { get; set; } = null!;
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
