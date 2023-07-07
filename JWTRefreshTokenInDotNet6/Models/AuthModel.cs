﻿

using JsonIgnoreAttribute = Newtonsoft.Json.JsonIgnoreAttribute;

namespace JWTRefreshTokenInDotNet6.Models
{
    public class AuthModel
    {
        public string Id { get; set; }
        public string? Message { get; set; }
        public bool IsAuthenticated { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public List<string>? Roles { get; set; }
        public string? Token { get; set; }
        public DateTime? ExpiresOn { get; set; }
        public string? UserType { get; set; }

        [JsonIgnore]
        public string? RefreshToken { get; set; }

        public DateTime RefreshTokenExpiration { get; set; }
    }
}