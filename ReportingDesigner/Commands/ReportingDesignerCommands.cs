﻿using System.Windows.Input;

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

        public static ICommand TogglePageBreaks
        {
            get { return new TogglePageBreaks(); }
        }

        public static ICommand EditMargins
        {
            get { return new EditMargins(); }
        }

        public static ICommand Print{
            get{return new Print(); }
        }

        public static ICommand AddPageBefore
        {
            get { return new AddPageBefore(); }
        }

        public static ICommand AddPageAfter
        {
            get { return new AddPageAfter(); }
        }

        public static ICommand AddFirstPage
        {
            get { return new AddFirstPage(); }
        }

        public static ICommand AddLastPage
        {
            get { return new AddLastPage(); }
        }

        public static ICommand PinControl
        {
            get { return new PinControl(); }
        }

        public static ICommand UnpinControl
        {
            get { return new UnpinControl(); }
        }

        public static ICommand CreatePageTemplate
        {
            get { return new CreatePageTemplate(); }
        }

        public static ICommand SavePageTemplate
        {
            get { return new SavePageTemplate(); }
        }

        public static ICommand NewPageTemplate
        {
            get { return new NewPageTemplate(); }
        }

        public static ICommand LoadPageTemplate
        {
            get { return new LoadPageTemplate(); }
        }

        public static ICommand EditPageTemplate
        {
            get { return new EditPageTemplate(); }
        }

        public static ICommand ApplyPageTemplate
        {
            get { return new ApplyPageTemplate(); }
        }

        public static ICommand UnapplyPageTemplate
        {
            get { return new UnapplyPageTemplate(); }
        }

        public static ICommand Render
        {
            get { return new RenderReport(); }
        }
    }
}
