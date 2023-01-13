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
        private ObservableCollection<Widget> _widgets;

        public MainWindow()
        {
            this.Widgets = GetWidgets(512);
            InitializeComponent();
        }

        public ObservableCollection<Widget> Widgets
        {
            get => _widgets;
            set
            {
                _widgets = value;
                OnPropertyChanged();
            }
        }

        private static ObservableCollection<Widget> GetWidgets(int count)
        {
            var widgets = new List<Widget>(count);

            for (var i = 0; i < count; i++)
            {
                widgets.Add(new Widget($"Widget-{i:000}"));
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
