using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace LinqTut
{
    class Program
    {
        static void Main(string[] args)
        {
            QueryStringArray();

            QueryIntArray();

            QueryArrayList();

            QueryCollection();

            QueryAnimalData();
        }

        static void QueryStringArray()
        {
            string[] dogs = { "K 9", "Brian Griffin", "Scooby Doo", "Old Yeller", "Rin Tin Tin", "Benji", "Charlie B. Barkin", "Lassie" };

            var dogSpaces = from dog in dogs
                            where dog.Contains(" ")
                            orderby dog descending
                            select dog;

            foreach (var i in dogSpaces)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine();
        }

        static int[] QueryIntArray()
        {
            int[] nums = { 5, 10, 15, 20 ,25, 30, 35 };

            var gt20 = from num in nums
                        where num > 20
                        orderby num
                        select num;

            foreach (var i in gt20)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine();

            Console.WriteLine($"Get Type : {gt20.GetType()}");

            var listGT20 = gt20.ToList<int>();
            var arrayGT20 = gt20.ToArray();

            nums[0] = 40;

            foreach (var i in gt20)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine();

            return arrayGT20;
        }

        static void QueryArrayList()
        {
            var famAnimals  = new ArrayList()
            {
                new Animal
                {
                    Name = "Heidi",
                    Height = 0.8,
                    Weight = 18
                },
                new Animal
                {
                    Name = "Shrek",
                    Height = 4,
                    Weight = 130
                },
                new Animal
                {
                    Name = "Congo",
                    Height = 3.8,
                    Weight = 90
                }
            };

            var famAnimalEnum = famAnimals.OfType<Animal>();

            var smAnimals = from animal in famAnimalEnum
                            where animal.Weight <= 90
                            orderby animal.Name
                            select animal;

            foreach (var i in smAnimals)
            {
                Console.WriteLine($"{i.Name} weighs {i.Weight} lbs");
            }

            Console.WriteLine();
        }

        static void QueryCollection()
        {
            var animalList = new List<Animal>()
            {
                new Animal
                {
                    Name = "German Shepherd",
                    Height = 25,
                    Weight = 77
                },
                new Animal
                {
                    Name = "Chihuahua",
                    Height = 7,
                    Weight = 4.4
                },
                new Animal
                {
                    Name = "Saint Bernard",
                    Height = 30,
                    Weight = 200
                }
            };

            var bigDogs = from dog in animalList
                            where (dog.Weight > 70) && (dog.Height > 25)
                            orderby dog.Name
                            select dog;

            foreach (var i in bigDogs)
            {
                Console.WriteLine($"{i.Name} weighs {i.Weight} lbs");
            }

            Console.WriteLine();
        }

        static void QueryAnimalData()
        {
            var animals = new Animal[]
            {
                new Animal
                {
                    Name = "German Shepherd",
                    Height = 25,
                    Weight = 77,
                    AnimalId = 1
                },
                new Animal
                {
                    Name = "Chihuahua",
                    Height = 7,
                    Weight = 4.4,
                    AnimalId = 2
                },
                new Animal
                {
                    Name = "Saint Bernard",
                    Height = 30,
                    Weight = 200,
                    AnimalId = 3
                },
                new Animal
                {
                    Name = "Pug",
                    Height = 12,
                    Weight = 16,
                    AnimalId = 1
                },
                new Animal
                {
                    Name = "Beagle",
                    Height = 15,
                    Weight = 23,
                    AnimalId = 2
                }
            };

            var owners = new Owner[]
            {
                new Owner
                {
                    Name = "Doug Parks",
                    OwnerId = 1
                },
                new Owner
                {
                    Name = "Sally Smith",
                    OwnerId = 2
                },
                new Owner
                {
                    Name = "Paul Brooks",
                    OwnerId = 3
                }
            };

            var nameHeight = from animal in animals
                            select new
                            {
                                animal.Name,
                                animal.Height
                            };

            foreach (var i in nameHeight)
            {
                Console.WriteLine(i.ToString());
            }

            Console.WriteLine();

            var innerJoin = from animal in animals
                            join owner in owners on animal.AnimalId equals owner.OwnerId
                            select new
                            {
                                OwnerName = owner.Name,
                                AnimalName = animal.Name
                            };
            
            foreach (var i in innerJoin)
            {
                Console.WriteLine($"{i.OwnerName} owns {i.AnimalName}");
            }

            Console.WriteLine();

            var groupJoin = from owner in owners
                            orderby owner.OwnerId
                            join animal in animals on owner.OwnerId equals animal.AnimalId
                            into ownerAnimals
                            select new
                            {
                                Owner = owner.Name,
                                Animals = from animal in ownerAnimals
                                            orderby animal.Name
                                            select animal
                            };

            foreach (var ownerGroup in groupJoin)
            {
                Console.WriteLine(ownerGroup.Owner);
                foreach (var animal in ownerGroup.Animals)
                {
                    Console.WriteLine($"* {animal.Name}");
                }
            }
            
            Console.WriteLine();
        }
    }
}