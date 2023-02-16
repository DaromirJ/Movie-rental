using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;

namespace Movie_rental
{
    public class Program
    {
        static void Main(string[] args)
        {
            MenuActionService actionService = new MenuActionService();
            MovieService movieService = new MovieService();
            actionService = Initialize(actionService);

            Console.WriteLine("Welcome to Movie rental app");
            while(true)
            {
                Console.WriteLine("Please let me know what you want to do");

                var mainMenu = actionService.GetMenuActionsByMenuName("Main");
                for(int i = 0; i < mainMenu.Count; i++)
                {
                    Console.WriteLine($"{mainMenu[i].Id}. {mainMenu[i].Name}");
                }
                var operation = Console.ReadKey();
                switch (operation.KeyChar)
                {
                    case '1':
                        var keyInfo = movieService.AddNewMovieView(actionService);
                        var id = movieService.AddNewMovie(keyInfo.KeyChar);
                        break;
                    case '2':
                        var removeId = movieService.RemoveMovieView();
                        movieService.RemoveMovie(removeId);
                        break;
                    case '3':
                        var detailId = movieService.MovieDetailSelectionView();
                        movieService.MovieDetailView(detailId);

                        break;
                    case '4':
                        var typeId = movieService.MovieTypeSelectionView();
                        movieService.MovieByTypeIdView(typeId);
                        break;

                    default:
                        Console.WriteLine("Action you entered does not exist");
                        break;
                }
            }
        }

        private static MenuActionService Initialize(MenuActionService actionService)
        {
            actionService.AddNewAction(1, "Add movie", "Main");
            actionService.AddNewAction(2, "Remove movie", "Main");
            actionService.AddNewAction(3, "Show details", "Main");
            actionService.AddNewAction(4, "List of movies", "Main");

            actionService.AddNewAction(1, "Sensational", "AddNewMovieMenu");
            actionService.AddNewAction(2, "Casual movie", "AddNewMovieMenu");
            actionService.AddNewAction(3, "Adventurous", "AddNewMovieMenu");
            actionService.AddNewAction(4, "Musical", "AddNewMovieMenu");
            return actionService;

        }
    }
}

