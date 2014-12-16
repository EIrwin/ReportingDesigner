using System;

namespace ReportingDesigner.Extensibility
{
    public class FormatSettings
    {
        private readonly PageSize _pageSize;
        public PageSize PageSize{
            get { return _pageSize; }
        }

        private readonly PageOrientation _pageOrientation;
        public PageOrientation PageOrientation {
            get { return _pageOrientation; }
        }

        private readonly FormatType _formatType;
        public FormatType FormatType {
            get { return _formatType; }
        }

        public FormatSettings(FormatType formatType,PageSize pageSize, PageOrientation pageOrientation)
        {
            _formatType = formatType;
            _pageSize = pageSize;
            _pageOrientation = pageOrientation;
        }
    }
}