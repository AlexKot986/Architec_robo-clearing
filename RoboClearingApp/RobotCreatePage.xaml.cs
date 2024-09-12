using System;
using System.Net.Http;
using Microsoft.Maui.Controls;
using RoboClearingClient;

namespace RoboClearingApp;

public partial class RobotCreatePage : ContentPage
{
	public RobotCreatePage()
	{
		InitializeComponent();
	}
	
	private async void CreateBtn(object sender, EventArgs e)
	{
		var newRobot = new RobotAddRequest { Model = model.Text, Name = name.Text };
		var client = new RClient("http://localhost:5133/", new HttpClient());
		
		int answer = await client.RobotAddAsync(newRobot);
		if (answer > 0)
			createLabel.Text = $"robot model: #{model.Text}, name: {name.Text} is created";
		else
			createLabel.Text = "create is fail";
	}
}