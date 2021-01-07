using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace WPFLibrary.Behaviors
{
    public class DraggableTreeViewItemBehavior : BaseDragAndDropContainerItemBehavior<TreeViewItem>
    {
        public DraggableTreeViewItemBehavior()
        {
            CanDragPredicate = (o) => (AssociatedObject as TreeView).SelectedItem != null;
            CanDropPredicate = (target) => target == null || IsChildOf((AssociatedObject as TreeView).SelectedItem, target.DataContext) == null;
            GetDataFunc = () => (AssociatedObject as TreeView).SelectedItem;
        }

        private TreeViewItem IsChildOf(object source, object target)
        {
            if (source == null)
                return null;
            TreeView treeView = AssociatedObject as TreeView;
            List<TreeViewItem> unintendExpands = new List<TreeViewItem>();
            var sourceContainer = ContainerFromItemRecursive(treeView.ItemContainerGenerator, source);
            return ContainerFromItemRecursive(sourceContainer.ItemContainerGenerator, target);

            TreeViewItem ContainerFromItemRecursive(ItemContainerGenerator root, object item)
            {
                var treeViewItem = root.ContainerFromItem(item) as TreeViewItem;
                if (treeViewItem != null)
                    return treeViewItem;
                foreach (var subItem in root.Items)
                {
                    treeViewItem = root.ContainerFromItem(subItem) as TreeViewItem;
                    var search = ContainerFromItemRecursive(treeViewItem.ItemContainerGenerator, item);
                    if (search != null)
                        return search;
                }
                return null;
            }
        }
    }
}
