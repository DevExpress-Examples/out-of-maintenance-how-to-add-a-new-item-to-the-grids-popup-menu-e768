Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Namespace WindowsApplication3
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			Dim v As New DevExpress.XtraGrid.Design.XViewsPrinting(gridControl1)
			gridView1.OptionsView.ShowFooter = True
		End Sub

		Private Sub gridView1_ShowGridMenu(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.GridMenuEventArgs) Handles gridView1.ShowGridMenu
			If e.MenuType <> DevExpress.XtraGrid.Views.Grid.GridMenuType.Summary Then
				Return
			End If
			Dim footerMenu As DevExpress.XtraGrid.Menu.GridViewFooterMenu = TryCast(e.Menu, DevExpress.XtraGrid.Menu.GridViewFooterMenu)
			Dim menuItem As New DevExpress.Utils.Menu.DXMenuItem("MyItem", New EventHandler(AddressOf MyMenuItem))
			menuItem.Tag = e.Menu
			footerMenu.Items.Add(menuItem)
		End Sub
		Private Sub MyMenuItem(ByVal sender As Object, ByVal e As EventArgs)
			Dim Item As DevExpress.Utils.Menu.DXMenuItem= TryCast(sender, DevExpress.Utils.Menu.DXMenuItem)
			Dim menu As DevExpress.XtraGrid.Menu.GridViewFooterMenu = TryCast(Item.Tag, DevExpress.XtraGrid.Menu.GridViewFooterMenu)
			MessageBox.Show(menu.View.FocusedColumn.FieldName)
		End Sub

	End Class
End Namespace