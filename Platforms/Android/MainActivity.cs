using Android.App;
using Android.Content.PM;
using Android.OS;
using AndroidX.Core.View;

namespace ContactBook;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        if (Window?.DecorView is Android.Views.View decorView)
        {
            ViewCompat.SetOnApplyWindowInsetsListener(decorView, new InsetsListener());
        }
    }
}

public class InsetsListener : Java.Lang.Object, IOnApplyWindowInsetsListener
{
    public WindowInsetsCompat OnApplyWindowInsets(Android.Views.View? v, WindowInsetsCompat? insets)
    {
        if (v == null || insets == null) return insets!;

        var systemBars = insets.GetInsets(WindowInsetsCompat.Type.SystemBars());
        v.SetPadding(systemBars.Left, systemBars.Top, systemBars.Right, systemBars.Bottom);
        return insets;
    }
}
