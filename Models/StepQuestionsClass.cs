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
            Bot.SendTextMessageAsync(UserContext.Users[UserContext.Users.IndexOf(person)].ID, UserContext.Users[UserContext.Users.IndexOf(person)].questions[UserContext.Users[UserContext.Users.IndexOf(person)].Сount].Text, replyMarkup: new BotButtons().InlineKeyboardMarkupButtons());
            /*Users[Users.IndexOf(person)].Сount++; */
            UserContext.Users[UserContext.Users.IndexOf(person)].Сount++;

            //    try
            //    {
            //        if (UserContext.Users[UserContext.Users.IndexOf(person)].Сount < ContextQuest.Questions.Count)
            //        {
            //            // MessageBox.Show(ContextQuest.Questions.Count.ToString());
            //          }
            //        else
            //        {
            //            UserContext.Users[UserContext.Users.IndexOf(person)].Сount = 0;
            //            Bot.SendTextMessageAsync(UserContext.Users[UserContext.Users.IndexOf(person)].ID, "Конец", replyMarkup: ContextQuest.Questions[UserContext.Users[UserContext.Users.IndexOf(person)].Сount].replyMarkup);

            //        }
            //    }
            //    catch (Exception e)
            //    {
            //        UserContext.Users[UserContext.Users.IndexOf(person)].Сount = 0;
            //       // Bot.SendTextMessageAsync(UserContext.Users[UserContext.Users.IndexOf(person)].ID, "Конец", replyMarkup: ContextQuest.Questions[UserContext.Users[UserContext.Users.IndexOf(person)].Сount].replyMarkup);
            //        Debug.WriteLine(e.Message);
            //        File.AppendAllText("data.log", $"{e.Message}\n");
            //    }
            //}

        }
    }
}
