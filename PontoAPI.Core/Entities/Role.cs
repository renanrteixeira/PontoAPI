using System.ComponentModel.DataAnnotations;

namespace PontoAPI.Core.Entities
{
    public class Role
    {
        [Key, Required]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; }
    }
}
