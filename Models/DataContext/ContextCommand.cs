using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFShapBot.Models.Commandbot;

namespace WPFShapBot.Models.DataContext
{
    class ContextCommand
    {
      private static ObservableCollection<Commandbot.ComBot> com = new ObservableCollection<Commandbot.ComBot>();

        public static ObservableCollection<ComBot> Com { get => com; set => com = value; }


        public static ObservableCollection<ComBot> GetComBots()
        {

            return Com;

        }
        public static void AddComBots(ComBot comBot)
        {


            com.Add(comBot);
        }
        public static void DelComBots(ComBot comBot)
        {

            com.Remove(comBot);

        }
    }
}
