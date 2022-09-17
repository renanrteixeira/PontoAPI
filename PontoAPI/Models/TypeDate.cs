using System.ComponentModel.DataAnnotations;


namespace PontoAPI.Models
{
    public class TypeDate
    {
        [Key, Required]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; }

        [Required]
        public TimeSpan Time { get; set; }

        [Required, StringLength(1)]
        public char Weekend { get; set; }
    }
}
