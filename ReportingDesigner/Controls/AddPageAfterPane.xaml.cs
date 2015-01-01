using System.Windows;
using System.Windows.Input;
using Telerik.Windows.Controls;

namespace ReportingDesigner.Controls
{
    /// <summary>
    /// Interaction logic for AddPageAfterPane.xaml
    /// </summary>
    public partial class AddPageAfterPane : RadDiagramShape
    {
        public ICommand Command
        {
            get { return AddPageButton.Command; }
            set { AddPageButton.Command = value; }
        }
        public object CommandParameter
        {
            get { return AddPageButton.CommandParameter; }
            set { AddPageButton.CommandParameter = value; }
        }

        public AddPageAfterPane()
        {
            InitializeComponent();
        }
    }
}
