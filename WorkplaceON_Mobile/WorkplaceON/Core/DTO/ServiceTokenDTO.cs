using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Core.DTO
{

    public class ServiceToken
    {
        [JsonProperty("ApplicationTenantLinkId")]
        public int ApplicationTenantLinkId { get; set; }

        [JsonProperty("ApplicationKey")]
        public string ApplicationKey { get; set; }

        [JsonProperty("TokenId")]
        public string TokenId { get; set; }

        [JsonProperty("TokenKey")]
        public string TokenKey { get; set; }

        [JsonProperty("TenantKey")]
        public string TenantKey { get; set; }

        [JsonProperty("UserId")]
        public int UserId { get; set; }

        [JsonProperty("Roles")]
        public string Roles { get; set; }

        [JsonProperty("Profiles")]
        public string Profiles { get; set; }

        [JsonProperty("UserName")]
        public string UserName { get; set; }

        [JsonProperty("FirstName")]
        public string FirstName { get; set; }

        [JsonProperty("LastName")]
        public string LastName { get; set; }

        [JsonProperty("SelectedRole")]
        public string SelectedRole { get; set; }

        [JsonProperty("SelectedProfile")]
        public string SelectedProfile { get; set; }

        [JsonProperty("LocaleId")]
        public int LocaleId { get; set; }

        [JsonProperty("AccessToken")]
        public string AccessToken { get; set; }

        [JsonProperty("TenantId")]
        public int TenantId { get; set; }

        [JsonProperty("ThemeId")]
        public int ThemeId { get; set; }

        [JsonProperty("ThemeName")]
        public string ThemeName { get; set; }

        [JsonProperty("ThemeFolderPath")]
        public string ThemeFolderPath { get; set; }

        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("ApplicationDescription")]
        public string ApplicationDescription { get; set; }

        [JsonProperty("IsExpirationCheckOptional")]
        public bool IsExpirationCheckOptional { get; set; }
    }

    public class JasonServiceToken
    {
        [JsonProperty("serviceToken")]
        public ServiceToken serviceToken { get; set; }

    }



}
