using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp1.Model;

namespace WpfApp1.VM
{
    internal class ButtonVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        public ObservableCollection<Mushroom> mushrooms { get; set; } = new ObservableCollection<Mushroom>();
        private Mushroom selectedMush;
        public Mushroom SelectedMush
        {
            get { return selectedMush; }
            set
            {
                selectedMush = value;
                OnPropertyChanged("SelectedMush");
            }
        }
        int maxID = 3;

        private RelayCommand mushroomAdd;
        public RelayCommand MushroomAdd
        {
            get
            {
                return mushroomAdd ?? (mushroomAdd = new RelayCommand(obj =>
                {
                    var mushroom = new Mushroom() { id = maxID, name = "Name", isEatable = false, colour = "White", height = 12, radius = 6, weight = 93 };
                    mushrooms.Add(mushroom);
                }));
            }
        }

        private RelayCommand mushroomDel;
        public RelayCommand MushroomDel
        {
            get
            {
                return mushroomDel ?? (mushroomDel = new RelayCommand(obj =>
                {
                    Mushroom mush = obj as Mushroom;
                    mushrooms.Remove(mush);

                }));

            }
        }
        public ButtonVM()
        {
            mushrooms = new ObservableCollection<Mushroom>()
            {
                new Mushroom() {id= 1, name= "Gribovik", isEatable= false, weight = 60 },
                new Mushroom() {id= 2, name= "Sedobnii grib", isEatable= true, radius = 4 },
                new Mushroom() {id= 3, name= "Muchomor", isEatable= false, colour = "Black" }
            };
        }
    }
}
