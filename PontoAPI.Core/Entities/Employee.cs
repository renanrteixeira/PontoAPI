using System.ComponentModel.DataAnnotations;

namespace PontoAPI.Core.Entities
{
    public class Employe : BaseId
    {
        [Required, StringLength(50)]
        public string Name { get; set; }

        [Required]
        public Role Rolefk { get; set; }

        [Required]
        public DateTime Admission { get; set; }

        [Required, StringLength(1)]
        public char Gender { get; set; }

        [Required, StringLength(1)]
        public char Status { get; set; }

        [Required]
        public Employee Employeefk { get; set; }
    }
}
