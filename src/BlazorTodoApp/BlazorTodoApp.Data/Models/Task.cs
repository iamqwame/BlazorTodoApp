using MongoDB.Bson.Serialization.Attributes;
using System;

namespace BlazorTodoApp.Data.Models
{
    public class Task
    {
        [BsonId]
        public Guid TaskId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsCompleted { get; set; }

    }
}
