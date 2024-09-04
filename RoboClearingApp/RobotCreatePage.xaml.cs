namespace RoboClearingApp;

public partial class RobotCreatePage : ContentPage
{
	public RobotCreatePage()
	{
		InitializeComponent();
	}
	private async void BackBtn(object sender, EventArgs e)
	{
		await Navigation.PopModalAsync();
	}
	private void CreateBtn(object sender, EventArgs e)
	{

	}
}