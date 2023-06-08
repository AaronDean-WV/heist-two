// The program should create a new bank object and randomly assign values for these properties:

// AlarmScore (between 0 and 100)
// VaultScore (between 0 and 100)
// SecurityGuardScore (between 0 and 100)
// CashOnHand (between 50,000 and 1 million)
// Let's do a little recon next. Print out a Recon Report to the user. This should tell the user what the bank's most secure system is, and what its least secure system is (don't print the actual integer scores--just the name, i.e. Most Secure: Alarm Least Secure: Vault


using System;
using System.Collections.Generic;

namespace Heist
{
    class Program
    {
        static void Main(string[] args)
        {
          List<IRobber> rolodex = new List<IRobber>(); 
            rolodex.Add(new Muscle() {
                Name = "Gary",
                SkillLevel = 50,
                PercentageCut = 20
            });
            rolodex.Add(new LockSpecialist() {
                Name = "Squidward",
                SkillLevel = 35,
                PercentageCut = 12
            });
            rolodex.Add(new Muscle() {
                Name = "Patrick",
                SkillLevel = 40,
                PercentageCut = 5
            });
            rolodex.Add(new Hacker() {
                Name = "Spongebob",
                SkillLevel = 60,
                PercentageCut = 25
            });
            rolodex.Add(new LockSpecialist() {
                Name = "Sandy",
                SkillLevel = 45,
                PercentageCut = 18
            });
            rolodex.Add(new Hacker() {
                Name = "Mr. Krabs",
                SkillLevel = 55,
                PercentageCut = 85
            });

            Console.WriteLine($"There are {rolodex.Count} operatives in the rolodex.");
            Console.WriteLine("Enter a new operative's name to add them to the rolodex.");
            string name = Console.ReadLine();
            if (name != "")
            {
                Console.WriteLine("Enter the operative's specialty.");
                Console.WriteLine("1. Hacker (Disables alarms)");
                Console.WriteLine("2. Muscle (Disarms guards)");
                Console.WriteLine("3. Lock Specialist (cracks vault)");
                int specialty = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Enter the operative's skill level (1-100).");
                int skillLevel = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Enter the percentage cut the operative demands for each mission.");
                int percentageCut = Int32.Parse(Console.ReadLine());
                if (specialty == 1)
                {
                    rolodex.Add(new Hacker() {
                        Name = name,
                        SkillLevel = skillLevel,
                        PercentageCut = percentageCut
                    });
                }
                else if (specialty == 2)
                {
                    rolodex.Add(new Muscle() {
                        Name = name,
                        SkillLevel = skillLevel,
                        PercentageCut = percentageCut
                    });
                }
                else if (specialty == 3)
                {
                    rolodex.Add(new LockSpecialist() {
                        Name = name,
                        SkillLevel = skillLevel,
                        PercentageCut = percentageCut
                    });
                }

                Console.WriteLine("Enter a new operative's name to add them to the rolodex or leave blank to stop.");
               string userInput = Console.ReadLine();
              if(!string.IsNullOrEmpty(userInput)) break;
        }
        Bank bigBank = new Bank();
        Random random = new Random();
        bigBank.AlarmScore = random.Next(0, 101);
        bigBank.VaultScore = random.Next(0, 101);
        bigBank.SecurityGuardScore = random.Next(0, 101);
        bigBank.CashOnHand = random.Next(50000, 1000001);
        
          string MostSecure()
        {
            if (bigBank.AlarmScore > bigBank.VaultScore && bigBank.AlarmScore > bigBank.SecurityGuardScore)
            {
                return "Alarm";
            }
            else if (bigBank.VaultScore > bigBank.AlarmScore && bigBank.VaultScore > bigBank.SecurityGuardScore)
            {
                return "Vault";
            }
            else if (bigBank.SecurityGuardScore > bigBank.AlarmScore && bigBank.SecurityGuardScore > bigBank.VaultScore)
            {
                return "Security Guards";
            }
            else
            {
                return "All systems are equally secure";
            }
        };
        Console.WriteLine($"The Most Secure system is: {MostSecure()}");
    }

    }
}