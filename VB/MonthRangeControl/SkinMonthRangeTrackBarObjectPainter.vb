Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Drawing
Imports DevExpress.XtraEditors.Drawing
Imports DevExpress.Skins
Imports DevExpress.LookAndFeel
Imports DevExpress.XtraEditors.ViewInfo

Namespace MonthRangeTrackBar
	Friend Class SkinMonthRangeTrackBarObjectPainter
		Inherits SkinRangeTrackBarObjectPainter
		Public Sub New(ByVal provider As ISkinProvider)
			MyBase.New(provider)
		End Sub

		Protected Overrides Function GetCalculator(ByVal viewInfo As DevExpress.XtraEditors.ViewInfo.TrackBarViewInfo) As DevExpress.XtraEditors.ViewInfo.TrackBarInfoCalculator
			Return New SkinMonthRangeTrackBarInfoCalculator(TryCast(viewInfo, RangeTrackBarViewInfo), Me)
		End Function

		Public Overrides Overloads Sub DrawPoints(ByVal e As TrackBarObjectInfoArgs, ByVal bMirror As Boolean)
			Dim p1 As Point = Point.Empty, p2 As Point = Point.Empty
			Dim xPos As Single
			Dim tickCount As Integer
			p1.Y = e.ViewInfo.PointsRect.Y
			xPos = 0
			tickCount = 0
			Do While tickCount < e.ViewInfo.TickCount
				p1.X = CInt(Fix(e.ViewInfo.PointsRect.X + xPos + 0.01f))
				p2.X = p1.X
				If tickCount <> 0 AndAlso tickCount <> e.ViewInfo.TickCount - 1 Then
					p2.Y = p1.Y + Math.Max(e.ViewInfo.PointsRect.Height * 3 \ 4, 1)
				Else
					p2.Y = p1.Y + e.ViewInfo.PointsRect.Height
				End If
				DrawLine(e, e.ViewInfo.TrackBarHelper.RotateAndMirror(p1, e.ViewInfo.MirrorPoint.Y, bMirror), e.ViewInfo.TrackBarHelper.RotateAndMirror(p2, e.ViewInfo.MirrorPoint.Y, bMirror))
				DrawTickText(e, p1, tickCount)
				xPos += e.ViewInfo.PointsDelta
				tickCount += 1
			Loop
		End Sub

		Private Shared Sub DrawTickText(ByVal e As TrackBarObjectInfoArgs, ByVal p As Point, ByVal tickCount As Integer)
			Dim vi As MonthRangeTrackBarViewInfo = TryCast(e.ViewInfo, MonthRangeTrackBarViewInfo)

			Dim currentDateValue As New DateTime(vi.RepositoryItem.InitialDateValue.Year, vi.RepositoryItem.InitialDateValue.Month, 1)
			currentDateValue = currentDateValue.AddMonths(tickCount)
			Dim sDisplayText As String = currentDateValue.ToString("MMM").ToUpper() & " " & currentDateValue.Year.ToString()

			' Check if there's enough space to draw the tick values assuming that there should be at least 15 pixels available for drawing
			' the text
			Dim freePixels As Integer = e.Bounds.Y + e.Bounds.Height - (e.ViewInfo.PointsRect.Y + e.ViewInfo.PointsRect.Height)
			If freePixels < 10 Then
				Return
			End If

			Dim textRect As New Rectangle()
			textRect.Y = e.ViewInfo.PointsRect.Y + e.ViewInfo.PointsRect.Height + 3
			textRect.Height = freePixels - 3

			Dim font As New Font(e.Appearance.Font.FontFamily, CType(Math.Min(freePixels - 3, 7), Single), FontStyle.Regular)

			Dim strFormat As StringFormat = e.Appearance.GetStringFormat()
			strFormat.Alignment = StringAlignment.Center

			textRect.X = CInt(Fix(p.X - e.ViewInfo.PointsDelta / 2))
			textRect.Width = CInt(Fix(e.ViewInfo.PointsDelta))

			Dim strSize As SizeF = e.Graphics.MeasureString(sDisplayText, font)
			Dim overlap As Double = strSize.Width \ textRect.Width

			If overlap <= 1 Then
				e.Paint.DrawString(e.Cache, sDisplayText, font, e.Cache.GetSolidBrush(e.Appearance.ForeColor), textRect, strFormat)
			Else
				Dim range As Integer = CInt(Fix(Math.Round(overlap)))
				textRect.Width = CInt(Fix(textRect.Width * overlap))

				Dim tail As Integer = If((e.ViewInfo.TickCount Mod 2 = 0), 0, 1)

				If tickCount Mod range <> tail Then
					e.Paint.DrawString(e.Cache, sDisplayText, font, e.Cache.GetSolidBrush(e.Appearance.ForeColor), textRect, strFormat)
				End If
			End If
		End Sub

		Protected Overrides Sub DrawTrackLineCore(ByVal e As TrackBarObjectInfoArgs, ByVal bounds As Rectangle)
			Dim ri As RangeTrackBarViewInfo = TryCast(e.ViewInfo, RangeTrackBarViewInfo)
			Dim rectForFill As New Rectangle(ri.MinThumbPos.X, e.Bounds.Y, ri.MaxThumbPos.X - ri.MinThumbPos.X, e.Bounds.Height)
			Dim color As Color = DevExpress.LookAndFeel.LookAndFeelHelper.GetSystemColor(DevExpress.LookAndFeel.UserLookAndFeel.Default.ActiveLookAndFeel, SystemColors.Highlight)
			e.Graphics.FillRectangle(New SolidBrush(color), rectForFill)
			MyBase.DrawTrackLineCore(e, bounds)
		End Sub
	End Class
End Namespace
