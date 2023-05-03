namespace WebApplication8.Data.DTOs.Library
{
    public class PutLibraryDTO
    {

        public object Name { get;  set; }
        public int Id { get; set; }

        public string Title { get;  set; }

        public string Description { get;  set; }
        public object LibraryId { get;  set; }
    }
}
