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
        private readonly string _name = typeof(Task).Name;

        public MongoApplicationContext(string databaseName)
        {
            var client = new MongoClient();
            _db = client.GetDatabase(databaseName);
        }

        public void AddTask(Task task)
        {
            var collection = _db.GetCollection<Task>(_name);
            collection.InsertOne(task);
        }

        public List<Task> GetTasks()
        {
            var collection = _db.GetCollection<Task>(_name);
            return collection.Find(new BsonDocument()).ToList();
        }

        public Task GetTask(Guid id)
        {
            var collection = _db.GetCollection<Task>(_name);
            var task = collection.Find(a => a.TaskId == id).FirstOrDefault();
            return task;
        }
    }
}
