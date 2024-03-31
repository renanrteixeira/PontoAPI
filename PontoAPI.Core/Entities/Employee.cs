using System.ComponentModel.DataAnnotations;

namespace PontoAPI.Core.Entities
{
    public class Employee : BaseId
    {
        public string? Name { get; set; }
        public DateOnly Admission { get; set; }
        public char Gender { get; set; }
        public char Status { get; set; }
        public Guid RoleId { get; set; }
        public Guid CompanyId { get; set; }

        public Role? Role { get; set; }
        public Company? Company { get; set; }
        public ICollection<Hour>? Hours { get; set; }
    }
}