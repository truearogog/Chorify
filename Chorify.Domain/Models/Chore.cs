namespace Chorify.Domain.Models
{
    public class Chore
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }

        public Chore(Guid id, string name, string description, string color)
        {
            Id = id;
            Name = name;
            Description = description;
            Color = color;
        }
    }
}
