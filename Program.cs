using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace RoverChallenge {
    class Program {
        static void Main (string[] args) {
            try {
                List<Rover> rovers = new List<Rover> ();
                Console.WriteLine ("Enter Map Size (example: 44)");
                string mapSize = Console.ReadLine ();
                Regex validator = new Regex (@"\d{2}");
                if (!validator.IsMatch (mapSize)) {
                    throw new Exception (message: "Map size input was not in correct format");
                }
                var iMapSize = mapSize.ToCharArray ().Select (c => Int32.Parse (c.ToString ())).ToArray ();

                Console.WriteLine ("Enter Rover Number (example: 2)");
                int roverCount;
                if (!int.TryParse (Console.ReadLine (), out roverCount)) {
                    throw new Exception (message: "Rover number was not in correct format");
                }

                for (int i = 0; i < roverCount; i++) {
                    Console.WriteLine ($"Enter Rover {i+1} Coordinate (example: 11n )");
                    string coordinate = Console.ReadLine ();
                    validator = new Regex (@"\d{2}[nNsSeEwW]");
                    if (!validator.IsMatch (coordinate)) {
                        throw new Exception (message: "Coordinate input was not in correct format");
                    }

                    Console.WriteLine ("Enter Rover Instructions (example: lrmlrm)");
                    string instructions = Console.ReadLine ();
                    validator = new Regex (@"^[lLrRmM]+$");
                    if (!validator.IsMatch (instructions)) {
                        throw new Exception (message: "Instruction input was not in correct format");
                    }
                    rovers.Add (new Rover () {
                        xCoordinate = Int32.Parse (coordinate.Substring (0, 1)),
                            yCoordinate = Int32.Parse (coordinate.Substring (1, 1)),
                            Direction = coordinate.Substring (2, 1).ToUpper (),
                            Instructions = instructions.ToUpper ().ToCharArray ().Select (c => c.ToString ()).ToArray ()
                    });
                }

                System.Console.WriteLine ("Calculating...");

                foreach (var rover in rovers) {
                    Instructions inst = new Instructions (rover, iMapSize);
                    Console.WriteLine (inst.StartInstructions ());
                }
                Console.ReadLine ();
            } catch (Exception ex) {
                Console.WriteLine (ex.Message);
                Console.ReadLine ();
            }
        }
    }
}