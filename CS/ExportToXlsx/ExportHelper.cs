using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;
using System.IO;
using DevExpress.XtraPrinting;

namespace ExportToXlsx
{
    class ExportHelper
    {
        GridControl grid;
        GridView view;
        RowFilterEventHandler handler;
        Dictionary<int, bool> ExpandStates;
        MemoryStream LayoutStream;
        int focusedRow;

        bool _masterOnly;
        bool _masterAndDetail;
        bool _nonBlank;


        public bool MasterOnly
        {
            get { return _masterOnly;}
            set 
            { 
                _masterOnly = value;
                if (_masterOnly == true)
                     _masterAndDetail= false;

            }
        }
        public bool MasterAndDetail
        {
            get { return _masterAndDetail;}
            set 
            { 
                _masterAndDetail = value;
                if (_masterAndDetail == true)
                    _masterOnly = false;
            }
        }
        public bool NonBlank
        {
            get { return _nonBlank;}
            set { _nonBlank = value;}
        }


        public ExportHelper(GridControl grid)
        {
            this.grid = grid;
            this.view = grid.MainView as GridView;
            this.MasterOnly = false;
            this.MasterAndDetail = false;
            this.NonBlank = false;
        }

        public void ExportToXlsx(Stream stream)
        {
            BeforeExport();
            grid.ExportToXlsx(stream);
            AfterExport();
        }
        public void ExportToXlsx(string filePath)
        {
            BeforeExport();
            grid.ExportToXlsx(filePath);
            AfterExport();
        }
        public void ExportToXlsx(Stream stream, XlsxExportOptions options)
        {
            BeforeExport();
            grid.ExportToXlsx(stream, options);
            AfterExport();
        }
        public void ExportToXlsx(string filePath, XlsxExportOptions options)
        {
            BeforeExport();
            grid.ExportToXlsx(filePath, options);
            AfterExport();
        }

        void SaveAllExpandState()
        {
            ExpandStates = new Dictionary<int, bool>();
            for (int i = view.DataRowCount - 1; i >= 0; i--)
                ExpandStates.Add(i, view.GetMasterRowExpanded(i));
        }
        void SetAllExpandState(bool expandState)
        {
            for (int i = view.DataRowCount - 1; i >= 0; i--)
                view.SetMasterRowExpanded(i, expandState);
        }

        void LoadAllExpandState()
        {
            foreach (KeyValuePair<int, bool> rec in ExpandStates)
                view.SetMasterRowExpanded(rec.Key, rec.Value);
        }

        public void BeforeExport()
        {
            focusedRow = view.FocusedRowHandle;
            if (view.GroupCount > 0)
            {
                LayoutStream = new MemoryStream();
                view.SaveLayoutToStream(LayoutStream);
            }
            if (MasterOnly || NonBlank || MasterAndDetail || view.GroupCount > 0)
                SaveAllExpandState();
            if (MasterOnly)
                SetAllExpandState(false);
            if (MasterAndDetail)
                SetAllExpandState(true);
            if (NonBlank)
            {
                handler = new DevExpress.XtraGrid.Views.Base.RowFilterEventHandler(view_CustomRowFilter);
                view.CustomRowFilter += handler;
                view.RefreshData();
            }

        }
        public void AfterExport()
        {
            if (NonBlank)
            {
                view.CustomRowFilter -= handler;
                view.RefreshData();
            }
            if (view.GroupCount > 0)
            {
                LayoutStream.Seek(0, SeekOrigin.Begin);
                view.RestoreLayoutFromStream(LayoutStream);
            }
            if (MasterOnly || NonBlank || MasterAndDetail || view.GroupCount > 0)
                LoadAllExpandState();
            view.FocusedRowHandle = focusedRow;
        }
        void view_CustomRowFilter(object sender, RowFilterEventArgs e)
        {
            GridView view = sender as GridView;
            if (view.IsMasterRowEmpty(e.ListSourceRow))
                e.Visible = false;
            else
            {
                bool expandState = view.GetMasterRowExpanded(e.ListSourceRow);
                if (!expandState)
                    view.SetMasterRowExpanded(e.ListSourceRow, true);
                ColumnView childView = (ColumnView)view.GetDetailView(e.ListSourceRow, 0);
                if (childView != null)
                    if (childView.DataRowCount == 0)
                        e.Visible = false;
                view.SetMasterRowExpanded(e.ListSourceRow, expandState);
            }
            e.Handled = true;
        }
    }
}
