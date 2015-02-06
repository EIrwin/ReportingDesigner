using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using ReportingDesigner.Data;
using ReportingDesigner.Events;
using ReportingDesigner.Extensibility;
using ReportingDesigner.ViewModels.PageTemplates;

namespace ReportingDesigner.Views.PageTemplates
{
    public partial class PageTemplateSelectWindow : Window
    {
        public delegate void TemplateSelectedHandler(object sender, TemplateSelectedEventArgs e);

        public event TemplateSelectedHandler TemplateSelected;

        public PageTemplateSelectWindow()
        {
            InitializeComponent();

            var pageTemplates = new ObservableCollection<PageTemplate>();

            var pageTemplateRepository = new PageTemplateRepository();
            pageTemplateRepository.AsQueryable().ToList().ForEach(pageTemplates.Add);
            
            DataContext = new PageTemplateSelectViewModel()
                {
                    PageTemplates = pageTemplates
                };
        }

        private void SelectTemplateButton_Click(object sender, RoutedEventArgs e)
        {
            var pageTemplate = (PageTemplate) PageTemplateListBox.SelectedItem;
            var args = new TemplateSelectedEventArgs(pageTemplate);
            OnTemplateSelected(args);
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void OnTemplateSelected(TemplateSelectedEventArgs  e)
        {
            if (TemplateSelected != null)
                TemplateSelected(this,e);
        }
    }
}
