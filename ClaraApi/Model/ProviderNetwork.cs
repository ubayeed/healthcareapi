namespace ClaraApi.Model
{
    public class ProviderNetwork
    {
        public int ProviderNetworkId { get; set; }
        public int ProviderId { get; set; }
        public int Active { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public int NetworkId { get; set; }
    }
}
