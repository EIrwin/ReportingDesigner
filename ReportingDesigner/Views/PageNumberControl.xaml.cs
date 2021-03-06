﻿using System;
using System.Collections.Generic;
using System.Windows;
using ReportingDesigner.Extensibility.Serialization;
using ReportingDesigner.ViewModels;

namespace ReportingDesigner.Views
{
    public partial class PageNumberControl : ReportControlView
    {
        private PageNumberControlViewModel _viewModel 
        {
            get { return (PageNumberControlViewModel)DataContext; }
        }

        public PageNumberControl()
        {
            InitializeComponent();
        }

        public override IDictionary<string, string> Serialize()
        {
            return new Dictionary<string, string>()
                {
                    {"VM.PageNumber", _viewModel.PageNumber.ToString()},
                    {"VM.ViewModelType", typeof (PageNumberControlViewModel).ToString()},
                    {"VM.SettingsViewType",typeof(PageNumberSettingsView).ToString()},
                    {"VM.IsTemplateControl",_viewModel.IsTemplateControl.ToString()}
                };
        }

        public override void Deserialize(SerializationInfo info)
        {
            _viewModel.PageNumber = int.Parse(info["VM.PageNumber"]);
            _viewModel.SettingsViewType = Type.GetType(info["VM.SettingsViewType"]);
            _viewModel.IsTemplateControl = bool.Parse(info["VM.IsTemplateControl"]);
        }
    }
}
