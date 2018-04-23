Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxGridView

Namespace DynamicShowHidePreview
	Partial Public Class _Default
		Inherits System.Web.UI.Page
		Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
			ASPxGridView1.DataSource = GetData()
			ASPxGridView1.DataBind()
		End Sub

		Private Function GetData() As DataTable
			Dim table As New DataTable()
			table.Columns.Add("ID", GetType(Integer))
			table.Columns.Add("Name", GetType(String))
			table.Columns.Add("Description", GetType(String))
			table.Columns.Add("AdditionalField", GetType(String))
			For i As Integer = 0 To 9
				table.Rows.Add(i, "Item " & i.ToString(), "Description " & i.ToString() & " - long text memo in this field is displayed in the preview pane.", "An additional field " & i.ToString())
			Next i
			Return table
		End Function

		Private Const MoreInfoPrefix As String = "MoreInfoForRow_"
		Private Function GetKey(ByVal key As Object) As String
			Return String.Format("{0}{1}", MoreInfoPrefix, key)
		End Function

		Protected Function IsPreviewVisible(ByVal key As Object) As Boolean
			Dim isVisible As Object = Session(GetKey(key))
			Return True.Equals(isVisible)
		End Function

		Protected Function GetShortDescriptionText(ByVal visibleIndex As Integer) As String
			Dim fullDescription As String = CStr(ASPxGridView1.GetRowValues(visibleIndex, "Description"))
			Dim shortDescription As String = fullDescription
			If fullDescription IsNot Nothing AndAlso fullDescription.Length > 15 Then
				shortDescription = fullDescription.Substring(0, 15) & "..."
			End If
			Return shortDescription
		End Function

		Protected Sub btnExpand_Click(ByVal sender As Object, ByVal e As EventArgs)
			Dim btn As ImageButton = CType(sender, ImageButton)
			Dim table As Control = btn.Parent.Parent.Parent ' button -> cell -> row -> table -> template container
			Dim container As GridViewPreviewRowTemplateContainer = CType(table.Parent, GridViewPreviewRowTemplateContainer)
			Dim key As Object = container.KeyValue
			Session(GetKey(key)) = Not IsPreviewVisible(key)
			ASPxGridView1.DataBind()
		End Sub
	End Class
End Namespace
