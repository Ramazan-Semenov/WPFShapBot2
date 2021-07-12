using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;

namespace WPFShapBot.Models.DataContext
{
    class ButtonContext
    {
       
        ////////public  IReplyMarkup InlineKeyboard()
        ////////{
        ////////    List<InlineKeyboardButton> vs = new List<InlineKeyboardButton>(Models.ReadWriteJson.ReadWriteF.Load(@"C:\Users\Roma\Desktop\WPFBOTEKS\bin\Debug\ButtonInlineFile\but.btn"));


        ////////    //vs.Add(new InlineKeyboardButton { Text = "правила приёма в КубГТУ на обучение", CallbackData = "правила" });
        ////////    //vs.Add(new InlineKeyboardButton { Text = "vvvvvvvvzxcv", CallbackData = "df" });

        ////////    //var q = new ObservableCollection<InlineKeyboardButton>(vs);
        ////////    //Models.ReadWriteJson.ReadWriteF.Save(@"C:\Users\Roma\Desktop\WPFBOTEKS\bin\Debug\ButtonInlineFile\but.btn", q);
     
        ////////    return new BotButtons().InlineKeyboardMarkupMaker(vs);
        ////////}


    }
}
