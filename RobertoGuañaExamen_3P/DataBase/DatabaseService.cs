
    using SQLite;
    using System.Threading.Tasks;
    using System.Collections.Generic;
using RobertoGuañaExamen_3P.Models;

namespace RobertoGuañaExamen_3P.DataBase
{
        public class DatabaseService
        {
            private readonly SQLiteAsyncConnection _database;

            public DatabaseService(string dbPath)
            {
                _database = new SQLiteAsyncConnection(dbPath);
                _database.CreateTableAsync<Movie>().Wait();
            }

            public Task<int> SaveMovieAsync(Movie movie) => _database.InsertAsync(movie);

            public Task<List<Movie>> GetMoviesAsync() => _database.Table<Movie>().ToListAsync();
        }
    }
