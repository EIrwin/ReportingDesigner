using System;
using System.Linq;
using System.Windows;
using ReportingDesigner.Data;
using ReportingDesigner.Extensibility;
using ReportingDesigner.ViewModels.PageTemplates;

namespace ReportingDesigner.Views.PageTemplates
{
    public partial class PageTemplateSaveWindow : Window
    {
        private PageTemplateSaveViewModel _viewModel;

        //This constructor is used if a template is being used
        public PageTemplateSaveWindow()
        {
            _viewModel = new PageTemplateSaveViewModel()
                {
                    PageTemplate = new PageTemplate()
                        {
                            Name = "Template",
                            Created = DateTime.Now,
                            Modified = DateTime.Now,
                        }
                };
        }

        //This constructor is used if an existing page template is being saved
        public PageTemplateSaveWindow(PageTemplateSaveViewModel viewModel)
        {
            _viewModel = viewModel;

            InitializeComponent();

            DataContext = viewModel;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var repository = new PageTemplateRepository();

            //if the page template exists, we only want to call 
            //save, otherwise we call insert
            if(!repository.AsQueryable().Any(p => p.ID == _viewModel.PageTemplate.ID))
                repository.Insert(_viewModel.PageTemplate);
            else
                repository.Save(_viewModel.PageTemplate);
            
            Close();
        }
    }
}
