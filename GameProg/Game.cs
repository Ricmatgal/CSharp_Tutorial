using OOProg;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace GameProg
{
	// EXERCISE
	// Make a game where the player have to :
	// - follow a succession of randomly generated intersections : at each intersection the player have to guess the Direction (Left, Forward, Right) using arrows key from the keyboard.
	// - choose a Vehicule to start the party
	// You have to count the time in second spent by the player to finish a party.
	// Then you can record the score done in a file called "Highscores.txt" : each row in the file is [Date, PlayerName(4 characters), VehiculeName(3 characters), time(s)]
	// Ask the name of the player just after he finished a party, before recording his score to the file.
	class Game
	{
		// These are not variables (no memory allocated).
		// We call them constants.
		public const int DEFAULT_INTERSECTIONS_COUNT = 10;
		public const int USERNAME_LENGHT = 4;
		public const string HIGHSCORES_FILENAME = "Highscores.txt";

		// This property has no associated attribute. It acts like a method.
		public bool Continue { get { return !_quit; } }

		// Better to always init your variables with default value, than having too much confidence in the compiler (the compiler "should" already put default values).
		private List<Direction> _intersections = new List<Direction>();
		private int _currentIntersectionIndex = 0;
		private Stopwatch _stopWatch = null;
		private Vehicule _vehicule = null;
		private bool _quit = false;

		void AskIntersection()
		{
			Console.WriteLine("Intersection " + (_currentIntersectionIndex + 1) + " : direction ?");
		}

		void AddScore(DateTime pDate, string pUsername, string pVehiculename, double pTime)
		{
			// Create the row entry.
			StringBuilder row = new StringBuilder();
			row.Append(pDate.ToString());
			row.Append(" ");
			row.Append(pUsername);
			row.Append(" ");
			row.Append(pVehiculename);
			row.Append(" ");
			row.Append(pTime.ToString("0.00"));
			row.Append("s");
			row.AppendLine();
			// Append the row to the Highscore file.
			string filepath = Path.GetFullPath("./" + HIGHSCORES_FILENAME);
			File.AppendAllText(filepath, row.ToString());
		}

		string GetUserName()
		{
			Console.Write("Enter your name : ");
			string username = "";
			while(username.Length < USERNAME_LENGHT)
			{
				ConsoleKey keyPressed = Console.ReadKey(true).Key;
				if( (keyPressed >= ConsoleKey.A) && (keyPressed <= ConsoleKey.Z) )
				{
					string letter = keyPressed.ToString();
					username += letter;
					Console.Write(letter); // Write the new letter.
				}
				else if(keyPressed == ConsoleKey.Backspace)
				{
					if(username.Length > 0)
					{
						username = username.Remove(username.Length - 1);
						Console.Write("\b \b"); // Remove the last letter.
					}
				}
			}
			Console.WriteLine();
			return username;
		}

		void StartNew(int pMaxIntersections)
		{
			// Exercise.
			// Generate new List of Random intersections.
			Random rand = new Random();
			_intersections.Clear();
			int directionsCount = Enum.GetValues(typeof(Direction)).Length;
			while (_intersections.Count < pMaxIntersections)
			{
				_intersections.Add((Direction)rand.Next(0, directionsCount));
			}
			// Reset progression.
			_currentIntersectionIndex = 0;
			// Reset vehicule.
			_vehicule = null;

			// Show Game rules.
			Console.WriteLine("====================================THE BEST GAME EVER========================================");
			Console.WriteLine(string.Format("Find the {0} successive directions to win the game in the minimum amount of time.", pMaxIntersections));
			Console.WriteLine("Press Escape to Quit...");
			Console.WriteLine("Please choose your vehicule to start : Car(1) | Bike(2) | Bus(3).");
			// Wait while user doesn't chose his vehicule.
			while (true)
			{
				ConsoleKey keyPressed = Console.ReadKey(true).Key;
				if (keyPressed == ConsoleKey.Escape)
				{
					_quit = true;
					// Stop the while loop.
					break;
				}
				else if(keyPressed == ConsoleKey.NumPad1)
				{
					_vehicule = new Car();
				}
				else if (keyPressed == ConsoleKey.NumPad2)
				{
					_vehicule = new Bike();
				}
				else if (keyPressed == ConsoleKey.NumPad3)
				{
					_vehicule = new Bus();
				}

				// User successfully choose a vehicule.
				if(_vehicule != null)
				{
					// Stop the while loop.
					Console.WriteLine("You choose : " + _vehicule.ToString());
					break;
				}
			}

			// Ask for the first intersection.
			AskIntersection();

			// Game is starting. Reset timer.
			_stopWatch = Stopwatch.StartNew();
		}

		void Update()
		{
			// Get direction at current intersection.
			Direction currentIntersectionDir = _intersections[_currentIntersectionIndex];

			// Get user input.
			bool success = false;
			bool gameplayKeyPressed = false;
			{
				ConsoleKey keyPressed = Console.ReadKey(true).Key;
				bool leftArrowPressed = (keyPressed == ConsoleKey.LeftArrow);
				bool upArrowPressed = (keyPressed == ConsoleKey.UpArrow);
				bool rightArrowPressed = (keyPressed == ConsoleKey.RightArrow);
				gameplayKeyPressed = (leftArrowPressed || upArrowPressed || rightArrowPressed);
				if (keyPressed == ConsoleKey.Escape)
				{
					_quit = true;
					return; // stop executing the next instructions and quit the function immediately.
				}
				else if(gameplayKeyPressed)
				{
					success =  (leftArrowPressed && (currentIntersectionDir == Direction.Left))
							|| (upArrowPressed && (currentIntersectionDir == Direction.Forward))
							|| (rightArrowPressed && (currentIntersectionDir == Direction.Right));
				}
			}

			if(gameplayKeyPressed)
			{
				// Update progression
				if (success)
				{
					_vehicule.Move(currentIntersectionDir);
					++_currentIntersectionIndex;
				}
				else
				{
					Console.WriteLine("Wrong direction. Try again...");
				}

				// Check if game finished.
				if (_currentIntersectionIndex >= _intersections.Count)
				{
					// Get time.
					_stopWatch.Stop();
					double time = _stopWatch.Elapsed.TotalSeconds;
					// Get Date.
					DateTime date = DateTime.Now;
					// Show End of Game Message.
					Console.WriteLine(string.Format("You finished the best game ever in {0:0.00}s !", time));
					Console.WriteLine("Congratulations !");
					// Get Username.
					string username = GetUserName();
					// Add the score in the highscore file.
					AddScore(date, username, _vehicule.GetType().Name.Substring(0, 3), time);
					// Ask for a new party.
					Console.WriteLine("Press Enter to start another party, or press Escape to quit...");
					while (true)
					{
						ConsoleKey keyPressed = Console.ReadKey(true).Key;
						if (keyPressed == ConsoleKey.Escape)
						{
							_quit = true;
							return; // break the loop and quit function immediately
						}
						else if (keyPressed == ConsoleKey.Enter)
						{
							StartNew(_intersections.Count);
							return; // break the loop and quit function immediately
						}
					}
				}
				else
				{
					// Ask for the next intersection.
					AskIntersection();
				}
			}
		}

		// This is the entry point of every program.
		//static void Main(string[] args) // can receive arguments from command line.
		//static void Main() // no arguments from command line.
		static void Main(string[] args) // can receive arguments from command line.
		{
			// OO Comprehension : a variable of type Vehicule can handle a child type.
			Vehicule vehicule = new Vehicule();
			Vehicule vehicule2 = new Car();
			Vehicule vehicule3 = new Bike();
			Vehicule vehicule4 = new Bus();
			Vehicule[] vehicules = new Vehicule[4] { vehicule, vehicule2, vehicule3, vehicule4 };
			// We can iterate through a set of Vehicule without the need to know their real type (child type).
			foreach(Vehicule vec in vehicules)
			{
				Console.WriteLine(vec.ToString());
			}

			int maxIntersections = DEFAULT_INTERSECTIONS_COUNT; // Default.
			// Get max intersections from command line if argument is present.
			if (args.Length > 0)
			{
				// Check if the argument is an integer.
				int max;
				if(int.TryParse(args[0], out max))
				{
					// If yes, override maxIntersections value.
					maxIntersections = max;
				}
			}
			
			// Start the game.
			Game game = new Game();
			game.StartNew(maxIntersections);
			// Game loop : update till the user quit.
			while(game.Continue)
			{
				game.Update();
				// Typical Game engine loop.
				// Inputs.Upate();
				// Animations.Update();
				// Physics.Update();
				// Audio.Update();
				// Graphics.Update();
				// UI.Update();
			}
		}
	}
}
