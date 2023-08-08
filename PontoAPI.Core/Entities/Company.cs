namespace PontoAPI.Core.Entities
{
    public class Company : BaseId
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Telephone { get; set; }

        public ICollection<Employee>? Employees { get; set; }
    }
}