using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp1.Model;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Mushroom Mushroom { get; set; }
        public Window1(Mushroom mush)
        {
            InitializeComponent();

            tb_Name.Text = mush.Name;
            tb_Color.Text = mush.Colour;
            tb_Height.Text = Convert.ToString(mush.Height);
            tb_Radius.Text = Convert.ToString(mush.Radius);
            tb_Weight.Text = Convert.ToString(mush.Weight);
            cb_IsEatable.IsChecked = mush.IsEatable;
        }

        private void but_Edit_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Mushroom = new Mushroom() { Name = tb_Name.Text, Colour = tb_Color.Text, Height = tb_Height.Text,
                Radius = tb_Radius.Text, Weight = tb_Weight.Text, IsEatable = cb_IsEatable.IsChecked};

            this.Close();
        }
    }
}
