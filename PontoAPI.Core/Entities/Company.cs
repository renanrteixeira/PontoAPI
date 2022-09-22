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

        [Required, StringLength(500)]
        public string address { get; set; }

        [Required, StringLength(50)]
        public string telephone { get; set; }

    }
}
