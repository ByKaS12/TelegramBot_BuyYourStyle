using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramBot_BuyYourStyle;



TelegramBotClient botClient = new TelegramBotClient("6056689939:AAF1p-qpx_1zS8ClqTnG6cfoCjRuaDrjjIQ");
using CancellationTokenSource cts = new();
List<InlineKeyboardMarkup> test = new List<InlineKeyboardMarkup>
{
    new[] { ClassToWorkTelegramBot.CreateButton("Меню", "menu") },
    new[] { ClassToWorkTelegramBot.CreateButton("Заказать", "Order"), ClassToWorkTelegramBot.CreateButton("Выйти", "EndUser") },
    new[] { ClassToWorkTelegramBot.CreateButton("Подтвердить заказ", "AccessOrder") },
    new[] { ClassToWorkTelegramBot.CreateButton("Отправить логин", "SendLogin") },
    new[] { ClassToWorkTelegramBot.CreateButton("Отправить пароль", "SendPass") },
    new[] { ClassToWorkTelegramBot.CreateButton("Посмотреть заказы", "CheckOrder"), ClassToWorkTelegramBot.CreateButton("Выйти", "EndAdmin") },
    new[] { ClassToWorkTelegramBot.CreateButton("", "menu") }

};

// StartReceiving does not block the caller thread. Receiving is done on the ThreadPool.
ReceiverOptions receiverOptions = new()
{
    AllowedUpdates = Array.Empty<UpdateType>() // receive all update types except ChatMember related updates
};
string copyData = "";
botClient.StartReceiving(
    updateHandler: HandleUpdateAsync,
    pollingErrorHandler: HandlePollingErrorAsync,
    receiverOptions: receiverOptions,
    cancellationToken: cts.Token
);

var me = await botClient.GetMeAsync();

Console.WriteLine($"Start listening for @{me.Username}");
Console.ReadLine();

// Send cancellation request to stop bot
cts.Cancel();

async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
{
    
    Message? message;
    string? messageText;
    long? chatId;
    bool flag = true;
    if (update.Message != null)
        flag = true;
    else if (update.CallbackQuery != null)
        flag = false;
    else return;

    if (flag) {
        message = update.Message;
        messageText = message.Text;
        chatId = message.Chat.Id;
    }
    else
    {
        message = update.CallbackQuery.Message;
        messageText = message.Text;
        chatId = message.Chat.Id;
    }
    Console.WriteLine($"Received a '{messageText}' message in chat {chatId}.");
    Console.WriteLine($"{message.From.Username}");
    if (update.Type == UpdateType.CallbackQuery)
    {
        var callbackQuery = update.CallbackQuery;
        switch (callbackQuery.Data)
        {

            case "menu":
                {
                    
                    break;
                }
            case "Order":
                {
                    string text = "Введите данные заказа, а затем нажмите на кнопку подтвердить:\n" +
                        "1. ФИО\n" +
                        "2. Артикул(ы) товара  (если артикулов больше одного, то через пробел)\n" +
                        "3. Количество товара(ов)  (если артикулов больше одного, то на каждый артикул своё количество товаров через пробел)\n" +
                        "4. Адрес доставки\n" +
                        "5. Индекс\n";
                    await botClient.SendTextMessageAsync(message.Chat.Id, text, replyMarkup: test[(int)TelegramBot_BuyYourStyle.BotCommand.AccessOrder], cancellationToken: cancellationToken);

                    break;
                }
            case "AccessOrder":
                {
                    Console.WriteLine(copyData);
                    string text = "Заказ успешно создан!\n" + "Ожидайте сообщения о заказе от нашего специалиста!\n";
                    await botClient.SendTextMessageAsync(message.Chat.Id, text, replyMarkup: test[(int)TelegramBot_BuyYourStyle.BotCommand.Order], cancellationToken: cancellationToken);
                    var testStr = copyData.Split("\n");
                    break;
                }
            default:
                break;
        }
    }
        switch (messageText.ToLower())
    {
        case "/start":
            {
                string text = "Здравствуй, Уважаемый покупатель магазина BuyYourStyle!\nЯ бот и помогу тебе оформить заказ!\nНажми на кнопку заказать для продолжения!\n";
                await botClient.SendTextMessageAsync(message.Chat.Id, text, replyMarkup: test[(int)TelegramBot_BuyYourStyle.BotCommand.Order], cancellationToken: cancellationToken);
                break;
            }
        case "/admin":
            {
                Message sentMessage = await botClient.SendTextMessageAsync(
    chatId: chatId,
    text: "Введи пароль:\n",
    cancellationToken: cancellationToken);
                break;
            }

        default:
            break;
    }


    copyData = messageText;
    // Echo received message text

}

Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
{
    var ErrorMessage = exception switch
    {
        ApiRequestException apiRequestException
            => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
        _ => exception.ToString()
    };

    Console.WriteLine(ErrorMessage);
    return Task.CompletedTask;
}