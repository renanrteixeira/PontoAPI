using System.ComponentModel.DataAnnotations;

namespace PontoAPI.Core.Entities
{
    public class TypeDate : BaseId
    {
        public string? Name { get; set; }
        public TimeSpan Time { get; set; }
        public char Weekend { get; set; }

        public ICollection<Hour>? Hours { get; set; }
    }
}