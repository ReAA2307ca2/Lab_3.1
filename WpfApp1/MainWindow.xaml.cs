using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Mushroom> mushrooms { get; set; } = new ObservableCollection<Mushroom>();
        int maxID = 3;
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            mushrooms = new ObservableCollection<Mushroom>()
            {
                new Mushroom() {id= 1, name= "Gribovik", isEatable= false },
                new Mushroom() {id= 2, name= "Sedobnii grib", isEatable= true },
                new Mushroom() {id= 3, name= "Muchomor", isEatable= false }
            };


        }

        private void bt_addNew_Click(object sender, RoutedEventArgs e)
        {
            mushrooms.Add(new Mushroom() { id = maxID, name = "Name", isEatable = false });
            maxID++;
            lw_listOfMush.SelectedIndex = mushrooms.Count()-1;
        }

        private void bt_delete_Click(object sender, RoutedEventArgs e)
        {
            if (mushrooms.Count <= 0 | lw_listOfMush.SelectedIndex == -1) { return; }
            mushrooms.RemoveAt(lw_listOfMush.SelectedIndex);
        }
    }
}