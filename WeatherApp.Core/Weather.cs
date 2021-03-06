﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeatherApp.Core
{
    public class Weather
    {
        public string Title { get; set; } = " ";
        public string Temperature { get; set; } = " ";
        public string Wind { get; set; } = " ";
        public string Main { get; set; } = " ";
        public string AirPressure { get; set; } = " ";
        public string Date { get; set; } = " ";
        public string Icon { get; set; } = " ";
    }
}