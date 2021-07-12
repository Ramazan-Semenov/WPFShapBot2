using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;

namespace WPFShapBot.Models.DataContext
{
    class ContextQuest
    {

        private static ObservableCollection<Questions> questions = GetQuestions();

        public static ObservableCollection<Questions> Questions { get => questions; set => questions = value; }

        public ContextQuest()
        {
            if (questions == null)
            {
                questions = new ObservableCollection<Questions>();
            }
        }
       
    
            public static ObservableCollection<Questions> GetQuestions()
                
        {
           
            if (questions == null)
            {
                questions = new ObservableCollection<Questions>();
            }
            string gg = @"Добро пожаловать в КубГТУ! Абитуриентам мы особо рады, поможем определиться с выбором, расскажем про все этапы подачи документов.
И самое главное, не нужно никуда ехать, документы на рассмотрение можно прислать сюда, а далее после проверки, специалист приемной комиссии свяжемся с Вами для согласования дальнейших действий 😇 Всё просто)";

            questions.Add(new Questions { ID = 4, Text = gg + "\nВ чём вопрос?" , replyMarkuppath= @"C:\Users\Roma\Desktop\WPFBOTEKS\bin\Debug\ButtonInlineFile\but.btn"/*, replyMarkup = new DataContext.ButtonContext().InlineKeyboard()*/ }); ;

            questions.Add(new Questions { ID = 5, Text = "Конец"/*, replyMarkup = new ReplyKeyboardRemove()*/ });
            //Models.ReadWriteJson.ReadWiteJson<ObservableCollection<Questions>> readWite = new Models.ReadWriteJson.ReadWiteJson<ObservableCollection<Questions>>();
            // readWite.WriteJson(@"C:\Users\Roma\Desktop\WPFBOTEKS\bin\Debug\QuestionsFile\QuestionsFile.json", questions);

            return questions;
        }
        //////async void st()
        //////{
        //////    ObservableCollection<InlineKeyboardButton> vs = new ObservableCollection<InlineKeyboardButton>();
        //////    vs.Add(new InlineKeyboardButton { Text = "правила приёма в КубГТУ на обучение", CallbackData = "df" });


        //////    Models.ReadWriteJson.ReadWiteJson<ObservableCollection<InlineKeyboardButton>> readWite = new Models.ReadWriteJson.ReadWiteJson<ObservableCollection<InlineKeyboardButton>>();
        //////    await readWite.WriteJson(@"C:\Users\Roma\Desktop\WPFBOTEKS\bin\Debug\ButtonInlineFile\but.json", vs);
        //////}
        public static void addquestions(Questions questionsp)
        {

            questions.Add(questionsp);

        }

        public static void Delquestions(int id)
        {

            questions.RemoveAt(id);

        }

    }
}
