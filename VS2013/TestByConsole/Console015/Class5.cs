using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Console015
{
  public class Class5
  {
    public static void Execute()
    {
      Console.WriteLine("[{0}] Downloading...", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
      HttpClient client = new HttpClient();

      string _address = "http://124.172.174.187:8888/vliveshow.Client/release/Setup_Dev_1.0.0.22.exe";
      // Send asynchronous request
      client.GetAsync(_address).ContinueWith(
          (requestTask) =>
          {
            // Get HTTP response from completed task.
            HttpResponseMessage response = requestTask.Result;

            // Check that response was successful or throw exception
            response.EnsureSuccessStatusCode();

            // Read response asynchronously and save to file
            response.Content.ReadAsFileAsync(@"d:\Setup_Dev_1.0.0.22.exe", true).ContinueWith(
                (readTask) =>
                {
                  Console.WriteLine("[{0}] Downloaded.", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                  //Process process = new Process();
                  //process.StartInfo.FileName = "output.png";
                  //process.Start();
                });
          });
      Console.ReadLine();
    }

    public static async Task HttpGetForLargeFileInRightWay()
    {
      using (HttpClient client = new HttpClient())
      {
        const string url = "http://124.172.174.187:8888/vliveshow.Client/release/Setup_Dev_1.0.0.22.exe";
        using (HttpResponseMessage response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead))
        using (Stream streamToReadFrom = await response.Content.ReadAsStreamAsync())
        {
          string fileToWriteTo = @"d:\Setup_Dev_1.0.0.22.exe"; //Path.GetTempFileName();
          using (Stream streamToWriteTo = File.Open(fileToWriteTo, FileMode.Create))
          {
            await streamToReadFrom.CopyToAsync(streamToWriteTo);
          }
        }
      }
    }
  }

  public static class HttpContentExtensions
  {
    public static Task ReadAsFileAsync(this HttpContent content, string filename, bool overwrite)
    {
      string pathname = Path.GetFullPath(filename);
      if (!overwrite && File.Exists(filename))
      {
        throw new InvalidOperationException(string.Format("File {0} already exists.", pathname));
      }

      FileStream fileStream = null;
      try
      {
        fileStream = new FileStream(pathname, FileMode.Create, FileAccess.Write, FileShare.None);
        return content.CopyToAsync(fileStream).ContinueWith(
            (copyTask) =>
            {
              fileStream.Close();
            });
      }
      catch
      {
        if (fileStream != null)
        {
          fileStream.Close();
        }

        throw;
      }
    }
  }
}
