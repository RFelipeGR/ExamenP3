
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RobertoGuañaExamen_3P.DataBase;
using RobertoGuañaExamen_3P.Services;

using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace RobertoGuañaExamen_3P.ViewModels
{
    public partial class MovieViewModel : ObservableObject
    {
        private readonly MovieService _movieService;
        private readonly DatabaseService _databaseService;

        [ObservableProperty]
        private string _searchQuery;

        [ObservableProperty]
        private string _message;

        public ObservableCollection<Movie> Movies { get; } = new();
        public string? SearchQuery { get; private set; }
        public string Message { get; private set; }

        public MovieViewModel(MovieService movieService, DatabaseService databaseService)
        {
            _movieService = movieService;
            _databaseService = databaseService;
        }

        [RelayCommand]
        public async Task SearchMovie()
        {
            if (string.IsNullOrWhiteSpace(SearchQuery))
            {
                Message = "El campo de búsqueda está vacío.";
                return;
            }

            var movie = await _movieService.SearchMovieAsync(SearchQuery);
            if (movie != null)
            {
                await _databaseService.SaveMovieAsync(movie);
                Movies.Add(movie);
                Message = "Película guardada correctamente.";
            }
            else
            {
                Message = "No se encontró ninguna película.";
            }
        }

        [RelayCommand]
        public void ClearSearch() => SearchQuery = string.Empty;

        [RelayCommand]
        public async Task LoadMovies()
        {
            var movies = await _databaseService.GetMoviesAsync();
            Movies.Clear();
            foreach (var movie in movies)
                Movies.Add(movie);
        }
    }

    internal class RelayCommandAttribute : Attribute
    {
    }

    internal class ObservablePropertyAttribute : Attribute
    {
    }
}
