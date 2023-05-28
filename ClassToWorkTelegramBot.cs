using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramBot_BuyYourStyle.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
//    using (var ms = new MemoryStream(byteArrayIn))
//{
//    return Image.FromStream(ms);
//}
public class ClassToWorkTelegramBot
    {

        private readonly CRUD db;
        public ClassToWorkTelegramBot(ApplicationContext context) { db = new CRUD(context); }
        public ClassToWorkTelegramBot() { }
        

        public static async void DownloadFile(TelegramBotClient Bot, Telegram.Bot.Types.Update update, ChatId chatId, CancellationToken cancellationToken)
        {
            var fileId = update.Message.Photo.Last().FileId;
            const string destinationFilePath = "../downloaded.file";

            await using Stream fileStream = System.IO.File.Create(destinationFilePath);
            var file = await Bot.GetInfoAndDownloadFileAsync(
                fileId: fileId,
                destination: fileStream,
                cancellationToken: cancellationToken);
            //add BD 
        }

        public static async void SendFile(TelegramBotClient Bot, ChatId chatId, CancellationToken cancellationToken) => 
            await Bot.SendPhotoAsync(
                chatId: chatId,
                photo: InputFile.FromStream(Stream.Null),
                caption: string.Empty,
                parseMode: ParseMode.Html,
                cancellationToken: cancellationToken);
   
        static public InlineKeyboardButton[] CreateButton(string NameButton, string command) => new[] { InlineKeyboardButton.WithCallbackData(NameButton, command) };

    }
}

