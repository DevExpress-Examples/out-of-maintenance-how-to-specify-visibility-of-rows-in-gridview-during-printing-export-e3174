using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using System.IO;
using DevExpress.XtraGrid;

namespace ExportToXlsx
{
    public partial class Form1 : Form
    {
        ExportHelper eh;
        public Form1()
        {
            InitializeComponent();
            BindingList<Parent> list = new BindingList<Parent>();
            list.Add(new Parent(0, "Parent1"));
            list[0].Children.Add(new Child(Guid.NewGuid().ToString(), "Data"));
            list[0].Children.Add(new Child(Guid.NewGuid().ToString(), "Data1"));
            list.Add(new Parent(1, "Parent2"));
            list.Add(new Parent(2, "Parent3"));
            list[2].Children.Add(new Child(Guid.NewGuid().ToString(), "Data2"));
            list[2].Children.Add(new Child(Guid.NewGuid().ToString(), "Data3"));
            gridControl1.DataSource = list;
            eh = new ExportHelper(gridControl1);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            eh.ExportToXlsx("test.xlsx");
            Process.Start("test.xlsx");
        }

        private void cb_MasterDetail_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_MasterDetail.Checked)
                cb_MasterOnly.Checked = false;
            eh.MasterAndDetail = cb_MasterDetail.Checked;
        }

        private void cb_MasterOnly_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_MasterOnly.Checked)
                cb_MasterDetail.Checked = false;
            eh.MasterOnly = cb_MasterOnly.Checked;
        }

        private void cb_NonBlank_CheckedChanged(object sender, EventArgs e)
        {
            eh.NonBlank = cb_NonBlank.Checked;
        }

    }
    public class Parent
    {
        int _Id;
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        string _Name;
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        BindingList<Child> _Children;
        public BindingList<Child> Children
        { get { return _Children; } }

        public Parent(int id, string name)
        {
            _Id = id;
            _Name = name;
            _Children = new BindingList<Child>();
        }
    }
    public class Child
    {
        public Child(string iD, string data)
        {
            _ID = iD;
            _Data = data;
        }

        string _ID;
        public string ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        string _Data;
        public string Data
        {
            get { return _Data; }
            set { _Data = value; }
        }
    }
}
