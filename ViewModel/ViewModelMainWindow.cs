using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using WPFShapBot.Models;
using WPFShapBot.ViewModel.Base;
using System.Diagnostics;
using System.Windows;
using WPFShapBot.Models.DataContext;

namespace WPFShapBot.ViewModel
{
    internal class ViewModelMainWindow: BaseViewModel
    {

           public ViewModelMainWindow()
        {
            
        }
        public ObservableCollection<BotUser> UsList { get => UserContext.Users; set { UserContext.Users = value; OnPropertyChanged(nameof(UsList)); } }

      //  public ObservableCollection<UserEmail> UsList { get=> UserContext.UserEmails; set { UserContext.UserEmails = value; OnPropertyChanged(nameof(UsList)); } }
      
    }
}
