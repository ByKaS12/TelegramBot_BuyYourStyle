using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot_BuyYourStyle.Models;

namespace TelegramBot_BuyYourStyle
{
    public class CRUD
    {
        private readonly ApplicationContext Context;
        public CRUD(ApplicationContext context) { Context = context; }
        public async void Save() => await Context.SaveChangesAsync();
    }
}
