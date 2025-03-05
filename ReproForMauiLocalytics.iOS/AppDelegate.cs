using Foundation;
using LocalyticsMaui.iOS;
using UIKit;
using UserNotifications;

namespace ReproForMauiLocalytics.iOS;

[Register(nameof(AppDelegate))]
public class AppDelegate : MauiUIApplicationDelegate
{
	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
	
    public override bool FinishedLaunching(UIApplication uiApplication, NSDictionary launchOptions)
    {
        // Localytics Integrate
        Localytics.LoggingEnabled = true;
        Localytics.Integrate("5e1811ca98b9439c63044f0-0467741a-f9d3-11ef-0a20-007c928ca240", launchOptions ?? new NSDictionary());
        // AutoIntegrate is not supported since .Net6. So, it shouldn't be used
        //Localytics.AutoIntegrate("b70c948d304fc756d8b6e63-ecd3437a-a073-11e6-c6e3-008d99911bee", new NSDictionary(), launchOptions ?? new NSDictionary());

        if (UIDevice.CurrentDevice.CheckSystemVersion(12, 0))
        {
            var options = UNAuthorizationOptions.Provisional;
            UNUserNotificationCenter.Current.RequestAuthorization(options, (granted, error) =>
            {
                Localytics.DidRequestUserNotificationAuthorizationWithOptions((UIntPtr)options, granted);
            });
        }
        else
        {
            // Register for remote notifications
            var pushSettings = UIUserNotificationSettings.GetSettingsForTypes(
                UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound,
                new NSSet());

            UIApplication.SharedApplication.RegisterUserNotificationSettings(pushSettings);
        }
        
        UIApplication.SharedApplication.RegisterForRemoteNotifications();
        
        return base.FinishedLaunching(uiApplication, launchOptions);
    }
}
