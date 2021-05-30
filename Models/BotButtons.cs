using System.Collections.Generic;
using System.Linq;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InlineQueryResults;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.ReplyMarkups;
namespace WPFShapBot.Models
{
    public class BotButtons
    {
        public IReplyMarkup GenReplyKeyboard(List<string> listcom)
        {
            var markup = new ReplyKeyboardMarkup();
            List<List<KeyboardButton>> keyboardButtons = new List<List<KeyboardButton>>();
            for (int i = 0; i < listcom.Count; i++)
            {
                keyboardButtons.Add(new List<KeyboardButton> { new KeyboardButton { Text = listcom[i] } });
            }
            markup.Keyboard = keyboardButtons;
            return markup;
        }
        //public static InlineKeyboardMarkup InlineKeyboardMarkupMaker(List<string> vs)
        //{
        //    InlineKeyboardButton[][] KeyboardButons = new InlineKeyboardButton[1][];
        //    KeyboardButons

        //    InlineKeyboardButton[][] ik = vs.Select(item => new[]
        //    {
        //      new InlineKeyboardButton(){ Text=item,  CallbackData=item }
        //}).ToArray();
        //    return new InlineKeyboardMarkup(ik);
        //}
        public InlineKeyboardMarkup send()
        {

            var KeyboardButons = new InlineKeyboardButton[][]
                  {
                  new InlineKeyboardButton[]
                  {
                     InlineKeyboardButton.WithCallbackData("Отправить", "send") ,
                  }
                  };
            return KeyboardButons;
        }
        public InlineKeyboardMarkup InlineKeyboardMarkupButtons()
        {

            var KeyboardButons = new InlineKeyboardButton[][]
                  {
                  new InlineKeyboardButton[]
                  {
                     InlineKeyboardButton.WithCallbackData("правила приёма в КубГТУ на обучение", "правила") ,
                  },
                   new InlineKeyboardButton[]
                  {
                     InlineKeyboardButton.WithCallbackData("перечень испытаний", "перечень испытаний") ,
                  },
                   new InlineKeyboardButton[]
                  {
                     InlineKeyboardButton.WithCallbackData("информация о наличие общежитий", "информация") ,
                  },
                   new InlineKeyboardButton[]
                  {
                     InlineKeyboardButton.WithCallbackData("стоимость обучения", "стоимость обучения") ,
                  },
                   new InlineKeyboardButton[]
                  {
                     InlineKeyboardButton.WithCallbackData("подача документов", "подача документов") ,
                  },
                   new InlineKeyboardButton[]
                  {
                     InlineKeyboardButton.WithCallbackData("Другое", "Другое") ,
                  },
                    new InlineKeyboardButton[]
                  {
                     InlineKeyboardButton.WithCallbackData("Начать с начала", "Начать с начала") ,
                  }
                  };
            return KeyboardButons;
        }
    }
}
