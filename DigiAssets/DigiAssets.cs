using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using DigiAssets.Core.Common;
using DigiAssets.Core.Models;
using Newtonsoft.Json;

namespace DigiAssets.Core
{
    public class DigiAssets : IDisposable
    {
        private readonly HttpClient httpClient;
        public string BaseUrl { get; }

        public DigiAssets(string baseUrl)
        {
            this.httpClient = new HttpClient();
            this.BaseUrl = baseUrl;
            if (!this.BaseUrl.EndsWith("/"))
            {
                this.BaseUrl += "/";
            }
            this.BaseUrl = this.BaseUrl.ToLower();
        }

        public async Task<SendAssetResponse> SendAssetAsync(AssetSendObject assetSendObject)
        {
            string body = JsonConvert.SerializeObject(assetSendObject);
            StringContent stringContent = new StringContent(body, Encoding.UTF8, "application/json");
            HttpResponseMessage msg = await httpClient.PostAsync($"{BaseUrl}sendasset", stringContent).ConfigureAwait(false);
            string response = await msg.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<SendAssetResponse>(response);
        }

        public async Task<BurnAssetResponse> BurnAssetAsync(AssetBurnObject assetBurnObject)
        {
            string body = JsonConvert.SerializeObject(assetBurnObject);
            StringContent stringContent = new StringContent(body, Encoding.UTF8, "application/json");
            HttpResponseMessage msg = await httpClient.PostAsync($"{BaseUrl}burnasset", stringContent).ConfigureAwait(false);
            string response = await msg.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<BurnAssetResponse>(response);
        }

        public async Task<IssueAssetResponse> Issue(AssetIssueObject assetIssueObject)
        {
            string body = JsonConvert.SerializeObject(assetIssueObject);
            StringContent stringContent = new StringContent(body, Encoding.UTF8, "application/json");
            HttpResponseMessage msg = await httpClient.PostAsync($"{BaseUrl}issue", stringContent).ConfigureAwait(false);
            string response = await msg.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IssueAssetResponse>(response);
        }

        public async Task Broadcast(SignedTransactionObject signedTransactionObject)
        {
            string body = JsonConvert.SerializeObject(signedTransactionObject);
            StringContent stringContent = new StringContent(body, Encoding.UTF8, "application/json");
            HttpResponseMessage msg = await httpClient.PostAsync($"{BaseUrl}broadcast", stringContent).ConfigureAwait(false);
            if (msg.IsSuccessStatusCode == false)
            {
                throw new HttpRequestException();
            }
        }

        public async Task<AssetMetaDataResponse> AssetMetaDataAsync(string assetId, string utxo = null, int verbosity = 1)
        {
            if (!string.IsNullOrEmpty(utxo))
            {
                var result = await httpClient.GetAsync($"{BaseUrl}stakeholders/{assetId}/{utxo}?verbosity={verbosity}");
                string content = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<AssetMetaDataResponse>(content);
            }
            else
            {
                var result = await httpClient.GetAsync($"{BaseUrl}stakeholders/{assetId}?verbosity={verbosity}");
                string content = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<AssetMetaDataResponse>(content);
            }
        }

        public async Task<AddressInfoResponse> AddressInfoAsync(string address)
        {
            var result = await httpClient.GetAsync($"{BaseUrl}addressinfo/{address}");
            string content = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<AddressInfoResponse>(content);
        }

        public async Task<StakeHoldersResponse> StakeHolders(string assetId, int? numConfirmations = null)
        {
            if (numConfirmations.HasValue)
            {
                var result = await httpClient.GetAsync($"{BaseUrl}stakeholders/{assetId}/{numConfirmations}");
                string content = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<StakeHoldersResponse>(content);
            }
            else
            {
                var result = await httpClient.GetAsync($"{BaseUrl}stakeholders/{assetId}");
                string content = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<StakeHoldersResponse>(content);
            }
        }

        #region IDisposable Support
        private bool disposedValue = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (httpClient != null)
                    {
                        httpClient.Dispose();
                        httpClient = null;
                    }
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}