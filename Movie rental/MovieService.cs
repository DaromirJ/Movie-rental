using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie_rental
{
    public class MovieService
    {
        public List<Movie> Movies { get; set; }
        public MovieService()
        {
            Movies = new List<Movie>();
        }

        public ConsoleKeyInfo AddNewMovieView(MenuActionService actionService)
        {
            var addNewMovieMenu = actionService.GetMenuActionsByMenuName("AddNewMovieMenu");
            Console.WriteLine("Please select movie type");
            for (int i = 0; i < addNewMovieMenu.Count; i++)
            {
                Console.WriteLine($"{addNewMovieMenu[i].Id}. {addNewMovieMenu[i].Name}");
            }

            var operation = Console.ReadKey();
            return operation;
        }
        public int AddNewMovie(char movieType)
        {
            int movieTypeId;
            Int32.TryParse(movieType.ToString(), out movieTypeId);
            Movie movie = new Movie();
            movie.TypeId = movieTypeId;
            Console.WriteLine("Please enter id for new movie:");
            var id = Console.ReadLine();
            int movieId;
            Int32.TryParse(id, out movieId);
            Console.WriteLine("Please enter name for new movie:");
            var name = Console.ReadLine();

            movie.Id = movieId;
            movie.Name = name;

            Movies.Add(movie);
            return movieId;
        }

        public int RemoveMovieView()
        {
            Console.WriteLine("Please enter id for movie you want to remove:");
            var movieId = Console.ReadKey();
            int id;
            Int32.TryParse(movieId.KeyChar.ToString(), out id);
            return id;

        }

        public void RemoveMovie(int removeId)
        {
            Movie filmToRemove = new Movie();
            foreach (var movie in Movies)
            {
                if (movie.Id == removeId)
                {
                    filmToRemove = movie;
                    break;
                }
            }
            Movies.Remove(filmToRemove);
        }

        public void MovieDetailView(int detailId)
        {
            Movie filmToShow = new Movie();
            foreach (var movie in Movies)
            {
                if (movie.Id == detailId)
                {
                    filmToShow = movie;
                    break;
                }
            }
            Console.WriteLine($"Movie id: {filmToShow.Id}");
            Console.WriteLine($"Movie name: {filmToShow.Name}");
            Console.WriteLine($"Movie type id: {filmToShow.TypeId}");
        }

        public int MovieDetailSelectionView()
        {
            Console.WriteLine("Please enter id for movie you wont to show");
            var movieId = Console.ReadKey();
            int id;
            Int32.TryParse(movieId.KeyChar.ToString(), out id);
            return id;

        }
    }
}
