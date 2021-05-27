using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPFShapBot.ViewModel.Base;

namespace WPFShapBot.ViewModel.menu
{
    class ViewModelMenu : BaseViewModel
    {
        Models.BotStart.StartBot start = new Models.BotStart.StartBot();

        public ViewModelMenu()
        {
            Close = new Control.LambdaCommand(OnGetCommandExecuteClose, CanGetCommandExecuteClose);
            Start = new Control.LambdaCommand(OnGetCommandExecuteStart, CanGetCommandExecuteStart);
            Stop = new Control.LambdaCommand(OnGetCommandExecuteStop, CanGetCommandExecuteStop);


        }

        public ICommand Close { get; }
        private bool CanGetCommandExecuteClose(object param) => true;
        private void OnGetCommandExecuteClose(object param) => Application.Current.Shutdown();


        public ICommand Start { get; }
        private bool CanGetCommandExecuteStart(object param) => true;
        private void OnGetCommandExecuteStart(object param) => start.start();

        public ICommand Stop { get; }
        private bool CanGetCommandExecuteStop(object param) => true;
        private void OnGetCommandExecuteStop(object param) => start.stop();

    }
}
