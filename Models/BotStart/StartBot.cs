using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;
using WPFShapBot.Models.Commandbot;
using WPFShapBot.Models.DataContext;

namespace WPFShapBot.Models.BotStart
{
    public class StartBot
    {
        static bool ff = true;

        ObservableCollection<ComBot> com = new ObservableCollection<ComBot>();

        public static ObservableCollection<Questions> questions = ContextQuest.Questions;

        private static ObservableCollection<Questions> command_1;





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


            //com = ContextCommand.GetComBots();
            //foreach (var item in com)
            //{
            //    if (e.CallbackQuery.Data == item.Name)
            //    {
            //        ff = item.ff;
            //        item.ex(e);
            //        break;
            //    }

            //}
            if (e.CallbackQuery.Data == "подача документов")
            {
                ff = true;
                command_1 = new ObservableCollection<Questions>();


                command_1.Add(new Questions { ID = 1, Text = "фио" });
                command_1.Add(new Questions { ID = 2, Text = "номер телефона" });
                command_1.Add(new Questions { ID = 3, Text = "направление", replyMarkup = new BotButtons().send() });
                //questions = command_1;
                var person = new BotUser(e.CallbackQuery.Message.Chat.FirstName, e.CallbackQuery.Message.Chat.Id, questions);

               DataContext.UserContext. Users[UserContext.Users.IndexOf(person)].questions = command_1;
                new MessageClient(UserContext.Users, questions, read: ff, UserContext.UserEmails).GenMessage(e);


            }

            if (e.CallbackQuery.Data == "send")
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
                   await new Save().sAsync(new Save().creatdir(@"C:\Users\Roma\Desktop\проверка", e.CallbackQuery.Message.Chat.Id.ToString()) + "\\" + e.CallbackQuery.Message.Chat.Id.ToString() + ".txt", text);
            }

            //}
            //else if (e.CallbackQuery.Data == "Command_3")
            //{
            //    questions = new ObservableCollection<Questions>();
            //    questions = resert;
            //    new MessageClient(UserContext.Users, questions).GenMessage(e);


            //    //   await bot.Bot.SendTextMessageAsync(e.CallbackQuery.Message.Chat.Id, "Command_2");
            //}


        }

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
