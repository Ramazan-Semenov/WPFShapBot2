using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPFShapBot.Models;
using WPFShapBot.Models.ConfigFileButton;

namespace WPFShapBot.ViewModel
{
    class AddQuestViewModel : Base.BaseViewModel
    {
        public AddQuestViewModel()
        {
            _que = new ObservableCollection<Questions>();





            DelCommand = new Control.LambdaCommand(OnGetCommandExecuteDel, CanGetCommandExecuteDel);
            Up = new Control.LambdaCommand(OnGetCommandExecuteUp, CanGetCommandExecuteUp);
            Down = new Control.LambdaCommand(OnGetCommandExecuteDown, CanGetCommandExecuteDown);
            Search = new Control.LambdaCommand(OnGetCommandExecuteSearch, CanGetCommandExecuteSearch);
            SaveCommand = new Control.LambdaCommand(OnGetCommandExecuteSave, CanGetCommandExecuteSave);
            Name = GetFile();
        }
        private ObservableCollection<Questions> _que;/*= Models.DataContext.ContextQuest.Questions;*/
        public ObservableCollection<Questions> que
        {
            get => _que;
            set
            {
                _que = value;
                OnPropertyChanged("que");
            }
        }

        public ObservableCollection<ConfigFileJson> GetFile()
        {
            ObservableCollection<ConfigFileJson> lists = new ObservableCollection<ConfigFileJson>();
            DirectoryInfo DirInfo = new DirectoryInfo(Directory.GetCurrentDirectory() + @"\QuestionsFile");
            FileInfo[] fiall = DirInfo.GetFiles();
            var fia = from Fi in fiall
                      where Fi.Extension.ToLower() == ".json" ||
                      Fi.Extension.ToLower() == ".btn"
                      select Fi;
            foreach (FileInfo file in fia)
            {
                lists.Add(item: new ConfigFileJson { StringPath = file.FullName, Name = file.Name });
            }
            return lists;
        }
        public ObservableCollection<ConfigFileJson> Name { get; set; }
        public Questions x { get; set; }
        public string txt { get; set; }
        public ICommand Up { get; set; }
        public ICommand SaveCommand { get; set; }
        static string Path;
        private bool CanGetCommandExecuteSave(object param) => true;
        private async void OnGetCommandExecuteSave(object param)
        {
            Models.ReadWriteJson.ReadWiteJson<ObservableCollection<Questions>> readWite = new Models.ReadWriteJson.ReadWiteJson<ObservableCollection<Questions>>();
            await readWite.WriteJson(Path, que);

        }
        private bool CanGetCommandExecuteUp(object param) => true;
        private void OnGetCommandExecuteUp(object param)
        {
            int sw = que.IndexOf(x);
            MessageBox.Show(sw.ToString());

            if (sw != -1)
            {
                int send = sw - 1;

                if (send >= 0 && send < que.Count)
                {



                    var temp = que[sw];
                    que[sw] = que[send];
                    que[send] = temp;
                }
            }


        }

        public ICommand Search { get; set; }
        private bool CanGetCommandExecuteSearch(object param) => true;
        private async void OnGetCommandExecuteSearch(object param)
        {
            Path = param.ToString();
            await ReadJsone(param);
            ///  MessageBox.Show(param.ToString());
        }

        private async Task ReadJsone(object param)
        {
            Models.ReadWriteJson.ReadWiteJson<ObservableCollection<Questions>> readWite = new Models.ReadWriteJson.ReadWiteJson<ObservableCollection<Questions>>();

            que = await readWite.ReadJson(param.ToString());



        }

        /// <summary>
        /// /////////////////////////////////////////////
        /// </summary>
        public ICommand Down { get; set; }
        private bool CanGetCommandExecuteDown(object param) => true;
        private void OnGetCommandExecuteDown(object param)
        {
            int sw = que.IndexOf(x);
            if (sw != -1)
            {
                int send = sw + 1;

                if (send >= 0 && send < que.Count)
                {

                    var temp = que[sw];
                    que[sw] = que[send];
                    que[send] = temp;
                }
            }


        }



        /// <summary>
        /// ///////////////////////////////
        /// </summary>
        public ICommand DelCommand { get; }
        private bool CanGetCommandExecuteDel(object param) => true;
        private void OnGetCommandExecuteDel(object param)
        {
            int sw = que.IndexOf(x);

            que.RemoveAt(sw);


        }
    }
}
