using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZooDb.Models;

namespace ZooDb.Data
{
    public static class SampleData
    {

        public static void Initialize(ZooContext context)
        {
            if (!context.Zoos.Any())
            {
                context.Zoos.AddRange(
                    new Zoo
                    {
                        Name = "Philadelphia National Zoo",
                        Address = "50 Watertown St",
                        FoundingYear = new DateTime(2006, 3, 20)
                       
                    }
                );
              
            }
            context.SaveChanges();
            if (!context.Employees.Any())
            {
                context.Employees.AddRange(
                    new Employee
                    {
                        FullName = "Jason Parker",
                        MaleFemale = "Male",
                        Age = 38,
                        Experience = "4 years",
                        PhoneNumber = "202-555-0143",
                        Zoo = context.Zoos.First()
                    }
                );
            }
            context.SaveChanges();

            if (!context.AnimalTypes.Any())
            {
                context.AnimalTypes.AddRange(
                    new AnimalType
                    {
                        TypeName = "Birds",
                        Description = "Birds are animals that have feathers and that are born out of hard-shelled eggs."
                    },
                    new AnimalType
                    {
                        TypeName = "Mammals",
                        Description = "If an animal drinks milk when it is a baby and has hair on its body, it belongs to the mammal class."
                    },
                    new AnimalType
                    {
                        TypeName = "Fish",
                        Description = "Fish are vertebrates that live in water and have gills, scales and fins on their body.  There are a lot of different fish and many of them look very odd indeed. "
                    },
                    new AnimalType
                    {
                        TypeName = "Reptiles",
                        Description = "Reptiles are a class of animal with scaly skin.  They are cold blooded and are born on land. Snakes, lizards, crocodiles, alligators and turtles all belong to the reptile class."
                    },
                    new AnimalType
                    {
                        TypeName = "Amphibians",
                        Description = "Amphibians are born in the water.  When they are born, they breath with gills like a fish.  But when they grow up, they develop lungs and can live on land."
                    },
                    new AnimalType
                    {
                        TypeName = "Arthropods",
                        Description = "Any animals that have more than four, jointed legs are arthropods.  Insects, spiders and crustaceans all belong to this class of animals."
                    }
                );
            }
            context.SaveChanges();
            if (!context.Aviaries.Any())
            {
                context.Aviaries.AddRange(
                    new Aviary
                    {
                        AviaryName = "Aviary for tigers"
                    },
                    new Aviary
                    {
                        AviaryName = "Aviary for birds №1"
                    },
                    new Aviary
                     {
                         AviaryName = "Aviary for birds №2"
                     },
                    new Aviary
                    {
                        AviaryName = "Aviary for wolfs"
                    },
                    new Aviary
                    {
                        AviaryName = "Aviary for bears"
                    },
                    new Aviary
                    {
                        AviaryName = "Aviary for snakes"
                    },
                    new Aviary
                    {
                        AviaryName = "Aviary for spiders"
                    },
                    new Aviary
                    {
                        AviaryName = "Aviary for alligators"
                    },
                    new Aviary
                    {
                        AviaryName = "Aviary for kangaroos"
                    },
                    new Aviary
                    {
                        AviaryName = "Aviary for dolphins"
                    },
                    new Aviary
                    {
                        AviaryName = "Aviary for sharks"
                    }
                );
            }
            context.SaveChanges();
            if (!context.Animals.Any())
            {
                context.Animals.AddRange(
                    new Animal
                    {
                        Name = "Koala",
                        AnimalType = context.AnimalTypes.First(),
                        Aviary = context.Aviaries.First(),
                        MaleFemale = "Female",
                        Growth = "0,65 m",
                        Weight = "7 kg",
                        Age = 5,
                        Birthday = new DateTime(2013, 10, 1),
                        Employee = context.Employees.First(),
                        Zoo = context.Zoos.First()
                    }
                );

            }
            context.SaveChanges();
          
           
        }

    }
}
