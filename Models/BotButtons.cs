using System.Collections.Generic;
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
        public InlineKeyboardMarkup GenInlineButton(List<string> listcom)
        {
            var KeyboardButons = new InlineKeyboardButton[listcom.Count][];
            for (int i = 0; i < listcom.Count; i++)
            {
                KeyboardButons[i] = new InlineKeyboardButton[]
                {
                   InlineKeyboardButton.WithCallbackData(listcom[i], listcom[i]) ,

                };
            }

            return KeyboardButons;
        }

        public InlineKeyboardMarkup InlineKeyboardMarkupButtons()
        {

            var KeyboardButons = new InlineKeyboardButton[][]
                  {
                  new InlineKeyboardButton[]
                  {
                     InlineKeyboardButton.WithCallbackData("правила приёма в КубГТУ на обучение", "сш") ,
                  },
                   new InlineKeyboardButton[]
                  {
                     InlineKeyboardButton.WithCallbackData("перечень испытаний", "dsd") ,
                  },
                   new InlineKeyboardButton[]
                  {
                     InlineKeyboardButton.WithCallbackData("информация о наличие общежитий", "dsd") ,
                  },
                   new InlineKeyboardButton[]
                  {
                     InlineKeyboardButton.WithCallbackData("стоимость обучения", "ллл") ,
                  },
                   new InlineKeyboardButton[]
                  {
                     InlineKeyboardButton.WithCallbackData("подача документов", "Command_1") ,
                  },
                   new InlineKeyboardButton[]
                  {
                     InlineKeyboardButton.WithCallbackData("Другое", "Command_2") ,
                  },
                    new InlineKeyboardButton[]
                  {
                     InlineKeyboardButton.WithCallbackData("Начать с начала", "Command_3") ,
                  }
                  };
            return KeyboardButons;
        }
    }
}
