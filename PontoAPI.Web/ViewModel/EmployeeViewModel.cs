namespace PontoAPI.Web.ViewModel
{
    public class EmployeeViewModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public DateOnly Admission { get; set; }
        public char Gender { get; set; }
        public char Status { get; set; }
        public Guid RoleId { get; set; }
        public Guid CompanyId { get; set; }
    }
}