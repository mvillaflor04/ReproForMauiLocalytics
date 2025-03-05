namespace ReproForMauiLocalytics;

public interface IPlatform
{
    void RegisterEvents();
    void SetPlacesShouldDisplay(bool display);
    void SetInAppShouldDisplay(bool display);
    void SetShouldDeeplink(bool display);
    void SetTestMode(bool testMode); 
    void SetTagEvent(string tag);
    void SetTagEvent(string tag, IDictionary<string, string> attributes);
    void SetTagEvent(string tag, IDictionary<string, string> attributes, int i);
    void SetCustomerId(string customerId);

    void SetOptions(IDictionary<string, object> options);
    
    void OpenSesion();
    void CloseSesion();
    void SetOptedOut(bool isOptedOut);
    
    void Upload();
    void SetPauseDataUploading(bool isPauseDataUploading);

}