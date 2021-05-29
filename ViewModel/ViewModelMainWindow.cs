using System.Collections.ObjectModel;
using WPFShapBot.Models;
using WPFShapBot.Models.DataContext;
using WPFShapBot.ViewModel.Base;

namespace WPFShapBot.ViewModel
{
    internal class ViewModelMainWindow : BaseViewModel
    {

        public ViewModelMainWindow()
        {

        }
        public ObservableCollection<BotUser> UsList { get => UserContext.Users; set { UserContext.Users = value; OnPropertyChanged(nameof(UsList)); } }

        //  public ObservableCollection<UserEmail> UsList { get=> UserContext.UserEmails; set { UserContext.UserEmails = value; OnPropertyChanged(nameof(UsList)); } }

    }
}
