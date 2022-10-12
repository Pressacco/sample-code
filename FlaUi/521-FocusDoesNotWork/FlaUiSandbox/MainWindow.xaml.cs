using System.Threading;

namespace FlaUiSandbox
{
    using System;
    using System.Windows;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Attach_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                UserOptions.IsEnabled = false;

                using (var window = new WindowManager(canAttach: true, FocusStrategy.SetForeground))
                {
                    window.SwitchWindows();
                    Thread.Sleep(TimeSpan.FromSeconds(2));
                }
            }
            finally
            {
                UserOptions.IsEnabled = true;
            }
        }

        private void Launch_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                UserOptions.IsEnabled = false;

                using (var window = new WindowManager(canAttach: false, FocusStrategy.SetForeground))
                {
                    window.SwitchWindows();
                    Thread.Sleep(TimeSpan.FromSeconds(2));
                }
            }
            finally
            {
                UserOptions.IsEnabled = true;
            }
        }

        private void ClickMe_OnClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Window was clicked.");
        }
    }
}
