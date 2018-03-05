using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;

namespace Console
{
    class Program
    {
        private static int Counter = 1;
        private static int MessageId = 1;
        private static readonly TelegramBotClient Bot = new TelegramBotClient("504837523:AAFdBl2L67i_4x_xEgDownwxyH0YpYmdSUg");
        static void Main(string[] args)
        {
            Bot.OnMessage += BotOnMessage;
            Bot.OnMessageEdited += BotOnMessage;
            Bot.StartReceiving();
            System.Console.ReadLine();
            Bot.StopReceiving();
        }

        private static async void BotOnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            if (e.Message.Type == Telegram.Bot.Types.Enums.MessageType.TextMessage)
            {
                if (e.Message.Text == "Status")
                {
                    var message = await Bot.SendTextMessageAsync(e.Message.Chat.Id, "Started : " + Counter.ToString());
                    MessageId = message.MessageId;
                    for (int i = 0; i < 100; i++)
                    {
                        int milliseconds = 500;
                        Thread.Sleep(milliseconds);
                        var x1 = Bot.EditMessageTextAsync(e.Message.Chat.Id, MessageId, "Status: " + i+"%");
                    }
                }
            }
        }
    }
}
