Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports DevExpress.XtraEditors.ViewInfo
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraEditors.Drawing
Imports DevExpress.LookAndFeel

Namespace MonthRangeTrackBar
	Friend Class MonthRangeTrackBarViewInfo
		Inherits RangeTrackBarViewInfo
		Public Sub New(ByVal item As RepositoryItem)
			MyBase.New(item)
		End Sub
		Public ReadOnly Property RepositoryItem() As RepositoryItemMonthRangeTrackBar
			Get
				Return TryCast(Me.Item, RepositoryItemMonthRangeTrackBar)
			End Get
		End Property

		Public Overrides Function GetTrackPainter() As DevExpress.XtraEditors.Drawing.TrackBarObjectPainter
			'if (IsPrinting)
			'    return new RangeTrackBarObjectPainter();
			'if (this.LookAndFeel.ActiveStyle == ActiveLookAndFeelStyle.WindowsXP)
			'    return new RangeTrackBarObjectPainter();
			'if (this.LookAndFeel.ActiveStyle == ActiveLookAndFeelStyle.Skin)
			Return New SkinMonthRangeTrackBarObjectPainter(LookAndFeel.ActiveLookAndFeel)
			'if (this.LookAndFeel.ActiveStyle == ActiveLookAndFeelStyle.Office2003)
			'    return new Office2003RangeTrackBarObjectPainter();
			'return new RangeTrackBarObjectPainter();
		End Function

		Protected Overrides Sub CalcTrackLineRect()
			MyBase.CalcTrackLineRect()
		End Sub
	End Class
End Namespace
