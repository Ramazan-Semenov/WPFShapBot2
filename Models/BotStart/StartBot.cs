using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;
using WPFShapBot.Models.DataContext;

namespace WPFShapBot.Models.BotStart
{
    class StartBot
    {
       
       // private static ObservableCollection<BotUser> Users;
       // public static ObservableCollection<UserEmail> userEmails;
        static bool ff = false;

         private static ObservableCollection<Questions> resert = Models.DataContext.ContextQuest.Questions;

        private static ObservableCollection<Questions> questions = Models.DataContext.ContextQuest.Questions;
        private static ObservableCollection<Questions> command_1;


        string gg = @"Добро пожаловать в КубГТУ! Абитуриентам мы особо рады, поможем определиться с выбором, расскажем про все этапы подачи документов.
И самое главное, не нужно никуда ехать, документы на рассмотрение можно прислать сюда, а далее после проверки, специалист приемной комиссии свяжемся с Вами для согласования дальнейших действий 😇 Всё просто)";

         

    public StartBot()
        {

        
        }
        public void start()
        {

            TeleBot.Bot.OnMessage += OnMessageHandler;
            TeleBot.Bot.OnCallbackQuery += OnInlineQueryHandler;
            TeleBot.Bot.StartReceiving();

        }
        public void stop()
        {

            TeleBot.Bot.StopReceiving();

        }

        private async void OnInlineQueryHandler(object sender, CallbackQueryEventArgs e)
        {
            if (e.CallbackQuery.Data == "Command_1")
            {
                ff = true;
                questions = new ObservableCollection<Questions>();
                command_1 = new ObservableCollection<Questions>();

                List<string> ss = new List<string>();
                ss.Add("send");
                ss.Add("Управа");
                command_1.Add(new Questions { ID = 1, Text = "фио" });
                command_1.Add(new Questions { ID = 2, Text = "номер телефона" });
                command_1.Add(new Questions { ID = 3, Text = "направление", replyMarkup = new BotButtons().GenInlineButton(ss) });
                questions = command_1;
                new MessageClient(UserContext.Users, questions, read: ff, UserContext.UserEmails).GenMessage(e);


            }
            else if (e.CallbackQuery.Data == "send")
            {

                string text = "";
                await TeleBot.Bot.SendTextMessageAsync(e.CallbackQuery.Message.Chat.Id, "Отправлено");
                foreach (var item in UserContext.UserEmails)
                {
                    foreach (var item1 in item.Messages)
                    {
                        text += "\n" + item1;
                        Debug.WriteLine(item1);

                    }
                }
                ;

                await new Save().sAsync(new Save().creatdir(@"C:\Users\Roma\Desktop\проверка", e.CallbackQuery.Message.Chat.Id.ToString()) + "\\" + e.CallbackQuery.Message.Chat.Id.ToString() + ".txt", text);
            }
            else if (e.CallbackQuery.Data == "Command_3")
            {
                questions = new ObservableCollection<Questions>();
                questions = resert;
                new MessageClient(UserContext.Users, questions).GenMessage(e);


                //   await bot.Bot.SendTextMessageAsync(e.CallbackQuery.Message.Chat.Id, "Command_2");
            }

        }

        /// <summary>
        /// Событие на получение сообщений
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">Получения клиента и его данных из сообщения</param>
        private static async void OnMessageHandler(object sender, MessageEventArgs e)
        {

            //MessageBox.Show(e.Message.Type.ToString());
            if (e.Message.Type == MessageType.Text)
            {
                new MessageClient(UserContext.Users, questions, ff, UserContext.UserEmails).GenMessage(e);

            }
            else if (e.Message.Type == MessageType.Photo)
            {
                await new MessageClient(UserContext.Users, questions).DownloadPhoto(e);
            }
            else if (e.Message.Type == MessageType.Document)
            {
                await new MessageClient(UserContext.Users, questions).DownloadDocument(e);
            }


        }

    }
}
