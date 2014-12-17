namespace ReportingDesigner.Extensibility
{
    public class LegalFormatSettingsFactory:FormatSettingsFactory
    {
        public override FormatSettings CreateFormatSettings(UnitType Type, PageOrientation orientation)
        {
            var settings = new FormatSettings(FormatType.Legal, PageSizes.Legal, PageOrientation.Portrait, UnitType.Points);
            return settings;
        }
    }
}