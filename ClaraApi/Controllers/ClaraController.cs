using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;
using ZstdSharp.Unsafe;

namespace ClaraApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaraController : ControllerBase
    {
        private readonly ILogger<ClaraController> _logger;
        public ClaraController(ILogger<ClaraController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("ping")]
        public string Ping()
        {
            DBConnection.Test();
            return "Hello";
        }

        [HttpGet]
        [Route("cpts")]
        public List<Model.CPT> GetCPTs()
        {
            return DBConnection.getAllCPTCodes();
        }

        [HttpGet]
        [Route("members")]
        public List<Model.Member> GetMembers()
        {
            return DBConnection.getAllMembers();
        }

        [HttpGet]
        [Route("networks")]
        public List<Model.Network> GetNetworks()
        {
            return DBConnection.getAllNetworks();
        }

        [HttpGet]
        [Route("providers")]
        public List<Model.Provider> GetProviders()
        {
            return DBConnection.getAllProviders();
        }

        [HttpGet]
        [Route("providernetworks")]
        public List<Model.ProviderNetwork> GetProviderNetorks()
        {
            return DBConnection.getAllProviderNetworks();
        }

        [HttpGet]
        [Route("payors")]
        public List<Model.Payor> GetPayors()
        {
            return DBConnection.getAllPayors();
        }

        [HttpGet]
        [Route("search_providers")]
        //public List<Model.Pricing> GetProviders(int memberId, int cptcode, string? zip = null)
        public List<dynamic> GetProviders(int memberId, int cptcode, string? zip = null)
        {
            var member = DBConnection.getAllMembers().Where(x => x.MemberId == memberId).SingleOrDefault();
            //var provNetworks = DBConnection.getAllProviderNetworks().Where(x => x.pay == member.PayorId)).Select(x => x).ToList();            

            List<Model.Provider> providers = new List<Model.Provider>();
            if (!string.IsNullOrEmpty(zip))
                providers = DBConnection.getAllProviders().Where(x => x.ZipCode == zip).ToList();
            else
                providers = DBConnection.getAllProviders();

            List<Model.Pricing> pricings = new List<Model.Pricing>();
            if (member is null)
                pricings = DBConnection.getAllPricings().Where(x => x.CPTCode == cptcode).ToList();
            else
                pricings = DBConnection.getAllPricings().Where(x => x.CPTCode == cptcode && x.PayorId == member.PayorId).ToList();

            var providerIds = providers.Select(x => x.ProviderId).ToList();
            var relevantPricings = pricings.Where(x => providerIds.Contains(x.ProviderId)).Select(x => x).ToList();
            //var provNetworks = DBConnection.getAllProviderNetworks().Where(x => providerIds.Contains(x.ProviderId)).Select(x => x).ToList();

            var result = new List<dynamic>();
            foreach (var pricing in relevantPricings) {
                pricing.Payor = DBConnection.getAllPayors().Where(x => x.PayorId == pricing.PayorId).First();
                pricing.Provider = DBConnection.getAllProviders().Where(x => x.ProviderId == pricing.ProviderId).First();
                pricing.CPT = DBConnection.getAllCPTCodes().Where(x => x.CPTCode == pricing.CPTCode).First();
                //var networkIds = DBConnection.getAllProviderNetworks().Where(x => providerIds.Contains(x.ProviderId)).Select(x => x.NetworkId).ToArray();
                var networkIds = DBConnection.getAllProviderNetworks().Where(x => x.ProviderId == pricing.ProviderId).Select(x => x.NetworkId).ToArray();
                pricing.Provider.Networks = DBConnection.getAllNetworks().Where(x => networkIds.Contains(x.NetworkId)).ToList();
                var resultItem = new {
                    memberName = member != null ? $"{member?.FirstName} {member?.LastName}" : "",
                    memberMaxOutOfPocket = (member != null ? @$"{member?.MaxOutOfPocket.ToString()}" : ""),
                    memberDeductibleUsed = member != null ? $"{member?.CurrentPaidDeductible.ToString()}" : "",
                    providerName = pricing.Provider.Name,
                    providerAddress = $"{pricing.Provider.StreetAddress}, {pricing.Provider.City}, {pricing.Provider.State} {pricing.Provider.ZipCode}",
                    providerMaxPrice = pricing.MaxPrice,
                    providerMinPrice = pricing.MinPrice,    
                    providerNetwork = pricing.Provider.Networks?.Count > 0 ? string.Join(", ",pricing.Provider.Networks.Select(x => x.Name).ToArray()) : "Out of network",
                    cptName = pricing.CPT.Desc,
                };
                result.Add(resultItem);
            }
            return result;
            //return relevantPricings;
        }
    }
}
