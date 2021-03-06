﻿using System;
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

    #region DrawImage

    /// <summary>
    /// 在指定区域绘制图片(可设置图片透明度) (平铺绘制）
    /// Draws the image.
    /// </summary>
    /// <param name="g">The g.</param>
    /// <param name="rect">The rect.</param>
    /// <param name="img">The img.</param>
    /// User:Ryan  CreateTime:2012-8-3 21:12.
    public static void DrawImage(Graphics g, Rectangle rect, Image img, float opacity)
    {
      if (opacity <= 0)
      {
        return;
      }

      using (ImageAttributes imgAttributes = new ImageAttributes())
      {
        GDIHelper.SetImageOpacity(imgAttributes, opacity >= 1 ? 1 : opacity);
        Rectangle imageRect = new Rectangle(rect.X, rect.Y + rect.Height / 2 - img.Size.Height / 2, img.Size.Width, img.Size.Height);
        g.DrawImage(img, rect, 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, imgAttributes);
      }
    }

    /// <summary>
    /// 绘制简单图片(平铺绘制）
    /// </summary>
    /// <param name="g">The g.</param>
    /// <param name="rect">The rect.</param>
    /// <param name="img">The img.</param>
    /// User:Ryan  CreateTime:2012-8-4 12:54.
    public static void DrawImage(Graphics g, Rectangle rect, Image img)
    {
      Rectangle imageRect = new Rectangle(rect.X, rect.Y + rect.Height / 2 - img.Size.Height / 2, img.Size.Width, img.Size.Height);
      g.DrawImage(img, rect, 0, 0, img.Width, img.Height, GraphicsUnit.Pixel);
    }

    /// <summary>
    /// 按照指定区域绘制指定大小的图片
    /// </summary>
    /// <param name="g">The g.</param>
    /// <param name="rect">The rect.</param>
    /// <param name="img">The img.</param>
    /// <param name="imgSize">Size of the img.</param>
    /// User:Ryan  CreateTime:2012-8-4 13:34.
    public static void DrawImage(Graphics g, Rectangle rect, Image img, Size imgSize)
    {
      if (g == null || img == null)
      {
        return;
      }

      int x = rect.X + rect.Width / 2 - imgSize.Width / 2, y = rect.Y;
      Rectangle imageRect = new Rectangle(x, y + rect.Height / 2 - imgSize.Height / 2, imgSize.Width, imgSize.Height);
      g.DrawImage(img, imageRect);
    }

    #endregion

    #region Draw image and string

    /// <summary>
    /// 在指定的区域绘制绘制图像和文字
    /// </summary>
    /// <param name="g">The g.</param>
    /// <param name="roundRect">The roundRect.</param>
    /// <param name="image">The image.</param>
    /// <param name="imageSize">Size of the image.</param>
    /// <param name="text">The text.</param>
    /// <param name="font">The font.</param>
    /// <param name="forceColor">Color of the force.</param>
    /// User:K.Anding  CreateTime:2011-7-24 22:07.
    public static void DrawImageAndString(Graphics g, Rectangle rect, Image image, Size imageSize, string text, Font font, Color forceColor)
    {
      int x = rect.X, y = rect.Y, len;
      SizeF sf = g.MeasureString(text, font);
      len = Convert.ToInt32(sf.Width);
      x += rect.Width / 2 - len / 2;
      if (image != null)
      {
        x -= imageSize.Width / 2;
        Rectangle imageRect = new Rectangle(x, y + rect.Height / 2 - imageSize.Height / 2, imageSize.Width, imageSize.Height);
        g.DrawImage(image, imageRect);
        x += imageSize.Width + 2;
      }

      g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
      using (SolidBrush brush = new SolidBrush(forceColor))
      {
        g.DrawString(text, font, brush, x, y + rect.Height / 2 - Convert.ToInt32(sf.Height) / 2 + 2);
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
    /// 使用渐变色渲染一个图形区域
    /// </summary>
    /// <param name="g">The g.</param>
    /// <param name="path">The path.</param>
    /// <param name="rect">The rect.</param>
    /// <param name="color">The color.</param>
    /// User:Ryan  CreateTime:2012-8-6 21:27.
    public static void FillPath(Graphics g, GraphicsPath path, Rectangle rect, GradientColor color)
    {
      using (LinearGradientBrush brush = new LinearGradientBrush(rect, color.First, color.Second, LinearGradientMode.Vertical))
      {
        brush.Blend.Factors = color.Factors;
        brush.Blend.Positions = color.Positions;
        g.FillPath(brush, path);
      }
    }

    /// <summary>
    /// 渲染圆角矩形区域（级渲染）
    /// </summary>
    /// <param name="g">The Graphics.</param>
    /// <param name="roundRect">The RoundRectangle.</param>
    /// <param name="color1">The color1.</param>
    /// <param name="color2">The color2.</param>
    /// <param name="blend">色彩混合渲染方案</param>
    /// User:K.Anding  CreateTime:2011-7-20 23:27.
    public static void FillPath(Graphics g, RoundRectangle roundRect, Color color1, Color color2, Blend blend)
    {
      GradientColor color = new GradientColor(color1, color2, blend.Factors, blend.Positions);
      GDIHelper.FillRectangle(g, roundRect, color);
    }

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

    #region 设置图片透明度(SetImageOpacity)

    /// <summary>
    /// 设置图片透明度.
    /// </summary>
    /// <param name="imgAttributes">The ImageAttributes.</param>
    /// <param name="opacity">透明度，0完全透明，1不透明（The opacity.）</param>
    /// User:Ryan  CreateTime:2011-07-28 15:26.
    public static void SetImageOpacity(ImageAttributes imgAttributes, float opacity)
    {
      float[][] nArray ={ new float[] {1, 0, 0, 0, 0},
                                              new float[] {0, 1, 0, 0, 0},
                                              new float[] {0, 0, 1, 0, 0},
                                              new float[] {0, 0, 0, opacity, 0},
                                              new float[] {0, 0, 0, 0, 1}};
      ColorMatrix matrix = new ColorMatrix(nArray);
      imgAttributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
    }

    #endregion

    #region DrawCheckBox

    /// <summary>
    /// 绘制选择状态(勾选状态)
    /// 手动绘制勾勾
    /// </summary>
    /// User:K.Anding  CreateTime:2011-7-24 21:59.
    public static void DrawCheckedState(Graphics g, Rectangle rect, Color color)
    {
      PointF[] points = new PointF[3];
      points[0] = new PointF(
          rect.X + rect.Width / 5f,
          rect.Y + rect.Height / 2.5f);
      points[1] = new PointF(
          rect.X + rect.Width / 2.5f,
          rect.Bottom - rect.Height / 3.6f);
      points[2] = new PointF(
          rect.Right - rect.Width / 5.0f,
          rect.Y + rect.Height / 7.0f);
      using (Pen pen = new Pen(color, 2))
      {
        g.SmoothingMode = SmoothingMode.AntiAlias;
        g.CompositingQuality = CompositingQuality.HighQuality;
        g.DrawLines(pen, points);
      }
    }

    /// <summary>
    /// 绘制选择状态(勾选状态)
    /// 设计好的图片勾
    /// </summary>
    /// User:K.Anding  CreateTime:2011-7-24 21:59.
    public static void DrawCheckedStateByImage(Graphics g, Rectangle rect)
    {
      rect.Inflate(-1, -1);
      g.DrawImage(Properties.Resources.check, rect);
    }

    /// <summary>
    /// 绘制选择状态
    /// </summary>
    /// User:K.Anding  CreateTime:2011-7-24 21:59.
    public static void DrawCheckedState(Graphics g, Rectangle rect)
    {
      DrawCheckedState(g, rect, Color.Green);
    }

    /// <summary>
    /// 绘制checkbox的边框和背景
    /// </summary>
    /// User:Ryan  CreateTime:2011-07-25 18:00.
    public static void DrawCheckBox(Graphics g, RoundRectangle roundRect)
    {
      using (GraphicsPath path = roundRect.ToGraphicsBezierPath())
      {
        using (PathGradientBrush brush = new PathGradientBrush(path))
        {
          brush.CenterColor = Color.YellowGreen; //TODO //SkinManager.CurrentSkin.BaseColor;
          //TODO
          //brush.SurroundColors = new Color[] { SkinManager.CurrentSkin.BorderColor };
          brush.SurroundColors = new Color[] { Color.Blue };
          Blend blend = new Blend();
          blend.Positions = new float[] { 0f, 0.18f, 1f };
          blend.Factors = new float[] { 0f, 0.89f, 1f };
          brush.Blend = blend;
          g.FillPath(brush, path);
        }

        DrawPathBorder(g, roundRect);
      }
    }

    #endregion
  }
}
