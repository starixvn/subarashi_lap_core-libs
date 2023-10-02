

using Fanex.ThirdParty.ExchangeProduct.Model;
using Fanex.ThirdParty.ExchangeProduct.Params;
using System.Threading.Tasks;

namespace Fanex.ThirdParty.ExchangeProduct.HttpClients
{
    public interface IExchangeHttpClient
    {
        Task<bool> IsUnderMaintenance();

        Task<ResponseResult<GetProfile>> GetProfileAsync(GetProfileParam param);

        Task<ResponseResult<CommissionInfo>> UpdateCommissionAsync(UpdateCommissionParam param);

        Task<ResponseResult<ReSettleSummary>> QueryReSettleSummaryTransactionAsync(QueryReSettleSummaryTransactionParam param);

        Task<ResponseResult<BetHistory>> QuerySettleBetHistoryAsync(QuerySettleBetHistoryParam param);

        Task<ResponseResult<Summary>> QuerySummaryTransactionAsync(QuerySummaryTransactionParam param);

        Task<ResponseResult<BetHistoryForAllStatus>> QueryBetHistoryForAllStatusAsync(QueryBetHistoryForAllStatusParam param);
    }
}
