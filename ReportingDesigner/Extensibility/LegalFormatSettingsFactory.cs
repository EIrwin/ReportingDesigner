namespace ReportingDesigner.Extensibility
{
    public class LegalFormatSettingsFactory:FormatSettingsFactory
    {
        public override FormatSettings CreateFormatSettings()
        {
            var settings = new FormatSettings(FormatType.Legal,PageSizes.Legal, PageOrientation.Portrait);
            return settings;
        }
    }
}