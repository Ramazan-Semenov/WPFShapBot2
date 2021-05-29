using System.Windows.Controls;

namespace WPFShapBot.Views
{
    /// <summary>
    /// Логика взаимодействия для messbot.xaml
    /// </summary>
    public partial class messbot : UserControl
    {
        public messbot()
        {
            InitializeComponent();
            DataContext = new ViewModel.ViewModelMainWindow();
        }
    }
}
