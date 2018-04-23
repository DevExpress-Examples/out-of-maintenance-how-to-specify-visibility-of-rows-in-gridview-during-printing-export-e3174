Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.Diagnostics
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting
Imports System.IO
Imports DevExpress.XtraGrid

Namespace ExportToXlsx
	Partial Public Class Form1
		Inherits Form
		Private eh As ExportHelper
		Public Sub New()
			InitializeComponent()
			Dim list As New BindingList(Of Parent)()
			list.Add(New Parent(0, "Parent1"))
			list(0).Children.Add(New Child(Guid.NewGuid().ToString(), "Data"))
			list(0).Children.Add(New Child(Guid.NewGuid().ToString(), "Data1"))
			list.Add(New Parent(1, "Parent2"))
			list.Add(New Parent(2, "Parent3"))
			list(2).Children.Add(New Child(Guid.NewGuid().ToString(), "Data2"))
			list(2).Children.Add(New Child(Guid.NewGuid().ToString(), "Data3"))
			gridControl1.DataSource = list
			eh = New ExportHelper(gridControl1)
		End Sub

		Private Sub simpleButton1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles simpleButton1.Click
			eh.ExportToXlsx("test.xlsx")
			Process.Start("test.xlsx")
		End Sub

		Private Sub cb_MasterDetail_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cb_MasterDetail.CheckedChanged
			If cb_MasterDetail.Checked Then
				cb_MasterOnly.Checked = False
			End If
			eh.MasterAndDetail = cb_MasterDetail.Checked
		End Sub

		Private Sub cb_MasterOnly_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cb_MasterOnly.CheckedChanged
			If cb_MasterOnly.Checked Then
				cb_MasterDetail.Checked = False
			End If
			eh.MasterOnly = cb_MasterOnly.Checked
		End Sub

		Private Sub cb_NonBlank_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cb_NonBlank.CheckedChanged
			eh.NonBlank = cb_NonBlank.Checked
		End Sub

	End Class
	Public Class Parent
		Private _Id As Integer
		Public Property Id() As Integer
			Get
				Return _Id
			End Get
			Set(ByVal value As Integer)
				_Id = value
			End Set
		End Property

		Private _Name As String
		Public Property Name() As String
			Get
				Return _Name
			End Get
			Set(ByVal value As String)
				_Name = value
			End Set
		End Property

		Private _Children As BindingList(Of Child)
		Public ReadOnly Property Children() As BindingList(Of Child)
			Get
				Return _Children
			End Get
		End Property

		Public Sub New(ByVal id As Integer, ByVal name As String)
			_Id = id
			_Name = name
			_Children = New BindingList(Of Child)()
		End Sub
	End Class
	Public Class Child
		Public Sub New(ByVal iD As String, ByVal data As String)
			_ID = iD
			_Data = data
		End Sub

		Private _ID As String
		Public Property ID() As String
			Get
				Return _ID
			End Get
			Set(ByVal value As String)
				_ID = value
			End Set
		End Property

		Private _Data As String
		Public Property Data() As String
			Get
				Return _Data
			End Get
			Set(ByVal value As String)
				_Data = value
			End Set
		End Property
	End Class
End Namespace
