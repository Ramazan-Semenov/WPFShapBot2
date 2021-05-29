using Telegram.Bot;

namespace WPFShapBot.Models
{
    public class TeleBot
    {

        private static readonly string token = "1833119055:AAFk3L81Z4lHybJo54uusZWCBX2a6D6z2hI";
        protected static TelegramBotClient bot = new TelegramBotClient(token: token);


        public static TelegramBotClient Bot { get => bot; set => bot = value; }

    }
}
