using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console006.Class
{
  class Course
  {
    public float Chinese { set; get; }
    public float Math { set; get; }
    public float Englisth { set; get; }

    // 声明一个公开的float类型的索引器
    public float this[int index]
    {
      // set访问器：赋值
      set
      {
        switch (index)
        {
          case 0:
            this.Chinese = value;
            break;
          case 1:
            this.Math = value;
            break;
          case 2:
            this.Englisth = value;
            break;
          default:
            // 索引越界时抛出异常
            throw new ArgumentOutOfRangeException();
        }
      }
      // get访问器：取值
      get
      {
        switch (index)
        {
          case 0:
            return this.Chinese;
          case 1:
            return this.Math;
          case 2:
            return this.Englisth;
          default:
            throw new ArgumentOutOfRangeException();
        }
      }
    }

    // 索引重载
    public float this[string name, float val]
    {
      set
      {
        switch (name)
        {
          case "Chinese":
            this.Chinese = value + val;
            break;
          case "Math":
            this.Math = value + val;
            break;
          case "English":
            this.Englisth = value + val;
            break;
          default:
            throw new ArgumentOutOfRangeException();
        }
      }
      get
      {
        switch (name)
        {
          case "Chinese":
            return this.Chinese;
          case "Math":
            return this.Math;
          case "English":
            return this.Englisth;
          default:
            throw new ArgumentOutOfRangeException();
        }
      }
    }

    // 重载2：只读索引
    protected string this[int index, string name, bool flag]
    {
      set
      {

      }
    }
  }
}
