using Telegram.Bot;

namespace WPFShapBot.Models
{
    public class TeleBot
    {

        private static readonly string token = "1832274388:AAHLBAsvNtNTPXrhkOUu36eBPZL0PWLnXGM";
        protected static TelegramBotClient bot = new TelegramBotClient(token: token);


        public static TelegramBotClient Bot { get => bot; set => bot = value; }

    }
}
