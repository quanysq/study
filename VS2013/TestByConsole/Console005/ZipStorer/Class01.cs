using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library001;
using System.Diagnostics;

namespace Console005.ZipStorer
{
  class C1
  {
    public static void Execute()
    {
      var sourceFolder = @"C:\Program Files\BDNA\JackyTest\637104969393433997";
      var outZipFile = @"C:\Program Files\BDNA\JackyTest\637104969393433997.zip";

      Stopwatch sw = new Stopwatch();
      sw.Start();
      //ZipUsingZipStorer(sourceFolder, outZipFile);
      //ZipUsing7Zip(sourceFolder, outZipFile);
      CalcFilesSize(sourceFolder);
      sw.Stop();
      CustomLogger.DEFAULT.InfoFormat("Elapsed: [{0}], ElapsedMilliseconds: [{1}]", sw.Elapsed, sw.ElapsedMilliseconds);
    }

    private static void ZipUsingZipStorer(string sourceFolder, string outZipFile)
    {
      ZipStorer zip = null;
      try
      {
        zip = ZipStorer.Create(outZipFile, "");
        Console.WriteLine("Created zip file: [{0}]", outZipFile);

        DirectoryInfo dir = new DirectoryInfo(sourceFolder);
        var fileList = dir.GetFiles("*.*");
        Console.WriteLine("Will zip [{0}] files...", fileList.Length);
        var i = 0;
        foreach (var file in fileList)
        {
          i++;
          var sourceFile = file.FullName;
          var fileName = Path.GetFileName(sourceFile);
          zip.AddFile(ZipStorer.Compression.Store, sourceFile, fileName, "");
          CustomLogger.DEFAULT.InfoFormat("[{1}] Added [{0}] to zip file", sourceFile, i);
        }
        Console.WriteLine("OK");
      }
      catch (Exception ex)
      {
        CustomLogger.DEFAULT.Error(ex);
        Console.WriteLine("Fail");
      }
      finally
      {
        if (zip != null) zip.Close();
      }
    }

    private static void ZipUsing7Zip(string sourceFolder, string outZipFile)
    {
      Console.WriteLine("Beginning zip...");
      string zipExePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "7-zip", "7z.exe");
      string filesPath = Path.Combine(sourceFolder, "*");
      //string cpuNumber = "4";
      //string cmd = string.Format("{0} a -tzip -m=Copy -mx=3 -mmt={3} \"{1}\" \"{2}\" -sdel", zipExePath, outZipFile, filesPath, cpuNumber);
      //string cmd = string.Format("\"{0}\" a -tzip -mx=0 -mmt={3} \"{1}\" \"{2}\"", zipExePath, outZipFile, filesPath, cpuNumber);
      //string cmd = string.Format("\"{0}\" a -tzip -mx=0 -mmt=on \"{1}\" \"{2}\"", zipExePath, outZipFile, filesPath);
      string cmd = string.Format("\"{0}\" a -tzip -mx=0 -mmt=off \"{1}\" \"{2}\"", zipExePath, outZipFile, filesPath);
      string errorMsg = "";
      string outputMsg = "";
      bool cmdResult = ExecuteCmdCommand(cmd, ref errorMsg, ref outputMsg);
      if (cmdResult)
      {
        Console.WriteLine("OK");
      }
      else
      {
        Console.WriteLine("Fail");
        if (!string.IsNullOrWhiteSpace(errorMsg))
        {
          CustomLogger.DEFAULT.ErrorFormat("Fail. Error message: [{0}]", errorMsg);
        }
      }
    }

    private static bool ExecuteCmdCommand(string commandLine, ref string errorMsg, ref string outputMsg)
    {
      //logger.Debug("net use start...");
      bool Flag = false;
      Process proc = new Process();
      string dosLine = "";
      try
      {
        proc.StartInfo.FileName = "cmd.exe";
        proc.StartInfo.UseShellExecute = false;
        proc.StartInfo.RedirectStandardInput = true;
        proc.StartInfo.RedirectStandardOutput = true;
        proc.StartInfo.RedirectStandardError = true;
        proc.StartInfo.CreateNoWindow = true;
        proc.Start();

        dosLine = commandLine;
        proc.StandardInput.WriteLine(dosLine);
        proc.StandardInput.WriteLine("exit");
        errorMsg = proc.StandardError.ReadToEnd();
        if (!string.IsNullOrEmpty(errorMsg))
        {
          CustomLogger.DEFAULT.Info(errorMsg);
        }
        outputMsg = proc.StandardOutput.ReadToEnd();
        if (!string.IsNullOrEmpty(outputMsg))
        {
          CustomLogger.DEFAULT.Info(outputMsg);

        }
        proc.WaitForExit();

        if (proc.ExitCode == 0)
        {
          Flag = true;
        }
        proc.StandardError.Close();
      }
      catch (Exception ex)
      {
        CustomLogger.DEFAULT.Error("Error occurred while executing CMD.", ex);
      }
      finally
      {
        proc.Close();
        proc.Dispose();
      }
      return Flag;
    }

    private static void CalcFilesSize(string sourceFolder)
    {
      DirectoryInfo dir = new DirectoryInfo(sourceFolder);
      var fileList = dir.GetFiles("*.*");
      Console.WriteLine("Will calc all [{0}] files size...", fileList.Length);
      long fileByteSize = 0;
      foreach (var file in fileList)
      {
        fileByteSize += file.Length;
      }
      //long fileByteSizeOf4GB = 4294967296; //4GB
      long fileKBSize = (fileByteSize / 1024);
      Console.WriteLine("OK! All files size are: [KB: {0}] [Byte: {1}]", fileKBSize, fileByteSize);
    }
  }
}
