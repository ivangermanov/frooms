using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Net.Http.Headers;
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

        public async Task<string> GetUserInfo()
        {
            var accessToken = await _httpContextAccessor.HttpContext.GetTokenAsync("access_token");

            Client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", accessToken);

            return await Client.GetStringAsync(FontysAPIEndpoints.userInfo);
        }

        #region Buildings
        public async Task<string> GetBuildings()
        {
            var accessToken = await _httpContextAccessor.HttpContext.GetTokenAsync("access_token");

            Client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", accessToken);

            return await Client.GetStringAsync(FontysAPIEndpoints.buildings);
        }

        public async Task<string> GetBuildings(string id)
        {
            var accessToken = await _httpContextAccessor.HttpContext.GetTokenAsync("access_token");

            Client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", accessToken);

            return await Client.GetStringAsync($"{FontysAPIEndpoints.buildings}/{id}");
        }

        public async Task<string> GetBuildingsNearby()
        {
            var accessToken = await _httpContextAccessor.HttpContext.GetTokenAsync("access_token");

            Client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", accessToken);

            var queryString = new Dictionary<string, string>()
            {
                { "latitude", "bar" },
                { "longitude", "bar" }
            };

            return await Client.GetStringAsync(QueryHelpers.AddQueryString($"{FontysAPIEndpoints.buildings}/nearby", queryString)); ;
        }
        #endregion

        #region Location
        public async Task<string> GetLocationCurrent()
        {
            var accessToken = await _httpContextAccessor.HttpContext.GetTokenAsync("access_token");

            Client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", accessToken);

            return await Client.GetStringAsync($"{FontysAPIEndpoints.location}/current");
        }

        public async Task<string> GetLocationMapImage(string campus, string building, string floor)
        {
            return await Client.GetStringAsync($"{FontysAPIEndpoints.location}/mapimage/{campus}/{building}/{floor}");
        }
        #endregion

        #region Permissions
        public async Task<string> GetPermissionsScopes()
        {
            var accessToken = await _httpContextAccessor.HttpContext.GetTokenAsync("access_token");

            Client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", accessToken);

            return await Client.GetStringAsync($"{FontysAPIEndpoints.permissions}/scopes");
        }

        public async Task<string> GetPermissionsRoles()
        {
            var accessToken = await _httpContextAccessor.HttpContext.GetTokenAsync("access_token");

            Client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", accessToken);

            return await Client.GetStringAsync($"{FontysAPIEndpoints.permissions}/roles");
        }

        public async Task<string> GetPermissionsClaims()
        {
            return await Client.GetStringAsync($"{FontysAPIEndpoints.permissions}/claims");
        }
        #endregion
    }
}
