using System;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;
using FluentNHibernateSQLiteCSharp.Services;

namespace CashFlowManager.Donators
{
    /// <summary>
    ///     Interaction logic for DonatorsViewer.xaml
    /// </summary>
    public partial class DonatorsViewer : Window
    {
        public DonatorsViewer()
        {
            InitializeComponent();
            //DonatorsDataGrid.RowEditEnding += new Rowed(CustomersCollectionChanged);
        }

        void CustomersCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (object item in e.OldItems)
                {
                    //CustomerUIObject customerObject = item as CustomerUIObject;

                    //// use the data access layer to delete the wrapped data object
                    //dataAccessLayer.DeleteCustomer(customerObject.GetDataObject());
                }
            }
        }

        private void DataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            // drill down from DataGridRow, through row view to our order row
            DataGridRow dgRow = e.Row;
            DataGrid dg = (DataGrid)sender;
            //DataRowView rowView = dgRow.Item as DataRowView;
            //NorthwindDataSet.OrdersRow orderRow =
            //      rowView.Row as NorthwindDataSet.OrdersRow;

            //// set the foreign key to the customer ID
            //orderRow.CustomerID = CustomerGrid.SelectedValue as string;
        }
    }
}