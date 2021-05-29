using System.Collections.ObjectModel;

namespace WPFShapBot.Models.DataContext
{
    public static class UserContext
    {


        private static ObservableCollection<BotUser> users = new ObservableCollection<BotUser>();
        private static ObservableCollection<UserEmail> userEmails = new ObservableCollection<UserEmail>();

        public static ObservableCollection<BotUser> Users { get => users; set => users = value; }
        public static ObservableCollection<UserEmail> UserEmails { get => userEmails; set => userEmails = value; }
    }
}
