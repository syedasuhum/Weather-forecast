using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Net.Http;
using Newtonsoft.Json;

public partial class Weather_app_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected async void btnGetWeather_Click(object sender, EventArgs e)
    {
        string cityName = txtCityName.Text.Trim();

        // Replace spaces in city name with %20 for URL
        string cityQuery = cityName.Replace(" ", "%20");

        // OpenWeatherMap API endpoint for current weather
        string apiKey = "09e82a3cdc8c8c925fef0c8f8abfa7d3"; // Replace with your own API key
        string apiUrl = string.Format("http://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}&units=metric", cityQuery, apiKey);


        // Create HttpClient
        using (HttpClient client = new HttpClient())
        {
            try
            {
                // Send GET request to API
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                // Check if request was successful
                if (response.IsSuccessStatusCode)
                {
                    // Read response content
                    string json = await response.Content.ReadAsStringAsync();

                    // Deserialize JSON response
                    WeatherData weatherData = JsonConvert.DeserializeObject<WeatherData>(json);

                    // Display weather information
                   
                    string weatherInfo = "<h1>Weather in " + weatherData.Name + ", " + weatherData.Sys.Country + ":</h3>"
+ "<h2>Description: " + weatherData.Weather[0].Description + "</p>"
+ "<h2>Temperature: " + weatherData.Main.Temp + "°C</p>"
+ "<h2>Feels like: " + weatherData.Main.FeelsLike + "°C</p>"
+"<h2> Humidity:" +weatherData.Main.Humidity + "°C</p>"
                                + "<p>Wind speed:" + weatherData.Wind.Speed +" m/s</p>";


                    lblWeatherInfo.Text = weatherInfo;
                    lblWeatherInfo.Visible = true;
                }
                else
                {
                    lblWeatherInfo.Text = "Failed to retrieve weather data. Status code: " + response.StatusCode;

                    lblWeatherInfo.Visible = true;
                }
            }
            catch (HttpRequestException ex)
            {
                lblWeatherInfo.Text = "Error: " + ex.Message;

                lblWeatherInfo.Visible = true;
            }
        }
    }


// Define classes to represent JSON response
public class WeatherData
{
    public Weather[] Weather { get; set; }
    public MainData Main { get; set; }
    public WindData Wind { get; set; }
    public string Name { get; set; }
    public SysData Sys { get; set; }
}

public class Weather
{
    public string Description { get; set; }
}

public class MainData
{
    public float Temp { get; set; }
    public float FeelsLike { get; set; }
    public int Humidity { get; set; }
}

public class WindData
{
    public float Speed { get; set; }
}

public class SysData
{
    public string Country { get; set; }
}

}