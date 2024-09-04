using RoboClearingClient;

namespace RoboClearingApp;

public partial class RobotPage : ContentPage
{
	public RobotPage()
	{
		InitializeComponent();
	}
	private void robot_ItemSelected(object sender, SelectedItemChangedEventArgs e)
	{

	}
	private async void GetAllBtn(object sender, EventArgs e)
	{
		RClient client = new RClient("http://localhost:5133/", new HttpClient());
		var robots = await client.RobotGetAllAsync();

		listView.ItemsSource = robots;
	}
	private void UpdateBtn(object sender, EventArgs e)
	{

	}
	private async void CreateBtn(object sender, EventArgs e)
	{
		await Navigation.PushModalAsync(new RobotCreatePage());
	}
}