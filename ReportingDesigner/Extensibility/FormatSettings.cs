using System;
using System.Windows;

namespace ReportingDesigner.Extensibility
{
    public class FormatSettings
    {
        private PageOrientation _pageOrientation;
        public PageOrientation PageOrientation {
            get { return _pageOrientation; }
            set { _pageOrientation = value; }
        }

        private UnitType _unitType;
        public UnitType UnitType{
            get { return _unitType; }
            set { _unitType =  value; }
        }

        private int _height;
        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }

        private int _width;
        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }

        private PageFormat _pageFormat;
        public PageFormat PageFormat{
            get { return _pageFormat; }
            set { _pageFormat = value; }
        }

        private Thickness _margin;
        public Thickness Margin{
            get { return _margin; }
            set { _margin = value; }
        }

        public FormatSettings(PageOrientation pageOrientation,PageFormat pageFormat,int height,int width)
        {
            _pageOrientation = pageOrientation;
            _pageFormat = pageFormat;
            _margin = new Thickness(0);
            _height = height;
            _width = width;
            _unitType = UnitType.Inches;
        }

        public FormatSettings(PageOrientation pageOrientation, PageFormat pageFormat, int height, int width,Thickness margin)
        {
            _pageOrientation = pageOrientation;
            _pageFormat = pageFormat;
            _margin = margin;
            _height = height;
            _width = width;
            _unitType = UnitType.Inches;
        }

    }
}