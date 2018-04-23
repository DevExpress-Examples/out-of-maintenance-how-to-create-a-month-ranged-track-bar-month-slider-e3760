using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Drawing;
using DevExpress.LookAndFeel;

namespace MonthRangeTrackBar
{
    class MonthRangeTrackBarViewInfo : RangeTrackBarViewInfo
    {
        public MonthRangeTrackBarViewInfo(RepositoryItem item) : base(item) { }
        public RepositoryItemMonthRangeTrackBar RepositoryItem
        {
            get { return this.Item as RepositoryItemMonthRangeTrackBar; }
        }

        public override DevExpress.XtraEditors.Drawing.TrackBarObjectPainter GetTrackPainter()
        {
            //if (IsPrinting)
            //    return new RangeTrackBarObjectPainter();
            //if (this.LookAndFeel.ActiveStyle == ActiveLookAndFeelStyle.WindowsXP)
            //    return new RangeTrackBarObjectPainter();
            //if (this.LookAndFeel.ActiveStyle == ActiveLookAndFeelStyle.Skin)
            return new SkinMonthRangeTrackBarObjectPainter(LookAndFeel.ActiveLookAndFeel);
            //if (this.LookAndFeel.ActiveStyle == ActiveLookAndFeelStyle.Office2003)
            //    return new Office2003RangeTrackBarObjectPainter();
            //return new RangeTrackBarObjectPainter();
        }

        protected override void CalcTrackLineRect()
        {
            base.CalcTrackLineRect();
        }
    }
}
