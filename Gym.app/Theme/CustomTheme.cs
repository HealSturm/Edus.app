using MudBlazor;

namespace Gym.app.Theme
{
    public static class CustomTheme
    {
        public static MudTheme LightTheme => new MudTheme()
        {
            PaletteLight = new PaletteLight()
            {
                Primary = "#3BB2CE",
                Secondary = "#545454",
                Tertiary = "#5CE1E6",
                Background = "#E5E6E6",
                AppbarBackground = "#3BB2CE",
                DrawerBackground = "#E5E6E6",
                Surface = "#FFFFFF",
                TextPrimary = "#545454",
                TextSecondary = "#3BB2CE"
            }
        };
    }
}
