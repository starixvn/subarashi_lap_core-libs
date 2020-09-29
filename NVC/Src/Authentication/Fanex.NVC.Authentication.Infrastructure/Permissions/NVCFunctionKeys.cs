namespace Fanex.NVC.Authentication.Infrastructure
{
    public static class NVCFunctionKeys
    {
        /*NAP Menu Permission*/
        public const string ManageUser = "ManageLicenseeUser";
        public const string ReportLicenseeWinLoss = "LicenseeWinLoss";
        public const string ReportCustomerWinLoss = "CustomerWinLoss";
        public const string ReportCashOutWinLoss = "CashOutWinLoss";
        public const string ReportWinLoss = "WinLossReport";
        public const string ReportMarketing = "MarketingReport";
        public const string BtcAdvancedSearch = "BtcAdvancedSearch";
        public const string ManageGroup = "ManageLicenseeGroup";

        public const string GroupReport = "REPORTS3";
        public const string GroupCustomerReport = "CUSTOMERREPORTS52";
        public const string GroupCustomerInformation = "CUSTOMERINFORMATION4";
        public const string GroupAccountManagement = "ACCOUNTMANAGEMENT6";

        /* Report */

        public const string ReportMatchWinLoss = "MatchWinLoss31";
        public const string ReportWinLossByProduct = "WinLossByProducts32";
        public const string ReportCancelledBets = "CancelledBets36";
        public const string ReportDailyBetList = "DailyBetList37";
        public const string ReportTurnover = "Turnover39";
        public const string ReportResults = "Results41";
        public const string ReportColossusBetsWinLoss = "ColossusBetsWinLoss71";
        public const string ReportExchangeWinLoss = "ExchangeWinloss77";

        /* Customer Info. */

        public const string CustomerInfoCustomerList = "CustomerList43";
        public const string CustomerInfoSpecialBA = "SpecialBA54";
        public const string CustomerInfoCommissionGroupList = "CommissionGroupList55";
        public const string CustomerInfoCustomerLog = "CustomerLog";
        public const string CustomerInfoEditBetSetting = "EditBetSetting70";

        public const string BetHistory = "BetHistory";
        public const string BetHistorySingleCustomer = "BetHistory_SingleCustomer";
        public const string BetHistoryRefNo = "BetHistory_RefNo";
        public const string BetHistoryRunning = "BetHistory_Running";
        public const string BetHistoryAdvancedSearch = "BetHistory_AdvancedSearch";

        /*External*/
        public const string PlayerAdmin = "PlayerAdmin";
        public const string PlayerAdminPlayerList = "PlayerAdminPlayerList";
        public const string PlayerAdminPlayerStatement = "PlayerAdminPlayerStatement";

        public const string PlayerAdminUpdateBaStatus = "PlayerAdmin_PL_BA";
        public const string PlayerAdminUpdateSpecialLevel = "PlayerAdmin_PL_SpecialLevel";
        public const string PlayerAdminUpdateOddsGroup = "PlayerAdmin_PL_OddGroups";

        public const string AccountInfo = "pa_acc_Info";

        /*Notification*/

        public const string Resettlement = "Resettlement";
    }
}