using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBot_BuyYourStyle
{
    enum BotCommand : int
    {
        Menu = 0,
        Order = 1,
        AccessOrder = 2,
        SendLogin = 3,
        SendPass = 4,
        CheckOrder = 5


    }
    internal class ClassToWorkTelegramBot
    {
        public ClassToWorkTelegramBot() { }

        static public InlineKeyboardButton[] CreateButton(string NameButton, string command) => new[] { InlineKeyboardButton.WithCallbackData(NameButton, command) };

    }
}
