using OpenWeatherAPI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Converter;
using WeatherApp.Models;
using WeatherApp.ViewModels;

namespace WeatherApp.Services
{
    public class OpenWeatherService : ITemperatureService
    {
        private static OpenWeatherProcessor owp;

        public TemperatureModel LastTemp;


        public OpenWeatherService(string apiKey)
        {
            owp = OpenWeatherProcessor.Instance;
            owp.ApiKey = apiKey;
        }


        public async Task<TemperatureModel> GetTempAsync()
        {
            var currentWeather = await owp.GetCurrentWeatherAsync();
            TemperatureModel temp = new TemperatureModel();

            //long l = Convert.ToInt64(DateTime.UnixEpoch);
            // theres a shit about the time hour (pc stuck 2hrs too early)
            DateTime dttime = new DateTime(1970,1,1,0,0,0, DateTimeKind.Utc);

            temp.DateTime = dttime.AddSeconds(currentWeather.DateTime).ToLocalTime();

            temp.Temperature = currentWeather.Main.Temperature;
            TemperatureConverter.FahrenheitInCelsius(temp.Temperature);

            LastTemp = temp;
            return temp;

        }
    }
}
