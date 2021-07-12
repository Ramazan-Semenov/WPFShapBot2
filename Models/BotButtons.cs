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
        public  InlineKeyboardMarkup InlineKeyboardMarkupMaker(List<InlineKeyboardButton> vs)
        {
            //InlineKeyboardButton[][] KeyboardButons = new InlineKeyboardButton[1][];
            //KeyboardButons

            InlineKeyboardButton[][] ik = vs.Select(item => new[]
            {
              new InlineKeyboardButton(){ Text=item.Text,  CallbackData=item.CallbackData }
        }).ToArray();
            return new InlineKeyboardMarkup(ik);
        }
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
        public InlineKeyboardMarkup InlineInfo()
        {
            //InlineKeyboardButton[][] KeyboardButons=new InlineKeyboardButton[1][];
            //KeyboardButons[0][0] = new InlineKeyboardButton() { Text = "ИКСИиБ" };
            ////KeyboardButons[0][0].Text = "ИКСИиБ";
            ////KeyboardButons[0][0].CallbackData = "ИКСИБ";
            //return new InlineKeyboardMarkup(KeyboardButons);

            var KeyboardButons = new InlineKeyboardButton[][]
                  {
                  new InlineKeyboardButton[]
                  {
                     InlineKeyboardButton.WithCallbackData("ИКСИиБ", "ИКСИБ") ,
                  },
                   new InlineKeyboardButton[]
                  {
                     InlineKeyboardButton.WithCallbackData("ИНГЭ", "ИНГЭ") ,
                  }
                  ,
                   new InlineKeyboardButton[]
                  {
                     InlineKeyboardButton.WithCallbackData("ИПиПП", "ИПиПП") ,
                  }
                     ,
                   new InlineKeyboardButton[]
                  {
                     InlineKeyboardButton.WithCallbackData("ИЭУБ", "ИЭУБ") ,
                  }
                   ,
                   new InlineKeyboardButton[]
                  {
                     InlineKeyboardButton.WithCallbackData("ИСТИ", "ИСТИ") ,
                  }
                  ,
                   new InlineKeyboardButton[]
                  {
                     InlineKeyboardButton.WithCallbackData("ИФН", "ИФН") ,
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
                     InlineKeyboardButton.WithCallbackData("Информация о институтах", "интитутах") ,
                  },
                   new InlineKeyboardButton[]
                  {
                     InlineKeyboardButton.WithCallbackData("Другое", "Другое") ,
                  },
                    new InlineKeyboardButton[]
                  {
                     InlineKeyboardButton.WithCallbackData("Начать с начала", "Начать с начала") ,
                  }
                  ,
                    new InlineKeyboardButton[]
                  {
                     InlineKeyboardButton.WithCallbackData("Факультеты", "Начать с начала") ,
                  }
                  };
            return KeyboardButons;
        }
    }
}
