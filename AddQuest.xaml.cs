using System.Windows;
using System.Windows.Controls;

namespace WPFShapBot
{
    /// <summary>
    /// Логика взаимодействия для AddQuest.xaml
    /// </summary>
    public partial class AddQuest : Window
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
