using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace ReportingDesigner.Commands
{
    public static class ReportingDesignerCommands
    {
        public static ICommand ToggleGridLines {
            get { return new ToggleGridLines(); }
        }

        public static ICommand Print{
            get{return new Print(); }
        }

        public static ICommand ChangePageSizeToLetter{
            get { return new ChangePageSizeToLetter(); }
        }

        public static ICommand ChangePageSizeToLegal{
            get { return new ChangePageSizeToLegal(); }
        }

        public static ICommand ChangePageSizeToA4{
            get { return new ChangePageSizeToA4(); }
        }

        public static ICommand AddNewPage{
            get{
                return new AddNewPage();
            }
        }
    }
}
