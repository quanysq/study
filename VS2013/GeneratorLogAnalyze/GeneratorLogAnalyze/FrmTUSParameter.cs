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
using zlib;

namespace GeneratorLogAnalyze
{
  public partial class FrmTUSParameter : Form
  {
    public FrmTUSParameter()
    {
      InitializeComponent();
    }

    private void FrmTUSParameter_Load(object sender, EventArgs e)
    {
      txtParameter.SelectAll();
    }

    private void btnDecrypt_Click(object sender, EventArgs e)
    {
      try
      {
        var requestinfoStr = txtParameter.Text.Trim();
        byte[] dCompressString = Convert.FromBase64String(requestinfoStr);
        byte[] dBytes = Decompress(dCompressString);
        txtResult.Text = Encoding.UTF8.GetString(dBytes);
      }
      catch (System.Net.Sockets.SocketException ex)
      {
        txtResult.Text = ex.Message;
      }
    }

    private byte[] Decompress(byte[] inData)
    {
      byte[] outData;
      using (MemoryStream outMemoryStream = new MemoryStream())
      using (ZOutputStream outZStream = new ZOutputStream(outMemoryStream))
      {
        outZStream.Write(inData, 0, inData.Length);
        outZStream.finish();
        outData = outMemoryStream.ToArray();
      }
      return outData;
    }

  }
}
