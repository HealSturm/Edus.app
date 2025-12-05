using System;
using Microsoft.Maui.Storage;

namespace Gym.app.Theme
{
    public class ThemeState
    {
        private const string PrefKey = "Theme.IsDark";
        private const string PrefSystemKey = "Theme.UseSystem";
        private const string PrefSection = "Theme";

        public bool IsDark { get; private set; }
        public bool UseSystem { get; private set; }
        public event Action? OnChanged;

        public ThemeState()
        {
            // Cargar preferencias
            UseSystem = Preferences.Get(PrefSystemKey, false, PrefSection);
            IsDark = Preferences.Get(PrefKey, false, PrefSection);

            if (UseSystem)
            {
#if ANDROID || IOS || MACCATALYST || WINDOWS
                // Si sigues el sistema, ajusta IsDark a la preferencia del OS
                var appTheme = Application.Current?.RequestedTheme ?? AppTheme.Light;
                IsDark = appTheme == AppTheme.Dark;
                // Suscribirse a cambios de tema del sistema
                Application.Current!.RequestedThemeChanged += OnRequestedThemeChanged;
#endif
            }
        }

        public void SetLight()
        {
            UseSystem = false;
            IsDark = false;
            Save();
            OnChanged?.Invoke();
        }

        public void SetDark()
        {
            UseSystem = false;
            IsDark = true;
            Save();
            OnChanged?.Invoke();
        }

        public void SetSystem()
        {
            UseSystem = true;
            // Reflejar el estado del sistema inmediatamente
#if ANDROID || IOS || MACCATALYST || WINDOWS
            var appTheme = Application.Current?.RequestedTheme ?? AppTheme.Light;
            IsDark = appTheme == AppTheme.Dark;
            Application.Current!.RequestedThemeChanged -= OnRequestedThemeChanged;
            Application.Current!.RequestedThemeChanged += OnRequestedThemeChanged;
#else
            IsDark = false;
#endif
            Save();
            OnChanged?.Invoke();
        }

#if ANDROID || IOS || MACCATALYST || WINDOWS
        private void OnRequestedThemeChanged(object? sender, AppThemeChangedEventArgs e)
        {
            if (!UseSystem) return;
            IsDark = e.RequestedTheme == AppTheme.Dark;
            Save();
            OnChanged?.Invoke();
        }
#endif

        private void Save()
        {
            Preferences.Set(PrefSystemKey, UseSystem, PrefSection);
            Preferences.Set(PrefKey, IsDark, PrefSection);
        }
    }
}