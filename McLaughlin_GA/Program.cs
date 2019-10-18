using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McLaughlin_GA
{
    class Program
    {

        static void Main(string[] args)
        {
            #region Properties
            List<Employee> employees = new List<Employee>();
            Random random = new Random();
            List<Chromosome> population = new List<Chromosome>();
            List<Chromosome> bufferPopulation = new List<Chromosome>();
            HelperMethods helperMethods = new HelperMethods();
            int generationCounter = 0;

            Chromosome prevMom = new Chromosome(), prevDad = new Chromosome();
            bool solved = false;
            #endregion

            #region Create Employees
            float?[] employee1 = new float?[] { 9, 12, null, null, 13, 18, 9, 12, 9, 12 };
            float?[] employee2 = new float?[] { null, null, 8, 10, null, null, 9, 12, 9, 18 };
            //float?[] employee2 = new float?[] { null, null, null, null, null, null, null, null, null, null };
            //float?[] employee3 = new float?[] { null, null, null, null, null, null, null, null, null, null };
             float?[] employee3 = new float?[] { 9, 18, null, null, 13, 18, null, null, null, null };
            float?[] employee4 = new float?[] { 8, 12, 13, 18, null, null, 13, 18, 8, 11 };
            float?[] employee5 = new float?[] { 9, 12, 9, 12, 9, 11, 9, 18, null, null };

            //float?[] employee1 = new float?[] { null, null, null, null, null, null, null, null, null, null };
            //float?[] employee2 = new float?[] { null, null, null, null, null, null, null, null, null, null };
            //float?[] employee3 = new float?[] { null, null, null, null, null, null, null, null, null, null };
            //float?[] employee4 = new float?[] { null, null, null, null, null, null, null, null, null, null };
            //float?[] employee5 = new float?[] { null, null, null, null, null, null, null, null, null, null };


            employees.Add(new Employee(employee1, "Sean", 0));
            employees.Add(new Employee(employee2, "Bob", 1));
            employees.Add(new Employee(employee3, "Tom", 2));
            employees.Add(new Employee(employee4, "Harry", 3));
            employees.Add(new Employee(employee5, "Phil", 4));
            #endregion

            population = helperMethods.CreatePopulation(random);
            for (int i = 0; i < population.Count; i++)
            {
                population[i].FitnessValue = helperMethods.CalcFitnessValue(population[i].chromosome, employees);

                Console.WriteLine("Chromosome " + i.ToString() + " Fitness = " + population[i].FitnessValue.ToString());

                Console.WriteLine("|---------------------------|");
                Console.WriteLine("|-------| M | T | W | TH| F |");
                Console.WriteLine("| Open  | " + population[i].chromosome[0].ToString() + " | " + population[i].chromosome[2].ToString() + " | " + population[i].chromosome[4].ToString() + " | " + population[i].chromosome[6].ToString() + " | " + population[i].chromosome[8].ToString() + " |");
                Console.WriteLine("|---------------------------|");
                Console.WriteLine("| Close | " + population[i].chromosome[1].ToString() + " | " + population[i].chromosome[3].ToString() + " | " + population[i].chromosome[5].ToString() + " | " + population[i].chromosome[7].ToString() + " | " + population[i].chromosome[9].ToString() + " |");
                Console.WriteLine("|---------------------------|");

            }

            while (!solved)
            {

                Console.Title = generationCounter.ToString();

                foreach (Chromosome c in population)
                {
                    if (c.FitnessValue == 1)
                    {
                        solved = true;
                        continue;
                    }
                }

                //Begin doing crossover
                if (bufferPopulation.Count < 40)
                {


                    //Select a mother chromosome for crossover.
                    Chromosome mom = helperMethods.RouletteSelection(population, random);
                    //Select a father chromosome for crossover.
                    Chromosome dad = helperMethods.RouletteSelection(population, random);

                    //If the mother and father chromosomes are the same pick a new father.
                    if (mom == dad)
                    {
                        continue;
                    }

                    if (mom == prevMom || dad == prevDad)
                        continue;
                    Chromosome[] temp = helperMethods.Crossover(mom, dad, random);

                    //Perform the crossover and add the 2 new children to a buffer population.
                    foreach (Chromosome c in temp)
                    {
                        bufferPopulation.Add(c);
                    }

                    prevMom = mom;
                    prevDad = dad;
                    continue;
                }

                population = bufferPopulation.ToList();

                bufferPopulation.Clear();

                for (int i = 0; i < population.Count; i++)
                {
                    population[i].FitnessValue = helperMethods.CalcFitnessValue(population[i].chromosome, employees);

                    Console.WriteLine("Chromosome " + i.ToString() + " Fitness = " + population[i].FitnessValue.ToString());

                    Console.WriteLine("|---------------------------|");
                    Console.WriteLine("|-------| M | T | W | TH| F |");
                    Console.WriteLine("| Open  | " + population[i].chromosome[0].ToString() + " | " + population[i].chromosome[2].ToString() + " | " + population[i].chromosome[4].ToString() + " | " + population[i].chromosome[6].ToString() + " | " + population[i].chromosome[8].ToString() + " |");
                    Console.WriteLine("|---------------------------|");
                    Console.WriteLine("| Close | " + population[i].chromosome[1].ToString() + " | " + population[i].chromosome[3].ToString() + " | " + population[i].chromosome[5].ToString() + " | " + population[i].chromosome[7].ToString() + " | " + population[i].chromosome[9].ToString() + " |");
                    Console.WriteLine("|---------------------------|");

                }
                generationCounter++;
                System.Threading.Thread.Sleep(500);
            }
            Console.ReadLine();
        }
    }
}
