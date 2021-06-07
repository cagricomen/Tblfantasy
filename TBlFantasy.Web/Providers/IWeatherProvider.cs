using System.Collections.Generic;
using TBlFantasy.Web.Models;

namespace TBlFantasy.Web.Providers
{
    public interface IWeatherProvider
    {
        List<WeatherForecast> GetForecasts();
    }
}
