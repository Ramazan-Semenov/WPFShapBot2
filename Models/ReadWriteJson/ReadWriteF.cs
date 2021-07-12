using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;

namespace WPFShapBot.Models.ReadWriteJson
{
    public class ReadWriteF
    {
        public static void Save(string path, ObservableCollection<InlineKeyboardButton> collection)
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
            using (BinaryWriter binWriter = new BinaryWriter(fs))
            {


                binWriter.Write(collection.Count); //(Int32) записываем кол-во элементов
                foreach (var item in collection)
                {
                    binWriter.Write(item.CallbackData);
                    binWriter.Write(item.Text);

                }
                
            }
        }

        public static ObservableCollection<InlineKeyboardButton> Load(string path)
        {
            ObservableCollection<InlineKeyboardButton> persons = new ObservableCollection<InlineKeyboardButton>();

            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
                using (BinaryReader binReader = new BinaryReader(fs))
                {
                    int quantity = binReader.ReadInt32();

                    for (int i = 0; i < quantity; i++)
                    {
                        string callbackdata = binReader.ReadString();
                        string text = binReader.ReadString();

                        persons.Add(new InlineKeyboardButton { Text = text, CallbackData = callbackdata });
                    }
                }
                return persons;
            }
            catch(Exception exp)
            {
                Trace.WriteLine(exp.Message+ ":  public static ObservableCollection<InlineKeyboardButton> Load(string path)");
                return persons; }
           
        }


    }
}
