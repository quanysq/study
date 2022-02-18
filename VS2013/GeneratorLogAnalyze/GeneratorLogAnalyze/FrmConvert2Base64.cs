using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneratorLogAnalyze
{
  public partial class FrmConvert2Base64 : Form
  {
    public FrmConvert2Base64()
    {
      InitializeComponent();
    }

    private string ReadFile(string path, Int64 startBlock, Int64 endBlock, Int64 block_size)
    {
      string fileBody = "";
      if (!File.Exists(path))
      {
        return "";
      }
      FileInfo fi = new FileInfo(path);
      FileStream fs = new System.IO.FileStream(fi.FullName, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.Read);
      try
      {
        MessageBox.Show("fi.Length: " + fi.Length);
        string fileName = fi.Name;
        if (startBlock + block_size > fi.Length)
        {
          block_size = fi.Length - startBlock;
        }
        byte[] buffer = new Byte[block_size];
        //fs.Seek(bolck_start,
        fs.Seek(startBlock, SeekOrigin.Begin);
        fs.Read(buffer, 0, (int)block_size);
        endBlock = startBlock + block_size;
        if (buffer.Length > 0)
        {
          fileBody = Convert.ToBase64String(buffer);
        }
      }
      catch { }
      finally
      {
        fs.Close();
      }
      return fileBody;
    }


    private void btnFile_Click(object sender, EventArgs e)
    {
      string filePath  = txtFile.Text.Trim();
      Int64 startBlock = Convert.ToInt64(txtStartBlock.Text.Trim());
      Int64 endBlock   = Convert.ToInt64(this.txtEndBlock.Text.Trim());
      Int64 block_size = Convert.ToInt64(this.txtBlockSize.Text.Trim());
      txtResult.Text = ReadFile(filePath, startBlock, endBlock, block_size);
    }

    private void btnString_Click(object sender, EventArgs e)
    {
      string text = txtFile.Text.Trim();
      byte[] b = Encoding.UTF8.GetBytes(text);
      txtResult.Text = Convert.ToBase64String(b);
    }

    private void btnBase_Click(object sender, EventArgs e)
    {
      string baseString = txtFile.Text.Trim();
      byte[] b = Convert.FromBase64String(baseString);
      txtResult.Text = Encoding.UTF8.GetString(b);
    }
  }
}
