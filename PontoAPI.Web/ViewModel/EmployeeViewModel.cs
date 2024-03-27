namespace PontoAPI.Web.ViewModel
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public RoleViewModel? Role { get; set; }
        public DateTime Admission { get; set; }
        public char Gander { get; set; }
        public char Status { get; set; }
        public CompanyViewModel? Company { get; set; }
    }
}