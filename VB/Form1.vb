Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraEditors.Repository

Namespace MonthSliderExample
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub simpleButton1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles simpleButton1.Click
			Text = monthRangeTrackBar1.MonthRangeValue.ToString()
		End Sub

		Private Sub dateEdit1_EditValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles dateEdit1.EditValueChanged
			monthRangeTrackBar1.Properties.InitialDateValue = CDate(dateEdit1.EditValue)
		End Sub
	End Class
End Namespace
