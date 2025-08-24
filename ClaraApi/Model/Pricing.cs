namespace ClaraApi.Model
{
    public class Pricing
    {
        public int PricingId { get; set; }
        public int PayorId { get; set; }
        public Payor? Payor { get; set; }
        public int ProviderId { get; set; }
        public Provider? Provider { get; set; }
        public double MaxPrice { get; set; }
        public double MinPrice { get; set; }
        public DateTime PriceValidUntil { get; set; }
        public int CPTCode { get; set; }
        public CPT? CPT { get; set; }
    }
}
