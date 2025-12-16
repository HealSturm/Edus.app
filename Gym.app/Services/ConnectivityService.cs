using System;
using System.Threading.Tasks;
using Microsoft.Maui.Networking;

namespace Gym.app.Services
{
    public sealed class ConnectivityService : IDisposable
    {
        public bool IsConnected => Connectivity.Current?.NetworkAccess == NetworkAccess.Internet;
        public event Action<bool>? ConnectivityChanged;

        readonly object _lock = new();
        Func<Task>? _pendingAction;

        public ConnectivityService()
        {
            Connectivity.Current.ConnectivityChanged += OnConnectivityChanged;
        }

        void OnConnectivityChanged(object? sender, ConnectivityChangedEventArgs e)
        {
            ConnectivityChanged?.Invoke(IsConnected);
            if (IsConnected)
                _ = RunPendingAsync();
        }

        public void EnqueueRetry(Func<Task> action)
        {
            lock (_lock) { _pendingAction = action; }
        }

        async Task RunPendingAsync()
        {
            Func<Task>? action;
            lock (_lock) { action = _pendingAction; _pendingAction = null; }
            if (action is null) return;

            try
            {
                await action();
            }
            catch
            {
                // Si falla, re-enqueue para reintentar cuando vuelva a conectarse
                EnqueueRetry(action);
            }
        }

        public void Dispose()
        {
            Connectivity.Current.ConnectivityChanged -= OnConnectivityChanged;
        }
    }
}