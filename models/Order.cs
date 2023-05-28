using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot_BuyYourStyle.models
{
    public class Order
    {
        public Guid Id { get; set; }
        public string CodeOrder { get; set; } = string.Empty;
        public virtual ICollection<Item> Items { get; set; } = new List<Item>();
        public Guid UserId { get; set; }
        public virtual User User { get; set; } = null!;
    }
}
