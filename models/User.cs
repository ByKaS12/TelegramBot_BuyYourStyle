using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot_BuyYourStyle.models
{
    public class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public int Discount { get; set; }
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
