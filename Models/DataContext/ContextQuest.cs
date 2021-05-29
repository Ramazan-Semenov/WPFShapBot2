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
            if (questions == null)
            {
                questions = new ObservableCollection<Questions>();
            }
            questions.Add(new Questions { ID = 4, Text = "\nВ чём вопрос?", replyMarkup = (IReplyMarkup)new BotButtons().InlineKeyboardMarkupButtons() });
            questions.Add(new Questions { ID = 5, Text = "ggggggggggggg", replyMarkup = new ReplyKeyboardRemove() });

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
