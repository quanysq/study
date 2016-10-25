using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Console028
{
  /// <summary>
  /// read NBI.Configuration.config
  /// </summary>
  public class C7
  {
    public static void Execute()
    {
      //string xmlpath = @"D:\VS2013\TestByConsole\Console028\XML\NBIConfig.xml";
      //SerializableDictionary<string, DBConnectionBase> dbinfo = new SerializableDictionary<string, DBConnectionBase>(); 
      //dbinfo = DeSerilizeObject<SerializableDictionary<string, DBConnectionBase>>(xmlpath);

      string xmlpath = @"D:\VS2013\TestByConsole\Console028\XML\NBI.Configuration.config";

      XmlDocument xml = new XmlDocument();
      xml.Load(xmlpath);

      XmlElement xlist = xml.SelectSingleNode("//Configuration/DBConnections") as XmlElement;
      string xmlstr = "<DBConnections>" + xlist.InnerXml + "</DBConnections>";
      Console.WriteLine(xmlstr);

      SerializableDictionary<string, DBConnectionBase> dbinfo = DeSerilizeObjectByXMLString<SerializableDictionary<string, DBConnectionBase>>(xmlstr);
    }

    public static T DeSerilizeObjectByXMLString<T>(string xmlDoccontent)
    {
      if (string.IsNullOrWhiteSpace(xmlDoccontent)) { return default(T); }
      XmlDocument xmlDoc = new XmlDocument();
      xmlDoc.LoadXml(xmlDoccontent);
      return DeSerilizeObject<T>(xmlDoc);
    }

    public static T DeSerilizeObject<T>(string path)
    {
      XmlDocument xmlDoc = new XmlDocument();
      try
      {
        xmlDoc.Load(path);
      }
      catch
      {
        throw;
      }
      return DeSerilizeObject<T>(xmlDoc);
    }

    public static T DeSerilizeObject<T>(XmlDocument xmlDoc)
    {
      if (xmlDoc == null) { return default(T); }
      XmlNode xmlNode = xmlDoc.DocumentElement;
      XmlNodeReader xmlReader = new XmlNodeReader(xmlNode);
      XmlRootAttribute xRoot = new XmlRootAttribute();
      xRoot.ElementName = xmlNode.Name;

      xRoot.IsNullable = true;

      XmlSerializer serializer = new XmlSerializer(typeof(T), xRoot);

      object obj = serializer.Deserialize(xmlReader);
      return (T)obj;
    }
  }

  [Serializable]
  [System.Xml.Serialization.XmlInclude(typeof(DBConnectionSQLServer))]
  public class DBConnectionBase
  {
    public string Name { get; set; }
    public ConnectionType ConnectionType { get; set; }
    public string Host { get; set; }
    public string User { get; set; }
    public string Password { get; set; }
  }

  [Serializable, XmlRoot(ElementName = "DBConnectionSQLServer", IsNullable = true)]
  public class DBConnectionSQLServer : DBConnectionBase
  {
    public DBConnectionSQLServer()
    {
      this.ConnectionType = ConnectionType.MsSqlServer;
    }

    #region Connection
    public string Pooling { get; set; }
    public string MinPoolSize { get; set; }
    public string MaxPoolSize { get; set; }
    public string ConnectionLifetime { get; set; }
    public string Catalog { get; set; }
    public string WindowsAuthentication { get; set; }
    public string UseCurrentUser { get; set; }
    public string ConnectAsUser { get; set; }
    public string ConnectAsPassword { get; set; }
    #endregion

  }

  [Serializable]
  public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, IXmlSerializable
  {

    #region

    public SerializableDictionary()
      : base()
    {
    }

    public SerializableDictionary(IDictionary<TKey, TValue> dictionary)
      : base(dictionary)
    {
    }


    public SerializableDictionary(IEqualityComparer<TKey> comparer)
      : base(comparer)
    {
    }


    public SerializableDictionary(int capacity)
      : base(capacity)
    {
    }

    public SerializableDictionary(int capacity, IEqualityComparer<TKey> comparer)
      : base(capacity, comparer)
    {
    }

    protected SerializableDictionary(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
    }

    #endregion



    #region realize IXmlSerializable

    public XmlSchema GetSchema()
    {
      return null;
    }

    public void WriteXml(XmlWriter write)
    {
      XmlSerializer KeySerializer = new XmlSerializer(typeof(TKey));
      XmlSerializer ValueSerializer = new XmlSerializer(typeof(TValue));

      try
      {
        foreach (KeyValuePair<TKey, TValue> kv in this)
        {
          write.WriteStartElement("SerializableDictionary");
          write.WriteStartElement("key");
          KeySerializer.Serialize(write, kv.Key, SerializeHelper.GetNamespaces());
          write.WriteEndElement();
          write.WriteStartElement("value");
          ValueSerializer.Serialize(write, kv.Value, SerializeHelper.GetNamespaces());
          write.WriteEndElement();
          write.WriteEndElement();
        }
      }
      catch (Exception exception)
      {
        throw exception;
      }

    }
    public void ReadXml(XmlReader reader)
    {

      XmlSerializer KeySerializer = new XmlSerializer(typeof(TKey));
      XmlSerializer ValueSerializer = new XmlSerializer(typeof(TValue));
      if (reader.IsEmptyElement || !reader.Read())
      {
        return;
      }


      while (reader.NodeType != XmlNodeType.EndElement)
      {
        reader.ReadStartElement("SerializableDictionary");
        reader.ReadStartElement("key");
        TKey tk = (TKey)KeySerializer.Deserialize(reader);
        reader.ReadEndElement();
        reader.ReadStartElement("value");
        TValue vl = (TValue)ValueSerializer.Deserialize(reader);
        reader.ReadEndElement();
        reader.ReadEndElement();
        this.Add(tk, vl);
        reader.MoveToContent();
      }
      reader.ReadEndElement();
    }


    #endregion
  }

  public static class SerializeHelper
  {
    public static XmlSerializerNamespaces GetNamespaces()
    {
      XmlSerializerNamespaces ns;
      ns = new XmlSerializerNamespaces();
      ns.Add(String.Empty, String.Empty);
      return ns;
    }

    /// <summary>
    /// get  binarySerilize 
    /// </summary>
    /// <param name="pObj"></param>
    /// <returns>if pObj is Null，return Null</returns>
    public static byte[] GetSerilizeBytes(object pObj)
    {
      if (pObj == null) { return null; }
      MemoryStream serializationStream = new MemoryStream();
      new BinaryFormatter().Serialize(serializationStream, pObj);
      serializationStream.Position = 0L;
      byte[] buffer = new byte[serializationStream.Length];
      serializationStream.Read(buffer, 0, buffer.Length);
      serializationStream.Close();
      return buffer;
    }

    /// <summary>
    /// Get Serilized XmlDoc
    /// </summary>
    /// <param name="pObj"></param>
    /// <returns>if pObj is Null，return Null</returns>
    public static XmlDocument GetSerilizeXmlDoc(object pObj)
    {
      if (pObj == null) { return null; }

      XmlSerializer serializer = new XmlSerializer(pObj.GetType());
      StringBuilder sb = new StringBuilder();
      StringWriter writer = new StringWriter(sb);
      serializer.Serialize((TextWriter)writer, pObj, SerializeHelper.GetNamespaces());
      XmlDocument document = new XmlDocument();
      document.LoadXml(sb.ToString());
      writer.Close();
      return document;
    }

    /// <summary>
    /// get object from serialized binary 
    /// </summary>
    /// <typeparam name="T">what type you want to get</typeparam>
    /// <param name="binData"></param>
    /// <returns></returns>
    public static T GetDeSerilizeObject<T>(byte[] binData)
    {
      if (binData == null) { return default(T); }
      BinaryFormatter formatter = new BinaryFormatter();
      MemoryStream serializationStream = new MemoryStream(binData);
      return (T)formatter.Deserialize(serializationStream);
    }

    /// <summary>
    /// get object from serialized xmlDoc 
    /// </summary>
    /// <typeparam name="T">what type you want to get</typeparam>
    /// <param name="xmlDoc">serialized xmlDoc</param>
    /// <returns></returns>
    public static T DeSerilizeObject<T>(XmlDocument xmlDoc)
    {
      if (xmlDoc == null) { return default(T); }
      XmlNode xmlNode = xmlDoc.DocumentElement;
      XmlNodeReader xmlReader = new XmlNodeReader(xmlNode);
      XmlRootAttribute xRoot = new XmlRootAttribute();
      xRoot.ElementName = xmlNode.Name;

      xRoot.IsNullable = true;


      XmlSerializer serializer = new XmlSerializer(typeof(T), xRoot);

      object obj =
      serializer.Deserialize(xmlReader);
      return (T)obj;
    }

    public static T DeSerilizeObjectByXMLString<T>(string xmlDoccontent)
    {
      if (string.IsNullOrWhiteSpace(xmlDoccontent)) { return default(T); }
      XmlDocument xmlDoc = new XmlDocument();
      xmlDoc.LoadXml(xmlDoccontent);
      return DeSerilizeObject<T>(xmlDoc);
    }

    public static T DeSerilizeObject<T>(XmlReader xmlDoc)
    {
      //if (xmlDoc == null) { return default(T); }
      //XmlNodeReader xmlReader = new XmlNodeReader(xmlDoc.DocumentElement);
      XmlSerializer serializer = new XmlSerializer(typeof(T));
      return (T)serializer.Deserialize(xmlDoc);
    }

    public static T DeSerilizeObject<T>(string path)
    {
      XmlDocument xmlDoc = new XmlDocument();
      try
      {
        xmlDoc.Load(path);
      }
      catch
      {
        throw;
      }
      return DeSerilizeObject<T>(xmlDoc);
    }

    /// <summary>
    /// save Serilized Object as a xml file
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="path">save xml file to the path</param>
    public static void SerilizeObject(object obj, string path)
    {
      try
      {

        using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.Read))
        {
          XmlSerializer xs = new XmlSerializer(obj.GetType());
          xs.Serialize(fs, obj, SerializeHelper.GetNamespaces());
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public static string SerilizeObject(object obj)
    {
      try
      {
        StringBuilder bufferSt = new StringBuilder();

        using (StringWriter stringWriter = new StringWriter(bufferSt))
        {
          XmlSerializer xs = new XmlSerializer(obj.GetType());
          xs.Serialize(stringWriter, obj, SerializeHelper.GetNamespaces());
        }
        return bufferSt.ToString();

      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
  }

  public enum ConnectionType
  {
    Null,
    Oracle,
    MsSqlServer,
    MySQL,
    Sybase,
    DB2,
    Postgres,
    CSV
  }
}
