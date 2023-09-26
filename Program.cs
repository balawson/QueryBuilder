// Blake Lawson
// Server Side Web Programming
// Lab 3
// 09/26/2023

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string dbPath = ("C:/Users/blake/source/repos/QueryBuild/data/data.db");

                using (var queryBuilder = new QueryBuilder(dbPath))
                {
                    queryBuilder.DeleteAll<Models.Pokemon>();
                    if (queryBuilder.ReadAll<Models.Pokemon>().Count() < 1)
                    {
                        Console.WriteLine("Deleted all records from Pokemon Table.");
                    }
                    
                    queryBuilder.DeleteAll<Models.BannedGame>();
                    if (queryBuilder.ReadAll<Models.Pokemon>().Count() < 1)
                    {
                        Console.WriteLine("Deleted all records from BannedGame Table.");
                    }

                    var pokemon1 = new Models.Pokemon
                    {
                        DexNumber = 1,
                        Name = "Party Weiner",
                        Form = "Male",
                        Type1 = "Rock",
                        Type2 = "Fire",
                        Total = 20,
                        HP = 200,
                        Attack = 43,
                        Defense = 80,
                        SpecialAttack = 120,
                        SpecialDefense = 130,
                        Speed = 55,
                        Generation = 1
                    };
                    queryBuilder.Create(pokemon1);
                    Console.WriteLine("Inserted a Pokemon instance into the database.");

                    var bannedGame1 = new Models.BannedGame
                    {
                        Title = "Madden 24",
                        Series = "Madden",
                        Country = "USA",
                        Details = "It's not banned but it should be since EA re-releases the same game every year.",
                    };
                    queryBuilder.Create(bannedGame1);
                    Console.WriteLine("Inserted a BannedGame instance into the database.");

                    var pokemon = new List<Models.Pokemon>
                    {
                        new Models.Pokemon
                        {
                            DexNumber = 2,
                            Name = "Punchy Rock",
                            Form = "Male",
                            Type1 = "Rock",
                            Type2 = "Grass",
                            Total = 33,
                            HP = 300,
                            Attack = 66,
                            Defense = 90,
                            SpecialAttack = 123,
                            SpecialDefense = 120,
                            Speed = 23,
                            Generation = 1
                        },
                        new Models.Pokemon
                        {
                            DexNumber = 3,
                            Name = "Onion Turtle",
                            Form = "",
                            Type1 = "Grass",
                            Type2 = "Fire",
                            Total = 60,
                            HP = 150,
                            Attack = 80,
                            Defense = 80,
                            SpecialAttack = 160,
                            SpecialDefense = 130,
                            Speed = 47,
                            Generation = 2
                        }
                    };
                    foreach (var game in pokemon)
                    {
                        queryBuilder.Create(game);
                    }
                    Console.WriteLine("Inserted a collection of Pokemon' into the database.");

                    var bannedGames = new List<Models.BannedGame>
                    {
                        new Models.BannedGame
                        {
                            Title = "Flappy Bird",
                            Series = "Flappy Bird",
                            Country = "Canada",
                            Details = "Caused Violence"
                        },
                        new Models.BannedGame
                        {
                            Title = "Call of Duty MW2",
                            Series = "Call of Duty",
                            Country = "USA",
                            Details = "Too fun!?!"
                        }
                    };
                    foreach (var game in bannedGames)
                    {
                        queryBuilder.Create(game);
                    }
                    Console.WriteLine("Inserted a collection of Banned Games into the database.");

                    queryBuilder.Dispose();
                }
            } catch (Exception x)
            {
                Console.WriteLine($"Error: {x.Message}");
            }
            
        }
    }
}
