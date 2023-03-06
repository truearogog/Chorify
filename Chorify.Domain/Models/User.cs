using System.ComponentModel.DataAnnotations;

namespace Chorify.Domain.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public User(Guid id, string email, string passwordHash)
        {
            Id = id;
            Email = email;
            PasswordHash = passwordHash;
        }
    }
}
