﻿using Microsoft.Maui.Controls;

namespace RoboClearingApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
