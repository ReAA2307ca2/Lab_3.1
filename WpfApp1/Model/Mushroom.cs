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
        public int id { get; set; }
        public string name { get; set; }
        public bool isEatable { get; set; }
        public string colour { get; set; }
        public float weight { get; set; }
        public float height { get; set; }
        public float radius { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
