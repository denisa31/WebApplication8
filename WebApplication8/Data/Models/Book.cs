using Microsoft.AspNetCore.Mvc;

namespace WebApplication8.Data.Models
{
    public class Book
    {
        public string name { get; set; }
        public object Name { get; internal set; }
        public int id { get; set; }
        public int Id { get; internal set; }
        public string title { get; set; }
        public string description { get; set; }
        public string author { get; set; }
                
    }
}
