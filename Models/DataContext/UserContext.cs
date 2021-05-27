using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFShapBot.Models.DataContext
{
 public static   class UserContext
    {


        private static ObservableCollection<BotUser> users =new ObservableCollection<BotUser>();
        private static ObservableCollection<UserEmail> userEmails=new ObservableCollection<UserEmail>();

        public static ObservableCollection<BotUser> Users { get => users; set => users = value; }
        public static ObservableCollection<UserEmail> UserEmails { get => userEmails; set => userEmails = value; }
    }
}
