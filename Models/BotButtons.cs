using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;

namespace WPFShapBot.Models
{
    public class BotButtons
    {
    //    private string text = "qqqqqq";
    //    private int count = 4;
    //    public string Text { get => text; set => text = value; }
    //    public int Count { get => count; set => count = value; }

        //public IReplyMarkup GetButtons()
        //{
        //    return new ReplyKeyboardMarkup
        //    {
        //        Keyboard = new List<List<KeyboardButton>>
        //         {
        //             new List<KeyboardButton>
        //             {
        //                new KeyboardButton{ Text =this.text},
        //                new KeyboardButton{Text =this.text}
        //             }

        //         }

        //    };
        //}
        public IReplyMarkup GenReplyKeyboard(List<string> listcom)
        {
            var markup = new ReplyKeyboardMarkup();
            //{
            //    Keyboard = new List<List<KeyboardButton>>
            //     {
            //         new List<KeyboardButton>
            //         {
            //            new KeyboardButton{ Text =this.text},
            //            new KeyboardButton{Text =this.text}
            //         }

            //     }

            //};

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
            //listcom.Add("send");
            //listcom.Add("Удалить");
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

        //private InlineKeyboardMarkup send()
        //{

        //    var KeyboardButons = new InlineKeyboardButton[][]
        //          {
        //          new InlineKeyboardButton[]
        //          {
        //             InlineKeyboardButton.WithCallbackData("Отправить", "send") ,
        //          }
        //          };
        //    return KeyboardButons;
        //}
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
        ////public  InlineKeyboardMarkup InlineKeyboardMarkupButtons()
        ////{
        ////    return new InlineKeyboardMarkup(new[]
        ////   {
        ////            new []
        ////            {
        ////                InlineKeyboardButton.WithCallbackData("Одноразовые товары", "Command_1"),
        ////                InlineKeyboardButton.WithCallbackData("Многоразовые товары","Command_2"),
        ////            }
        ////        });
        ////}
    }
}
