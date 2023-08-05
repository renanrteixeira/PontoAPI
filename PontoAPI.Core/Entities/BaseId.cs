using System.ComponentModel.DataAnnotations;

namespace PontoAPI.Core.Entities
{
    public class BaseId
    {
        [Key, Required]
        public int Id { get; set; }
    }
}