using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICSharpCode.SharpZipLib;
using ICSharpCode.SharpZipLib.Zip;
using System.IO;
using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip.Compression;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;
using ICSharpCode.SharpZipLib.GZip;
using ICSharpCode.SharpZipLib.Tar;

namespace Console005.SharpZipLib
{
  /// <summary>
  /// 打包
  /// </summary>
  class C1
  {
    public static void Execute()
    {
      ZipFileExec();
      //FastZipExec();
      //FindEntryExec();
      //GetInputStreamExec();
      //FastUnZipExec();
      //UnzipStreamExec();
      //UpdateZipStreamEntryExec();
      //DeleteZipStreamEntryExec();
      //ZipStreamExec();
      //ZipFilesExec();
      //ZipFilesExec(0);
      //TarZipDirectoryExec();
      //CompressExec();

      Console.WriteLine("OK!");
    }

    // test successful
    private static void ZipFileExec()
    {
      using (ZipFile zip = ZipFile.Create(@"D:\Temp\SharpZipLibTest\test.zip"))
      {
        zip.BeginUpdate();
        zip.SetComment("this is my zip package.");
        zip.Add(@"D:\Temp\SharpZipLibTest\updater.config");       //添加一个文件
        zip.AddDirectory(@"D:\Temp\SharpZipLibTest\it");  //添加一个文件夹(这个方法不会压缩文件夹里的文件)
        zip.Add(@"D:\Temp\SharpZipLibTest\it\web1.config");     //添加文件夹里的文件
        zip.CommitUpdate();
      }
    }

    // test success
    private static void FastZipExec()
    {
      FastZip fz = new FastZip();
      fz.CreateZip(@"D:\Temp\SharpZipLibTest\test.zip", @"D:\Temp\SharpZipLibTest\it", true, "");
    }

    // test success
    private static void FindEntryExec()
    {
      using (ZipFile zip = new ZipFile(@"D:\Temp\SharpZipLibTest\it.zip"))
      {
        var entryIndex = zip.FindEntry("web3.config", true);
        Console.WriteLine("entryIndex: [{0}]", entryIndex);
      }
    }

    // test successful
    private static void GetInputStreamExec()
    {
      using (ZipFile zip = new ZipFile(@"D:\Temp\SharpZipLibTest\it.zip"))
      {
        var entryIndex = zip.FindEntry("web3.config", true);
        using (StreamReader sr = new StreamReader(zip.GetInputStream(entryIndex)))
        {
          string result = sr.ReadToEnd();
          Console.WriteLine(result);
        }
      }
    }

    // test successful
    private static void FastUnZipExec()
    {
      FastZip fastZip = new FastZip();
      fastZip.ExtractZip(@"D:\Temp\SharpZipLibTest\it.zip", @"D:\Temp\SharpZipLibTest\unzip", null);
    }

    // test successful
    private static void UnzipStreamExec()
    {
      var entryFilename = @"D:\Temp\SharpZipLibTest\it\web1.config";
      string entryName = Path.GetFileName(entryFilename);
      Stream zippedStream = File.Open(@"D:\Temp\SharpZipLibTest\it.zip", FileMode.Open, FileAccess.Read, FileShare.Read);
      ZipFile zipFile = new ZipFile(zippedStream);
      if (zipFile.FindEntry(entryName, true) < 0)
      {
        throw new InvalidOperationException(string.Format("No entry [{0}] found in the zip.", entryName));
      }
      zippedStream.Position = 0;
      MemoryStream ms = new MemoryStream();
      ZipInputStream zipInputStream = new ZipInputStream(zippedStream);
      ZipEntry zipEntry = zipInputStream.GetNextEntry();
      while (zipEntry != null)
      {
        string zipEntryFilename = Path.GetFileName(zipEntry.Name);
        if (string.Equals(zipEntryFilename, entryName, StringComparison.CurrentCultureIgnoreCase))
        {
          byte[] buffer = new byte[2048];
          StreamUtils.Copy(zipInputStream, ms, buffer);
          break;
        }
        zipEntry = zipInputStream.GetNextEntry();
      }
      Console.WriteLine(ms);
      zippedStream.Close();
      zipFile.Close();
    }

    // test successful
    private static void UpdateZipStreamEntryExec()
    {
      var fileStream = File.Open(@"D:\Temp\SharpZipLibTest\it.zip", FileMode.Open, FileAccess.Read, FileShare.Read);
      MemoryStream zippedStream = new MemoryStream();
      fileStream.CopyTo(zippedStream);
      fileStream.Close();
      ZipFile zipFile = new ZipFile(zippedStream);
      //ZipFile zipFile = new ZipFile(@"D:\Temp\SharpZipLibTest\it.zip");
      Console.WriteLine("Entry count before add: [{0}]", zipFile.Count);
      zipFile.UseZip64 = UseZip64.On;
      zipFile.BeginUpdate();
      zipFile.Add(@"D:\Temp\SharpZipLibTest\updater.config", "abc.config");
      zipFile.CommitUpdate();
      Console.WriteLine("Entry count after add: [{0}]", zipFile.Count);
      zipFile.IsStreamOwner = false;
      zippedStream.Close();
      zipFile.Close();
      //zippedStream.Position = 0;

      /*
       * 1. 不能直接添加文件在 FileStream 
       * 2. MemoryStream 的话文件是添加在内存中，实现物理文件不会被添加
       * 3. ZipFile zipFile = new ZipFile(@"D:\Temp\SharpZipLibTest\it.zip") 的话会改变实际文件
       */
    }

    // test successful
    private static void DeleteZipStreamEntryExec()
    {
      var fileStream = File.Open(@"D:\Temp\SharpZipLibTest\it.zip", FileMode.Open, FileAccess.Read, FileShare.Read);
      MemoryStream zippedStream = new MemoryStream();
      fileStream.CopyTo(zippedStream);
      fileStream.Close();
      ZipFile zipFile = new ZipFile(zippedStream);
      //ZipFile zipFile = new ZipFile(@"D:\Temp\SharpZipLibTest\it.zip");
      Console.WriteLine("Entry count before add: [{0}]", zipFile.Count);
      zipFile.UseZip64 = UseZip64.On;
      zipFile.BeginUpdate();
      zipFile.Delete("abc.config");
      zipFile.CommitUpdate();
      Console.WriteLine("Entry count after add: [{0}]", zipFile.Count);
      zipFile.IsStreamOwner = false;
      zippedStream.Close();
      zipFile.Close();
    }

    // test successful
    private static void ZipStreamExec()
    {
      MemoryStream zippedStream = new MemoryStream();
      ZipOutputStream zipout = new ZipOutputStream(zippedStream);
      zipout.UseZip64 = UseZip64.Dynamic;
      string sourceFile = @"D:\Temp\SharpZipLibTest\updater.config";
      using (FileStream fs = File.OpenRead(sourceFile))
      {
        string fileName = Path.GetFileName(sourceFile);
        ZipEntry entry = new ZipEntry(fileName) { DateTime = DateTime.Now };
        zipout.PutNextEntry(entry);

        StreamUtils.Copy(fs, zipout, new byte[4096]);
        zipout.CloseEntry();
      }
      zipout.IsStreamOwner = false;
      zipout.Close();
      zippedStream.Position = 0;
      using (var file = new FileStream(@"D:\Temp\SharpZipLibTest\ZipStream.zip", FileMode.Create, FileAccess.Write, FileShare.None))
      {
        zippedStream.CopyTo(file);
      }
      zippedStream.Close();
    }

    // test successful
    private static void ZipFilesExec()
    {
      var zippedFileName = @"D:\Temp\SharpZipLibTest\ZipFiles.zip";
      List<string> sourceFileList = new List<string> { @"D:\Temp\SharpZipLibTest\updater.config" };
      using (ZipOutputStream zipout = new ZipOutputStream(System.IO.File.Create(zippedFileName)))
      {
        zipout.UseZip64 = UseZip64.Dynamic;
        foreach (string sourceFile in sourceFileList)
        {
          using (System.IO.FileStream fs = System.IO.File.OpenRead(sourceFile))
          {
            long m = 1024 * 1024 * 2; //
            byte[] buffer = null;

            int index = sourceFile.LastIndexOf("\\");
            string fileName = sourceFile.Substring(index + 1, sourceFile.Length - index - 1);
            ZipEntry entry = new ZipEntry(fileName);
            entry.DateTime = DateTime.Now;
            //entry.ForceZip64();//file size>4G--UseZip64 = UseZip64.Dynamic,ignore this line
            zipout.PutNextEntry(entry);

            for (long i = 1; i <= fs.Length / m + 1; i++)
            {
              if (m * i < fs.Length)
              {
                buffer = new byte[m];
                fs.Seek(m * (i - 1), System.IO.SeekOrigin.Begin);
              }
              else
              {
                if (fs.Length < m)
                {
                  buffer = new byte[fs.Length];
                }
                else
                {
                  buffer = new byte[fs.Length - m * (i - 1)];
                  fs.Seek(m * (i - 1), System.IO.SeekOrigin.Begin);
                }
              }
              fs.Read(buffer, 0, buffer.Length);
              zipout.Write(buffer, 0, buffer.Length);
              zipout.Flush();
            }//end for
          }//end using
        }//end foreach
      }//end using
    }

    // test successful
    private static void ZipFilesExec(int type)
    {
      var m_zipFile = @"D:\Temp\SharpZipLibTest\ZipFile.zip";
      ZipOutputStream m_zipOutputStream = new ZipOutputStream(File.Create(m_zipFile));
      m_zipOutputStream.UseZip64 = UseZip64.Dynamic;

      {
        byte[] buffer = new byte[4096];

        string fileName = @"D:\Temp\SharpZipLibTest\updater.config";
        ZipEntry entry = new ZipEntry(Path.GetFileName(fileName));
        //entry.ForceZip64();//file size>4G--UseZip64 = UseZip64.Dynamic,ignore this line
        entry.DateTime = DateTime.Now;
        m_zipOutputStream.PutNextEntry(entry);

        using (FileStream fs = File.OpenRead(fileName))
        {
          entry.Size = fs.Length;
          int sourceBytes;
          do
          {
            sourceBytes = fs.Read(buffer, 0, buffer.Length);
            m_zipOutputStream.Write(buffer, 0, sourceBytes);
          }
          while (sourceBytes > 0);
        }
        m_zipOutputStream.Flush();
      }
      m_zipOutputStream.Close();
      m_zipOutputStream = null;
    }

    // test successful
    private static void TarZipDirectoryExec()
    {
      string sourceDirectory = @"D:\Temp\SharpZipLibTest\it";
      string targetTar = @"D:\Temp\SharpZipLibTest\Tarzip.tar";
      Stream outStream = File.Create(targetTar);
      Stream gzoStream = new GZipOutputStream(outStream);
      TarArchive tarArchive = TarArchive.CreateOutputTarArchive(gzoStream);
      tarArchive.RootPath = sourceDirectory.Replace(Path.DirectorySeparatorChar, '/');
      if (tarArchive.RootPath.EndsWith("/")) tarArchive.RootPath = tarArchive.RootPath.Remove(tarArchive.RootPath.Length - 1);
      AddDirectoryFilesToTar(tarArchive, sourceDirectory, true);
      tarArchive.Close();
    }
    private static void AddDirectoryFilesToTar(TarArchive tarArchive, string sourceDirectory, bool recurse)
    {
      // Optionally, write an entry for the directory itself.
      // Specify false for recursion here if we will add the directory's files individually.
      TarEntry tarEntry = TarEntry.CreateEntryFromFile(sourceDirectory);
      tarArchive.WriteEntry(tarEntry, false);
      // Write each file to the tar.
      string[] filenames = Directory.GetFiles(sourceDirectory);
      foreach (string filename in filenames)
      {
        tarEntry = TarEntry.CreateEntryFromFile(filename);
        tarArchive.WriteEntry(tarEntry, true);
      }
      if (recurse)
      {
        string[] directories = Directory.GetDirectories(sourceDirectory);
        foreach (string directory in directories)
          AddDirectoryFilesToTar(tarArchive, directory, recurse);
      }
    }

    // 不管什么版本的sharpziplib，使用DeflaterOutputStream生成的压缩文件都打不开
    private static void CompressExec()
    {
      var zippedFileName = @"D:\Temp\SharpZipLibTest\Compress.zip";
      List<string> sourceFileList = new List<string> { @"D:\Temp\SharpZipLibTest\updater.config" };
      Deflater mdeflater = new Deflater();
      using (ZipOutputStream zipout = new ZipOutputStream(new DeflaterOutputStream(System.IO.File.Create(zippedFileName), mdeflater)))
      {
        zipout.SetLevel(0);
        zipout.UseZip64 = UseZip64.Dynamic;
        foreach (string sourceFile in sourceFileList)
        {
          using (System.IO.FileStream fs = System.IO.File.OpenRead(sourceFile))
          {
            long m = 1024 * 1024 * 2; //
            byte[] buffer = null;

            int index = sourceFile.LastIndexOf("\\");
            string fileName = sourceFile.Substring(index + 1, sourceFile.Length - index - 1);
            ZipEntry entry = new ZipEntry(fileName);
            entry.DateTime = DateTime.Now;
            //entry.ForceZip64();//file size>4G--UseZip64 = UseZip64.Dynamic,ignore this line

            zipout.PutNextEntry(entry);

            for (long i = 1; i <= fs.Length / m + 1; i++)
            {
              if (m * i < fs.Length)
              {
                buffer = new byte[m];
                fs.Seek(m * (i - 1), System.IO.SeekOrigin.Begin);
              }
              else
              {
                if (fs.Length < m)
                {
                  buffer = new byte[fs.Length];
                }
                else
                {
                  buffer = new byte[fs.Length - m * (i - 1)];
                  fs.Seek(m * (i - 1), System.IO.SeekOrigin.Begin);
                }
              }
              fs.Read(buffer, 0, buffer.Length);
              zipout.Write(buffer, 0, buffer.Length);
              zipout.Flush();
            }//end for
          }//end using
        }//end foreach
      }//end using
    }
  }
}
