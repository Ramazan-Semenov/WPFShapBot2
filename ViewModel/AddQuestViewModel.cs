using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using WPFShapBot.Models;

namespace WPFShapBot.ViewModel
{
    class AddQuestViewModel : Base.BaseViewModel
    {
        public AddQuestViewModel()
        {
            AddCommand = new Control.LambdaCommand(OnGetCommandExecuteClose, CanGetCommandExecuteClose);
            DelCommand = new Control.LambdaCommand(OnGetCommandExecuteDel, CanGetCommandExecuteDel);

        }
        private ObservableCollection<Questions> _que = Models.DataContext.ContextQuest.Questions;
        public ObservableCollection<Questions> que
        {
            get => _que;
            set
            {
                _que = value;
                OnPropertyChanged("txt");
            }
        }

        public string txt { get; set; }
        public ICommand AddCommand { get; }
        private bool CanGetCommandExecuteClose(object param) => true;
        private void OnGetCommandExecuteClose(object param)
        {
            Questions questions = new Questions() { Text = this.txt };
            Models.DataContext.ContextQuest.addquestions(questions);

            foreach (var item in que)
            {
                Debug.WriteLine(item.ID);

                Debug.WriteLine(item.Text);

            }
        }



        public ICommand DelCommand { get; }
        private bool CanGetCommandExecuteDel(object param) => true;
        private void OnGetCommandExecuteDel(object param)
        {
            //    Questions questions = new Questions() { Text = this.txt };
            Models.DataContext.ContextQuest.Delquestions(0);


        }
    }
}
