using System.Windows;
using System.Windows.Controls;

namespace WPFShapBot
{
    /// <summary>
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
            DataContext = new ViewModel.menu.ViewModelMenu();
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;

        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;

        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GridMain.Children.Clear();
            GridMain.Children.Clear();
            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "ItemHome":
                    GridMain.Children.Remove(new Views.messbot());

                    GridMain.Children.Add(new Views.AddQuest());

                    break;
                case "ItemCreate":
                    GridMain.Children.Remove(new Views.AddQuest());

                    GridMain.Children.Add(new Views.messbot());
                    break;
                case "Tickets":
                     GridMain.Children.Add(new Views.UserControl1());
                    break;
                case "Messages":
                    GridMain.Children.Add(new Views.UserControl2());
                    break;
                default:
                
                    break;
            }
        }

        private void opendb_Click(object sender, RoutedEventArgs e)
        {
            GridMain.Children.Clear();
                 GridMain.Children.Add(new Views.Setting());

        }
    }
}
