namespace DemoApp
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Runtime.CompilerServices;
    using System.ComponentModel;
    using System.Windows;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private ObservableCollection<Widget> _realWidgets;
        private ObservableCollection<Widget> _virtualWidgets;
        private ObservableCollection<Widget> _templateWidgets;

        public MainWindow()
        {
            this.RealWidgets = GetWidgets(512, "RealWidgets");
            this.VirtualWidgets = GetWidgets(512, "VirtualWidgets");
            this.TemplateWidgets = GetWidgets(512, "TemplateWidgets");

            InitializeComponent();
        }

        public ObservableCollection<Widget> RealWidgets
        {
            get => _realWidgets;
            set
            {
                _realWidgets = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Widget> VirtualWidgets
        {
            get => _virtualWidgets;
            set
            {
                _virtualWidgets = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Widget> TemplateWidgets
        {
            get => _templateWidgets;
            set
            {
                _templateWidgets = value;
                OnPropertyChanged();
            }
        }

        private static ObservableCollection<Widget> GetWidgets(int count, string name)
        {
            var widgets = new List<Widget>(count);

            for (var i = 0; i < count; i++)
            {
                widgets.Add(new Widget($"{name}-{i:000}"));
            }

            return new ObservableCollection<Widget>(widgets);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
