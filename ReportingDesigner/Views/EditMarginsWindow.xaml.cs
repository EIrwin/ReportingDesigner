using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ReportingDesigner.Events;

namespace ReportingDesigner.Views
{
    /// <summary>
    /// Interaction logic for EditMarginsWindow.xaml
    /// </summary>
    public partial class EditMarginsWindow : Window
    {
        public EventHandler<MarginChangedEventArgs> MarginChanged;
        public Thickness _margin;

        public EditMarginsWindow(Thickness margin)
        {

            InitializeComponent();
            _margin = margin;
            this.DataContext = _margin;
        }

        private void SaveMarginsButton_Click(object sender, RoutedEventArgs e)
        {
            var top = double.Parse(TopMarginTextBox.Text);
            var bottom = double.Parse(BottomMarginTextBox.Text);
            var left = double.Parse(LeftMarginTextBox.Text);
            var right = double.Parse(RightMarginTextBox.Text);

            MarginChangedEventArgs args = new MarginChangedEventArgs();
            args.Margin = _margin = new Thickness(left, top, right, bottom);
            
            MarginChanged(this, args);

            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
