using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Windows;
using WPFShapBot.Models.DataContext;

namespace WPFShapBot.Models
{
    class StepQuestionsClass : TeleBot
    {
        public StepQuestionsClass(ObservableCollection<BotUser> Users/*, ObservableCollection<Questions> mes*/)
        {
            UserContext.Users = Users;
            // ContextQuest.Questions = mes;
        }
        /// <summary>
        /// переход к следующему сообщению
        /// </summary>
        /// <param name = "person" > Клиент, котором</ param >
        public void StepQuestions(BotUser person)
        {
            try
            {
                long iD = UserContext.Users[UserContext.Users.IndexOf(person)].ID;
                string text = UserContext.Users[UserContext.Users.IndexOf(person)].questions[UserContext.Users[UserContext.Users.IndexOf(person)].Сount].Text;
                Bot.SendTextMessageAsync(iD, text, replyMarkup: UserContext.Users[UserContext.Users.IndexOf(person)].questions[UserContext.Users[UserContext.Users.IndexOf(person)].Сount].replyMarkup);
                /*Users[Users.IndexOf(person)].Сount++; */
                UserContext.Users[UserContext.Users.IndexOf(person)].Сount++;
            }
            catch { UserContext.Users[UserContext.Users.IndexOf(person)].Сount=0; }

            //try
            //{
            //    if (UserContext.Users[UserContext.Users.IndexOf(person)].Сount < UserContext.Users[UserContext.Users.IndexOf(person)].questions.Count)
            //    {
            //        long iD = UserContext.Users[UserContext.Users.IndexOf(person)].ID;
            //        string text = UserContext.Users[UserContext.Users.IndexOf(person)].questions[UserContext.Users[UserContext.Users.IndexOf(person)].Сount].Text;
            //        Bot.SendTextMessageAsync(iD, text, replyMarkup: UserContext.Users[UserContext.Users.IndexOf(person)].questions[UserContext.Users[UserContext.Users.IndexOf(person)].Сount].replyMarkup);
            //        /*Users[Users.IndexOf(person)].Сount++; */
            //        UserContext.Users[UserContext.Users.IndexOf(person)].Сount++;
            //    }
            //    else
            //    {
            //        UserContext.Users[UserContext.Users.IndexOf(person)].Сount = 0;
            //        Bot.SendTextMessageAsync(UserContext.Users[UserContext.Users.IndexOf(person)].ID, "Конец");

            //    }
            //}
            //catch (Exception e)
            //{
            //    UserContext.Users[UserContext.Users.IndexOf(person)].Сount = 0;
            //    // Bot.SendTextMessageAsync(UserContext.Users[UserContext.Users.IndexOf(person)].ID, "Конец", replyMarkup: ContextQuest.Questions[UserContext.Users[UserContext.Users.IndexOf(person)].Сount].replyMarkup);
            //    Debug.WriteLine(e.Message);
            //    File.AppendAllText("data.log", $"{e.Message}\n");
            //}
        }

    }
    }

