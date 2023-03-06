﻿namespace Chorify.Domain.Models
{
    public class Chore
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public Guid UserId { get; set; }

        public Chore(Guid id, string name, string description, string color, Guid? userId = null)
        {
            Id = id;
            Name = name;
            Description = description;
            Color = color;

            if (userId.HasValue) UserId = userId.Value;
        }
    }
}
