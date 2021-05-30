using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            List<string> vs = new List<string>();

            vs.Add("правила приёма в КубГТУ на обучение");
            vs.Add("перечень испытаний");
            vs.Add("информация о наличие общежитий");
            vs.Add("стоимость обучения");
            vs.Add("подача документов");
            vs.Add("Другое");
            vs.Add("Начать с начала");
            if (questions == null)
            {
                questions = new ObservableCollection<Questions>();
            }
            string gg = @"Добро пожаловать в КубГТУ! Абитуриентам мы особо рады, поможем определиться с выбором, расскажем про все этапы подачи документов.
И самое главное, не нужно никуда ехать, документы на рассмотрение можно прислать сюда, а далее после проверки, специалист приемной комиссии свяжемся с Вами для согласования дальнейших действий 😇 Всё просто)";

            questions.Add(new Questions { ID = 4, Text =gg+ "\nВ чём вопрос?", replyMarkup = new BotButtons().InlineKeyboardMarkupButtons() } );

            questions.Add(new Questions { ID = 5, Text = "Конец", replyMarkup = new ReplyKeyboardRemove() });

            return questions;
        }

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
