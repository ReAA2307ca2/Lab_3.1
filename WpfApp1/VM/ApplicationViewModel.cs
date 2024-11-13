using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp1.Data;
using WpfApp1.Model;

namespace WpfApp1.VM
{
    internal class ButtonVM : INotifyPropertyChanged
    {
        public ApplicationConnector db = new ApplicationConnector();

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        public ObservableCollection<Mushroom> mushrooms { get; set; }
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
        int maxID = 1;

        private RelayCommand mushroomAdd;
        public RelayCommand MushroomAdd
        {
            get
            {
                return mushroomAdd ?? (mushroomAdd = new RelayCommand(obj =>
                {
                    var mushroom = new Mushroom() {Name = "Name", IsEatable = false, Colour = "White", Height = "12", Radius = "6", Weight = "93"};
                    
                    db.mushrooms.Add(mushroom);
                    db.SaveChanges();
                    
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
                    if (obj == null) return;
                    Mushroom mush = obj as Mushroom;
                    db.mushrooms.Remove(mush);
                    db.SaveChanges();
                }));

            }
        }

        private RelayCommand mushroomEdit;
        public RelayCommand MushroomEdit
        {
            get
            {
                return mushroomEdit ?? (mushroomEdit = new RelayCommand(obj =>
                {
                    Mushroom? mush = obj as Mushroom;
                    if (mush == null) return;
                    Window1 editWindow = new Window1(mush);
                    editWindow.ShowDialog();
                    if (editWindow.DialogResult == true)
                    {
                        {
                            mush.Name = editWindow.Mushroom.Name;
                            mush.Colour = editWindow.Mushroom.Colour;
                            mush.Radius = editWindow.Mushroom.Radius;
                            mush.Weight = editWindow.Mushroom.Weight;
                            mush.Height = editWindow.Mushroom.Height;
                            mush.IsEatable = editWindow.Mushroom.IsEatable;
                            db.Entry(mush).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                    }
                }));

            }
        }
        public ButtonVM()
        {
            db.Database.EnsureCreated();
            db.mushrooms.Load();
            mushrooms = db.mushrooms.Local.ToObservableCollection();
        }
    }
}
