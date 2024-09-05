using RoboClearingClient;

namespace RoboClearingApp;

public partial class RobotPage : ContentPage
{
	private RClient _client;
	private RobotResponce? _currentRobot;
	public RobotPage()
	{
		_client = new RClient("http://localhost:5133/", new HttpClient());
		InitializeComponent();
	}
	private void robot_ItemSelected(object sender, SelectedItemChangedEventArgs e)
	{
		_currentRobot = e.SelectedItem as RobotResponce;
		selectedLabel.Text = $"#{_currentRobot?.Id} {_currentRobot?.Name}";
	}
	private async void GetAllBtn(object sender, EventArgs e)
	{
		var robots = await _client.RobotGetAllAsync();
		listView.ItemsSource = robots;
	}
	private async void UpdateBtn(object sender, EventArgs e)
	{
		if (_currentRobot != null) 
			await Navigation.PushAsync(new RobotUpdatePage(_currentRobot));
		else
			selectedLabel.Text = "null";
	}
	private async void CreateBtn(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new RobotCreatePage());
	}
}