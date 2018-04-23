Imports Microsoft.VisualBasic
Imports System
Namespace MonthSliderExample
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Me.simpleButton1 = New DevExpress.XtraEditors.SimpleButton()
			Me.dateEdit1 = New DevExpress.XtraEditors.DateEdit()
			Me.defaultLookAndFeel1 = New DevExpress.LookAndFeel.DefaultLookAndFeel(Me.components)
			Me.monthRangeTrackBar1 = New MonthRangeTrackBar.MonthRangeTrackBar()
			CType(Me.dateEdit1.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.dateEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.monthRangeTrackBar1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.monthRangeTrackBar1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' simpleButton1
			' 
			Me.simpleButton1.Location = New System.Drawing.Point(12, 104)
			Me.simpleButton1.Name = "simpleButton1"
			Me.simpleButton1.Size = New System.Drawing.Size(155, 23)
			Me.simpleButton1.TabIndex = 1
			Me.simpleButton1.Text = "Show period in the caption"
'			Me.simpleButton1.Click += New System.EventHandler(Me.simpleButton1_Click);
			' 
			' dateEdit1
			' 
			Me.dateEdit1.EditValue = Nothing
			Me.dateEdit1.Location = New System.Drawing.Point(12, 65)
			Me.dateEdit1.Name = "dateEdit1"
			Me.dateEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() { New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
			Me.dateEdit1.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() { New DevExpress.XtraEditors.Controls.EditorButton()})
			Me.dateEdit1.Size = New System.Drawing.Size(155, 20)
			Me.dateEdit1.TabIndex = 3
'			Me.dateEdit1.EditValueChanged += New System.EventHandler(Me.dateEdit1_EditValueChanged);
			' 
			' defaultLookAndFeel1
			' 
			Me.defaultLookAndFeel1.LookAndFeel.SkinName = "Seven Classic"
			' 
			' monthRangeTrackBar1
			' 
			Me.monthRangeTrackBar1.Dock = System.Windows.Forms.DockStyle.Top
			Me.monthRangeTrackBar1.EditValue = New DevExpress.XtraEditors.Repository.TrackBarRange(0, 0)
			Me.monthRangeTrackBar1.Location = New System.Drawing.Point(0, 0)
			Me.monthRangeTrackBar1.Name = "monthRangeTrackBar1"
			Me.monthRangeTrackBar1.Size = New System.Drawing.Size(675, 45)
			Me.monthRangeTrackBar1.TabIndex = 2
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(675, 149)
			Me.Controls.Add(Me.dateEdit1)
			Me.Controls.Add(Me.monthRangeTrackBar1)
			Me.Controls.Add(Me.simpleButton1)
			Me.Name = "Form1"
			Me.Text = "Form1"
			CType(Me.dateEdit1.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.dateEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.monthRangeTrackBar1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.monthRangeTrackBar1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private WithEvents simpleButton1 As DevExpress.XtraEditors.SimpleButton
		Private monthRangeTrackBar1 As MonthRangeTrackBar.MonthRangeTrackBar
		Private WithEvents dateEdit1 As DevExpress.XtraEditors.DateEdit
		Private defaultLookAndFeel1 As DevExpress.LookAndFeel.DefaultLookAndFeel

	End Class
End Namespace

