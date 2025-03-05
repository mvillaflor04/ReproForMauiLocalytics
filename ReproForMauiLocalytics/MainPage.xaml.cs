namespace ReproForMauiLocalytics;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage(IServiceProvider services)
	{
		InitializeComponent();
		
		var platform = services.GetRequiredService<IPlatform>();
		
		platform.RegisterEvents();
		platform.SetCustomerId("TestCustomerId");
		platform.SetOptions(new Dictionary<string, object>
		{
			{"ll_wifi_upload_interval_seconds", 15},
			{"ll_session_timeout_seconds", 10}
		});

		platform.SetTestMode(true);
		platform.OpenSesion();
		platform.CloseSesion();
		platform.SetTagEvent("Event bEfore opting out");
		platform.SetOptedOut(true);
		platform.SetOptedOut(false);

		platform.SetOptedOut(true);
		platform.SetTagEvent("EventWhenOptedOut");
		platform.SetOptedOut(false);

		platform.SetTagEvent("TagEvent");
		platform.Upload();
		platform.SetTagEvent("TagEventWithEmptyAttribs", new Dictionary<string, string>());
		platform.SetPauseDataUploading(true);
		Dictionary<string, string> dict = new Dictionary<string, string>
		{
			{ "attr1", "1" }
		};
		platform.SetTagEvent("TagEventWithAttribs", dict);
		platform.Upload();
		platform.SetTagEvent("TagEventWithAttribsWithValue", dict, 0);
		platform.Upload();
		platform.SetTagEvent("TagEventWithAttribsWithValue", dict, 10);
		platform.SetPauseDataUploading(false);
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}
}

