using System;
using System.Collections.ObjectModel;
using System.Windows;
using Telegram.Bot.Args;
using WPFShapBot.Models.DataContext;

namespace WPFShapBot.Models.Commandbot
{
    public class ComBot
    {

      public   bool ff = false;
        ObservableCollection<Questions> command_1;

        public string Name { get; set; }
        Action action;
        public ComBot(ObservableCollection<Questions> questions = null, Action action=null, bool write = false)
        {
            MessageBox.Show(write.ToString());

            ff = write;
            if (questions == null)
            {
                questions = new ObservableCollection<Questions>();

            }
            command_1 = new ObservableCollection<Questions>();
            if (action==null)
            {
                action = p;
            }
           this.action = action;
            command_1 = questions;

        }
        void p() { }
        public ComBot()
        {

            command_1 = new ObservableCollection<Questions>();


        }
        
        public void ex(CallbackQueryEventArgs e)
        {

            var person = new BotUser(e.CallbackQuery.Message.Chat.FirstName, e.CallbackQuery.Message.Chat.Id);


             action();
            UserContext.Users[UserContext.Users.IndexOf(person)].Сount = 0;
            //ff = true;
            BotStart.StartBot.questions = new ObservableCollection<Questions>();
            BotStart.StartBot.questions = command_1;
          //  MessageBox.Show(Write.WriteUser.ToString());
            new MessageClient(UserContext.Users, BotStart.StartBot.questions, read: ff, UserContext.UserEmails).GenMessage(e);

        }



    }
}
