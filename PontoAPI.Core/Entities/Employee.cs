using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PontoAPI.Core.Entities
{
    public class Employee : BaseId
    {
        [Required, StringLength(50)]
        public string Name { get; set; }
        [Required, ForeignKey("Rolefk")]
        public virtual Role Role { get; set; }
        [Required]
        public DateTime Admission { get; set; }
        [Required, StringLength(1)]
        public char Gender { get; set; }
        [Required, StringLength(1)]
        public char Status { get; set; }
        [Required, ForeignKey("Companyfk")]
        public virtual Company Company { get; set; }
        //    [Required]
        //public Employee Employeefk { get; set; }
    }
}
