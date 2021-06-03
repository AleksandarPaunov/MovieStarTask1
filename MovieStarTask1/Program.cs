using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;



namespace MovieStarTask1
{
    class Program
    {
        static void Main(string[] args)
        {
           


            var jsonText = File.ReadAllText("input.txt"); 
            var movieStars = JsonConvert.DeserializeObject<IList<MovieStar>>(jsonText);

            foreach (var star in movieStars)
            {
                Console.WriteLine(star.Name +" "+star.Surname);
                Console.WriteLine(star.Sex);
                Console.WriteLine(star.Nationality);
                
                //Console.WriteLine(DateTime.Now.Year-DateTime.Parse(star.DateOfBirth).Year+" years old");
                //Age(star.DateOfBirth);
                AgeCalculation2(star.DateOfBirth);
            }

        }
        public static void Age(string dateOfBirth) // Easy way to get the age but not as accurate.
        {
            var customerBY = DateTime.Parse(dateOfBirth).Year;
            var today = DateTime.Now.Year;

            var age = today - customerBY;

            Console.WriteLine(age + " years old");

        }

        public static void AgeCalculation2(string dateOfBirth) // More accurage but uglier way.
        {
            var dobApi = DateTime.Parse(dateOfBirth);
            int now = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
            int dob = int.Parse(dobApi.ToString("yyyyMMdd"));
            int age = (now - dob) / 10000; // drops the last 4 digits

            Console.WriteLine(age + " years old");

        }
    }
}
