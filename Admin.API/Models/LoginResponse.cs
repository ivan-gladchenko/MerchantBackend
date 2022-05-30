namespace Admin.API.Models
{
    public class LoginResponse
    {
        public string accessToken { get; set; }
        public long expireTime { get; set; }
        public string error { get; set; }
    }
}
