using Merchant.Core.Models;

namespace Admin.API.Models.Dto
{
    public class MerchantUserDto
    {
        public long Id { get; set; }
        public string AppUserName { get; set; }
        public string ApiKey { get; set; }
        public string WebhookAddress { get; set; }

        public MerchantUserDto(MerchantUser user)
        {
            Id = user.Id;
            AppUserName = user.AppUserName;
            ApiKey = user.ApiKey;
            WebhookAddress = user.WebhookAddress;
        }
    }
}
