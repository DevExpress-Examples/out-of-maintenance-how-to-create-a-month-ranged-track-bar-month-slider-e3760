using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraEditors.Drawing;
using System.ComponentModel;

namespace MonthRangeTrackBar
{
    //The attribute that points to the registration method 
    [UserRepositoryItem("RegisterMonthRangeTrackBar")]
    public class RepositoryItemMonthRangeTrackBar : RepositoryItemRangeTrackBar
    {
        static readonly object drawingTick = new object();
        //private string tickDisplayText;
        private DateTime initialDataValue;

        // Static constructor should call registration method
        static RepositoryItemMonthRangeTrackBar() { RegisterMonthRangeTrackBar(); }

        public const string MonthRangeTrackBarName = "MonthRangeTrackBar";
        public override string EditorTypeName { get { return MonthRangeTrackBarName; } }

        public static void RegisterMonthRangeTrackBar()
        {
            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(
                MonthRangeTrackBarName, typeof(MonthRangeTrackBar), typeof(RepositoryItemMonthRangeTrackBar),
                typeof(MonthRangeTrackBarViewInfo), new RangeTrackBarPainter(), true));
        }

        public RepositoryItemMonthRangeTrackBar() : base()
        {
            InitialDateValue = DateTime.Now;
        }

        [Description("Gets or set an initial date value for tracking"), Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public DateTime InitialDateValue
        {
            set
            {
                initialDataValue = value;
                RaisePropertiesChanged(EventArgs.Empty);
            }
            get
            {
                return initialDataValue;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override int TickFrequency
        {
            get
            {
                return base.TickFrequency;
            }
            set
            {
                base.TickFrequency = value;
            }
        }
        // Override the Assign method
        public override void Assign(RepositoryItem item)
        {
            BeginUpdate();
            base.Assign(item);
            RepositoryItemMonthRangeTrackBar source = item as RepositoryItemMonthRangeTrackBar;
            if (source == null) return;
            EndUpdate();
        }
    }
}
