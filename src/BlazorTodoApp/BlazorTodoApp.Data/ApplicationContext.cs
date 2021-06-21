using BlazorTodoApp.Data.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace BlazorTodoApp.Data
{
    public class MongoApplicationContext
    {
        private readonly IMongoDatabase _db;

        public MongoApplicationContext(string databaseName)
        {
            var client = new MongoClient();
            _db = client.GetDatabase(databaseName);
        }

        public void AddTask(Task task)
        {
            string collectionName = typeof(Task).Name;
            var collection = _db.GetCollection<Task>(collectionName);
            collection.InsertOne(task);
        }

        public List<Task> GetTasks()
        {
            string collectionName = typeof(Task).Name;
            var collection = _db.GetCollection<Task>(collectionName);
            return collection.Find(new BsonDocument()).ToList();
        }

        public Task GetTask(Guid id)
        {
            string collectionName = typeof(Task).Name;
            var collection = _db.GetCollection<Task>(collectionName);
            var task = collection.Find(a => a.TaskId == id).FirstOrDefault();
            return task;
        }
    }
}
