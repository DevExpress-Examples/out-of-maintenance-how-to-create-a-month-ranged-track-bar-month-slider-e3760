Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraEditors.Registrator
Imports DevExpress.XtraEditors.ViewInfo
Imports DevExpress.XtraEditors.Drawing
Imports System.ComponentModel

Namespace MonthRangeTrackBar
	'The attribute that points to the registration method 
	<UserRepositoryItem("RegisterMonthRangeTrackBar")> _
	Public Class RepositoryItemMonthRangeTrackBar
		Inherits RepositoryItemRangeTrackBar
		Private Shared ReadOnly drawingTick As Object = New Object()
		'private string tickDisplayText;
		Private initialDataValue As DateTime

		' Static constructor should call registration method
		Shared Sub New()
			RegisterMonthRangeTrackBar()
		End Sub

		Public Const MonthRangeTrackBarName As String = "MonthRangeTrackBar"
		Public Overrides ReadOnly Property EditorTypeName() As String
			Get
				Return MonthRangeTrackBarName
			End Get
		End Property

		Public Shared Sub RegisterMonthRangeTrackBar()
			EditorRegistrationInfo.Default.Editors.Add(New EditorClassInfo(MonthRangeTrackBarName, GetType(MonthRangeTrackBar), GetType(RepositoryItemMonthRangeTrackBar), GetType(MonthRangeTrackBarViewInfo), New RangeTrackBarPainter(), True))
		End Sub

		Public Sub New()
			MyBase.New()
			InitialDateValue = DateTime.Now
		End Sub

		<Description("Gets or set an initial date value for tracking"), Browsable(True), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
		Public Property InitialDateValue() As DateTime
			Set(ByVal value As DateTime)
				initialDataValue = value
				RaisePropertiesChanged(EventArgs.Empty)
			End Set
			Get
				Return initialDataValue
			End Get
		End Property

		<Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
		Public Overrides Property TickFrequency() As Integer
			Get
				Return MyBase.TickFrequency
			End Get
			Set(ByVal value As Integer)
				MyBase.TickFrequency = value
			End Set
		End Property
		' Override the Assign method
		Public Overrides Sub Assign(ByVal item As RepositoryItem)
			BeginUpdate()
			MyBase.Assign(item)
			Dim source As RepositoryItemMonthRangeTrackBar = TryCast(item, RepositoryItemMonthRangeTrackBar)
			If source Is Nothing Then
				Return
			End If
			EndUpdate()
		End Sub
	End Class
End Namespace
