﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
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
            await this.SetAccessTokenInHeader();

            return await Client.GetStringAsync(FontysAPIEndpoints.userInfo);
        }

        #region Buildings
        public async Task<string> GetBuildings()
        {
            await this.SetAccessTokenInHeader();

            return await Client.GetStringAsync(FontysAPIEndpoints.buildings);
        }

        public async Task<string> GetBuildings(string id)
        {
            await this.SetAccessTokenInHeader();

            return await Client.GetStringAsync($"{FontysAPIEndpoints.buildings}/{id}");
        }

        public async Task<string> GetBuildingsNearby()
        {
            await this.SetAccessTokenInHeader();

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
            await this.SetAccessTokenInHeader();

            return await Client.GetStringAsync($"{FontysAPIEndpoints.location}/current");
        }

        public async Task<string> GetLocationMapImage(string campus, string building, string floor)
        {
            await this.SetAccessTokenInHeader();

            return await Client.GetStringAsync($"{FontysAPIEndpoints.location}/mapimage/{campus}/{building}/{floor}");
        }

        public async Task<string> GetLocationFloorStatistics()
        {
            await this.SetAccessTokenInHeader();

            return await Client.GetStringAsync($"{FontysAPIEndpoints.location}/floor-statistics");
        }
        #endregion

        #region Permissions
        public async Task<string> GetPermissionsScopes()
        {
            await this.SetAccessTokenInHeader();

            return await Client.GetStringAsync($"{FontysAPIEndpoints.permissions}/scopes");
        }

        public async Task<string> GetPermissionsRoles()
        {
            await this.SetAccessTokenInHeader();

            return await Client.GetStringAsync($"{FontysAPIEndpoints.permissions}/roles");
        }

        public async Task<string> GetPermissionsClaims()
        {
            return await Client.GetStringAsync($"{FontysAPIEndpoints.permissions}/claims");
        }
        #endregion
    }
}