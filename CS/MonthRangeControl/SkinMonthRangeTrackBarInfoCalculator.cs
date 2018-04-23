using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraEditors.Drawing;
using System.Drawing;

namespace MonthRangeTrackBar
{
    class SkinMonthRangeTrackBarInfoCalculator : SkinRangeTrackBarInfoCalculator
    {
        public SkinMonthRangeTrackBarInfoCalculator(RangeTrackBarViewInfo viewInfo, RangeTrackBarObjectPainter painter) : base(viewInfo, painter) { }

        protected override System.Drawing.Rectangle CalcTrackLineRect()
        {
            Rectangle returnedValue = base.CalcTrackLineRect();
            returnedValue.X += 5;
            returnedValue.Width -= 10;
            return returnedValue;
        }

        protected override Rectangle CalcPointsRect()
        {
            Rectangle returnedValue = base.CalcPointsRect();
            returnedValue.X += 5;
            returnedValue.Width -= 10;
            return returnedValue;
        }
    }
}
