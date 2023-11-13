using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ReadyWaters.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public ICommand TapCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));

#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        public event PropertyChangedEventHandler? PropertyChanged;
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.

        public ObservableCollection<Brush> PaletteBrushes { get; set; }
        public ObservableCollection<Brush> CustomColor2 { get; set; }
        public ObservableCollection<Brush> CustomColor3 { get; set; }

        public ObservableCollection<Brush> CustomColor4 { get; set; }
        public ObservableCollection<Brush> AlterColor1 { get; set; }

        private bool enableAnimation = true;
        public bool EnableAnimation
        {
            get { return enableAnimation; }
            set
            {
                enableAnimation = value;
                OnPropertyChanged("EnableAnimation");
            }
        }

        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public BaseViewModel()
        {
            PaletteBrushes = new ObservableCollection<Brush>()
            {
               new SolidColorBrush(Color.FromArgb("#FFFFFF")),
                 new SolidColorBrush(Color.FromArgb("#FFFFFF")),
                 new SolidColorBrush(Color.FromArgb("#FFFFFF")),
                 new SolidColorBrush(Color.FromArgb("#FFFFFF")),
                 new SolidColorBrush(Color.FromArgb("#FFFFFF"))
            };
            CustomColor2 = new ObservableCollection<Brush>()
            {
                new SolidColorBrush(Color.FromArgb("#ec41f2"))
            };

            CustomColor3 = new ObservableCollection<Brush>()
            {
                new SolidColorBrush(Color.FromArgb("#1c43ed"))
            };

            CustomColor4 = new ObservableCollection<Brush>()
            {
                new SolidColorBrush(Color.FromArgb("#95DB9C")),
                new SolidColorBrush(Color.FromArgb("#B95375")),
                new SolidColorBrush(Color.FromArgb("#56BBAF")),
                new SolidColorBrush(Color.FromArgb("#606D7F")),
                new SolidColorBrush(Color.FromArgb("#E99941")),
                new SolidColorBrush(Color.FromArgb("#327DBE")),
                new SolidColorBrush(Color.FromArgb("#E7695A")),
                new SolidColorBrush(Color.FromArgb("#2D4552")),
                new SolidColorBrush(Color.FromArgb("#4E9B8F")),
                new SolidColorBrush(Color.FromArgb("#E9A56C")),
            };


            AlterColor1 = new ObservableCollection<Brush>()
            {
                new SolidColorBrush(Color.FromArgb("#314A6E")),
                 new SolidColorBrush(Color.FromArgb("#48988B")),
            };
        }
    }
}
