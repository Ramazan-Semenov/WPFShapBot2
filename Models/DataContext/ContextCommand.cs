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
            questions.Add(new Questions { ID = 2, Text = "Направление" });
            questions.Add(new Questions { ID = 2, Text = "Отправить анкету", replyMarkup = new BotButtons().send() }) ;

            ObservableCollection<Questions> command1 = new ObservableCollection<Questions>();
            command1.Add(new Questions { ID = 2, Text = "Отправлено" });
            ObservableCollection<Questions> questions1 = new ObservableCollection<Questions>();
            questions1.Add(new Questions { ID = 1, Text = @" Центральная приемная комиссия \n350072,
                г.Краснодар, \nул.Московская,
                д. 2 «А»,
                ауд. 111,
                112 \nТел.: (861) 255 - 25 - 32,
                (861) 274 - 65 - 71" });
            //////////////////////////////////////////////////////////////////
            com.Add(new ComBot(questions, write: true) { Name = "подача документов" });
            com.Add(new ComBot( write: false) { Name = "правила" });
            com.Add(new ComBot( write: false) { Name = "перечень испытаний" });
            com.Add(new ComBot(questions1, write: false) { Name = "информация" });
            com.Add(new ComBot(resert, write: false) { Name = "Начать с начала" });
            com.Add(new ComBot( write: false) { Name = "стоимость обучения" });
            com.Add(new ComBot( write: false) { Name = "Другое" });


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
