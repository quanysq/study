using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorLogAnalyze.Common
{
  public sealed class EncryptUtil
  {
    #region DES Encryption
    private const string KEY_64 = "bdna@cla";// 8 char
    private const string IV_64 = "bdna@cla"; // 8 char

    public static string Encode(string data)
    {
      if (string.IsNullOrEmpty(data))
      {
        return null;
      }
      byte[] byKey = System.Text.ASCIIEncoding.ASCII.GetBytes(KEY_64);
      byte[] byIV = System.Text.ASCIIEncoding.ASCII.GetBytes(IV_64);

      DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
      int i = cryptoProvider.KeySize;
      MemoryStream ms = new MemoryStream();
      CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateEncryptor(byKey, byIV), CryptoStreamMode.Write);

      StreamWriter sw = new StreamWriter(cst);
      sw.Write(data);
      sw.Flush();
      cst.FlushFinalBlock();
      sw.Flush();
      return Convert.ToBase64String(ms.GetBuffer(), 0, (int)ms.Length);

    }

    public static string Decode(string data)
    {
      if (string.IsNullOrEmpty(data))
      {
        return null;
      }
      byte[] byKey = System.Text.ASCIIEncoding.ASCII.GetBytes(KEY_64);
      byte[] byIV = System.Text.ASCIIEncoding.ASCII.GetBytes(IV_64);

      byte[] byEnc;
      try
      {
        byEnc = Convert.FromBase64String(data);
      }
      catch
      {
        return null;
      }

      DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
      MemoryStream ms = new MemoryStream(byEnc);
      CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateDecryptor(byKey, byIV), CryptoStreamMode.Read);
      StreamReader sr = new StreamReader(cst);
      return sr.ReadToEnd();
    }

    public static string SafeEncode(string value)
    {
      if (string.IsNullOrEmpty(value))
        return null;
      string result = string.Empty;
      try
      {
        result = EncryptUtil.Encode(value);
      }
      catch
      {
        result = value;
      }
      return result;
    }

    public static string SafeDecode(string value)
    {
      if (string.IsNullOrEmpty(value))
        return null;
      string result = string.Empty;
      try
      {
        result = EncryptUtil.Decode(value);
        if (string.IsNullOrEmpty(result))
        {
          return value;
        }
      }
      catch
      {
        result = value;
      }
      return result;
    }
    #endregion

    #region AES Encryption
    private static byte[] _commonKey = new byte[0];
    private static byte[] _commonIv = new byte[0];
    private static string keyBody = "WQbdG5pvDFaaZKCi4td3Jrx2OvPlIQgc";
    
    /// <summary>
    /// Initializes the variable at the first time. 
    /// </summary>
    private static void InitAES(string key)
    {
      string commonKey = "";
      string commonIv = "";

      commonKey = string.IsNullOrWhiteSpace(key) ? keyBody : key;
      commonKey = commonKey.Trim();
      commonIv = commonKey.Length >= 16 ? commonKey.Substring(16, 16) : commonKey;

      if (commonIv.Length != 16 || commonKey.Length != 32) throw new Exception("The specified key length is incorrect.");

      _commonKey = Encoding.UTF8.GetBytes(commonKey);
      _commonIv = Encoding.UTF8.GetBytes(commonIv);
    }

    private static byte[] ReadAESKey(string key)
    {
      InitAES(key);
      return _commonKey;
    }

    private static byte[] ReadAESIKey(string key)
    {
      InitAES(key);
      return _commonIv;
    }
    /// <summary>
    /// Encoding the data.
    /// </summary>
    /// <param name="data">source data</param>
    /// <returns></returns>
    public static string AESEncode(string data, string keyStr, bool isCompliantFIPS)
    {
      byte[] key = ReadAESKey(keyStr);
      byte[] iv = ReadAESIKey(keyStr);
      byte[] valueByte = Encoding.UTF8.GetBytes(data);

      dynamic aes = null;
      try
      {
        if (isCompliantFIPS)
        {
          aes = new AesCryptoServiceProvider();
        }
        else
        {
          aes = new RijndaelManaged();
        }

        aes.IV = iv;
        aes.Key = key;
        aes.Mode = CipherMode.CBC;
        aes.Padding = PaddingMode.PKCS7;
        ICryptoTransform cryptoTransform = aes.CreateEncryptor();
        byte[] resultArray = cryptoTransform.TransformFinalBlock(valueByte, 0, valueByte.Length);
        return Convert.ToBase64String(resultArray, 0, resultArray.Length);
      }
      catch
      {
        throw;
      }
      finally
      {
        aes.Dispose();
      }

      /*using (RijndaelManaged ri = new RijndaelManaged())
      {
        ri.IV = iv;
        ri.Key = key;
        ri.Mode = CipherMode.CBC;
        ri.Padding = PaddingMode.PKCS7;
        ICryptoTransform cryptoTransform = ri.CreateEncryptor();
        byte[] resultArray = cryptoTransform.TransformFinalBlock(valueByte, 0, valueByte.Length);
        return Convert.ToBase64String(resultArray, 0, resultArray.Length);
      }*/

    }

    /// <summary>
    /// Decode the encoded data.
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public static string AESDecode(string data, string keyStr, bool isCompliantFIPS)
    {
      if (string.IsNullOrEmpty(data))
      {
        return "Please enter data!";
      }

      byte[] key = ReadAESKey(keyStr);
      byte[] iv = ReadAESIKey(keyStr);
      byte[] valueByte;
      try
      {
        valueByte = Convert.FromBase64String(data);
      }
      catch(Exception ex)
      {
        return string.Format("Error occurred when converting data from base64 to string. [{0}]", ex.Message);
      }

      dynamic aes = null;
      try
      {
        if (isCompliantFIPS)
        {
          aes = new AesCryptoServiceProvider();
        }
        else
        {
          aes = new RijndaelManaged();
        }
        aes.IV = iv;
        aes.Key = key;
        aes.Mode = CipherMode.CBC;
        aes.Padding = PaddingMode.PKCS7;
        ICryptoTransform cryptoTransform = aes.CreateDecryptor();
        byte[] resultArray = cryptoTransform.TransformFinalBlock(valueByte, 0, valueByte.Length);
        return Encoding.UTF8.GetString(resultArray);
      }
      catch
      {
        throw;
      }
      finally
      {
        aes.Dispose();
      }

      /*using (RijndaelManaged ri = new RijndaelManaged())
      {
        ri.IV = iv;
        ri.Key = key;
        ri.Mode = CipherMode.CBC;
        ri.Padding = PaddingMode.PKCS7;
        ICryptoTransform cryptoTransform = ri.CreateDecryptor();
        byte[] resultArray = cryptoTransform.TransformFinalBlock(valueByte, 0, valueByte.Length);
        return Encoding.UTF8.GetString(resultArray);
      }*/
    }
    #endregion AES

    #region RSA Encryption
    private static RSACryptoServiceProvider rsaEn = new RSACryptoServiceProvider();
    private static RSACryptoServiceProvider rsaDe = new RSACryptoServiceProvider();

    /// <summary>
    /// Encode the data by key.
    /// </summary>
    /// <param name="data">source data</param>
    /// <param name="key">key</param>
    /// <returns>Encoded data</returns>
    public static string RSAEncode(string data, string publicKey, bool isCompliantFIPS)
    {
      string key;
      try
      {
        key = AESDecode(publicKey, null, isCompliantFIPS);
      }
      catch
      {
        key = publicKey;
      }

      if (!string.IsNullOrEmpty(data))
      {
        rsaEn.FromXmlString(key);
        byte[] sourceBytes;
        byte[] cipherbytes = null;
        int t = (int)(Math.Ceiling((double)data.Length / (double)50));
        StringBuilder builder = new StringBuilder();

        try
        {

          for (int i = 0; i <= t - 1; i++)
          {
            sourceBytes = Encoding.UTF8.GetBytes(data.Substring(i * 50, data.Length - (i * 50) > 50 ? 50 : data.Length - (i * 50)));
            cipherbytes = rsaEn.Encrypt(sourceBytes, false);
            builder.Append(Convert.ToBase64String(cipherbytes) + ",");
          }

        }
        catch (Exception e)
        {
          throw e;
        }
        return builder.ToString();
      }
      return null;
    }

    /// <summary>
    /// Decoding the data by key.
    /// </summary>
    /// <param name="data">source data</param>
    /// <returns>decoded data.</returns>
    public static string RSADecode(string data, string privateKey, bool isCompliantFIPS)
    {
      string key;
      try
      {
        key = AESDecode(privateKey, null, isCompliantFIPS);
      }
      catch
      {
        key = privateKey;
      }

      if (!string.IsNullOrEmpty(data))
      {
        rsaDe.FromXmlString(key);
        string[] splits = new string[] { "," };
        string[] sBytes = data.Split(splits, StringSplitOptions.RemoveEmptyEntries);
        byte[] buffer;
        byte[] byteVal;
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < sBytes.Length; i++)
        {

          try
          {
            if (sBytes[i].Length < 128)
            {
              builder.Append(sBytes[i]);
            }
            else
            {
              byteVal = Convert.FromBase64String(sBytes[i]);
              buffer = rsaDe.Decrypt(byteVal, false);
              builder.Append(Encoding.UTF8.GetString(buffer));
            }
          }
          catch (Exception)
          {
            throw;
          }

        }

        string test = builder.ToString();
        return builder.ToString();
      }

      return null;
    }
    

    #endregion RSA
  }
}
