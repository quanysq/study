using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICSharpCode.SharpZipLib;
using ICSharpCode.SharpZipLib.Zip;

namespace Console035
{
  class Program
  {
    static void Main(string[] args)
    {
      //using (ZipFile zip = ZipFile.Create(@"D:\test.zip"))
      //{
      //  zip.BeginUpdate();
      //  zip.SetComment("this is my zip package.");
      //  zip.Add(@"D:\VS2013\Updateset\Patch\US43_201508_BUG03120_CPE\AnalyzePatchSet\tus.schema.xml");       //添加一个文件
      //  zip.AddDirectory(@"D:\VS2013\Updateset\Patch\US43_201508_BUG03120_CPE\AnalyzePatchSet\it");  //添加一个文件夹(这个方法不会压缩文件夹里的文件)
      //  zip.Add(@"D:\VS2013\Updateset\Patch\US43_201508_BUG03120_CPE\AnalyzePatchSet\it\aggregates_create_oracle.sql");     //添加文件夹里的文件
      //  zip.CommitUpdate();
      //}

      FastZip fz = new FastZip();
      fz.CreateZip(@"D:\test.zip", @"D:\VS2013\Updateset\Patch\US43_201508_BUG03120_CPE\AnalyzePatchSet", true, "");
    }
  }
}
