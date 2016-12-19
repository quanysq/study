using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console001
{
  /// <summary>
  /// 比较两个DirectoryInfo对象是否相等
  /// </summary>
  class DirectoryInfoEquality : IEqualityComparer<DirectoryInfo>
  {
    public bool Equals(DirectoryInfo x, DirectoryInfo y)
    {
      return x.FullName == y.FullName;
    }

    public int GetHashCode(DirectoryInfo obj)
    {
      if (obj == null)
      {
        return 0;
      }
      else
      {
        return obj.ToString().GetHashCode();
      }
    }
  }

  class EnDirectory
  {

    /// <summary>
    /// Gets or sets the full name.
    /// </summary>
    /// <value>
    /// The full name.
    /// </value>
    public string FullName { get; set; }
    public string Name { get; set; }
  }

  /// <summary>
  /// 比较两个EnDirectory对象是否相等
  /// </summary>
  class EnDirectoryEquality : IEqualityComparer<EnDirectory>
  {

    /// <summary>
    /// Determines whether the specified objects are equal.
    /// </summary>
    /// <param name="x">The first object of type <paramref name="T" /> to compare.</param>
    /// <param name="y">The second object of type <paramref name="T" /> to compare.</param>
    /// <returns>
    /// true if the specified objects are equal; otherwise, false.
    /// </returns>
    public bool Equals(EnDirectory x, EnDirectory y)
    {
      return x.FullName == y.FullName;
    }

    public int GetHashCode(EnDirectory obj)
    {
      if (obj == null)
      {
        return 0;
      }
      else
      {
        return obj.ToString().GetHashCode();
      }
    }
  }
}
