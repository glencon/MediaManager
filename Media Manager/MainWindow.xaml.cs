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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Media_Manager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SolidColorBrush white = new SolidColorBrush(Colors.White);
        SolidColorBrush black = new SolidColorBrush(Colors.Black);
        SolidColorBrush grey = new SolidColorBrush(Colors.Gray);
        Label selected = null;
        Label[] menu;

        public MainWindow()
        {
            InitializeComponent();
            menu = new Label[2];
            menu[0] = Movies;
            menu[1] = TV_Shows;
        }

        private void ExitItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SettingsItem_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow settings = new SettingsWindow();
            settings.Owner = this;
            settings.ShowDialog();
        }

        private void MenuLabel_MouseEnter(object sender, MouseEventArgs e)
        {
            Label source = (Label)e.Source;
            paintMouseOver(source);
        }

        private void MenuLabel_MouseLeave(object sender, MouseEventArgs e)
        {
            Label source = (Label)e.Source;
            paintMouseLeave(source);
        }

        private void MenuLabel_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Label source = (Label)e.Source;
            selected = source;
            paintSelected(source);
            redrawOthers();
        }

        private void redrawOthers()
        {
            foreach (Label lbl in menu)
                paintMouseLeave(lbl);
        }

        private void paintMouseOver(Label lbl)
        {
            lbl.Foreground = white;
            lbl.Background = grey;
        }

        private void paintMouseLeave(Label lbl)
        {
            if (lbl.Equals(selected))
                paintSelected(lbl);
            else
                paintNormal(lbl);
        }

        private void paintNormal(Label source)
        {
            source.Foreground = black;
            source.Background = white;
        }

        private void paintSelected(Label lbl)
        {
            lbl.Foreground = white;
            lbl.Background = black;
        }
    }
}
