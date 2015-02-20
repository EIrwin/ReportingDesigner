using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using ReportingDesigner.Data;
using ReportingDesigner.Events;
using ReportingDesigner.Extensibility;
using ReportingDesigner.ViewModels.PageTemplates;

namespace ReportingDesigner.Views.PageTemplates
{
    public partial class UnapplyPageTemplateWindow : Window
    {
        private ApplyPageTemplateViewModel _viewModel;

        public delegate void ApplyTemplateEventHandler(object sender,TemplateApplicationEventArgs args);

        public event ApplyTemplateEventHandler ApplyTemplateInit;

        public UnapplyPageTemplateWindow()
        {
            InitializeComponent();

            var pageTemplates = new ObservableCollection<PageTemplate>();

            var pageTemplateRepository = new PageTemplateRepository();
            pageTemplateRepository.AsQueryable().ToList().ForEach(pageTemplates.Add);

            DataContext = _viewModel = new ApplyPageTemplateViewModel()
                {
                    PageTemplates = pageTemplates
                };;
        }

        private void OnApplyTempInit(TemplateApplicationEventArgs e)
        {
            if (ApplyTemplateInit != null)
                ApplyTemplateInit(this, e);
        }

        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            Close();

            var args = new TemplateApplicationEventArgs(_viewModel.ApplicationMethod, _viewModel.PageTemplate);

            if (_viewModel.ApplicationMethod == TemplateApplicationMethod.SinglePage)
            {
                args.Page = int.Parse(SinglePageTextBox.Text);
            }

            if (_viewModel.ApplicationMethod == TemplateApplicationMethod.Range)
            {
                args.StartPage = int.Parse(RangeStartPageTextBox.Text);
                args.EndPage = int.Parse(RangeEndPageTextBox.Text);
            }

            OnApplyTempInit(args);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
