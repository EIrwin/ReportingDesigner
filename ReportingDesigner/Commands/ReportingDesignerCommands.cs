using System.Windows.Input;

namespace ReportingDesigner.Commands
{
    public static class ReportingDesignerCommands
    {
        public static ICommand ToggleGridLines {
            get { return new ToggleGridLines(); }
        }

        public static ICommand ToggleMarginLines
        {
            get { return new ToggleMarginLines(); }
        }

        public static ICommand EditMargins
        {
            get { return new EditMargins(); }
        }

        public static ICommand Print{
            get{return new Print(); }
        }


        public static ICommand AddNewPage{
            get{
                return new AddNewPage();
            }
        }
    }
}
