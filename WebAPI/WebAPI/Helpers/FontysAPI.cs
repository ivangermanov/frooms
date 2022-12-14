using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using WebAPI.Services.Interfaces;

namespace WebAPI.Helpers
{
    public class FontysAPI
    {
        private static readonly HttpClient Client = new HttpClient();
        private static IHttpContextAccessor _httpContextAccessor;

        public FontysAPI(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        private async Task SetAccessTokenInHeader()
        {
            var accessToken = await _httpContextAccessor.HttpContext.GetTokenAsync("access_token");

            Client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", accessToken);
        }

        public async Task<string> GetUserInfo()
        {
            await SetAccessTokenInHeader();

            return await Client.GetStringAsync(FontysAPIEndpoints.userInfo);
        }

        #region Buildings

        public async Task<string> GetBuildings()
        {
            await SetAccessTokenInHeader();

            return await Client.GetStringAsync(FontysAPIEndpoints.buildings);
        }

        public async Task<string> GetBuildings(string id)
        {
            await SetAccessTokenInHeader();

            return await Client.GetStringAsync($"{FontysAPIEndpoints.buildings}/{id}");
        }

        public async Task<string> GetBuildingsNearby()
        {
            await SetAccessTokenInHeader();

            var queryString = new Dictionary<string, string>
            {
                {"latitude", "bar"},
                {"longitude", "bar"}
            };

            return await Client.GetStringAsync(QueryHelpers.AddQueryString($"{FontysAPIEndpoints.buildings}/nearby",
                queryString));
            ;
        }

        #endregion

        #region Location

        public async Task<string> GetLocationCurrent()
        {
            await SetAccessTokenInHeader();

            return await Client.GetStringAsync($"{FontysAPIEndpoints.location}/current");
        }

        public async Task<byte[]> GetLocationMapImage(string campus, string building, string floor)
        {
            await SetAccessTokenInHeader();

            if (campus != "EHV" || building != "R10")
                return await Client.GetByteArrayAsync(
                    $"{FontysAPIEndpoints.location}/mapimage/{campus}/{building}/{floor}");

            return floor switch
            {
                // R10 is mocked
                "BG" => await Client.GetByteArrayAsync("https://i.ibb.co/Q6CWjTY/BG.png"),
                "1e" => await Client.GetByteArrayAsync("https://i.ibb.co/8B9svhT/1e.png"),
                "2e" => await Client.GetByteArrayAsync("https://i.ibb.co/LPDL4z1/2e.png"),
                "3e" => await Client.GetByteArrayAsync("https://i.ibb.co/2kDc20G/3e.png"),
                "4e" => await Client.GetByteArrayAsync("https://i.ibb.co/1KNmPpP/4e.png"),
                _ => await Client.GetByteArrayAsync(
                    $"{FontysAPIEndpoints.location}/mapimage/{campus}/{building}/{floor}")
            };
        }

        public async Task<string> GetLocationFloorStatistics()
        {
            await SetAccessTokenInHeader();

            return await Client.GetStringAsync($"{FontysAPIEndpoints.location}/floor-statistics");
        }

        #endregion

        #region Permissions

        public async Task<string> GetPermissionsScopes()
        {
            await SetAccessTokenInHeader();

            return await Client.GetStringAsync($"{FontysAPIEndpoints.permissions}/scopes");
        }

        public async Task<string> GetPermissionsRoles()
        {
            await SetAccessTokenInHeader();

            return await Client.GetStringAsync($"{FontysAPIEndpoints.permissions}/roles");
        }

        public async Task<string> GetPermissionsClaims()
        {
            return await Client.GetStringAsync($"{FontysAPIEndpoints.permissions}/claims");
        }

        #endregion
    }
}