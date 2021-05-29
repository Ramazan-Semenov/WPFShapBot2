using System.Windows.Controls;

namespace WPFShapBot.Views
{
    /// <summary>
    /// Логика взаимодействия для AddQuest.xaml
    /// </summary>
    public partial class AddQuest : UserControl
    {
        public AddQuest()
        {
            InitializeComponent();
            DataContext = new ViewModel.AddQuestViewModel();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
