using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace PontoAPI.Core.Entities
{
    public class Company
    {
        [Key, Required]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; }

    }
}
