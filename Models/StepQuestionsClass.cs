using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFShapBot.Models.DataContext;

namespace WPFShapBot.Models
{
    class StepQuestionsClass : TeleBot
    {
       // private ObservableCollection<BotUser> Users;
        // private  ObservableCollection<Questions> questions;
       // private ObservableCollection<Questions> mes;
        // private BotButtons Buttons=new BotButtons();
        public StepQuestionsClass(ObservableCollection<BotUser> Users, ObservableCollection<Questions> mes)
        {
            UserContext.Users = Users;
            // this.Users = Users;
            ContextQuest.Questions = mes;
          //  this.mes = mes;


            //mes = new ObservableCollection<mes>();
            //mes.Add(new mes { Text=gg});
            //mes.Add(new mes { text = "В чём вопрос?", replyMarkup = (IReplyMarkup)new BotButtons().rrrrr() });

            //mes.Add(new mes { text = "Конец",replyMarkup=new ReplyKeyboardRemove() });
        }



        /// <summary>
        /// переход к следующему сообщению
        /// </summary>
        /// <param name = "person" > Клиент, котором</ param >
        public void StepQuestions(BotUser person)
        {
            try
            {


                Bot.SendTextMessageAsync(UserContext.Users[UserContext.Users.IndexOf(person)].ID, ContextQuest.Questions[UserContext.Users[UserContext.Users.IndexOf(person)].Сount].Text, replyMarkup: ContextQuest.Questions[UserContext.Users[UserContext.Users.IndexOf(person)].Сount].replyMarkup);
                UserContext.Users[UserContext.Users.IndexOf(person)].Сount++;

          //  MessageBox.Show(Users[Users.IndexOf(person)].Сount.ToString());
                // Bot.DeleteWebhookAsync();
                //if (mes.Count > Users[Users.IndexOf(person)].Сount)
                //{
                //    if (Users[Users.IndexOf(person)].Сount==2)
                //    {

                //    //    new TeleBot().Bot.ed

                //        new TeleBot().Bot.SendTextMessageAsync(Users[Users.IndexOf(person)].ID, mes[Users[Users.IndexOf(person)].Сount].text/*, replyMarkup: Buttons.GetButtons()*/);
                //        Users[Users.IndexOf(person)].Сount++;
                //    }
                //    else
                //    {
                //       // var ff = new ReplyKeyboardRemove();


                //        new TeleBot().Bot.SendTextMessageAsync(Users[Users.IndexOf(person)].ID, questions[Users[Users.IndexOf(person)].Сount].Text);
                //        Users[Users.IndexOf(person)].Сount++;

                //    }

                //}
                //else
                //{

                //    new TeleBot().Bot.SendTextMessageAsync(new mes().chatId,new mes().text="sd");
                //}
            }
            catch (Exception e)
            {
                UserContext.Users[UserContext.Users.IndexOf(person)].Сount = 0;
                Debug.WriteLine(e.Message);
                File.AppendAllText("data.log", $"{e.Message}\n");
            }
        }

    }
}
