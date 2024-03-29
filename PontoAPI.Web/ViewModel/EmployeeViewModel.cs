namespace PontoAPI.Web.ViewModel
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateOnly Admission { get; set; }
        public char Gender { get; set; }
        public char Status { get; set; }
        public int RoleId { get; set; }
        public int CompanyId { get; set; }
    }
}