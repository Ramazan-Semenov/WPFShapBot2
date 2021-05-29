using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Telegram.Bot.Args;
using WPFShapBot.Models.DataContext;

namespace WPFShapBot.Models.Commandbot
{
   public class ComBot
    {

        // public static ObservableCollection<UserEmail> userEmails;
        static bool ff = false;

          ObservableCollection<Questions> resert = Models.DataContext.ContextQuest.Questions;

       // private static ObservableCollection<Questions> questions = Models.DataContext.ContextQuest.Questions;
          ObservableCollection<Questions> command_1;
        public string Name { get; set; }
       // public static ObservableCollection<Questions> CommandQuestions { get => command; set => command = value; }
       public ComBot ( ObservableCollection<Questions> questions = null)
        {
            if(questions==null)
            {
                questions = new ObservableCollection<Questions>();

            }
                command_1 = new ObservableCollection<Questions>();
            
            command_1 = questions;

        }
        public ComBot()
        {
        
            command_1 = new ObservableCollection<Questions>();


        }
        public void ex(CallbackQueryEventArgs e)
        {

            var person = new BotUser(e.CallbackQuery.Message.Chat.FirstName, e.CallbackQuery.Message.Chat.Id);

            UserContext.Users[UserContext.Users.IndexOf(person)].Сount = 0;
            ff = true;
            BotStart.StartBot.questions = new ObservableCollection<Questions>();
         BotStart.StartBot.questions = command_1;
            new MessageClient(UserContext.Users, BotStart.StartBot.questions, read: ff, UserContext.UserEmails).GenMessage(e);

        }



    }
}
