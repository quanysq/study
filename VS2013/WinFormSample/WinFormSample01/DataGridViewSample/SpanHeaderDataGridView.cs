using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormSample01.DataGridViewSample
{
  public class SpanHeaderDataGridView : DataGridView
  {
    private struct SpanInfo //表头信息
    {
      public SpanInfo(string text, int position, int left, int right)
      {
        this.Text = text;
        this.Position = position;
        this.Left = left;
        this.Right = right;
      }

      public string Text; //列主标题
      public int Position; //位置，1:左，2中，3右
      public int Left; //对应左行
      public int Right; //对应右行
    }
    private Dictionary<int, SpanInfo> SpanRows = new Dictionary<int, SpanInfo>();//需要2维表头的列
    /// <summary>
    /// 合并列
    /// </summary>
    /// <param name="ColIndex">列的索引</param>
    /// <param name="ColCount">需要合并的列数</param>
    /// <param name="Text">合并列后的文本</param>
    public void AddSpanHeader(int ColIndex, int ColCount, string Text)
    {
      if (ColCount < 2)
      {
        throw new Exception("行宽应大于等于2，合并1列无意义。");
      }
      //将这些列加入列表
      int Right = ColIndex + ColCount - 1; //同一大标题下的最后一列的索引
      SpanRows[ColIndex] = new SpanInfo(Text, 1, ColIndex, Right); //添加标题下的最左列
      SpanRows[Right] = new SpanInfo(Text, 3, ColIndex, Right); //添加该标题下的最右列
      for (int i = ColIndex + 1; i < Right; i++) //中间的列
      {
        SpanRows[i] = new SpanInfo(Text, 2, ColIndex, Right);
      }
    }

    protected override void OnCellPainting(DataGridViewCellPaintingEventArgs e)
    {
      if (e.RowIndex == -1)
      {
        if (SpanRows.ContainsKey(e.ColumnIndex)) //被合并的列
        {
          //画边框
          Graphics g = e.Graphics;
          e.Paint(e.CellBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border);

          //int left = e.CellBounds.Left, top = e.CellBounds.Top + 2,
          //right = e.CellBounds.Right, bottom = e.CellBounds.Bottom;

          //Jacky
          int left = this.GetColumnDisplayRectangle(SpanRows[e.ColumnIndex].Left, true).Left;
          int top = e.CellBounds.Top + 1;
          int right = this.GetColumnDisplayRectangle(SpanRows[e.ColumnIndex].Right, true).Right;
          int bottom = e.CellBounds.Bottom - 1;

          /*
          switch (SpanRows[e.ColumnIndex].Position)
          {
            case 1:
              left += 2;
              break;
            case 2:
              break;
            case 3:
              right -= 2;
              break;
          }*/
          
          //画上半部分底色
          //g.FillRectangle(new SolidBrush(SystemColors.Control), left, top, right - left, (bottom - top) / 2);
          
          //Jacky
          g.FillRectangle(new SolidBrush(Color.White), left, top, right - left, bottom - top);  
          

          //画中线
          //g.DrawLine(new Pen(this.GridColor), left, (top + bottom) / 2, right, (top + bottom) / 2);

          //写小标题
          StringFormat sf = new StringFormat();
          sf.Alignment = StringAlignment.Center;
          sf.LineAlignment = StringAlignment.Center;

          //g.DrawString(e.Value + "", e.CellStyle.Font, Brushes.Black, new Rectangle(left, (top + bottom) / 2, right - left, (bottom - top) / 2), sf);
          //left = this.GetColumnDisplayRectangle(SpanRows[e.ColumnIndex].Left, true).Left - 2;

          //if (left < 0) left = this.GetCellDisplayRectangle(-1, -1, true).Width;
          //right = this.GetColumnDisplayRectangle(SpanRows[e.ColumnIndex].Right, true).Right - 2;
          //if (right < 0) right = this.Width;

          //g.DrawString(SpanRows[e.ColumnIndex].Text, e.CellStyle.Font, Brushes.Black, new Rectangle(left, top, right - left, (bottom - top) / 2), sf);
          g.DrawString(SpanRows[e.ColumnIndex].Text, e.CellStyle.Font, Brushes.Black, new Rectangle(left, top, right - left, bottom - top), sf);

          e.Handled = true;
        }
      }
      base.OnCellPainting(e);
    }

    protected override void OnScroll(ScrollEventArgs e)
    {
      if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
      {
        ReDrawHead();
      }
      
      base.OnScroll(e);
    }

    
    //刷新显示表头
    public void ReDrawHead()
    {
      foreach (int si in SpanRows.Keys)
      {
        this.Invalidate(this.GetCellDisplayRectangle(si, -1, true));
      }
    }
  }
}
