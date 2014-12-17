namespace ReportingDesigner.Extensibility
{
    public class LetterFormatSettingsFactory:FormatSettingsFactory
    {
        public override FormatSettings CreateFormatSettings()
        {
            var settings = new FormatSettings(FormatType.Legal,PageSizes.Letter, PageOrientation.Portrait,UnitType.Points);
            return settings;
        }
    }
}