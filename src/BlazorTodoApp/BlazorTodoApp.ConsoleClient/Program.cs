using BlazorTodoApp.Data;
using BlazorTodoApp.Data.Models;
using System;

namespace BlazorTodoApp.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //creating an instance of our mongo db
            var db = new MongoApplicationContext("Todo");
            
            //Adding new task

            db.AddTask(new Task
            {
                Name = "task_",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(1),
                Description = "momo data ",
                IsCompleted = false,

            });

            //Getting list of inserted task
            var dats = db.GetTasks();
           
            Console.WriteLine("Hello World!");
        }
    }
}
