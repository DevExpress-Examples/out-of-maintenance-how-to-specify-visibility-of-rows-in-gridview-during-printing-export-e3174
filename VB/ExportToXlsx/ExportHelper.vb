Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Base
Imports System.IO
Imports DevExpress.XtraPrinting

Namespace ExportToXlsx
	Friend Class ExportHelper
		Private grid As GridControl
		Private view As GridView
		Private handler As RowFilterEventHandler
		Private ExpandStates As Dictionary(Of Integer, Boolean)
		Private LayoutStream As MemoryStream
		Private focusedRow As Integer

		Private _masterOnly As Boolean
		Private _masterAndDetail As Boolean
		Private _nonBlank As Boolean


		Public Property MasterOnly() As Boolean
			Get
				Return _masterOnly
			End Get
			Set(ByVal value As Boolean)
				_masterOnly = value
				If _masterOnly = True Then
					 _masterAndDetail= False
				End If

			End Set
		End Property
		Public Property MasterAndDetail() As Boolean
			Get
				Return _masterAndDetail
			End Get
			Set(ByVal value As Boolean)
				_masterAndDetail = value
				If _masterAndDetail = True Then
					_masterOnly = False
				End If
			End Set
		End Property
		Public Property NonBlank() As Boolean
			Get
				Return _nonBlank
			End Get
			Set(ByVal value As Boolean)
				_nonBlank = value
			End Set
		End Property


		Public Sub New(ByVal grid As GridControl)
			Me.grid = grid
			Me.view = TryCast(grid.MainView, GridView)
			Me.MasterOnly = False
			Me.MasterAndDetail = False
			Me.NonBlank = False
		End Sub

		Public Sub ExportToXlsx(ByVal stream As Stream)
			BeforeExport()
			grid.ExportToXlsx(stream)
			AfterExport()
		End Sub
		Public Sub ExportToXlsx(ByVal filePath As String)
			BeforeExport()
			grid.ExportToXlsx(filePath)
			AfterExport()
		End Sub
		Public Sub ExportToXlsx(ByVal stream As Stream, ByVal options As XlsxExportOptions)
			BeforeExport()
			grid.ExportToXlsx(stream, options)
			AfterExport()
		End Sub
		Public Sub ExportToXlsx(ByVal filePath As String, ByVal options As XlsxExportOptions)
			BeforeExport()
			grid.ExportToXlsx(filePath, options)
			AfterExport()
		End Sub

		Private Sub SaveAllExpandState()
			ExpandStates = New Dictionary(Of Integer, Boolean)()
			For i As Integer = view.DataRowCount - 1 To 0 Step -1
				ExpandStates.Add(i, view.GetMasterRowExpanded(i))
			Next i
		End Sub
		Private Sub SetAllExpandState(ByVal expandState As Boolean)
			For i As Integer = view.DataRowCount - 1 To 0 Step -1
				view.SetMasterRowExpanded(i, expandState)
			Next i
		End Sub

		Private Sub LoadAllExpandState()
			For Each rec As KeyValuePair(Of Integer, Boolean) In ExpandStates
				view.SetMasterRowExpanded(rec.Key, rec.Value)
			Next rec
		End Sub

		Public Sub BeforeExport()
			focusedRow = view.FocusedRowHandle
			If view.GroupCount > 0 Then
				LayoutStream = New MemoryStream()
				view.SaveLayoutToStream(LayoutStream)
			End If
			If MasterOnly OrElse NonBlank OrElse MasterAndDetail OrElse view.GroupCount > 0 Then
				SaveAllExpandState()
			End If
			If MasterOnly Then
				SetAllExpandState(False)
			End If
			If MasterAndDetail Then
				SetAllExpandState(True)
			End If
			If NonBlank Then
				handler = New DevExpress.XtraGrid.Views.Base.RowFilterEventHandler(AddressOf view_CustomRowFilter)
				AddHandler view.CustomRowFilter, handler
				view.RefreshData()
			End If

		End Sub
		Public Sub AfterExport()
			If NonBlank Then
				RemoveHandler view.CustomRowFilter, handler
				view.RefreshData()
			End If
			If view.GroupCount > 0 Then
				LayoutStream.Seek(0, SeekOrigin.Begin)
				view.RestoreLayoutFromStream(LayoutStream)
			End If
			If MasterOnly OrElse NonBlank OrElse MasterAndDetail OrElse view.GroupCount > 0 Then
				LoadAllExpandState()
			End If
			view.FocusedRowHandle = focusedRow
		End Sub
		Private Sub view_CustomRowFilter(ByVal sender As Object, ByVal e As RowFilterEventArgs)
			Dim view As GridView = TryCast(sender, GridView)
			If view.IsMasterRowEmpty(e.ListSourceRow) Then
				e.Visible = False
			Else
				Dim expandState As Boolean = view.GetMasterRowExpanded(e.ListSourceRow)
				If (Not expandState) Then
					view.SetMasterRowExpanded(e.ListSourceRow, True)
				End If
				Dim childView As ColumnView = CType(view.GetDetailView(e.ListSourceRow, 0), ColumnView)
				If childView IsNot Nothing Then
					If childView.DataRowCount = 0 Then
						e.Visible = False
					End If
				End If
				view.SetMasterRowExpanded(e.ListSourceRow, expandState)
			End If
			e.Handled = True
		End Sub
	End Class
End Namespace
