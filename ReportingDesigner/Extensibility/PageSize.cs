namespace ReportingDesigner.Extensibility
{
    public class PageSize
    {
        private double _height;
        public double Height{
            get { return _height; }
            set { _height = value; }
        }

        private double _width;
        public double Width {
            get { return _width; }
            set { _width = value; }
        }

        public PageSize(double height, double width)
        {
            _height = height;
            _width = width;
        }
    }
}