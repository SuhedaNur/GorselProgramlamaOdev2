﻿using GorselProgramlamaOdev2.Sayfalar;
namespace GorselProgramlamaOdev2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new AppShell();
            MainPage = new Giris();
        }
    }
}
