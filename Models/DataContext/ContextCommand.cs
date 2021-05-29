using System.Collections.ObjectModel;
using WPFShapBot.Models.Commandbot;

namespace WPFShapBot.Models.DataContext
{
    class ContextCommand
    {
        private static ObservableCollection<Questions> resert = Models.DataContext.ContextQuest.Questions;

        private static ObservableCollection<ComBot> com = new ObservableCollection<Commandbot.ComBot>();

        public static ObservableCollection<ComBot> Com { get => com; set => com = value; }

      static  void print()
        {
            TeleBot.Bot.SendTextMessageAsync(1643805757, "Roma");
        }
        public static ObservableCollection<ComBot> GetComBots()
        {
            ObservableCollection<Questions> command = new ObservableCollection<Questions>();

            command.Add(new Questions { ID = 1, Text = "фио" });
            command.Add(new Questions { ID = 2, Text = "номер телефона" });
            ObservableCollection<Questions> command1 = new ObservableCollection<Questions>();

            //////////////////////////////////////////////////////////////////
            command1.Add(new Questions { ID = 2, Text = "Отправлено" });
            com.Add(new ComBot(command, print) { Name = "Command_1" });
            com.Add(new ComBot(command1) { Name = "send" });
            com.Add(new ComBot(resert) { Name = "Command_3" });

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
