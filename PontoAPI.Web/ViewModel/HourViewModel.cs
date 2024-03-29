using PontoAPI.Core.Entities;
using PontoAPI.Core.Entities.Enum;

namespace PontoAPI.Web.ViewModel
{
    public class HourViewModel
    {
        public Guid Id { get; set; }
        public int EmployeeId { get; set; }
        public DateOnly Date { get; set; }
        public TypeHour Type { get; set; }
        public int TypeDateId { get; set; }
        public TimeSpan Hour1 { get; set; }
        public TimeSpan Hour2 { get; set; }
        public TimeSpan Hour3 { get; set; }
        public TimeSpan Hour4 { get; set; }
        public TimeSpan Hour5 { get; set; }
        public TimeSpan Hour6 { get; set; }
        public TimeSpan Balance { get; set; }
    }
}