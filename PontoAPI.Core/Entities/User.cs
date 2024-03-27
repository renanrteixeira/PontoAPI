using System.ComponentModel.DataAnnotations;

namespace PontoAPI.Core.Entities
{
    public class User : BaseId
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public char Admin { get; set; }
        public char Status { get; set; }
    }
}