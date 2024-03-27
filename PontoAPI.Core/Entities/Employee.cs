using System.ComponentModel.DataAnnotations;

namespace PontoAPI.Core.Entities
{
    public class Employee : BaseId
    {
        public string? Name { get; set; }
        public DateOnly Admission { get; set; }
        public char Gender { get; set; }
        public char Status { get; set; }
        public int RoleId { get; set; }
        public int CompanyId { get; set; }

        public Role? Role { get; set; }
        public Company? Company { get; set; }
        public ICollection<Hour>? Hours { get; set; }
    }
}