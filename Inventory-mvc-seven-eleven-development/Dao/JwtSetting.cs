using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Inventory_mvc_seven_eleven.Dao
{
    public class JwtSetting
    {
        public const string Issuer = "Thara";
        public const string Audience = "ApiUser";
        public const string Key = "thisisoursecurekey";
        public const string AuthSchema =
        "Identity.Application" + "," + JwtBearerDefaults.AuthenticationScheme;

    }

}