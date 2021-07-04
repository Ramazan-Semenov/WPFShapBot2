using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WPFShapBot.Models;
using WPFShapBot.Models.ConfigFileButton;

namespace WPFShapBot.ViewModel.US
{
    class US:Base.BaseViewModel
    {
        public US()
        {
            ObservableCollection<Questions> questions = new ObservableCollection<Questions>();
            questions.Add(new Questions {  Text= "правила приёма в КубГТУ на обучение" });
            questions.Add(new Questions { Text = "перечень испытаний" });
            questions.Add(new Questions { Text = "информация о наличие общежитий" });
            questions.Add(new Questions { Text = "стоимость обучения" });
            questions.Add(new Questions { Text = "подача документов" });

            questions.Add(new Questions { Text = "Информация о институтах" });

            questions.Add(new Questions { Text = "Другое" });
            questions.Add(new Questions { Text = "Начать с начала" });
            _que = questions;
            JS = new ObservableCollection<string>();

            AddCommand = new Control.LambdaCommand(OnGetCommandExecuteAdd, CanGetCommandExecuteAdd);
            DelCommand = new Control.LambdaCommand(OnGetCommandExecuteDel, CanGetCommandExecuteDel);
            Click=new Control.LambdaCommand(OnGetCommandExecuteClick, CanGetCommandExecuteClick);
            Up= new Control.LambdaCommand(OnGetCommandExecuteUp, CanGetCommandExecuteUp);
            Down =new  Control.LambdaCommand(OnGetCommandExecuteDown, CanGetCommandExecuteDown);


            Name = GetFile();
            //Com = new ObservableCollection<Questions>();
            //Com.Add(new Questions { Text="Список" });
            //vs = new ObservableCollection<string>();
        }
        private ObservableCollection<Questions> _que ;
        public ObservableCollection<Questions> que
        {
            get => _que;
            set
            {
                _que = value;
                OnPropertyChanged("que");
            }
        }
        //public ObservableCollection<Questions> Com
        //{
        //    get;set;
        //}
        public ObservableCollection<ConfigFileJsonButton> GetFile()
        {
            ObservableCollection<ConfigFileJsonButton> lists = new ObservableCollection<ConfigFileJsonButton>();
            DirectoryInfo DirInfo = new DirectoryInfo(Directory.GetCurrentDirectory() + @"\ButtonInlineFile");
            FileInfo[] fiall = DirInfo.GetFiles();
            var fia = from Fi in fiall
                      where Fi.Extension.ToLower() == ".jpg" ||
                            Fi.Extension.ToLower() == ".png" ||
                            Fi.Extension.ToLower() == ".jpeg" ||
                            Fi.Extension.ToLower() == ".bmp"
                      select Fi;
            foreach (FileInfo file in fia)
            {
                lists.Add(item: new ConfigFileJsonButton { StringPath = file.FullName, Name = file.Name });
            }
            return lists;
        }
        public ObservableCollection<ConfigFileJsonButton> Name { get; set; }
        public ObservableCollection<string> JS { get; set; }
        public ObservableCollection<string> vs { get; set; }
        public  Questions x { get; set; }
        public string txt { get; set; }
        public ICommand Up { get; set; }
        private bool CanGetCommandExecuteUp(object param) => true;
        private void OnGetCommandExecuteUp(object param)
        {
            int sw = que.IndexOf(x);
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
        private void OnGetCommandExecuteSearch(object param) { }
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
        /// //////////////////////////
        /// </summary>
        public ICommand Click { get; }
        private bool CanGetCommandExecuteClick(object param) => true;
        private void OnGetCommandExecuteClick(object param)
        {
            vs.Add("1");
            vs.Add("2");
            vs.Add("3");

            vs.Add("4");


        }
        /// <summary>
        /// //////////////////////////////////
        /// </summary>
        public ICommand AddCommand { get; }
        private bool CanGetCommandExecuteAdd(object param) => true; 
        private void OnGetCommandExecuteAdd(object param)
        {
           
          int sw=  que.IndexOf(x);
            if (sw != -1)
            {
                int send = sw - 1;

                if (send>=0&&send<que.Count)
                {

               

                    var temp = que[sw];
                    que[sw] = que[send];
                    que[send] = temp;
                }
            }


            //Questions questions = new Questions() { Text = this.txt };
            //Models.DataContext.ContextQuest.addquestions(questions);
            que.Add(new Questions { Text = this.txt });
            //JS.Add(  this.txt );


            //foreach (var item in que)
            //{
            //    Debug.WriteLine(item.ID);

            //    Debug.WriteLine(item.Text);

            //}
        }


        /// <summary>
        /// ///////////////////////////////
        /// </summary>
        public ICommand DelCommand { get; }
        private bool CanGetCommandExecuteDel(object param) => true;
        private void OnGetCommandExecuteDel(object param)
        {
            //    Questions questions = new Questions() { Text = this.txt };
            int sw = que.IndexOf(x);

            que.RemoveAt(sw);


        }
    }
}
