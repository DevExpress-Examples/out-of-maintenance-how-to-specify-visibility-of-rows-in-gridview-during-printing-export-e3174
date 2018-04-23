Imports Microsoft.VisualBasic
Imports System
Namespace ExportToXlsx
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Dim gridLevelNode1 As New DevExpress.XtraGrid.GridLevelNode()
			Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
			Me.gridControl1 = New DevExpress.XtraGrid.GridControl()
			Me.gridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
			Me.simpleButton1 = New DevExpress.XtraEditors.SimpleButton()
			Me.panelControl1 = New DevExpress.XtraEditors.PanelControl()
			Me.cb_MasterDetail = New DevExpress.XtraEditors.CheckButton()
			Me.cb_NonBlank = New DevExpress.XtraEditors.CheckButton()
			Me.cb_MasterOnly = New DevExpress.XtraEditors.CheckButton()
			CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.gridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.gridView1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.panelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.panelControl1.SuspendLayout()
			Me.SuspendLayout()
			' 
			' GridView2
			' 
			Me.GridView2.GridControl = Me.gridControl1
			Me.GridView2.Name = "GridView2"
			' 
			' gridControl1
			' 
			Me.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill
			gridLevelNode1.LevelTemplate = Me.GridView2
			gridLevelNode1.RelationName = "Children"
			Me.gridControl1.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() { gridLevelNode1})
			Me.gridControl1.Location = New System.Drawing.Point(0, 62)
			Me.gridControl1.MainView = Me.gridView1
			Me.gridControl1.Name = "gridControl1"
			Me.gridControl1.ShowOnlyPredefinedDetails = True
			Me.gridControl1.Size = New System.Drawing.Size(426, 316)
			Me.gridControl1.TabIndex = 2
			Me.gridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() { Me.gridView1, Me.GridView2})
			' 
			' gridView1
			' 
			Me.gridView1.GridControl = Me.gridControl1
			Me.gridView1.Name = "gridView1"
			Me.gridView1.OptionsPrint.PrintDetails = True
			' 
			' simpleButton1
			' 
			Me.simpleButton1.Dock = System.Windows.Forms.DockStyle.Left
			Me.simpleButton1.Location = New System.Drawing.Point(2, 2)
			Me.simpleButton1.Name = "simpleButton1"
			Me.simpleButton1.Size = New System.Drawing.Size(84, 58)
			Me.simpleButton1.TabIndex = 1
			Me.simpleButton1.Text = "Export ot xlsx"
'			Me.simpleButton1.Click += New System.EventHandler(Me.simpleButton1_Click);
			' 
			' panelControl1
			' 
			Me.panelControl1.Controls.Add(Me.cb_MasterDetail)
			Me.panelControl1.Controls.Add(Me.cb_NonBlank)
			Me.panelControl1.Controls.Add(Me.cb_MasterOnly)
			Me.panelControl1.Controls.Add(Me.simpleButton1)
			Me.panelControl1.Dock = System.Windows.Forms.DockStyle.Top
			Me.panelControl1.Location = New System.Drawing.Point(0, 0)
			Me.panelControl1.Name = "panelControl1"
			Me.panelControl1.Size = New System.Drawing.Size(426, 62)
			Me.panelControl1.TabIndex = 3
			' 
			' cb_MasterDetail
			' 
			Me.cb_MasterDetail.Location = New System.Drawing.Point(220, 5)
			Me.cb_MasterDetail.Name = "cb_MasterDetail"
			Me.cb_MasterDetail.Size = New System.Drawing.Size(142, 23)
			Me.cb_MasterDetail.TabIndex = 4
			Me.cb_MasterDetail.Text = "All Master and Detail Rows"
'			Me.cb_MasterDetail.CheckedChanged += New System.EventHandler(Me.cb_MasterDetail_CheckedChanged);
			' 
			' cb_NonBlank
			' 
			Me.cb_NonBlank.Location = New System.Drawing.Point(92, 34)
			Me.cb_NonBlank.Name = "cb_NonBlank"
			Me.cb_NonBlank.Size = New System.Drawing.Size(122, 23)
			Me.cb_NonBlank.TabIndex = 3
			Me.cb_NonBlank.Text = "Non Blank Rows Only"
'			Me.cb_NonBlank.CheckedChanged += New System.EventHandler(Me.cb_NonBlank_CheckedChanged);
			' 
			' cb_MasterOnly
			' 
			Me.cb_MasterOnly.Location = New System.Drawing.Point(92, 5)
			Me.cb_MasterOnly.Name = "cb_MasterOnly"
			Me.cb_MasterOnly.Size = New System.Drawing.Size(122, 23)
			Me.cb_MasterOnly.TabIndex = 2
			Me.cb_MasterOnly.Text = "Master Rows Only"
'			Me.cb_MasterOnly.CheckedChanged += New System.EventHandler(Me.cb_MasterOnly_CheckedChanged);
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(426, 378)
			Me.Controls.Add(Me.gridControl1)
			Me.Controls.Add(Me.panelControl1)
			Me.Name = "Form1"
			Me.Text = "Form1"
			CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.gridControl1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.gridView1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.panelControl1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.panelControl1.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private WithEvents simpleButton1 As DevExpress.XtraEditors.SimpleButton
		Private gridControl1 As DevExpress.XtraGrid.GridControl
		Friend GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
		Private gridView1 As DevExpress.XtraGrid.Views.Grid.GridView
		Private panelControl1 As DevExpress.XtraEditors.PanelControl
		Private WithEvents cb_NonBlank As DevExpress.XtraEditors.CheckButton
		Private WithEvents cb_MasterOnly As DevExpress.XtraEditors.CheckButton
		Private WithEvents cb_MasterDetail As DevExpress.XtraEditors.CheckButton
	End Class
End Namespace

