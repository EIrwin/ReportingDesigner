using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ReportingDesigner.Models;
using ReportingDesigner.ViewModels;

namespace ReportingDesigner.Controls
{
    public partial class Toolbox
    {
        #region [Constructors]

        public Toolbox()
        {
            InitializeComponent();
        }

        #endregion

        #region [Public Methods]

        public void LoadToolboxComponents(List<ToolboxComponentAnnouncement> toolboxComponents)
        {
            foreach (ToolboxComponentAnnouncement announcement in toolboxComponents)
            {
                ToolboxComponent item = new ToolboxComponent();
                item.PreviewMouseLeftButtonDown += ListBoxItem_PreviewMouseLeftButtonDown;
                item.Content = announcement.Display;
                item.DataContext = new ToolboxItemViewModel()
                {
                    Name = announcement.Name,
                    Display = announcement.Display,
                    ViewType = announcement.ViewType,
                    ComponentType = announcement.ComponentType,
                    ViewModelType = announcement.ViewModelType,
                    SettingsViewType = announcement.SettingsViewType
                };

                //Attempt to find TreeViewItem from 'Category' header
                TreeViewItem treeviewItem = GetTreeviewItemByHeader(announcement.Category);

                if (treeviewItem != null)
                {
                    //Add to existing ListBox if TreeViewItem with 'Category' Header exists
                    foreach (object childItem in treeviewItem.Items)
                    {
                        if (childItem is ListBox)
                        {
                            ((ListBox)childItem).Items.Add(item);

                            //We want the items in the list box to
                            //be sorted alphabetically
                            ((ListBox)childItem).Items.SortDescriptions.Add(
                                new System.ComponentModel.SortDescription("Content",
                                                                          System.ComponentModel.ListSortDirection
                                                                                .Ascending));
                        }
                    }
                }
                else
                {
                    //CreateControl new TreeViewItem with 'Category' Header
                    TreeViewItem newTreeViewItem = new TreeViewItem();
                    newTreeViewItem.Header = announcement.Category;

                    //CreateControl New ListBox for child of TreeViewItem
                    ListBox newListBox = new ListBox();
                    newListBox.BorderThickness = new Thickness(0);
                    newListBox.Items.Add(item);
                    newListBox.Margin = new Thickness(-15, 0, 0, 0);    //This is only a temporary fix

                    //Add ListBox to TreeViewItem
                    newTreeViewItem.Items.Add(newListBox);

                    //Add TreeViewItem to TreeView
                    ToolboxTreeview.Items.Add(newTreeViewItem);

                    //We want the collection of ListBox controls
                    //to be sorted alphabetically
                    ToolboxTreeview.Items.SortDescriptions.Add(new System.ComponentModel.SortDescription("Header",
                                                                                                         System
                                                                                                             .ComponentModel
                                                                                                             .ListSortDirection
                                                                                                             .Ascending));
                }
            }
        }

        #endregion

        #region [Private/Protected Methods]

        private TreeViewItem GetTreeviewItemByHeader(string header)
        {
            TreeViewItem treeViewItem = null;

            foreach (TreeViewItem item in ToolboxTreeview.Items)
            {
                if (item.Header.Equals(header))
                    treeViewItem = item;
            }

            return treeViewItem;
        }

        private void ListBoxItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ListBoxItem listBoxItem = e.Source as ListBoxItem;

            if (listBoxItem != null && e.LeftButton == MouseButtonState.Pressed)
            {
                ToolboxItemViewModel model = (ToolboxItemViewModel)listBoxItem.DataContext;
                DragDrop.DoDragDrop(listBoxItem, model, DragDropEffects.Copy);
            }
        }

        #endregion
    }

    
}
