using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Services.Interfaces
{
    public static class FontysAPIEndpoints
    {
        private const string baseURL = "https://api.fhict.nl";
        public const string buildings = baseURL + "/buildings";
        public const string location = baseURL + "/location";
        public const string permissions = baseURL + "/permissions";

        public const string userInfo = "https://identity.fhict.nl/connect/userinfo";
    }
}
