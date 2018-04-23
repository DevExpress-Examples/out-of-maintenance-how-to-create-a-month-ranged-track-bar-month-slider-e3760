using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using DevExpress.XtraEditors.Drawing;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.XtraEditors.ViewInfo;

namespace MonthRangeTrackBar
{
    class SkinMonthRangeTrackBarObjectPainter : SkinRangeTrackBarObjectPainter
    {
        public SkinMonthRangeTrackBarObjectPainter(ISkinProvider provider) : base(provider) { }

        protected override DevExpress.XtraEditors.ViewInfo.TrackBarInfoCalculator GetCalculator(DevExpress.XtraEditors.ViewInfo.TrackBarViewInfo viewInfo)
        {
            return new SkinMonthRangeTrackBarInfoCalculator(viewInfo as RangeTrackBarViewInfo, this);
        }

        public override void DrawPoints(TrackBarObjectInfoArgs e, bool bMirror)
        {
            Point p1 = Point.Empty, p2 = Point.Empty;
            float xPos;
            int tickCount;
            p1.Y = e.ViewInfo.PointsRect.Y;
            for (xPos = 0, tickCount = 0; tickCount < e.ViewInfo.TickCount; xPos += e.ViewInfo.PointsDelta, tickCount++)
            {
                p2.X = p1.X = (int)(e.ViewInfo.PointsRect.X + xPos + 0.01f);
                if (tickCount != 0 && tickCount != e.ViewInfo.TickCount - 1) p2.Y = p1.Y + Math.Max(e.ViewInfo.PointsRect.Height * 3 / 4, 1);
                else p2.Y = p1.Y + e.ViewInfo.PointsRect.Height;
                DrawLine(e, e.ViewInfo.TrackBarHelper.RotateAndMirror(p1, e.ViewInfo.MirrorPoint.Y, bMirror), e.ViewInfo.TrackBarHelper.RotateAndMirror(p2, e.ViewInfo.MirrorPoint.Y, bMirror));
                DrawTickText(e, p1, tickCount);
            }
        }

        private static void DrawTickText(TrackBarObjectInfoArgs e, Point p, int tickCount)
        {
            MonthRangeTrackBarViewInfo vi = e.ViewInfo as MonthRangeTrackBarViewInfo;

            DateTime currentDateValue = new DateTime(vi.RepositoryItem.InitialDateValue.Year, vi.RepositoryItem.InitialDateValue.Month, 1);
            currentDateValue = currentDateValue.AddMonths(tickCount);
            string sDisplayText = currentDateValue.ToString("MMM").ToUpper() + " " + currentDateValue.Year.ToString();

            // Check if there's enough space to draw the tick values assuming that there should be at least 15 pixels available for drawing
            // the text
            int freePixels = e.Bounds.Y + e.Bounds.Height - (e.ViewInfo.PointsRect.Y + e.ViewInfo.PointsRect.Height);
            if (freePixels < 10)
                return;

            Rectangle textRect = new Rectangle();
            textRect.Y = e.ViewInfo.PointsRect.Y + e.ViewInfo.PointsRect.Height + 3;
            textRect.Height = freePixels - 3;

            Font font = new Font(e.Appearance.Font.FontFamily, (Single)Math.Min(freePixels - 3, 7), FontStyle.Regular);

            StringFormat strFormat = e.Appearance.GetStringFormat();
            strFormat.Alignment = StringAlignment.Center;

            textRect.X = (int)(p.X - e.ViewInfo.PointsDelta / 2);
            textRect.Width = (int)(e.ViewInfo.PointsDelta);

            SizeF strSize = e.Graphics.MeasureString(sDisplayText, font);
            double overlap = strSize.Width / textRect.Width;

            if (overlap <= 1)
                e.Paint.DrawString(e.Cache, sDisplayText, font, e.Cache.GetSolidBrush(e.Appearance.ForeColor), textRect, strFormat);
            else
            {
                int range = (int)Math.Round(overlap);
                textRect.Width = (int)(textRect.Width * overlap);

                int tail = (e.ViewInfo.TickCount % 2 == 0) ? 0 : 1;

                if (tickCount % range != tail)
                    e.Paint.DrawString(e.Cache, sDisplayText, font, e.Cache.GetSolidBrush(e.Appearance.ForeColor), textRect, strFormat);
            }
        }

        protected override void DrawTrackLineCore(TrackBarObjectInfoArgs e, Rectangle bounds)
        {
            RangeTrackBarViewInfo ri = e.ViewInfo as RangeTrackBarViewInfo;
            Rectangle rectForFill = new Rectangle(ri.MinThumbPos.X, e.Bounds.Y, ri.MaxThumbPos.X - ri.MinThumbPos.X, e.Bounds.Height);
            Color color = DevExpress.LookAndFeel.LookAndFeelHelper.GetSystemColor(DevExpress.LookAndFeel.UserLookAndFeel.Default.ActiveLookAndFeel, SystemColors.Highlight);
            e.Graphics.FillRectangle(new SolidBrush(color), rectForFill);
            base.DrawTrackLineCore(e, bounds);
        }
    }
}
