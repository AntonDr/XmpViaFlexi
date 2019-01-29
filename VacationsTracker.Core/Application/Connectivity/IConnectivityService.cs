namespace VacationsTracker.Core.Application.Connectivity
{
    public interface IConnectivityService
    {
        bool IsConnected { get; }
    }
}
