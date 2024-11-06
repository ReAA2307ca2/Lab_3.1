using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    public class Mushroom : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsEatable { get; set; }
        public string Colour { get; set; }
        public float Weight { get; set; }
        public float Height { get; set; }
        public float Radius { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
