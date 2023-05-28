using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot_BuyYourStyle.models
{
    public class Item
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public byte[] ByteImage { get; set; }
        public string Code { get; set; } = string.Empty;
        public Guid OrderId { get; set; }
        public virtual Order Order { get; set; } = null!;


    }
}
