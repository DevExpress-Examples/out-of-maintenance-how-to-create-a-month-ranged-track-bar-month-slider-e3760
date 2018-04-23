using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;

namespace MonthRangeTrackBar
{
    public class MonthRangeTrackBar : RangeTrackBarControl
    {
        static MonthRangeTrackBar() { RepositoryItemMonthRangeTrackBar.RegisterMonthRangeTrackBar(); }
        public MonthRangeTrackBar() : base() { }

        public override string EditorTypeName { get { return RepositoryItemMonthRangeTrackBar.MonthRangeTrackBarName; } }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new RepositoryItemMonthRangeTrackBar Properties
        { get { return base.Properties as RepositoryItemMonthRangeTrackBar; } }

        public DateTimeRange MonthRangeValue
        {
            get 
            { 
                return new DateTimeRange(
                    InreaseInitialDate(((TrackBarRange)EditValue).Minimum), 
                    InreaseInitialDate(((TrackBarRange)EditValue).Maximum));             
            }
        }

        protected DateTime InreaseInitialDate(int iMonthCount)
        {
            DateTime retDate = new DateTime(Properties.InitialDateValue.Year, Properties.InitialDateValue.Month, 1);
            retDate = retDate.AddMonths(iMonthCount);
            return retDate;
        }
    }

    public struct DateTimeRange
    {
        DateTime minimumDate_;
        DateTime maximumDate_;    

		public DateTimeRange(DateTime minimum, DateTime maximum) { 
			this.minimumDate_ = minimum;
			this.maximumDate_ = maximum;
		}
		public DateTime MinimumDate { 
			get { return minimumDate_; } 
		}
		public DateTime MaximumDate { 
			get { return maximumDate_; } 
		}
		public override string ToString() 
        {
            return String.Format("{0} {1} - {2} {3}", MinimumDate.ToString("MMM"), MinimumDate.Year, MaximumDate.ToString("MMM"), MaximumDate.Year);
		}
    }
}
