﻿using System;
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
using ReportingDesigner.Extensibility;
using ReportingDesigner.ViewModels.PageTemplates;

namespace ReportingDesigner.Views.PageTemplates
{
    public partial class ApplyPageTemplateWindow : Window
    {
        public ApplyPageTemplateWindow()
        {
            InitializeComponent();

            var pageTemplates = new ObservableCollection<PageTemplate>();

            var pageTemplateRepository = new PageTemplateRepository();
            pageTemplateRepository.AsQueryable().ToList().ForEach(pageTemplates.Add);

            DataContext = new ApplyPageTemplateViewModel()
            {
                PageTemplates = pageTemplates
            };
        }

        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
