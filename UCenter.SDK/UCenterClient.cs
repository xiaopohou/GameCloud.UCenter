﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;
using UCenter.Common.Models;
using UCenter.Common.Database.Entities;

namespace UCenter.SDK
{
    public class UCenterClient
    {
        private readonly UCenterHttpClient httpClient;
        private readonly string host;

        public UCenterClient(string host)
        {
            this.httpClient = new UCenterHttpClient();
            this.host = host;
        }


        public async Task<AccountRegisterResponse> AccountRegisterAsync(AccountRegisterInfo info)
        {
            string url = GenerateApiEndpoint("account", "register");
            var response = await httpClient.SendAsyncWithException<AccountRegisterInfo, AccountRegisterResponse>(HttpMethod.Post, url, info);
            return response;
        }

        public async Task<AccountLoginResponse> AccountLoginAsync(AccountLoginInfo info)
        {
            string url = GenerateApiEndpoint("account", "login");
            var response = await httpClient.SendAsyncWithException<AccountLoginInfo, AccountLoginResponse>(HttpMethod.Post, url, info);
            return response;
        }

        public async Task<AccountChangePasswordResponse> AccountChangePassword(AccountChangePasswordInfo info)
        {
            string url = this.GenerateApiEndpoint("account", "changepassword");
            return await httpClient.SendAsyncWithException<AccountChangePasswordInfo, AccountChangePasswordResponse>(HttpMethod.Post, url, info);
        }

        public async Task<AppEntity> AppLoginAsync(AppLoginInfo info)
        {
            string url = GenerateApiEndpoint("app", "login");
            var response = await httpClient.SendAsyncWithException<AppLoginInfo, AppEntity>(HttpMethod.Post, url, info);
            return response;
        }

        public async Task<AppVerifyAccountResponse> AppVerifyAccountAsync(AccountVerificationInfo info)
        {
            string url = GenerateApiEndpoint("app", "verifyaccount");
            var response = await httpClient.SendAsyncWithException<AccountVerificationInfo, AppVerifyAccountResponse>(HttpMethod.Post, url, info);
            return response;
        }

        public async Task<AppDataResponse> AppReadDataAsync(AppDataInfo info)
        {
            string url = GenerateApiEndpoint("app", "readdata");
            var response = await httpClient.SendAsyncWithException<AppDataInfo, AppDataResponse>(HttpMethod.Post, url, info);
            return response;
        }

        public async Task<AppDataResponse> AppWriteDataAsync(AppDataInfo info)
        {
            string url = GenerateApiEndpoint("app", "writedata");
            var response = await httpClient.SendAsyncWithException<AppDataInfo, AppDataResponse>(HttpMethod.Post, url, info);
            return response;
        }

        private string GenerateApiEndpoint(string controller, string route, string queryString = null)
        {
            var url = $"{this.host}/api/{controller}/{route}";
            if (!string.IsNullOrEmpty(queryString))
            {
                url = $"{url}/?{queryString}";
            }

            return url;
        }
    }
}
