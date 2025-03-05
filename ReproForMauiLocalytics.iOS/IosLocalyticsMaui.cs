using LocalyticsMaui.Common;
using LocalyticsMaui.iOS;

namespace ReproForMauiLocalytics.iOS;

public class IosLocalyticsMaui : LocalyticsSDK, ILocalytics, IPlatform
{
    private readonly LocalyticsSDK _localyticsSDK = LocalyticsSDK.SharedInstance;
    
    protected bool inappShouldDisplay = true;
    protected bool placesShouldDisplay = true;
    protected bool shouldDeepLink = true;
    
    public virtual bool InAppShouldShowHandler(object inAppCampaign) { return true; }
    public virtual bool PlacesShouldDisplay(object placesCampaign) { return true; }

    public bool ShouldDeepLinkHandler(string url)
    {
        return shouldDeepLink;
    }
    
    public void RegisterEvents()
    {
        LocalyticsSDK.LocalyticsDidTriggerRegions += (sender, e) =>
            {
                System.Diagnostics.Debug.WriteLine("MauiEvent LocalyticsDidTriggerRegions " + e);
            };

            LocalyticsSDK.LocalyticsDidUpdateLocation += (sender, e) =>
            {
                System.Diagnostics.Debug.WriteLine("MauiEvent LocalyticsDidUpdateLocation " + e);
            };

            LocalyticsSDK.LocalyticsDidUpdateMonitoredGeofences += (sender, e) =>
            {
                System.Diagnostics.Debug.WriteLine("MauiEvent LocalyticsDidUpdateMonitoredGeofences " + e);
            };

            // Analytics Events
            LocalyticsSDK.LocalyticsSessionDidOpen += (sender, e) =>
            {
                System.Diagnostics.Debug.WriteLine("MauiEvent SessionDidOpenEvent: " + e);
            };

            LocalyticsSDK.LocalyticsDidTagEvent += (sender, e) =>
            {
                System.Diagnostics.Debug.WriteLine("MauiEvent SessionDidTagEvent: " + e);
            };

            LocalyticsSDK.LocalyticsSessionWillClose += (sender, e) =>
            {
                System.Diagnostics.Debug.WriteLine("MauiEvent SessionWillCloseEvent: " + e);
            };

            LocalyticsSDK.LocalyticsSessionWillOpen += (sender, e) =>
            {
                System.Diagnostics.Debug.WriteLine("MauiEvent SessionWillOpenEvent: " + e);
            };

            LocalyticsSDK.InAppDidDismissEvent += (sender, e) =>
            {
                System.Diagnostics.Debug.WriteLine("MauiEvent InAppDidDismissEvent " + e);
            };

            LocalyticsSDK.InAppDidDisplayEvent += (sender, e) =>
            {
                System.Diagnostics.Debug.WriteLine("MauiEvent InAppDidDisplayEvent " + e);
            };

            LocalyticsSDK.InAppWillDismissEvent += (sender, e) =>
            {
                System.Diagnostics.Debug.WriteLine("MauiEvent InAppWillDismissEvent " + e);
            };

            LocalyticsSDK.InAppWillDisplayDelegate = (campaign, configuration) =>
            {
                System.Diagnostics.Debug.WriteLine("MauiEvent LocalyticsWillDisplayInAppMessage " + campaign + "," + configuration);
                return configuration;
            };

            LocalyticsSDK.CallToActionShouldDeepLinkDelegate = (string deeplink, ICampaignBase campaign) =>
            {
                System.Diagnostics.Debug.WriteLine("MauiEvent LocalyticsCallToActionShouldDeepLinkDelegate " + deeplink + "," + campaign);
                return true;
            };

            LocalyticsSDK.DidOptOut = (object sender, DidOptOutEventArgs optOutEventArgs) =>
            {
                System.Diagnostics.Debug.WriteLine("MauiEvent LocalyticsDidOptOut " + optOutEventArgs);
            };

            LocalyticsSDK.DidPrivacyOptOut = (object sender, DidOptOutEventArgs optOutEventArgs) =>
            {
                System.Diagnostics.Debug.WriteLine("MauiEvent LocalyticsDidPrivacyOptOut " + optOutEventArgs);
            };
    }

    public void SetPlacesShouldDisplay(bool display)
    {
        placesShouldDisplay = display;
    }

    public void SetInAppShouldDisplay(bool display)
    {
        inappShouldDisplay = display;
    }

    public void SetShouldDeeplink(bool display)
    {
        shouldDeepLink = display;
    }

    public void SetTestMode(bool testMode)
    {
        _localyticsSDK.TestModeEnabled = testMode;
    }

    public void SetTagEvent(string tag)
    {
        _localyticsSDK.TagEvent(tag);
    }

    public void SetTagEvent(string tag, IDictionary<string, string> attributes)
    {
        _localyticsSDK.TagEvent(tag, attributes);
    }

    public void SetTagEvent(string tag, IDictionary<string, string> attributes, int i)
    {
        _localyticsSDK.TagEvent(tag, attributes, i);
    }

    public void SetCustomerId(string customerId)
    {
        _localyticsSDK.SetCustomerId(customerId, false);
    }
    
    public new void SetOptions(IDictionary<string, object> options)
    {
        _localyticsSDK.SetOptions(options);
    }

    public void OpenSesion()
    {
        _localyticsSDK.OpenSession();
    }

    public void CloseSesion()
    {
        _localyticsSDK.CloseSession();
    }

    public void SetOptedOut(bool isOptedOut)
    {
        _localyticsSDK.OptedOut = isOptedOut;
    }

    public void SetPauseDataUploading(bool isPauseDataUploading)
    {
        _localyticsSDK.PauseDataUploading(isPauseDataUploading);
    }
}