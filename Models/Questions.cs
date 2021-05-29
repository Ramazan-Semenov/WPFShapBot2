using System.Threading;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace WPFShapBot.Models
{
    public class Questions
    {

        private int id;
        public int ID
        {
            get => id;
            set => id = value;
        }

        private string text;
        public string Text
        {
            get => text;
            set => text = value;
        }
        public ParseMode parseMode = ParseMode.Default;
        public bool disableWebPagePreview = false;
        public bool disableNotification = false;
        public int replyToMessageId = 0;
        public IReplyMarkup replyMarkup = new ReplyKeyboardRemove();
        public CancellationToken cancellationToken = default;

    }
}
