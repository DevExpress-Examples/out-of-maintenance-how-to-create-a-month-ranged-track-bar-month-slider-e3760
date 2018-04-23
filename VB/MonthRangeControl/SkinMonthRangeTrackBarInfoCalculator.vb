Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports DevExpress.XtraEditors.ViewInfo
Imports DevExpress.XtraEditors.Drawing
Imports System.Drawing

Namespace MonthRangeTrackBar
	Friend Class SkinMonthRangeTrackBarInfoCalculator
		Inherits SkinRangeTrackBarInfoCalculator
		Public Sub New(ByVal viewInfo As RangeTrackBarViewInfo, ByVal painter As RangeTrackBarObjectPainter)
			MyBase.New(viewInfo, painter)
		End Sub

		Protected Overrides Function CalcTrackLineRect() As System.Drawing.Rectangle
			Dim returnedValue As Rectangle = MyBase.CalcTrackLineRect()
			returnedValue.X += 5
			returnedValue.Width -= 10
			Return returnedValue
		End Function

		Protected Overrides Function CalcPointsRect() As Rectangle
			Dim returnedValue As Rectangle = MyBase.CalcPointsRect()
			returnedValue.X += 5
			returnedValue.Width -= 10
			Return returnedValue
		End Function
	End Class
End Namespace
