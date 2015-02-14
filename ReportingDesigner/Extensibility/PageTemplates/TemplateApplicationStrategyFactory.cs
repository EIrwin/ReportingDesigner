namespace ReportingDesigner.Extensibility.PageTemplates
{
    public static class TemplateApplicationStrategyFactory
    {
        public static TemplateApplicationStrategy Create(TemplateApplicationMethod method)
        {
            TemplateApplicationStrategy strategy = null;

            switch (method)
            {
                case TemplateApplicationMethod.CurrentPage :
                    strategy = new CurrentPageApplicationStrategy();
                    break;
                case TemplateApplicationMethod.SinglePage :
                    strategy = new SinglePageApplicationStrategy();
                    break;
                case TemplateApplicationMethod.EvenPages :
                    strategy = new EvenPagesApplicationStrategy();
                    break;
                case TemplateApplicationMethod.OddPages :
                    strategy = new OddPagesApplicationStrategy();
                    break;
                case TemplateApplicationMethod.Range :
                    strategy = new RangeApplicationStrategy();
                    break;
                case TemplateApplicationMethod.AllPages :
                    strategy = new AllPagesApplicationStrategy();
                    break;
            }


            return strategy;
        }
    }
}