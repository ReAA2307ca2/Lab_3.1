using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfApp1.Model
{
    public class Mushroom : INotifyPropertyChanged
    {
        public int Id { get; set; }
        private string name; 
        public string Name 
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            } 
        }
        private bool? _isEat;

        public bool? IsEatable 
        { 
            get {  return _isEat; } 
            set 
            {
                _isEat = value;
                OnPropertyChanged("IsEatable");
            } 
        }
        private string col;
        public string Colour 
        { 
            get { return col; } 
            set 
            {  
                col = value;
                OnPropertyChanged("Colour");
            } 
        }
        private string weg;
        public string Weight 
        {
            get { return weg; } 
            set
            {
                weg = value;
                OnPropertyChanged("Weight");
            } 
        }
        private string hei;
        public string Height
        {
            get { return hei; }
            set
            {
                hei = value;
                OnPropertyChanged("Height");
            }
        }
        private string rad;
        public string Radius 
        {
            get { return rad; } 
            set 
            {
                rad = value;
                OnPropertyChanged("Radius");
            } 
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
