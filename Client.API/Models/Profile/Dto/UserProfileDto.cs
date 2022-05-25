using Merchant.Core.Models;

namespace Client.API.Models.Profile.Dto
{
    public class UserProfileDto
    {
        public string ApiKey { get; set; }
        public string WebhookAddress { get; set; }
        public UserProfileDto(MerchantUser user)
        {
            ApiKey = user.ApiKey;
            WebhookAddress = user.WebhookAddress;
        }
    }
}
