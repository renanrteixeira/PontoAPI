using System.ComponentModel.DataAnnotations;
using PontoAPI.Core.Entities.Enum;

namespace PontoAPI.Core.Entities
{
    public class Hour : BaseId
    {
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public DateOnly Date { get; set; }
        [Required]
        public TypeHour Type { get; set; }  //Gerar enumerable
        [Required]
        public int TypeDateId { get; set; }
        [Required]
        public TimeSpan Hour1 { get; set; }
        [Required]
        public TimeSpan Hour2 { get; set; }
        [Required]
        public TimeSpan Hour3 { get; set; }
        [Required]
        public TimeSpan Hour4 { get; set; }
        [Required]
        public TimeSpan Hour5 { get; set; }
        [Required]
        public TimeSpan Hour6 { get; set; }
        [Required]
        public TimeSpan Balance { get; set; }

        public TypeDate? TypeDate { get; set; }
        public Employee? Employee { get; set; }
    }
}