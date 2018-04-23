Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.ComponentModel
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Repository

Namespace MonthRangeTrackBar
	Public Class MonthRangeTrackBar
		Inherits RangeTrackBarControl
		Shared Sub New()
			RepositoryItemMonthRangeTrackBar.RegisterMonthRangeTrackBar()
		End Sub
		Public Sub New()
			MyBase.New()
		End Sub

		Public Overrides ReadOnly Property EditorTypeName() As String
			Get
				Return RepositoryItemMonthRangeTrackBar.MonthRangeTrackBarName
			End Get
		End Property

		<DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
		Public Shadows ReadOnly Property Properties() As RepositoryItemMonthRangeTrackBar
			Get
				Return TryCast(MyBase.Properties, RepositoryItemMonthRangeTrackBar)
			End Get
		End Property

		Public ReadOnly Property MonthRangeValue() As DateTimeRange
			Get
				Return New DateTimeRange(InreaseInitialDate((CType(EditValue, TrackBarRange)).Minimum), InreaseInitialDate((CType(EditValue, TrackBarRange)).Maximum))
			End Get
		End Property

		Protected Function InreaseInitialDate(ByVal iMonthCount As Integer) As DateTime
			Dim retDate As New DateTime(Properties.InitialDateValue.Year, Properties.InitialDateValue.Month, 1)
			retDate = retDate.AddMonths(iMonthCount)
			Return retDate
		End Function
	End Class

	Public Structure DateTimeRange
		Private minimumDate_ As DateTime
		Private maximumDate_ As DateTime

		Public Sub New(ByVal minimum As DateTime, ByVal maximum As DateTime)
			Me.minimumDate_ = minimum
			Me.maximumDate_ = maximum
		End Sub
		Public ReadOnly Property MinimumDate() As DateTime
			Get
				Return minimumDate_
			End Get
		End Property
		Public ReadOnly Property MaximumDate() As DateTime
			Get
				Return maximumDate_
			End Get
		End Property
		Public Overrides Function ToString() As String
			Return String.Format("{0} {1} - {2} {3}", MinimumDate.ToString("MMM"), MinimumDate.Year, MaximumDate.ToString("MMM"), MaximumDate.Year)
		End Function
	End Structure
End Namespace
