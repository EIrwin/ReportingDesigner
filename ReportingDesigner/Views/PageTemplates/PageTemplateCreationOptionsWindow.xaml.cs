using System;
using System.Windows;
using ReportingDesigner.Events;
using ReportingDesigner.ViewModels;

namespace ReportingDesigner.Views
{
    /// <summary>
    /// Interaction logic for PageTemplateCreationOptionsWindow.xaml
    /// </summary>
    public partial class PageTemplateCreationOptionsWindow : Window
    {
        public delegate void OptionsSelectedHandler(object sender,OptionsSelectedEventArgs e);

        public event OptionsSelectedHandler OptionsSelected;

        public PageTemplateCreationOptionsWindow()
        {
            InitializeComponent();

            DataContext = new PageTemplateCreationOptionsViewModel();
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = (PageTemplateCreationOptionsViewModel) DataContext;
            var args = new OptionsSelectedEventArgs(viewModel.Name);
            OnOptionsSelected(args);
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        protected void OnOptionsSelected(OptionsSelectedEventArgs e)
        {
            if (OptionsSelected != null)
                OptionsSelected(this, e);
        }
    }
}
