namespace ReportingDesigner.Extensibility
{
    public class PageSize
    {
        private readonly double _height;
        public double Height{
            get { return _height; }
        }

        private readonly double _width;
        public double Width {
            get { return _width; }
        }

        public PageSize(double height, double width)
        {
            _height = height;
            _width = width;
        }
    }
}