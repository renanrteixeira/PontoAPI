using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PontoAPI.Models
{
    public class Employe
    {
        [Key, Required]
        public int Id { get; set; }

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
        public Employe Employefk { get; set; }
    }
}
