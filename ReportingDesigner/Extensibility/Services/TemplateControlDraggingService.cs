﻿using System.ComponentModel;
using System.Windows;
using ReportingDesigner.Annotations;
using ReportingDesigner.ViewModels;
using ReportingDesigner.Views;
using Telerik.Windows.Diagrams.Core;

namespace ReportingDesigner.Extensibility.Services
{
    public class TemplateControlDraggingService :DraggingService,INotifyPropertyChanged
    {
        private Rect _dragAllowedArea;

        public Rect DragAllowedArea
        {
            get { return _dragAllowedArea; }
            set
            {
                if (value.Equals(_dragAllowedArea)) return;
                _dragAllowedArea = value;
                OnPropertyChanged("DragAllowedArea");
            }
        }

        private ReportControlView _draggedView;

        public TemplateControlDraggingService(IGraphInternal graph) : base(graph)
        {
            DragAllowedArea = Rect.Empty;
        }

        public TemplateControlDraggingService(IGraphInternal graph,Rect dragAllowedArea,ReportControlView draggedView):base(graph)
        {
            DragAllowedArea = dragAllowedArea;
            _draggedView = draggedView;
        }

        public override void Drag(Point newPoint)
        {
            Point dragPoint = newPoint;

            var viewModel = (ReportControlViewModel)_draggedView.DataContext;

            //if the mouse position during a drag operation should be restricted within the DragAllowedArea
            if (this.DragAllowedArea != Rect.Empty && !this.DragAllowedArea.Contains(newPoint) && viewModel.IsTemplateControl)
            {
                //calculate the proper position of the dragPoint
                double X = dragPoint.X;
                double Y = dragPoint.Y;
                if (X > this.DragAllowedArea.Right)
                    X = this.DragAllowedArea.Right - _draggedView.ActualWidth;
                else if (X < this.DragAllowedArea.Left)
                    X = this.DragAllowedArea.Left + _draggedView.ActualWidth;

                if (Y > this.DragAllowedArea.Bottom)
                    Y = this.DragAllowedArea.Bottom - _draggedView.ActualHeight;
                else if (Y < this.DragAllowedArea.Top)
                    Y = this.DragAllowedArea.Top + _draggedView.ActualHeight;

                dragPoint = new Point(X, Y);
            }

            base.Drag(dragPoint);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}