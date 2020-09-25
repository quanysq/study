using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Console025.MongoDBTest
{
  class C1
  {
    public static void Execute(string[] args)
    {
      // Add();
      // Update();
      Delete();
      Search();
    }


    private static void Add()
    {
      string connStr ="mongodb://127.0.0.1:27017";
      string dbname="MongoDBDemo";
      var client = new MongoDB.Driver.MongoClient(connStr);
      IMongoDatabase db = client.GetDatabase(dbname);
      var collection = db.GetCollection<User>("User");
      User MongodbLog = new User();
      MongodbLog.Id=ObjectId.GenerateNewId();
      MongodbLog.Name = "Jacky";
      MongodbLog.Sex = "男";
      MongodbLog.Address = "北京市";
      MongodbLog.Age = 28;
      MongodbLog.CreateDate = DateTime.Now;
      MongodbLog.UpdateDate = DateTime.Now;
      collection.InsertOneAsync(MongodbLog);
      Console.WriteLine("OK");
    }

    private static void Update()
    {
      string connStr = "mongodb://127.0.0.1:27017";
      string dbname = "MongoDBDemo";
      var client = new MongoDB.Driver.MongoClient(connStr);
      IMongoDatabase db = client.GetDatabase(dbname);
      var collection = db.GetCollection<User>("User");
      FilterDefinition<User> filter = Builders<User>.Filter.Eq("Name", "Jacky");
      UpdateDefinition<User> updater = Builders<User>.Update.Set("Address", "广州");
      collection.UpdateOne(filter, updater);
      Console.WriteLine("OK");
    }

    private static void Search()
    {
      string connStr = "mongodb://127.0.0.1:27017";
      string dbname = "MongoDBDemo";
      var client = new MongoDB.Driver.MongoClient(connStr);
      IMongoDatabase db = client.GetDatabase(dbname);
      var collection = db.GetCollection<User>("User");
      FilterDefinition<User> filter = Builders<User>.Filter.Eq("Name", "Jacky");
      var result = collection.Find<User>(filter).ToList();
      Console.WriteLine("OK! Count: [{0}]", result.Count);
      if (result.Count > 0) Console.WriteLine(result[0].Name);
    }

    private static void Delete()
    {
      string connStr = "mongodb://127.0.0.1:27017";
      string dbname = "MongoDBDemo";
      var client = new MongoDB.Driver.MongoClient(connStr);
      IMongoDatabase db = client.GetDatabase(dbname);
      var collection = db.GetCollection<User>("User");
      FilterDefinition<User> filter = Builders<User>.Filter.Eq("Name", "Jacky");
      collection.DeleteOne(filter);
      Console.WriteLine("OK");
    }

    class User
    {
      public ObjectId Id { get; set; }
      public string Name { get; set; }
      public string Sex { get; set; }
      public string Address { get; set; }
      public int Age { get; set; }
      public DateTime CreateDate { get; set; }
      public DateTime UpdateDate { get; set; } 
    }
  }


}
