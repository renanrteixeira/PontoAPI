using System.ComponentModel.DataAnnotations;

namespace PontoAPI.Core.Entities
{
    public class Role : BaseId
    {
        public string? Name { get; set; }

        public  ICollection<Employee>? Employees { get; set; }
    }
}