using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using static System.Console;

namespace HighScoreManager
{
    class Program
    {
        
        static readonly HttpClient httpClient = new HttpClient();

        static void Main(string[] args)
        {
            httpClient.BaseAddress = new Uri("https://localhost:5001/api/games");
            CursorVisible = false;

            bool applicationRunning = true;

            do
            {
                WriteLine("1. Register highscore");
                WriteLine("2. List games");
                WriteLine("3. Add game");
                WriteLine("4. Delete game");
                WriteLine("5. Exit");

                ConsoleKeyInfo input = ReadKey(true);

                Clear();

                switch (input.Key)
                {
                    case ConsoleKey.D1:

                        RegisterHighscore();

                        break;

                    case ConsoleKey.D2:

                        ListGames();

                        break;

                    case ConsoleKey.D3:

                        AddGame();

                        break;

                    case ConsoleKey.D4:

                        DeleteGame();

                        break;

                    case ConsoleKey.D5:

                        applicationRunning = false;

                        break;
                }

                Clear();

            } while (applicationRunning);

        }

        private static void DeleteGame()
        {
            Write("ID:");

            string id = ReadLine();

            var response = httpClient.DeleteAsync($"games/{id}").Result;

            Clear();
            if (response.IsSuccessStatusCode) 
            {
                WriteLine("Game deleted");
            }
            else
            {
                WriteLine("No game has been deletd");
            }
            Thread.Sleep(2000);
        }
        private static void AddGame()
        {

            Write("Title: ");

            string name = ReadLine();


            Write("Description: ");

            string description = ReadLine();

            Write("Release Year: ");

            int releaseYear = int.Parse(ReadLine());

            Write("Genre: ");

            string genre = ReadLine();


            //https://via.placeholder.com/300x300.png?text=game
            Write("Image URL: ");

            string imageUrl = ReadLine();


            Write("Is this correct? (Y / N) ");

            var isCorrectInput = ReadKey(true).Key;

            while (isCorrectInput != ConsoleKey.Y && isCorrectInput != ConsoleKey.N)
            {
                isCorrectInput = ReadKey(true).Key;
            }
            if (isCorrectInput == ConsoleKey.Y)
            {
                Clear();

                var game = new Game(name, description, releaseYear, genre, imageUrl);

                //serialized game to JSON
                var serializedGame = JsonConvert.SerializeObject(game);
          
                var data = new StringContent(serializedGame, Encoding.UTF8, "application/json");

                //send our serialized game over the network, up to HifhScore (where it then deserialized to some object) 
                var response = httpClient.PostAsync("games", data).Result;

                if (response.IsSuccessStatusCode) 
                {
                    WriteLine("Game added");
                }
                else
                {
                    WriteLine("Sorry, invalid data");
                }

                Thread.Sleep(2000);
                Clear();

            }
        }
        private static void ListGames()
        {
            var resopnse = httpClient.GetAsync("games")
                .GetAwaiter()
                .GetResult();

            if (resopnse.IsSuccessStatusCode)
            {
                var jsonString = resopnse.Content.ReadAsStringAsync()
                    .Result;

                var games = JsonConvert.DeserializeObject<IEnumerable<Game>>(jsonString);

                WriteLine("ID       Title ");
                WriteLine("-----------------------------------------------------");
                foreach (var game in games)
                {
                    WriteLine($"{game.GameId}\t {game.Name}");
                }
            }
            ReadKey(true);


        }

        private static void RegisterHighscore()
        {

            Write("Game name: ");

            string gameName =  ReadLine();


            Write("Player: ");

            string playerName = ReadLine();

            Write("Date: ");

            string date = ReadLine();

            Write("Score: ");

            int score = int.Parse(ReadLine());

            Write("Is this correct? (Y / N) ");

            var isCorrectInput = ReadKey(true).Key;

            while (isCorrectInput != ConsoleKey.Y && isCorrectInput != ConsoleKey.N)
            {
                isCorrectInput = ReadKey(true).Key;
            }
            if (isCorrectInput == ConsoleKey.Y)
            {
                Clear();
                var gameId = FetchGameIdByGameName(gameName);

                var highScore = new HighScore( gameId, playerName, date, score);

                //serialized highScore to JSON
                var serializedGame = JsonConvert.SerializeObject(highScore);

                var data = new StringContent(serializedGame, Encoding.UTF8, "application/json");

                // Set the content type to JSON 
                data.Headers.ContentType = new MediaTypeHeaderValue("application/json");


                //send our serialized game over the network, up to HighScore (where it then deserialized to some object) 
                var response = httpClient.PostAsync("highscores", data).Result;

                if (response.IsSuccessStatusCode)
                {
                    WriteLine("Highscore registered");
                }
                else
                {
                    WriteLine("Sorry, invalid data");
                }

                Thread.Sleep(2000);
                Clear();

            }

        }

        private static int FetchGameIdByGameName(string gameName)
        {
            // HTTP GET https://localhost:5001/api/games
            var response = httpClient.GetAsync("games")
                .GetAwaiter()
                .GetResult();

            if (response.IsSuccessStatusCode)
            {
                var jsonString = response.Content.ReadAsStringAsync()
                    .GetAwaiter()
                    .GetResult();

                var games = JsonConvert.DeserializeObject<IEnumerable<Game>>(jsonString);

                foreach (var game in games)
                {
                    if (game.Name == gameName)
                    {
                        return game.GameId;
                    }
                }
            }
            return -1;
        }
        
    }
}
