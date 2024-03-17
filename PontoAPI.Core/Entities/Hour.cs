using System.ComponentModel.DataAnnotations;
using PontoAPI.Core.Entities.Enum;

namespace PontoAPI.Core.Entities
{
    public class Hour : BaseId
    {
        public int EmployeeId { get; set; }
        public DateOnly Date { get; set; }
        public TypeHour Type { get; set; }  //Gerar enumerable
        public int TypeDateId { get; set; }
        public TimeSpan Hour1 { get; set; }
        public TimeSpan Hour2 { get; set; }
        public TimeSpan Hour3 { get; set; }
        public TimeSpan Hour4 { get; set; }
        public TimeSpan Hour5 { get; set; }
        public TimeSpan Hour6 { get; set; }
        public TimeSpan Balance { get; set; }

        public TypeDate? TypeDate { get; set; }
        public Employee? Employee { get; set; }
    }
}