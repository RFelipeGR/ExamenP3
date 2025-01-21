using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Android.Graphics;
using MovieSearchApp.Models;
using Newtonsoft.Json;

namespace RobertoGuañaExamen3P.Services
{
    public class MovieService
    {
        private readonly HttpClient _httpClient = new();

        public async Task<Movie?> SearchMovieAsync(string query)
        {
            try
            {
                var url = $"https://freetestapi.com/api/v1/movies?search={query}&limit=1";
                var response = await _httpClient.GetStringAsync(url);

                var result = JsonConvert.DeserializeObject<dynamic>(response);
                if (result.movies != null && result.movies.Count > 0)
                {
                    var movieData = result.movies[0];
                    return new Movie
                    {
                        Title = (string)movieData.title,
                        Genre = (string)movieData.genres[0],
                        MainActor = (string)movieData.actors[0],
                        Awards = (string)movieData.awards,
                        Website = (string)movieData.website,
                        Scordova = "RGuaña"
                    };
                }

                return null;
            }
            catch
            {
                return null;
            }
        }
    }
}
