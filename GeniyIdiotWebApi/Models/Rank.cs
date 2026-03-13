namespace GeniyIdiotWebApi.Models
{
    public class Rank
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Rank() { }
        public Rank(int id, string name, int count)
        {
            Id = id;
            Name = name;
        }
    }
}
