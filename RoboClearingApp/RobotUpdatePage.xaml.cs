using System;
using System.Net.Http;
using Microsoft.Maui.Controls;
using RoboClearingClient;

namespace RoboClearingApp;

public partial class RobotUpdatePage : ContentPage
{
    private RClient _client;
    private RobotResponce _currentRobot;
	public RobotUpdatePage(RobotResponce robot)
	{
        _currentRobot = robot;
        _client = new RClient("http://localhost:5133/", new HttpClient());
        InitializeComponent();
        name.Text = robot.Name;
        updateLabel.Text = $"robot id: #{robot.Id}, name: {robot.Name}";
    }
    private async void UpdateBtn(object sender, EventArgs e)
    {
        try
        {
            var updateRobot = new RobotUpdateRequest { Id = _currentRobot.Id, Status = _currentRobot.Status, Name = name.Text };

            int answer = await _client.RobotUpdateAsync(updateRobot);
            if (answer > 0)
                updateLabel.Text = $"robot id: #{_currentRobot.Id}, name: {_currentRobot.Name} is updated --> new name: {name.Text}";
            else
                updateLabel.Text = "update is fail";
        }
        catch (Exception ex)
        {
            updateLabel.Text = ex.Message;
        }
    }
    private async void DeleteBtn(object sender, EventArgs e)
    {
        try
        {
            int answer = await _client.RobotDeleteAsync(_currentRobot.Id);
            if (answer > 0)
                updateLabel.Text = $"robot id: #{_currentRobot.Id}, name: {_currentRobot.Name} is deleted";
            else
                updateLabel.Text = "delete is fail";
        }
        catch (Exception ex)
        {
            updateLabel.Text = ex.Message;
        }      
    }
}