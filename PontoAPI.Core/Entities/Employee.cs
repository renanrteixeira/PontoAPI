using System.ComponentModel.DataAnnotations;

namespace PontoAPI.Core.Entities
{
    public class Employee : BaseId
    {
        [Required, StringLength(50)]
        public string? Name { get; set; }
        [Required]
        public int RoleId { get; set; }
        public Role? Role { get; set; }
        [Required]
        public DateOnly Admission { get; set; }
        [Required, StringLength(1)]
        public char Gender { get; set; }
        [Required, StringLength(1)]
        public char Status { get; set; }
        [Required]
        public int CompanyId { get; set; }
        public Company? Company { get; set; }

        public ICollection<Hour>? Hours { get; set; }
    }
}