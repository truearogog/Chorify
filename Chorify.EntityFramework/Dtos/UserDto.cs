using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chorify.EntityFramework.Dtos
{
    public class UserDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public List<ChoreDto> Chores { get; set; }

        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
