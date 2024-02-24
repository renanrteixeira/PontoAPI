using System.ComponentModel.DataAnnotations;

namespace PontoAPI.Core.Entities
{
    public class User : BaseId
    {
        [Required, StringLength(50)]
        public string? Name { get; set; }
        [Required, StringLength(255)]
        public string? Email { get; set; }
        [Required, StringLength(255)]
        public string? UserName { get; set; }
        [Required, StringLength(255)]
        public string? Password { get; set; }
        [Required, StringLength(1)]
        public char Admin { get; set; }
        [Required, StringLength(1)]
        public char Status { get; set; }
    }
}