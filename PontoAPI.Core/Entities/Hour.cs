using System.ComponentModel.DataAnnotations;
using PontoAPI.Core.Entities.Enum;

namespace PontoAPI.Core.Entities
{
    public class Hour
    {
        [Key, Required]
        public int Id { get; set; }

        [Required]
        public Employe Employefk { get; set; }

        [Required]
        public DateOnly Date { get; set; }

        [Required]
        public TypeHour Type { get; set; }  //Gerar enumerable

        [Required]
        public TypeDate TypeDatefk { get; set; }

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
        public TimeSpan balance { get; set; }
    }
}
