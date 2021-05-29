using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Telegram.Bot.Args;
using WPFShapBot.Models.DataContext;
namespace WPFShapBot.Models
{
    public class MessageClient : TeleBot
    {

        //private ObservableCollection<BotUser> Users;
        //  private ObservableCollection<Questions> mes;
        public static bool Read;
        ObservableCollection<UserEmail> userEmails;
        private StepQuestionsClass StepQuestions;
        public MessageClient(ObservableCollection<BotUser> Users, ObservableCollection<Questions> mes, bool read = false, ObservableCollection<UserEmail> userEmails = null)
        {
            UserContext.Users = Users;
            ContextQuest.Questions = mes;
            //    this.mes = mes;
            Read = read;
            this.userEmails = userEmails;
            StepQuestions = new StepQuestionsClass(Users, mes);
        }

        public void GenMessage(MessageEventArgs e)
        {


            string msg = $"{DateTime.Now}: {e.Message.Chat.FirstName} {e.Message.Chat.Id} {e.Message.Text}";

            File.AppendAllText("data.log", $"{msg}\n");

            Debug.WriteLine(msg);
            Application.Current.Dispatcher.Invoke(() =>
            {
                NewUser(e);

            });
        }
        public async Task DownloadDocument(MessageEventArgs e)
        {
            var person = new BotUser(e.Message.Chat.FirstName, e.Message.Chat.Id);

            try
            {
                NewUser(e);

                var file = Bot.GetFileAsync(e.Message.Document.FileId);
                new Save().creatdir(@"C:\Users\Roma\Desktop\проверка", e.Message.Chat.Id.ToString());

                var fileName = @"C:\Users\Roma\Desktop\проверка\" + e.Message.Chat.Id.ToString() + "\\" + file.Result.FileId + "." + file.Result.FilePath.Split('.').Last();
                Debug.WriteLine(file.Result.FilePath);
                using (var saveImageStream = File.Open(fileName, FileMode.Create))
                {


                    await Bot.DownloadFileAsync(file.Result.FilePath, saveImageStream);
                }
                await Bot.SendTextMessageAsync(e.Message.Chat.Id, "Document save");
                await Bot.SendTextMessageAsync(UserContext.Users[UserContext.Users.IndexOf(person)].ID, ContextQuest.Questions[UserContext.Users[UserContext.Users.IndexOf(person)].Сount].Text, replyMarkup: ContextQuest.Questions[UserContext.Users[UserContext.Users.IndexOf(person)].Сount].replyMarkup);
                UserContext.Users[UserContext.Users.IndexOf(person)].Сount++;

            }
            catch (Exception exp)
            {
                UserContext.Users[UserContext.Users.IndexOf(person)].Сount = 0;

                File.AppendAllText("data.log", $"\n{exp.Message}\n");
            }

        }
        public async Task DownloadPhoto(MessageEventArgs e)
        {
            var person = new BotUser(e.Message.Chat.FirstName, e.Message.Chat.Id);

            try
            {

                var file = bot.GetFileAsync(e.Message.Photo.LastOrDefault().FileId);
                new Save().creatdir(@"C:\Users\Roma\Desktop\проверка", e.Message.Chat.Id.ToString());

                var fileName = @"C:\Users\Roma\Desktop\проверка\" + e.Message.Chat.Id.ToString() + "\\" + file.Result.FileId + "." + file.Result.FilePath.Split('.').Last();
                Debug.WriteLine(file.Result.FilePath);
                using (var saveImageStream = File.Open(fileName, FileMode.Create))
                {


                    await bot.DownloadFileAsync(file.Result.FilePath, saveImageStream);
                }
                await bot.SendTextMessageAsync(e.Message.Chat.Id, "Image save");
                await Bot.SendTextMessageAsync(UserContext.Users[UserContext.Users.IndexOf(person)].ID, ContextQuest.Questions[UserContext.Users[UserContext.Users.IndexOf(person)].Сount].Text, replyMarkup: ContextQuest.Questions[UserContext.Users[UserContext.Users.IndexOf(person)].Сount].replyMarkup);

                UserContext.Users[UserContext.Users.IndexOf(person)].Сount++;

            }

            catch (Exception exp)
            {
                UserContext.Users[UserContext.Users.IndexOf(person)].Сount = 0;

                File.AppendAllText("data.log", $"\n{exp.Message}\n");
            }
        }
        private void NewUser(MessageEventArgs e)
        {
            try
            {

                var person = new BotUser(e.Message.Chat.FirstName, e.Message.Chat.Id);
                if (!UserContext.Users.Contains(person))
                {
                    UserContext.Users.Add(person);
                }
                UserContext.Users[UserContext.Users.IndexOf(person)].AddMessage($"{person.Nike}: {e.Message.Text}");
                if (Read == true)
                {

                    var person_email = new UserEmail(e.Message.Chat.FirstName, e.Message.Chat.Id);


                    if (!userEmails.Contains(person_email))
                    {
                        person.Сount = 0;
                        userEmails.Add(person_email);
                        person_email.Сount = 0;
                    }
                    userEmails[userEmails.IndexOf(person_email)].AddMessage($"{person.Nike}: {e.Message.Text}");
                    //    MessageBox.Show("dfdfdf");
                }

                StepQuestions.StepQuestions(person);
            }
            catch (Exception exp)
            {
                File.AppendAllText("data.log", $"\n{exp.Message}\n");

            }
        }
        /// ///////////////////////////////////////////////////////////////////////

        public async Task DownloadDocument(CallbackQueryEventArgs e)
        {
            var person = new BotUser(e.CallbackQuery.Message.Chat.FirstName, e.CallbackQuery.Message.Chat.Id);

            try
            {
                NewUser(e);

                var file = Bot.GetFileAsync(e.CallbackQuery.Message.Document.FileId);
                new Save().creatdir(@"C:\Users\Roma\Desktop\проверка", e.CallbackQuery.Message.Chat.Id.ToString());

                var fileName = @"C:\Users\Roma\Desktop\проверка\" + e.CallbackQuery.Message.Chat.Id.ToString() + "\\" + file.Result.FileId + "." + file.Result.FilePath.Split('.').Last();
                Debug.WriteLine(file.Result.FilePath);
                using (var saveImageStream = File.Open(fileName, FileMode.Create))
                {


                    await Bot.DownloadFileAsync(file.Result.FilePath, saveImageStream);
                }
                await Bot.SendTextMessageAsync(e.CallbackQuery.Message.Chat.Id, "Document save");
                await Bot.SendTextMessageAsync(UserContext.Users[UserContext.Users.IndexOf(person)].ID, ContextQuest.Questions[UserContext.Users[UserContext.Users.IndexOf(person)].Сount].Text, replyMarkup: ContextQuest.Questions[UserContext.Users[UserContext.Users.IndexOf(person)].Сount].replyMarkup);

                UserContext.Users[UserContext.Users.IndexOf(person)].Сount++;

            }
            catch (Exception exp)
            {
                UserContext.Users[UserContext.Users.IndexOf(person)].Сount = 0;

                File.AppendAllText("data.log", $"\n{exp.Message}\n");

            }

        }
        public async Task DownloadPhoto(CallbackQueryEventArgs e)
        {
            //try
            //{
            ////newuser(e)
            var person = new BotUser(e.CallbackQuery.Message.Chat.FirstName, e.CallbackQuery.Message.Chat.Id);

            var file = bot.GetFileAsync(e.CallbackQuery.Message.Photo.LastOrDefault().FileId);
            new Save().creatdir(@"C:\Users\Roma\Desktop\проверка", e.CallbackQuery.Message.Chat.Id.ToString());
            var fileName = @"C:\Users\Roma\Desktop\проверка\" + e.CallbackQuery.Message.Chat.Id.ToString() + "\\" + file.Result.FileId + "." + file.Result.FilePath.Split('.').Last();
            Debug.WriteLine(file.Result.FilePath);
            using (var saveImageStream = File.Open(fileName, FileMode.Create))
            {


                await bot.DownloadFileAsync(file.Result.FilePath, saveImageStream);
            }
            await bot.SendTextMessageAsync(e.CallbackQuery.Message.Chat.Id, "Image save");
            await Bot.SendTextMessageAsync(UserContext.Users[UserContext.Users.IndexOf(person)].ID, ContextQuest.Questions[UserContext.Users[UserContext.Users.IndexOf(person)].Сount].Text, replyMarkup: ContextQuest.Questions[UserContext.Users[UserContext.Users.IndexOf(person)].Сount].replyMarkup);

            //Users[Users.IndexOf(person)].Сount++;
            if (ContextQuest.Questions.Count == UserContext.Users[UserContext.Users.IndexOf(person)].Сount)
            {

            }
            else
            {
                UserContext.Users[UserContext.Users.IndexOf(person)].Сount++;

            }
            //}
            //catch { }
        }
        private void NewUser(CallbackQueryEventArgs e)
        {
            //try
            //{

            var person = new BotUser(e.CallbackQuery.Message.Chat.FirstName, e.CallbackQuery.Message.Chat.Id);
            if (!UserContext.Users.Contains(person))
            {
                UserContext.Users.Add(person);
            }
            UserContext.Users[UserContext.Users.IndexOf(person)].AddMessage($"{person.Nike}: {e.CallbackQuery.Message.Text}");
            //StepQuestions.StepQuestions(person);
            if (Read == true)
            {
                var person_email = new UserEmail(e.CallbackQuery.Message.Chat.FirstName, e.CallbackQuery.Message.Chat.Id);

                if (!userEmails.Contains(person_email))
                {

                    userEmails.Add(person_email);
                    UserContext.Users[UserContext.Users.IndexOf(person)].Сount = 0;
                }
                userEmails[userEmails.IndexOf(person_email)].AddMessage($"{person.Nike}: {e.CallbackQuery.Message.Text}");
                //     StepQuestions.StepQuestions();
                // MessageBox.Show("Work!!");
            }
            //  UserContext.Users[UserContext.Users.IndexOf(person)].Сount = 0;
            StepQuestions.StepQuestions(person);
            //}
            //catch { }
        }
        public void GenMessage(CallbackQueryEventArgs e)
        {
            string msg = $"{DateTime.Now}: {e.CallbackQuery.Message.Chat.FirstName} {e.CallbackQuery.Message.Chat.Id} {e.CallbackQuery.Message.Text}";

            File.AppendAllText("data.log", $"{msg}\n");

            Debug.WriteLine(msg);
            Application.Current.Dispatcher.Invoke(() =>
            {
                NewUser(e);

            });
        }


    }
}
