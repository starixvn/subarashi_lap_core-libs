using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Fanex.ThirdParty.ExchangeProduct.Constant;
using Fanex.ThirdParty.ExchangeProduct.Enums;
using Fanex.ThirdParty.ExchangeProduct.Exceptions;
using Fanex.ThirdParty.ExchangeProduct.Model;
using Fanex.ThirdParty.ExchangeProduct.Params;
using Newtonsoft.Json;

namespace Fanex.ThirdParty.ExchangeProduct.HttpClients
{
    public class ExchangeHttpClient : IExchangeHttpClient
    {
        private const string JsonContentType = "application/json";

        private readonly HttpClient _httpClient;
        private readonly ExchangeOption _option;

        private string BaseAddress => string.IsNullOrWhiteSpace(_option?.BaseAddress) ? _httpClient?.BaseAddress?.OriginalString : _option?.BaseAddress;

        public ExchangeHttpClient(HttpClient httpClient, ExchangeOption option)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _option = option ?? throw new ArgumentNullException(nameof(option));
            if (string.IsNullOrWhiteSpace(httpClient?.BaseAddress?.OriginalString) && string.IsNullOrWhiteSpace(option?.BaseAddress))
            {
                throw new ArgumentException("Not set up BaseAddress yet");
            }
        }

        public async Task<bool> IsUnderMaintenance()
        {
            var param = new GetProfileParam()
            {
                CustId = new Random().Next(1, 100),
                GroupMode = 0,
            };
            var url = BaseAddress + _option.UrlGetProfile;
            var jsonString = JsonConvert.SerializeObject(param);
            var content = new StringContent(jsonString, Encoding.UTF8, JsonContentType);

            using (var response = await _httpClient.PostAsync(url, content).ConfigureAwait(false))
            {
                try
                {
                    response.EnsureSuccessStatusCode();
                }
                catch (Exception ex)
                {
                    ThrowExceptionWithExtraInfo(ex, url, jsonString);
                }

                var result = JsonConvert.DeserializeObject<ResponseResult<GetProfile>>(await response.Content.ReadAsStringAsync());

                return result.ErrorCode == ExchangeErrorCode.UnderMaintenance || result.Result.status == CitiStatus.Under_Maintainence;
            }
        }

        public Task<ResponseResult<GetProfile>> GetProfileAsync(GetProfileParam param)
            => PostAsync<GetProfile, GetProfileParam>(BaseAddress + _option.UrlGetProfile, param);

        public Task<ResponseResult<BetHistoryForAllStatus>> QueryBetHistoryForAllStatusAsync(QueryBetHistoryForAllStatusParam param)
            => PostAsync<BetHistoryForAllStatus, QueryBetHistoryForAllStatusParam>(BaseAddress + _option.UrlQueryBetHistoryForAllStatus, param);

        public Task<ResponseResult<ReSettleSummary>> QueryReSettleSummaryTransactionAsync(QueryReSettleSummaryTransactionParam param)
            => PostAsync<ReSettleSummary, QueryReSettleSummaryTransactionParam>(BaseAddress + _option.UrlQueryReSettleSummaryTransaction, param);

        public Task<ResponseResult<BetHistory>> QuerySettleBetHistoryAsync(QuerySettleBetHistoryParam param)
            => PostAsync<BetHistory, QuerySettleBetHistoryParam>(BaseAddress + _option.UrlQuerySettleBetHistory, param);

        public Task<ResponseResult<Summary>> QuerySummaryTransactionAsync(QuerySummaryTransactionParam param)
            => PostAsync<Summary, QuerySummaryTransactionParam>(BaseAddress + _option.UrlQuerySummaryTransaction, param);

        public Task<ResponseResult<CommissionInfo>> UpdateCommissionAsync(UpdateCommissionParam param)
            => PostAsync<CommissionInfo, UpdateCommissionParam>(BaseAddress + _option.UrlUpdateCommission, param);

        public Task<ResponseResult<CurrentBet>> QueryCurrentBetsByLastTime(QueryCurrentBetsByLastTimeParam param)
            => PostAsync<CurrentBet, QueryCurrentBetsByLastTimeParam>(BaseAddress + _option.UrlQueryCurrentBetsByLastTime, param);

        public async Task<ResponseResult<TResult>> PostAsync<TResult, TParam>(string url, TParam param)
            where TResult : class
        {
            var jsonString = JsonConvert.SerializeObject(param, new JsonSerializerSettings { DateFormatString = "yyyy-MM-dd HH:mm:ss"});
            var content = new StringContent(jsonString, Encoding.UTF8, JsonContentType);
            using (var response = await _httpClient.PostAsync(url, content).ConfigureAwait(false))
            {
                try
                {
                    response.EnsureSuccessStatusCode();
                }
                catch (Exception ex)
                {
                    ThrowExceptionWithExtraInfo(ex, url, jsonString);
                }

                var result = JsonConvert.DeserializeObject<ResponseResult<TResult>>(await response.Content.ReadAsStringAsync());

                if (result.ErrorCode != ExchangeErrorCode.Success)
                {
                    BuildMsgAndThrowException(result, url, jsonString);
                }
                return result;
            }
        }

        private void BuildMsgAndThrowException<TResult>(ResponseResult<TResult> result, string url, string param) where TResult : class
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Exchange API response have error");
            stringBuilder.AppendLine($"Url: {url}");
            stringBuilder.AppendLine($"Error Code: {result.ErrorCode}");
            stringBuilder.AppendLine($"Error Description: {result.ErrorDescription}");
            stringBuilder.AppendLine($"Param: {param}");
            throw new ExchangeException(stringBuilder.ToString());
        }

        private void ThrowExceptionWithExtraInfo(Exception exception, string url, string param)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Exchange API response have error");
            stringBuilder.AppendLine($"Url: {url}");
            stringBuilder.AppendLine($"Param: {param}");
            throw new ExchangeException(stringBuilder.ToString(), exception);
        }


    }
}