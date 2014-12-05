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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ReportingDesigner.Views
{
    /// <summary>
    /// Interaction logic for TextBlockView.xaml
    /// </summary>
    public partial class TextBlockView : ReportControlView
    {

        private const string TextName = "Text";

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(TextBlockView), new FrameworkPropertyMetadata("", OnTextChange));

        public string Text
        {
            get { return (string)this.GetValue(TextProperty); }
            set { this.SetValue(TextProperty, value); }
        }

        public TextBlockView()
        {
            InitializeComponent();
        }

        private static void OnTextChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((TextBlockView)d).OnTextChange(e);
        }

        private void OnTextChange(DependencyPropertyChangedEventArgs e)
        {
            this.Content = this.Text;
        }
    }
}
