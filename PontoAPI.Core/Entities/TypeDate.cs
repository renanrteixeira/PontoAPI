using System.ComponentModel.DataAnnotations;

namespace PontoAPI.Core.Entities
{
    public class TypeDate : BaseId
    {
        [Required, StringLength(50)]
        public string? Name { get; set; }
        [Required]
        public TimeSpan Time { get; set; }
        [Required, StringLength(1)]
        public char Weekend { get; set; }

        public ICollection<Hour>? Hours { get; set; }
    }
}