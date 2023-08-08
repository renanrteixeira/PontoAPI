using System.ComponentModel.DataAnnotations;

namespace PontoAPI.Core.Entities
{
    public class Role : BaseId
    {
        [Required, StringLength(50)]
        public string? Name { get; set; }

        public ICollection<Employee>? Employees { get; set; }
    }
}