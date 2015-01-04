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
using ReportingDesigner.ViewModels;

namespace ReportingDesigner.Views
{
    /// <summary>
    /// Interaction logic for PageNumberView.xaml
    /// </summary>
    public partial class PageNumberView : UserControl
    {
        private PageNumberViewModel _viewModel;

        public PageNumberView()
        {
            InitializeComponent();

            _viewModel = new PageNumberViewModel();

            this.DataContext = _viewModel;
        }

        public int GetPageNumber()
        {
            return _viewModel.PageNumber;
        }

        public void SetPageNumber(int page)
        {
            _viewModel.PageNumber = page;
        }
    }
}
