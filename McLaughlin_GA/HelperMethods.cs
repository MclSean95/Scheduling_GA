using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McLaughlin_GA
{
    class HelperMethods
    {
        public Chromosome CreateChromosome(Random random)
        {
            Chromosome temp = new Chromosome();
            int[] chromosome = new int[10];

            for (int i = 0; i < chromosome.Length; i++)
            {
                chromosome[i] = random.Next(0, 5);
            }
            temp.chromosome = chromosome;
            return temp;
        }

        public List<Chromosome> CreatePopulation(Random random)
        {
            List<Chromosome> temp = new List<Chromosome>();
            Chromosome chromosome = new Chromosome();
            for (int i = 0; i < 40; i++)
            {
                temp.Add(CreateChromosome(random));
            }
            return temp;
        }

        public float CalcFitnessValue(int[] chromosome, List<Employee> employees)
        {
            float conflicts = 0;

            Employee current;
            Employee previous = null;
            int dayCounter = 0;

            for (int i = 0; i < chromosome.Length; i++)
            {
                current = employees[chromosome[i]];

                if (current.HoursWorked >= 24)
                    conflicts++;

                if (i % 2 == 0)
                {
                    //If the starting unavailability falls sometime during the shift.
                    if (current.GetAvailabilityStart(dayCounter) >= 9 && current.GetAvailabilityStart(dayCounter) <= 13)
                        conflicts++;
                    //If the ending unavailability falls sometime during the shift.
                    if (current.GetAvailabilityEnd(dayCounter) >= 9 && current.GetAvailabilityEnd(dayCounter) <= 13)
                        conflicts++;
                    //If the start unavailability starts before the shift and the unavailability ends after the end of the shift.
                    if (current.GetAvailabilityStart(dayCounter) <= 9 && current.GetAvailabilityEnd(dayCounter) >= 13)
                        conflicts++;
                }
                else
                {
                    //If the starting unavailability falls sometime during the shift.
                    if (current.GetAvailabilityStart(dayCounter) >= 13 && current.GetAvailabilityStart(dayCounter) <= 17)
                        conflicts++;
                    //If the ending unavailability falls sometime during the shift.
                    if (current.GetAvailabilityEnd(dayCounter) >= 13 && current.GetAvailabilityEnd(dayCounter) <= 17)
                        conflicts++;
                    //If the start unavailability starts before the shift and the unavailability ends after the end of the shift.
                    if (current.GetAvailabilityStart(dayCounter) <= 13 && current.GetAvailabilityEnd(dayCounter) >= 17)
                        conflicts++;
                }

                if (previous != null)
                {
                    if (previous.EmployeeID == current.EmployeeID)
                        conflicts++;
                }

                current.HoursWorked += 4;
                previous = current;

                if (i % 2 == 0 && i != 0)
                    dayCounter++;
            }



            float fitness = 1 / (conflicts + 1);

            return fitness;
        }

        public Chromosome[] Crossover(Chromosome mom, Chromosome dad, Random random)
        {
            Chromosome[] babies = new Chromosome[2];
            int crossoverPoint1;
            Chromosome baby1 = new Chromosome();
            Chromosome baby2 = new Chromosome();
            baby1.chromosome = new int[10];
            baby2.chromosome = new int[10];

                crossoverPoint1 = random.Next(0, mom.chromosome.Length-2);

            for (int i = 0; i < 10; i++)
            {
                if (i < crossoverPoint1)
                {
                   baby1.chromosome[i] = mom.chromosome[i];
                    baby2.chromosome[i] = dad.chromosome[i];
                }
                else
                {
                    baby2.chromosome[i] = mom.chromosome[i];
                   baby1.chromosome[i] = dad.chromosome[i];
                }
            }
            babies[0] = baby1;
            babies[1] = baby2;

            return babies;
        }

        public Chromosome RouletteSelection(List<Chromosome> population, Random random)
        {
            float totalFitness = 0;
            float currentFitness = 0;

            foreach (Chromosome c in population)
            {
                totalFitness += c.FitnessValue;
            }

            float rand = (float)random.NextDouble() * totalFitness;

            foreach (Chromosome c in population)
            {
                if (rand >= currentFitness && rand <= currentFitness + c.FitnessValue)
                    return c;

                currentFitness += c.FitnessValue;
            }

            return null;
        }

        
    }
}
