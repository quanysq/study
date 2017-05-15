﻿#region COPYRIGHT
//
//     THIS IS GENERATED BY TEMPLATE
//     
//     AUTHOR  :     ROYE
//     DATE       :     2010
//
//     COPYRIGHT (C) 2010, TIANXIAHOTEL TECHNOLOGIES CO., LTD. ALL RIGHTS RESERVED.
//
#endregion

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.APIs;
using System.ComponentModel;
using System.Diagnostics;
using System.Win32;
using System.Windows.Forms;

namespace TX.Framework.WindowUI.Controls
{
    public delegate void TreeListViewItemHandler(object sender);
    public delegate void TreeListViewItemCheckedHandler(object sender, bool ischecked);

    public class TreeListViewItem : ListViewItem
    {
        private TreeListViewItem _Parent;
        private TreeListViewItemCollection _Items;
        private bool _IsExpanded;

        public event TreeListViewItemHandler AfterCollapse;
        public event TreeListViewItemHandler AfterExpand;

        public TreeListViewItem()
        {
            _Items = new TreeListViewItemCollection(this);
        }

        public TreeListViewItem(string value)
            : this()
        {
            this.Text = value;
        }

        public TreeListViewItem(string value, int imageIndex)
            : this(value)
        {
            this.ImageIndex = imageIndex;
        }

        internal void GetCheckedItems(ref TreeListViewItemCollection items)
        {
            if (Checked) items.Add(this);
            foreach (TreeListViewItem item in Items)
            {
                item.GetCheckedItems(ref items);
            }
        }

        public void BeginEdit(int column)
        {
            if (TreeListView == null)
            {
                throw new Exception("The item is not associated with a TreeListView");
            }
            if (!TreeListView.Visible)
            {
                throw new Exception("The item is not visible");
            }
            if (column + 1 > TreeListView.Columns.Count)
            {
                throw new Exception("The column is greater the number of columns in the TreeListView");
            }
            TreeListView.Focus();
            Focused = true;
            TreeListView._LastItemClicked = new EditItemInformations(this, column, this.SubItems[column].Text);
            base.BeginEdit();
        }

        public new void BeginEdit()
        {
            BeginEdit(0);
        }

        public void Redraw()
        {
            if (ListView == null || !Visible) return;
            try
            {
                NativeMethods.SendMessage(ListView.Handle, (int)ListViewMessages.REDRAWITEMS, Index, Index);
            }
            catch { }
        }

        public Rectangle GetBounds(TreeListViewItemBoundsPortion portion)
        {
            switch ((int)portion)
            {
                case (int)TreeListViewItemBoundsPortion.PlusMinus:
                    {
                        if (TreeListView == null)
                        {
                            throw new Exception("This item is not associated with a TreeListView control");
                        }
                        Point pos = base.GetBounds(ItemBoundsPortion.Entire).Location;
                        Point position = new Point(
                            Level * SystemInformation.SmallIconSize.Width + 1 + pos.X,
                            TreeListView.GetItemRect(Index, ItemBoundsPortion.Entire).Top + 1);
                        return new Rectangle(position, TreeListView.ShowPlusMinus ? SystemInformation.SmallIconSize : new Size(0, 0));
                    }
                default:
                    ItemBoundsPortion lviPortion = (ItemBoundsPortion)(int)portion;
                    return base.GetBounds(lviPortion);
            }
        }

        internal void SetParent(TreeListViewItem parent)
        {
            _Parent = parent;
        }

        public new void Remove()
        {
            if (ListView != null)
            {
                if (ListView.InvokeRequired)
                {
                    throw new Exception("Invoke required");
                }
            }
            TreeListViewItemCollection collection = this.Container;
            if (collection != null)
            {
                collection.Remove(this);
            }
        }

        public bool IsAParentOf(TreeListViewItem item)
        {
            TreeListViewItem[] parents = item.ParentsInHierarch;
            foreach (TreeListViewItem parent in parents)
            {
                if (parent == this)
                {
                    return true;
                }
            }
            return false;
        }

        public new void EnsureVisible()
        {
            if (!Visible)
            {
                if (IsInATreeListView)
                {
                    TreeListView.BeginUpdate();
                }
                if (ListView != null)
                {
                    ListView.Invoke(new MethodInvoker(ExpandParents));
                }
                else
                {
                    ExpandParents();
                }
                if (TreeListView != null)
                {
                    TreeListView.EndUpdate();
                }
            }
            base.EnsureVisible();
        }

        internal void ExpandParents()
        {
            if (Parent != null)
            {
                if (!Parent.IsExpanded)
                {
                    Parent.ExpandInternal();
                }
                Parent.ExpandParents();
            }
        }

        /// <summary>
        /// Set the indentation using the level of this item
        /// </summary>
        /// <returns>True if successfull, false otherwise</returns>
        public bool SetIndentation()
        {
            if (!IsInATreeListView) return false;
            bool res = true;
            LV_ITEM lvi = new LV_ITEM();
            lvi.iItem = Index;
            lvi.iIndent = Level;
            if (TreeListView.ShowPlusMinus) lvi.iIndent++;
            lvi.mask = ListViewItemFlags.INDENT;
            try
            {
                SendMessage(ListView.Handle, ListViewMessages.SETITEM, 0, ref lvi);
            }
            catch
            {
                res = false;
            }
            return res;
        }

        /// <summary>
        /// Refresh indentation of this item and of its children (recursively)
        /// </summary>
        /// <param name="recursively">Recursively</param>
        public void RefreshIndentation(bool recursively)
        {
            if (ListView == null) return;
            if (ListView.InvokeRequired)
            {
                throw new Exception("Invoke Required");
            }
            if (!this.Visible) return;
            SetIndentation();
            if (recursively)
            {
                try
                {
                    foreach (TreeListViewItem item in this.Items)
                    {
                        item.RefreshIndentation(true);
                    }
                }
                catch { }
            }
        }

        public void Expand()
        {
            if (IsInATreeListView)
            {
                if (ListView.InvokeRequired)
                {
                    throw new Exception("Invoke Required");
                }
            }

            if (TreeListView != null) TreeListView.BeginUpdate();
            ExpandInternal();
            if (TreeListView != null) TreeListView.EndUpdate();
        }

        internal void ExpandInternal()
        {
            if (IsInATreeListView)
            {
                if (ListView.InvokeRequired)
                {
                    throw new Exception("Invoke Required");
                }
            }

            TreeListViewItem selItem = null;
            if (TreeListView != null)
            {
                selItem = TreeListView.FocusedItem;
            }

            // Must set ListView.checkDirection to CheckDirection.None.
            // Forbid recursively checking.
            CheckDirection oldDirection = CheckDirection.All;
            if (ListView != null)
            {
                oldDirection = this.ListView.CheckDirection;
                ListView.CheckDirection = CheckDirection.None;
            }

            // The item wasn't expanded -> raise an event
            if (Visible && !_IsExpanded && ListView != null)
            {
                TreeListViewCancelEventArgs e = new TreeListViewCancelEventArgs(this, TreeListViewAction.Expand);
                ListView.RaiseBeforeExpand(e);
                if (e.Cancel) return;
            }

            if (Visible)
            {
                for (int i = Items.Count - 1; i >= 0; i--)
                {
                    TreeListViewItem item = this.Items[i];
                    if (!item.Visible)
                    {
                        ListView listView = this.ListView;
                        listView.Items.Insert(this.Index + 1, item);
                        item.SetIndentation();
                    }
                    if (item.IsExpanded) item.Expand();
                }
            }
            // The item wasn't expanded -> raise an event
            if (Visible && !_IsExpanded && IsInATreeListView)
            {
                this._IsExpanded = true;
                TreeListViewEventArgs e = new TreeListViewEventArgs(this, TreeListViewAction.Expand);
                ListView.RaiseAfterExpand(e);
                if (AfterExpand != null)
                {
                    AfterExpand(this);
                }
            }
            this._IsExpanded = true;

            // Reset ListView.checkDirection
            if (IsInATreeListView)
            {
                ListView.CheckDirection = oldDirection;
            }
            if (TreeListView != null && selItem != null)
            {
                if (selItem.Visible)
                {
                    selItem.Focused = true;
                }
            }
        }

        public void ExpandAll()
        {
            if (IsInATreeListView)
            {
                if (ListView.InvokeRequired)
                {
                    throw (new Exception("Invoke Required"));
                }
            }
            if (TreeListView != null) TreeListView.BeginUpdate();
            ExpandAllInternal();
            if (TreeListView != null) TreeListView.EndUpdate();
        }

        internal void ExpandAllInternal()
        {
            if (IsInATreeListView)
            {
                if (ListView.InvokeRequired)
                {
                    throw new Exception("Invoke Required");
                }
            }
            ExpandInternal();
            // Expand canceled -> stop expandall for the children of this item
            if (!IsExpanded) return;
            for (int i = 0; i < Items.Count; i++)
            {
                Items[i].ExpandAllInternal();
            }
        }

        public void Collapse()
        {
            if (IsInATreeListView)
            {
                if (ListView.InvokeRequired)
                {
                    throw new Exception("Invoke Required");
                }
            }
            if (TreeListView != null) TreeListView.BeginUpdate();
            CollapseInternal();
            if (TreeListView != null) TreeListView.EndUpdate();
        }

        internal void CollapseInternal()
        {
            if (IsInATreeListView)
            {
                if (ListView.InvokeRequired)
                {
                    throw new Exception("Invoke Required");
                }
            }
            TreeListViewItem selItem = null;
            if (TreeListView != null) selItem = TreeListView.FocusedItem;
            // The item was expanded -> raise an event
            if (Visible && _IsExpanded && ListView != null)
            {
                TreeListViewCancelEventArgs e = new TreeListViewCancelEventArgs(this, TreeListViewAction.Collapse);
                ListView.RaiseBeforeCollapse(e);
                if (e.Cancel) return;
            }

            // Collapse
            if (this.Visible)
            {
                foreach (TreeListViewItem item in Items)
                {
                    item.Hide();
                }
            }

            // The item was expanded -> raise an event
            if (Visible && _IsExpanded && IsInATreeListView)
            {
                this._IsExpanded = false;
                TreeListViewEventArgs e = new TreeListViewEventArgs(this, TreeListViewAction.Collapse);
                ListView.RaiseAfterCollapse(e);
                if (AfterCollapse != null) AfterCollapse(this);
            }
            this._IsExpanded = false;
            if (IsInATreeListView && selItem != null)
            {
                if (selItem.Visible)
                    selItem.Focused = true;
                else
                {
                    ListView listview = (ListView)TreeListView;
                    listview.SelectedItems.Clear();
                    TreeListViewItem[] items = selItem.ParentsInHierarch;
                    for (int i = items.Length - 1; i >= 0; i--)
                    {
                        if (items[i].Visible)
                        {
                            items[i].Focused = true;
                            break;
                        }
                    }
                }
            }
        }

        public void CollapseAll()
        {
            if (IsInATreeListView)
            {
                if (ListView.InvokeRequired)
                {
                    throw new Exception("Invoke Required");
                }
            }
            if (TreeListView != null) TreeListView.BeginUpdate();
            CollapseAllInternal();
            if (TreeListView != null) TreeListView.EndUpdate();
        }

        internal void CollapseAllInternal()
        {
            if (IsInATreeListView)
            {
                if (ListView.InvokeRequired)
                {
                    throw new Exception("Invoke Required");
                }
            }
            foreach (TreeListViewItem item in this.Items)
            {
                item.CollapseAllInternal();
            }
            CollapseInternal();
        }

        /// <summary>
        /// Hide this node (remove from TreeListView but
        /// not from associated Parent items)
        /// </summary>
        internal void Hide()
        {
            if (IsInATreeListView)
            {
                if (ListView.InvokeRequired)
                {
                    throw new Exception("Invoke Required");
                }
            }
            foreach (TreeListViewItem item in Items)
            {
                item.Hide();
            }
            if (Visible)
            {
                base.Remove();
            }
            Selected = false;
        }

        internal void DrawPlusMinus()
        {
            if (!IsInATreeListView) return;
            if (TreeListView._Updating) return;
            using (Graphics g = Graphics.FromHwnd(TreeListView.Handle))
            {
                DrawPlusMinus(g);
            }
        }

        internal void DrawPlusMinus(Graphics g)
        {
            if (!IsInATreeListView) return;
            if (TreeListView._Updating) return;
            if (Items.Count == 0 || TreeListView.Columns.Count == 0) return;

            using (ImageAttributes attr = new ImageAttributes())
            {
                attr.SetColorKey(Color.Transparent, Color.Transparent);
                if (TreeListView.Columns[0].Width > (Level + 1) * SystemInformation.SmallIconSize.Width)
                {
                    g.DrawImage(
                        IsExpanded ?Properties.Resources.Collapse1:Properties.Resources.Expand1,
                        GetBounds(TreeListViewItemBoundsPortion.PlusMinus),
                        0,
                        0,
                        SystemInformation.SmallIconSize.Width,
                        SystemInformation.SmallIconSize.Height,
                        GraphicsUnit.Pixel,
                        attr);
                }
            }
        }

        internal void DrawPlusMinusLines()
        {
            if (!IsInATreeListView) return;
            if (TreeListView._Updating) return;
            using (Graphics g = Graphics.FromHwnd(TreeListView.Handle))
            {
                DrawPlusMinusLines(g);
            }
        }

        internal void DrawPlusMinusLines(Graphics g)
        {
            if (!IsInATreeListView) return;
            if (TreeListView._Updating) return;
            if (!TreeListView.ShowPlusMinus || TreeListView.Columns.Count == 0) return;

            int itemLevel = Level;
            Rectangle plusminusRect = GetBounds(TreeListViewItemBoundsPortion.PlusMinus);
            Rectangle entireRect = GetBounds(TreeListViewItemBoundsPortion.Entire);
            using (HatchBrush hb = new HatchBrush(HatchStyle.Percent50, this.TreeListView.PlusMinusLineColor, BackColor))
            using (Pen pen = new Pen(hb))
            {
                #region Vertical line

                Point point1 = new Point(plusminusRect.Right - SystemInformation.SmallIconSize.Width / 2 - 1, entireRect.Top);
                Point point2 = new Point(point1.X, entireRect.Bottom);
                // If ListView has no items that have the same level before this item
                if (!HasLevelBeforeItem(itemLevel)) point1.Y += SystemInformation.SmallIconSize.Height / 2;
                // If ListView has no items that have the same level after this item
                if (!HasLevelAfterItem(itemLevel)) point2.Y -= SystemInformation.SmallIconSize.Height / 2 + 1;
                if (TreeListView.Columns[0].Width > (Level + 1) * SystemInformation.SmallIconSize.Width)
                {
                    g.DrawLine(pen, point1, point2);
                }

                #endregion

                #region Horizontal line

                point1 = new Point(plusminusRect.Right - SystemInformation.SmallIconSize.Width / 2 - 1,
                    GetBounds(TreeListViewItemBoundsPortion.Entire).Top + SystemInformation.SmallIconSize.Height / 2);
                point2 = new Point(plusminusRect.Right + 1, point1.Y);
                if (TreeListView.Columns[0].Width > (Level + 1) * SystemInformation.SmallIconSize.Width)
                {
                    g.DrawLine(pen, point1, point2);
                }

                #endregion

                #region Lower Level lines

                for (int level = Level - 1; level > -1; level--)
                {
                    if (HasLevelAfterItem(level))
                    {
                        point1 = new Point(SystemInformation.SmallIconSize.Width * (2 * level + 1) / 2 + entireRect.X, entireRect.Top);
                        point2 = new Point(point1.X, entireRect.Bottom);
                        if (TreeListView.Columns[0].Width > (level + 1) * SystemInformation.SmallIconSize.Width)
                        {
                            g.DrawLine(pen, point1, point2);
                        }
                    }
                }

                #endregion
            }
        }

        internal bool HasLevelAfterItem(int level)
        {
            if (TreeListView == null) return false;
            int lev = Level, tempLevel;
            ListView listview = (ListView)TreeListView;
            for (int i = Index + 1; i < listview.Items.Count; i++)
            {
                tempLevel = ((TreeListViewItem)listview.Items[i]).Level;
                if (tempLevel == level) return true;
                if (tempLevel < level) return false;
            }
            return false;
        }

        internal bool HasLevelBeforeItem(int level)
        {
            if (TreeListView == null) return false;
            Debug.Assert(!TreeListView.InvokeRequired);
            int lev = Level, tempLevel;
            ListView listview = (ListView)TreeListView;
            for (int i = Index - 1; i > -1; i--)
            {
                tempLevel = ((TreeListViewItem)listview.Items[i]).Level;
                if (tempLevel <= level) return true;
            }
            return false;
        }

        internal void DrawFocusCues()
        {
            if (!IsInATreeListView) return;
            if (TreeListView._Updating) return;
            if (TreeListView.HideSelection && !TreeListView.Focused) return;

            Graphics g = Graphics.FromHwnd(TreeListView.Handle);
            if (Visible)
            {
                Rectangle entireitemrect = GetBounds(ItemBoundsPortion.Entire);
                if (entireitemrect.Bottom > entireitemrect.Height * 1.5f)
                {
                    Rectangle labelItemRect = GetBounds(ItemBoundsPortion.Label);
                    Rectangle itemOnlyRect = GetBounds(ItemBoundsPortion.ItemOnly);
                    Rectangle selectedItemRect = new Rectangle(
                        labelItemRect.Left,
                        labelItemRect.Top,
                        TreeListView.FullRowSelect ? entireitemrect.Width - labelItemRect.Left - 1 : itemOnlyRect.Width - SystemInformation.SmallIconSize.Width - 1,
                        labelItemRect.Height - 1);
                    Pen pen = new Pen(TreeListView.Focused && Selected ? Color.Blue : ColorUtil.CalculateColor(System.Drawing.SystemColors.Highlight, System.Drawing.SystemColors.Window, 130));
                    for (int i = 1; i < TreeListView.Columns.Count; i++)
                    {
                        Rectangle rect = TreeListView.GetSubItemRect(Index, i);
                        if (rect.X < selectedItemRect.X)
                        {
                            selectedItemRect = new Rectangle(
                                rect.X,
                                selectedItemRect.Y,
                                selectedItemRect.Width + (selectedItemRect.X - rect.X),
                                selectedItemRect.Height);
                        }
                    }
                    g.DrawRectangle(new Pen(ColorUtil.VSNetSelectionColor), selectedItemRect);
                    // Fill the item (in CommCtl V6, the selection area is not always the same :
                    // label only or first column). I decided to always draw the entire column...
                    if (!TreeListView.FullRowSelect)
                    {
                        g.FillRectangle(new SolidBrush(BackColor),
                            itemOnlyRect.Right - 1,
                            itemOnlyRect.Top,
                            labelItemRect.Width - itemOnlyRect.Width + SystemInformation.SmallIconSize.Width + 1,
                            selectedItemRect.Height + 1);
                    }
                    bool draw = true;
                    if (PrevVisibleItem != null)
                    {
                        if (PrevVisibleItem.Selected)
                        {
                            draw = false;
                        }
                    }
                    // Draw upper line if previous item is not selected
                    if (draw)
                    {
                        g.DrawLine(pen, selectedItemRect.Left, selectedItemRect.Top, selectedItemRect.Right, selectedItemRect.Top);
                    }
                    g.DrawLine(pen, selectedItemRect.Left, selectedItemRect.Top, selectedItemRect.Left, selectedItemRect.Bottom);
                    draw = true;
                    if (NextVisibleItem != null)
                    {
                        if (NextVisibleItem.Selected)
                        {
                            draw = false;
                        }
                    }
                    // Draw lower line if net item is not selected
                    if (draw)
                    {
                        g.DrawLine(pen, selectedItemRect.Left, selectedItemRect.Bottom, selectedItemRect.Right, selectedItemRect.Bottom);
                    }
                    g.DrawLine(pen, selectedItemRect.Right, selectedItemRect.Top, selectedItemRect.Right, selectedItemRect.Bottom);
                    // If FullRowSelect is false and multiselect is enabled, the items don't have the same width
                    if (!TreeListView.FullRowSelect && NextVisibleItem != null)
                    {
                        if (NextVisibleItem.Selected)
                        {
                            int nextItemWidth = NextVisibleItem.GetBounds(TreeListViewItemBoundsPortion.ItemOnly).Width;
                            if (nextItemWidth != itemOnlyRect.Width)
                            {
                                g.DrawLine(
                                    pen,
                                    selectedItemRect.Right,
                                    selectedItemRect.Bottom,
                                    selectedItemRect.Right - (itemOnlyRect.Width - nextItemWidth),
                                    selectedItemRect.Bottom);
                            }
                        }
                    }
                    pen.Dispose();
                }
            }
            g.Dispose();
        }

        internal void DrawIntermediateState()
        {
            if (!IsInATreeListView) return;
            if (TreeListView._Updating) return;
            using (Graphics g = Graphics.FromHwnd(TreeListView.Handle))
            {
                DrawIntermediateState(g);
            }
        }

        internal void DrawIntermediateState(Graphics g)
        {
            if (!IsInATreeListView) return;
            if (TreeListView._Updating) return;
            if (TreeListView.CheckBoxes != CheckBoxesTypes.Recursive || TreeListView.Columns.Count == 0) return;

            if (CheckStatus == CheckState.Indeterminate)
            {
                Rectangle rect = GetBounds(ItemBoundsPortion.Icon);
                Rectangle r = TreeListView._Comctl32Version >= 6 ?
                    new Rectangle(rect.Left - 14, rect.Top + 5, rect.Height - 10, rect.Height - 10) :
                    new Rectangle(rect.Left - 11, rect.Top + 5, rect.Height - 10, rect.Height - 10);
                using (Brush brush = new System.Drawing.Drawing2D.LinearGradientBrush(r, Color.Gray, Color.LightBlue, 45, false))
                {
                    if (TreeListView.Columns[0].Width > (Level + (TreeListView.ShowPlusMinus ? 2 : 1)) * SystemInformation.SmallIconSize.Width)
                    {
                        g.FillRectangle(brush, r);
                    }
                }
            }
        }

        private TreeListViewItemCollection GetParentsInHierarch()
        {
            TreeListViewItemCollection temp = Parent != null ? Parent.GetParentsInHierarch() : new TreeListViewItemCollection();
            if (Parent != null)
            {
                temp.Add(Parent);
            }
            return temp;
        }

        public TreeListViewItem NextVisibleItem
        {
            get
            {
                if (!IsInATreeListView || !Visible) return null;
                ListView listview = (ListView)TreeListView;
                if (Index >= listview.Items.Count - 1) return null;
                return (TreeListViewItem)listview.Items[Index + 1];
            }
        }

        public TreeListViewItem PrevVisibleItem
        {
            get
            {
                if (!IsInATreeListView || !Visible) return null;
                ListView listview = (ListView)TreeListView;
                if (Index < 1) return null;
                return (TreeListViewItem)listview.Items[Index - 1];
            }
        }

        /// <summary>
        /// 获取或设置一个值，该值指示是否选中此项。
        /// </summary>
        public new bool Checked
        {
            get
            {
                try
                {
                    return base.Checked;
                }
                catch
                {
                    return false;
                }
            }
            set
            {
                if (IsInATreeListView)
                {
                    if (TreeListView.InvokeRequired)
                    {
                        throw new Exception("Invoke required");
                    }
                }
                try
                {
                    // Check downwards recursively
                    if (ListView != null && ListView.CheckDirection == CheckDirection.Downwards && _Items.Count > 0)
                    {
                        foreach (TreeListViewItem childItem in _Items)
                        {
                            childItem.Checked = value;
                        }
                    }
                    if (base.Checked == value) return;
                    base.Checked = value;
                }
                catch { }
            }
        }

        /// <summary>
        /// 获取或设置一个值，该值指示选中状态。
        /// </summary>
        public CheckState CheckStatus
        {
            get
            {
                if (_Items.Count <= 0)
                {
                    return this.Checked ? CheckState.Checked : CheckState.Unchecked;
                }
                else
                {
                    bool allChecked = true;
                    bool allUnChecked = true;

                    TreeListViewItem[] items = Items.ToArray();
                    foreach (TreeListViewItem item in items)
                    {
                        if (item.CheckStatus == CheckState.Indeterminate)
                        {
                            return CheckState.Indeterminate;
                        }
                        else if (item.CheckStatus == CheckState.Checked)
                        {
                            allUnChecked = false;
                        }
                        else
                        {
                            allChecked = false;
                        }
                    }
                    if (allChecked)
                    {
                        return CheckState.Checked;
                    }
                    else if (allUnChecked)
                    {
                        return CheckState.Unchecked;
                    }
                    else
                    {
                        return CheckState.Indeterminate;
                    }
                }
            }
        }

        /// <summary>
        /// Gets a collection of the parent of this item
        /// </summary>
        [Browsable(false)]
        public TreeListViewItem[] ParentsInHierarch
        {
            get { return GetParentsInHierarch().ToArray(); }
        }


        /// <summary>
        /// 获取当前项的绝对路径
        /// </summary>
        [Browsable(false)]
        public string FullPath
        {
            get
            {
                if (Parent != null)
                {
                    string pathSeparator = IsInATreeListView ? TreeListView.PathSeparator : "\\";
                    string strPath = Parent.FullPath + pathSeparator + Text;
                    return strPath.Replace(pathSeparator + pathSeparator, pathSeparator);
                }
                return Text;
            }
        }

        /// <summary>
        /// 获取或设置该项的文本。
        /// </summary>
        public new string Text
        {
            get { return base.Text; }
            set
            {
                base.Text = value;
                TreeListViewItemCollection collection = Container;
                if (collection != null)
                {
                    collection.Sort(false);
                }
            }
        }

        /// <summary>
        /// Get the collection that contains this item
        /// </summary>
        public TreeListViewItemCollection Container
        {
            get
            {
                if (Parent != null)
                {
                    return Parent.Items;
                }
                if (IsInATreeListView)
                {
                    return TreeListView.Items;
                }
                return null;
            }
        }

        internal bool IsInATreeListView
        {
            get { return TreeListView != null; }
        }

        /// <summary>
        /// Get the biggest index in the listview of the visible childs of this item
        /// including this item
        /// </summary>
        [Browsable(false)]
        public int LastChildIndexInListView
        {
            get
            {
                if (!IsInATreeListView)
                {
                    throw new Exception("No ListView control");
                }
                int index = this.Index, temp;
                foreach (TreeListViewItem item in Items)
                {
                    if (item.Visible)
                    {
                        temp = item.LastChildIndexInListView;
                        if (temp > index) index = temp;
                    }
                }
                return index;
            }
        }

        /// <summary>
        /// (递归)获取当前项的所有子项的总数
        /// </summary>
        [Browsable(false)]
        public int ChildrenCount
        {
            get
            {
                TreeListViewItem[] items = _Items.ToArray();
                int count = items.Length;
                foreach (TreeListViewItem item in items)
                {
                    count += item.ChildrenCount;
                }
                return count;
            }
        }

        /// <summary>
        /// 获取或设置是否为已展开
        /// </summary>
        public bool IsExpanded
        {
            get
            {
                return _IsExpanded;
            }
            set
            {
                if (_IsExpanded == value) return;
                if (value)
                {
                    Expand();
                }
                else
                {
                    Collapse();
                }
            }
        }

        /// <summary>
        /// 获取item的深度
        /// </summary>
        [Browsable(false)]
        public int Level
        {
            get { return Parent == null ? 0 : Parent.Level + 1; }
        }

        /// <summary>
        /// 获取当前项的父项
        /// </summary>
        public TreeListViewItem Parent
        {
            get { return _Parent; }
        }

        /// <summary>
        /// 获取包含于当前项的子项
        /// </summary>
        public TreeListViewItemCollection Items
        {
            get { return _Items; }
        }

        public new TreeListView ListView
        {
            get
            {
                if (base.ListView != null) return (TreeListView)base.ListView;
                if (Parent != null) return Parent.ListView;
                return null;
            }
        }

        public TreeListView TreeListView
        {
            get { return (TreeListView)ListView; }
        }

        public bool Visible
        {
            get { return base.Index > -1; }
        }

        [DllImport("user32.dll")]
        internal static extern bool SendMessage(IntPtr hWnd, ListViewMessages msg, Int32 wParam, ref LV_ITEM lParam);
    }
}