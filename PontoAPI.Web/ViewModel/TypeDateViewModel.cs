namespace PontoAPI.Web.ViewModel
{
    public class TypeDateViewModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public TimeSpan Time { get; set; }
        public char Weekend { get; set; }
    }
}