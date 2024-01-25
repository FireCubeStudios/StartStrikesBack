using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.DataTransfer;

namespace CubeKit.UI.Helpers
{
    /// <summary>
    /// Helper methods for adding seamless drag & drop support to different <see cref="ListViewBase"/>
    /// </summary>
    /// <typeparam name="T">The type of the dragged & dropped items</typeparam>
    public class DragDropHelper<T>
    {
        /// <summary> ID strings for data package</summary>
        const string Item = "CubeActionItem";
        const string Source = "CubeActionList";

        /// <summary>
        /// Invoked when dragging starts
        /// Set data package ID's
        /// </summary>
        public void DragItemsStarting(object sender, DragItemsStartingEventArgs e)
        {
            e.Data.Properties[Item] = e.Items[0];
            e.Data.Properties[Source] = sender as ListViewBase;
        }

        /// <summary>
        /// Invoked when item drags over <see cref="ListViewBase"/>
        /// </summary>
        public void DragOver(object sender, DragEventArgs e)
        {
            e.AcceptedOperation = DataPackageOperation.Move;
            e.DragUIOverride.IsGlyphVisible = false;
            e.Handled = true;
        }

        /// <summary>
        /// Occurs when item drops on <see cref="ListViewBase"/>
        /// </summary>
        /// <param name="sender">The <see cref="ListViewBase"/> to drop to</param>
        /// <param name="e">The <see cref="DragEventArgs"/></param>
        public void Drop(object sender, DragEventArgs e)
        {
            DragOperationDeferral Deferral = e.GetDeferral(); // Create a deferral to process item
            ListViewBase TargetList = sender as ListViewBase; // Target listview which we are dropping to
            ListViewBase SourceList = e.DataView.Properties[Source] as ListViewBase; // Source listview where item is from
            ObservableCollection<T> SourceItems = SourceList.ItemsSource as ObservableCollection<T>;
            ObservableCollection<T> TargetItems = TargetList.ItemsSource as ObservableCollection<T>;
            T DragItem = (T)e.DataView.Properties[Item];

            // Position of cursor
            var pt = e.GetPosition(TargetList);
            // Get index of where item was dropped in list
            var DropIndex = (
                from index in Enumerable.Range(0, TargetList.Items.Count) // Index range from 0 to number of items
                let Element = TargetList.ContainerFromIndex(index) as UIElement // Get item
                let posElement = Element.TransformToVisual(TargetList).TransformPoint(default) // Item point position
                let size = Element.ActualSize // Item size
                let IsMoreThanTopLeft = pt.X >= posElement.X && pt.Y >= posElement.Y // Overflowing check for grid
                let IsLessThanBottomRight = pt.X <= posElement.X + size.X && pt.Y <= posElement.Y + size.Y // Overflowing check for grid
                where IsMoreThanTopLeft && IsLessThanBottomRight
                select (int?)index // Retrieve index with data
            ).FirstOrDefault(); // Return the first result

            try
            {
                SourceItems.Remove(DragItem); // Remove item from original list
            }
            catch { /* Ignore lists that have groups */}
            TargetItems.Insert(DropIndex.HasValue ? (int)DropIndex : 0, DragItem); // Add item to new list

            e.AcceptedOperation = DataPackageOperation.Move; // Set operation as moved
            Deferral.Complete(); // Set deferral to complete so framework can continue processing
            e.Handled = true; // Set drop operation as completed
        }
    }
}
