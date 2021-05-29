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
        public StepQuestionsClass(ObservableCollection<BotUser> Users, ObservableCollection<Questions> mes)
        {
            UserContext.Users = Users;
            ContextQuest.Questions = mes;
        }
        /// <summary>
        /// переход к следующему сообщению
        /// </summary>
        /// <param name = "person" > Клиент, котором</ param >
        public void StepQuestions(BotUser person)
        {
            try
            {
                if (UserContext.Users[UserContext.Users.IndexOf(person)].Сount < ContextQuest.Questions.Count)
                {
                   // MessageBox.Show(ContextQuest.Questions.Count.ToString());
                    Bot.SendTextMessageAsync(UserContext.Users[UserContext.Users.IndexOf(person)].ID, ContextQuest.Questions[UserContext.Users[UserContext.Users.IndexOf(person)].Сount].Text, replyMarkup: ContextQuest.Questions[UserContext.Users[UserContext.Users.IndexOf(person)].Сount].replyMarkup);
                    UserContext.Users[UserContext.Users.IndexOf(person)].Сount++;
                }
                else
                {
                    UserContext.Users[UserContext.Users.IndexOf(person)].Сount = 0;
                    Bot.SendTextMessageAsync(UserContext.Users[UserContext.Users.IndexOf(person)].ID, "Конец", replyMarkup: ContextQuest.Questions[UserContext.Users[UserContext.Users.IndexOf(person)].Сount].replyMarkup);

                }
            }
            catch (Exception e)
            {
                UserContext.Users[UserContext.Users.IndexOf(person)].Сount = 0;
                Bot.SendTextMessageAsync(UserContext.Users[UserContext.Users.IndexOf(person)].ID, "Конец", replyMarkup: ContextQuest.Questions[UserContext.Users[UserContext.Users.IndexOf(person)].Сount].replyMarkup);
                Debug.WriteLine(e.Message);
                File.AppendAllText("data.log", $"{e.Message}\n");
            }
        }

    }
}
