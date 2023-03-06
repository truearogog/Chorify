using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chorify.EntityFramework.Dtos
{
    public class ChoreDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }

        public Guid UserId { get; set; }
        public UserDto User { get; set; }

        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
