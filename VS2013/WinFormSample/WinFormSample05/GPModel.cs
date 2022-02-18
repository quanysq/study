using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormSample05
{
  public class GPModel
  {
    /// <summary>
    /// 1日线；2周线
    /// </summary>
    public int DataType { get; set; }
    /// <summary>
    /// 日期
    /// </summary>
    public string CreateDate { get; set; }
    /// <summary>
    /// 星期
    /// </summary>
    public string CreateDateWeek { get; set; }
    /// <summary>
    /// 股票全称：股票名称+" "+股票代码
    /// </summary>
    public string GPFullName { get; set; }
    /// <summary>
    /// 股票名称
    /// </summary>
    public string GPName { get; set; }
    /// <summary>
    /// 股票代码
    /// </summary>
    public string GPCode { get; set; }

    // K线
    /// <summary>
    /// 开盘价
    /// </summary>
    public double Open { get; set; }
    /// <summary>
    /// 收盘价
    /// </summary>
    public double Close { get; set; }
    /// <summary>
    /// 最高价
    /// </summary>
    public double Highest { get; set; }
    /// <summary>
    /// 最低价
    /// </summary>
    public double Lowest { get; set; }
    /// <summary>
    /// 涨跌幅（字符串）
    /// </summary>
    public string Range { get; set; }
    public double RangeNum { get; set; }

    //均线
    public double MA5 { get; set; }
    public double MA10 { get; set; }
    public double MA30 { get; set; }
    
    //成交量
    /// <summary>
    /// 成交量
    /// </summary>
    public double Volume { get; set; }

    //MACD
    public double Macd { get; set; }
    public double Diff { get; set; }
    public double Def { get; set; }

    //KDJ
    public double K { get; set; }
    public double D { get; set; }
    public double J { get; set; }

    //RSI
    public double RSI6 { get; set; }
    public double RSI12 { get; set; }
    public double RIS24 { get; set; }
  }
}
