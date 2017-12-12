using AccountSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AccountSystem.Views
{
    /// <summary>
    /// Interaction logic for PositionsView.xaml
    /// </summary>
    public partial class PositionsView : UserControl
    {
        public PositionsView()
        {
            InitializeComponent();
        }
        
        public void HandleColumnHeaderSizeChanged(object sender, SizeChangedEventArgs sizeChangedEventArgs)
        {
            if (sizeChangedEventArgs.NewSize.Width <= 80)
            {
                sizeChangedEventArgs.Handled = true;
                ((GridViewColumnHeader)sender).Column.Width = 80;
            }
        }

        GridViewColumnHeader _lastHeaderClicked = null;
        ListSortDirection? _lastDirection = null;

        void GridViewColumnHeaderClickedHandler(object sender,
                                                RoutedEventArgs e)
        {
            GridViewColumnHeader headerClicked =
                  e.OriginalSource as GridViewColumnHeader;
            ListSortDirection? direction;

            if (headerClicked != null)
            {
                if (headerClicked.Role != GridViewColumnHeaderRole.Padding)
                {
                    if (headerClicked != _lastHeaderClicked)
                    {
                        direction = ListSortDirection.Ascending;
                    }
                    else
                    {
                        if (_lastDirection == ListSortDirection.Ascending)
                        {
                            direction = ListSortDirection.Descending;
                        }
                        else if (_lastDirection == null)
                        {
                            direction = ListSortDirection.Ascending;
                        }
                        else
                        {
                            direction = null;
                        }
                    }

                    string header = headerClicked.Content as string;
                    Sort(header, direction);

                    if (direction == ListSortDirection.Ascending)
                    {
                        headerClicked.Column.HeaderTemplate =
                          Resources["HeaderTemplateArrowUp"] as DataTemplate;
                    }
                    else if (direction == ListSortDirection.Descending)
                    {
                        headerClicked.Column.HeaderTemplate =
                          Resources["HeaderTemplateArrowDown"] as DataTemplate;
                    }
                    else
                    {
                        headerClicked.Column.HeaderTemplate = null;
                    }

                    // Remove arrow from previously sorted header  
                    if (_lastHeaderClicked != null && _lastHeaderClicked != headerClicked)
                    {
                        _lastHeaderClicked.Column.HeaderTemplate = null;
                    }

                    _lastHeaderClicked = headerClicked;
                    _lastDirection = direction;
                }
            }
        }

        private void Sort(string sortBy, ListSortDirection? direction)
        {
            if (direction == null)
            {
                return;
            }

            ListSortDirection nonNullableDirection = direction == 0 ? ListSortDirection.Ascending : ListSortDirection.Descending;

            ICollectionView dataView =
              CollectionViewSource.GetDefaultView(this.lv.ItemsSource);

            dataView.SortDescriptions.Clear();
            SortDescription sd = new SortDescription(sortBy, nonNullableDirection);
            dataView.SortDescriptions.Add(sd);
            dataView.Refresh();
        }

        private void OnMouseLeftButtonDown(object o, object args)
        {
            ((PositionsViewModel)DataContext).SelectPositionAction.Execute(null);
        }
    }
}
