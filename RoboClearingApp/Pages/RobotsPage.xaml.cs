//using AndroidX.ConstraintLayout.Core.Widgets;
using RoboClearingDesctop.Data;

namespace RoboClearingApp;

public partial class RobotsPage : ContentPage
{
	public RobotsPage()
	{
		InitializeComponent();
    }
    private async void OnGetRobotByIdClicked(object sender, EventArgs e)
    {
        RoboClearingClient client = new RoboClearingClient("http://localhost:5133/", new HttpClient());
        var robot = await client.RobotGetByIdAsync(1);
        //lb.Text = robot.Name;
    }
    private async void OnGetAllRobotsClicked(object sender, EventArgs e)
    {
        RoboClearingClient client = new RoboClearingClient("http://localhost:5133/", new HttpClient());
        var robots = await client.RobotGetAllAsync();
    
        listView.ItemsSource = robots;
    }
    private void OnClrBtn(object sender, EventArgs e)
    {
        listView.ItemsSource = null;
    }

}