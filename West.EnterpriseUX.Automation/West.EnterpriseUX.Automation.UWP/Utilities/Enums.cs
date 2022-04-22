using System.ComponentModel;

namespace West.EnterpriseUX.Automation.UWP.Utilities
{
    public enum LoadingText
    {
        Loading,
        Fetching,
        Preparing,
        Retry,
        Authenticating,
        Please,
        Logging,
        Adding,
        Saving,
        Deleting,
        Removing,
        Refreshing,
    };
    public enum SortOrder
    {
        Ascending,
        Descending,
    };
    public enum WDAbstractions
    {
        Details,
        KPIs,
        Charts,
        Storyboards,
    };
    public enum MyAppsOptions
    {
        Favorites,
        Insights,
        [Description("Insights and Analytics")]
        InsightsandAnalytics,
        [Description("My Task")]
        MyTask,
        Collaboration
    };
    public enum DetailActionOptions
    {
        [Description("Expand Record")]
        ExpandRecord,
    };
    public enum AppSystem
    {
        dev,
        dvv,
        quality
    };
    public enum KPIChartsContextOptions
    {
        Refresh,
        Delete,
        Edit,
        Share
    };
    public enum ButtonActionOptions
    {
        NEXT,
        Confirm,
        SAVE,
        Ok,
        Edit,
        CONFIRM,
        Today,
        Save,
        Add,
        Reload,
        Yes,
        No
    };

}
