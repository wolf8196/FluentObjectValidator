namespace FluentObjectValidator.Tests.Functional.DTOs
{
    public class AdvertDTO
    {
        public string Title { get; set; }

        public decimal? Price { get; set; }

        public string Description { get; set; }

        public string PhotoBase64 { get; set; }

        public int[] AddressIds { get; set; }
    }
}