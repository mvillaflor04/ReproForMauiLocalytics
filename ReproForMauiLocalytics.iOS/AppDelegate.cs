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
        
        // Register for remote notifications
#pragma warning disable CA1422
        var pushSettings = UIUserNotificationSettings.GetSettingsForTypes (
            UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound,
            new NSSet ());
#pragma warning restore CA1422

#pragma warning disable CA1422
        UIApplication.SharedApplication.RegisterUserNotificationSettings(pushSettings);
#pragma warning restore CA1422
        UIApplication.SharedApplication.RegisterForRemoteNotifications();
        
        return base.FinishedLaunching(uiApplication, launchOptions);
    }

    [Export("application:didRegisterForRemoteNotificationsWithDeviceToken:")]
    public virtual void RegisteredForRemoteNotifications(UIKit.UIApplication application, NSData deviceToken)
    {
        Localytics.SetPushToken(deviceToken);
    }

    [Export("application:didFailToRegisterForRemoteNotificationsWithError:")]
    public void FailedToRegisterForRemoteNotifications(UIKit.UIApplication application, NSError error)
    {
        Console.WriteLine("Registration For Remote Notifications Failed");
        Console.WriteLine("Error : " + error.LocalizedDescription);
    }
}
