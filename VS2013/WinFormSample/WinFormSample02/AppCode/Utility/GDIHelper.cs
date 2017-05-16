using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace WinFormSample02
{
  /// <summary>
  /// GDI绘制辅助类
  /// </summary>
  /// User:Ryan  CreateTime:2012-8-3 21:03.
  internal class GDIHelper
  {
    #region InitializeGraphics

    /// <summary>
    /// 初始化Graphics对象为高质量的绘制
    /// </summary>
    /// <param name="g">The g.</param>
    /// User:Ryan  CreateTime:2011-08-19 16:53.
    public static void InitializeGraphics(Graphics g)
    {
      if (g != null)
      {
        g.SmoothingMode = SmoothingMode.AntiAlias;
        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
        g.CompositingQuality = CompositingQuality.HighQuality;
      }
    }

    #endregion

    #region FillRectangle

    /// <summary>
    /// 渲染一个矩形区域（渐变色）
    /// Fills the rectangle.
    /// </summary>
    /// <param name="g">The g.</param>
    /// <param name="rect">The rect.</param>
    /// <param name="color">The color.</param>
    /// User:Ryan  CreateTime:2012-8-3 21:25.
    public static void FillRectangle(Graphics g, Rectangle rect, GradientColor color)
    {
      if (rect.Width <= 0 || rect.Height <= 0 || g == null)
      {
        return;
      }

      using (LinearGradientBrush brush = new LinearGradientBrush(rect, color.First, color.Second, LinearGradientMode.Vertical))
      {
        brush.Blend.Factors = color.Factors;
        brush.Blend.Positions = color.Positions;
        g.FillRectangle(brush, rect);
      }
    }

    /// <summary>
    /// 渲染一个矩形区域（单色）
    /// Fills the rectangle.
    /// </summary>
    /// <param name="g">The g.</param>
    /// <param name="rect">The rect.</param>
    /// <param name="color">The color.</param>
    /// User:Ryan  CreateTime:2012-8-3 21:46.
    public static void FillRectangle(Graphics g, Rectangle rect, Color color)
    {
      if (rect.Width <= 0 || rect.Height <= 0 || g == null)
      {
        return;
      }

      using (Brush brush = new SolidBrush(color))
      {
        g.FillRectangle(brush, rect);
      }
    }

    /// <summary>
    /// 渲染一个圆角矩形区域（渐变色）
    /// Fills the rectangle.
    /// </summary>
    /// <param name="g">The g.</param>
    /// <param name="roundRect">The round rect.</param>
    /// <param name="color">The color.</param>
    /// User:Ryan  CreateTime:2012-8-3 21:45.
    public static void FillRectangle(Graphics g, RoundRectangle roundRect, GradientColor color)
    {
      if (roundRect.Rect.Width <= 0 || roundRect.Rect.Height <= 0)
      {
        return;
      }

      using (GraphicsPath path = roundRect.ToGraphicsBezierPath())
      {
        using (LinearGradientBrush brush = new LinearGradientBrush(roundRect.Rect, color.First, color.Second, LinearGradientMode.Vertical))
        {
          brush.Blend.Factors = color.Factors;
          brush.Blend.Positions = color.Positions;
          g.FillPath(brush, path);
        }
      }
    }

    /// <summary>
    /// 渲染一个圆角矩形区域（单色）
    /// Fills the rectangle.
    /// </summary>
    /// <param name="g">The g.</param>
    /// <param name="roundRect">The round rect.</param>
    /// <param name="color">The color.</param>
    /// User:Ryan  CreateTime:2012-8-3 21:45.
    public static void FillRectangle(Graphics g, RoundRectangle roundRect, Color color)
    {
      if (roundRect.Rect.Width <= 0 || roundRect.Rect.Height <= 0)
      {
        return;
      }

      using (GraphicsPath path = roundRect.ToGraphicsBezierPath())
      {
        using (Brush brush = new SolidBrush(color))
        {
          g.FillPath(brush, path);
        }
      }
    }

    #endregion

    #region FillPath
    /// <summary>
    /// 使用渐变色填充区域
    /// </summary>
    /// <param name="g">The g.</param>
    /// <param name="roundRect">The round rect.</param>
    /// <param name="color1">The color1.</param>
    /// <param name="color2">The color2.</param>
    /// User:Ryan  CreateTime:2012-8-4 19:15.
    public static void FillPath(Graphics g, RoundRectangle roundRect, Color color1, Color color2)
    {
      if (roundRect.Rect.Width <= 0 || roundRect.Rect.Height <= 0)
      {
        return;
      }

      using (GraphicsPath path = roundRect.ToGraphicsBezierPath())
      {
        using (LinearGradientBrush brush = new LinearGradientBrush(roundRect.Rect, color1, color2, LinearGradientMode.Vertical))
        {
          g.FillPath(brush, path);
        }
      }
    }

    #endregion

    #region DrawPathBorder

    /// <summary>
    /// 绘制一个图形区域的边框
    /// </summary>
    /// <param name="g">The g.</param>
    /// <param name="path">The path.</param>
    /// <param name="color">The color.</param>
    /// User:Ryan  CreateTime:2012-8-6 21:31.
    public static void DrawPathBorder(Graphics g, GraphicsPath path, Color color)
    {
      using (Pen pen = new Pen(color, 1))
      {
        g.DrawPath(pen, path);
      }
    }

    /// <summary>
    /// 绘制指定区域路径的边框.
    /// 注意:若要设置边框宽度，需要自己调整区域，它是向外绘制的
    /// </summary>
    /// <param name="g">The Graphics.</param>
    /// <param name="roundRect">The RoundRectangle.</param>
    /// <param name="color">The color.</param>
    /// <param name="borderWidth">Width of the border.</param>
    /// User:Ryan  CreateTime:2011-07-28 16:11.
    public static void DrawPathBorder(Graphics g, RoundRectangle roundRect, Color color, int borderWidth)
    {
      using (GraphicsPath path = roundRect.ToGraphicsBezierPath())
      {
        using (Pen pen = new Pen(color, borderWidth))
        {
          g.DrawPath(pen, path);
        }
      }
    }

    /// <summary>
    /// 绘制指定区域路径的边框
    /// </summary>
    /// User:Ryan  CreateTime:2011-07-28 16:11.
    public static void DrawPathBorder(Graphics g, RoundRectangle roundRect, Color color)
    {
      DrawPathBorder(g, roundRect, color, 1);
    }

    /// <summary>
    /// 绘制指定区域路径的边框
    /// </summary>
    public static void DrawPathInnerBorder(Graphics g, RoundRectangle roundRect, Color color)
    {
      Rectangle rect = roundRect.Rect;
      rect.X++; rect.Y++; rect.Width -= 2; rect.Height -= 2;
      DrawPathBorder(g, new RoundRectangle(rect, roundRect.CornerRadius), color);
    }

    /// <summary>
    /// 绘制指定区域路径的边框
    /// </summary>
    public static void DrawPathOuterBorder(Graphics g, RoundRectangle roundRect, Color color)
    {
      Rectangle rect = roundRect.Rect;
      rect.X--; rect.Y--; rect.Width += 2; rect.Height += 2;
      DrawPathBorder(g, new RoundRectangle(rect, roundRect.CornerRadius), color);
    }

    /// <summary>
    /// 绘制指定区域路径的边框
    /// </summary>
    public static void DrawPathOuterBorder(Graphics g, RoundRectangle roundRect, Color color, int borderWidth)
    {
      Rectangle rect = roundRect.Rect;
      rect.X--; rect.Y--; rect.Width += 2; rect.Height += 2;
      DrawPathBorder(g, new RoundRectangle(rect, roundRect.CornerRadius), color, borderWidth);
    }

    /// <summary>
    /// 绘制指定区域路径的边框
    /// </summary>
    public static void DrawPathBorder(Graphics g, RoundRectangle roundRect)
    {
      //TODO
      //DrawPathBorder(g, roundRect, SkinManager.CurrentSkin.BorderColor);
      DrawPathBorder(g, roundRect, Color.Red);
    }

    /// <summary>
    /// 绘制指定区域路径的边框
    /// </summary>
    public static void DrawPathInnerBorder(Graphics g, RoundRectangle roundRect)
    {
      //TODO
      //Color c = SkinManager.CurrentSkin.InnerBorderColor;
      Color c = Color.LightYellow;
      ////c = Color.Green;
      DrawPathInnerBorder(g, roundRect, c);
    }

    /// <summary>
    /// 绘制指定区域路径的边框
    /// </summary>
    public static void DrawPathOuterBorder(Graphics g, RoundRectangle roundRect)
    {
      //TODO
      //DrawPathOuterBorder(g, roundRect, SkinManager.CurrentSkin.OuterBorderColor);
      DrawPathOuterBorder(g, roundRect, Color.Blue);
    }

    #endregion
  }
}
