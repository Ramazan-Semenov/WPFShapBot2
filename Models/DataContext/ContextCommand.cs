using System.Collections.Generic;
using System.Collections.ObjectModel;
using Telegram.Bot.Types.ReplyMarkups;
using WPFShapBot.Models.Commandbot;

namespace WPFShapBot.Models.DataContext
{
    class ContextCommand
    {
        private static ObservableCollection<Questions> resert = ContextQuest.Questions;

        private static ObservableCollection<ComBot> com = new ObservableCollection<ComBot>();

        public static ObservableCollection<ComBot> Com { get => com; set => com = value; }

      static  void print()
        {
            TeleBot.Bot.SendTextMessageAsync(1643805757, "Roma");
        }
        public static ObservableCollection<ComBot> GetComBots()
        {
            List<string> vs = new List<string>();
            vs.Add("send");

            ObservableCollection<Questions>  questions  = new ObservableCollection<Questions>();

            questions.Add(new Questions { ID = 1, Text = "фио" });
            questions.Add(new Questions { ID = 2, Text = "номер телефона" });
            questions.Add(new Questions { ID = 2, Text = "Отправить", replyMarkup= (IReplyMarkup)new BotButtons().GenInlineButton(vs) });

            ObservableCollection <Questions> command1 = new ObservableCollection<Questions>();
            command1.Add(new Questions { ID = 2, Text = "Отправлено" });

            //////////////////////////////////////////////////////////////////
            com.Add(new ComBot(questions, write: true) { Name = "Command_1" });
            com.Add(new ComBot(resert, write: false) { Name = "Command_3" });


          //  com.Add(new ComBot(questions,print)  { Name = "send" });

            return Com;

        }
        public static void AddComBots(ComBot comBot)
        {

            com.Add(comBot);
        }
        public static void DelComBots(ComBot comBot)
        {

            com.Remove(comBot);

        }
    }
}
