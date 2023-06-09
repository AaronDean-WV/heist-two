// Now that we have a clue what kind of security we're working with, we can try to built out the perfect crew.

// Print out a report of the rolodex that includes each person's name, specialty, skill level, and cut. Include an index in the report for each operative so that the user can select them by that index in the next step. (You may want to update the IRobber interface and/or the implementing classes to be able to print out the specialty)

// Create a new List<IRobber> and store it in a variable called crew. Prompt the user to enter the index of the operative they'd like to include in the heist. Once the user selects an operative, add them to the crew list.

// Allow the user to select as many crew members as they'd like from the rolodex. Continue to print out the report after each crew member is selected, but the report should not include operatives that have already been added to the crew, or operatives that require a percentage cut that can't be offered.

// Once the user enters a blank value for a crew member, we're ready to begin the heist. Each crew member should perform his/her skill on the bank. Afterwards, evaluate if the bank is secure. If not, the heist was a success! Print out a success message to the user. If the bank does still have positive values for any of its security properties, the heist was a failure. Print out a failure message to the user.

// If the heist was a success, print out a report of each members' take, along with how much money is left for yourself.

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
                PercentageCut = 25,
                
            });
            rolodex.Add(new LockSpecialist() {
                Name = "Squidward",
                SkillLevel = 35,
                PercentageCut = 15,
               
            });
            rolodex.Add(new Muscle() {
                Name = "Patrick",
                SkillLevel = 40,
                PercentageCut = 15,
                
            });
            rolodex.Add(new Hacker() {
                Name = "Spongebob",
                SkillLevel = 60,
                PercentageCut = 14,
               
            });
            rolodex.Add(new LockSpecialist() {
                Name = "Sandy",
                SkillLevel = 45,
                PercentageCut = 16,
           
            });
           rolodex.Add(new Hacker() {
                Name = "Mr. Krabs",
                SkillLevel = 55,
                PercentageCut = 20,
                
            });

            Console.WriteLine($"There are {rolodex.Count} operatives in the rolodex.");
                   
while (true)
{
    Console.WriteLine("Enter a new operative's name to add them to the rolodex or leave blank to pick the crew.");
    string name = Console.ReadLine();
    if (string.IsNullOrEmpty(name))
    {
        break;
    }
     Console.WriteLine("Enter the operative's specialty.");
    Console.WriteLine("1. Hacker (Disables alarms)");
    Console.WriteLine("2. Muscle (Disarms guards)");
    Console.WriteLine("3. Lock Specialist (cracks vault)");
    int specialty = Int32.Parse(Console.ReadLine());

     Console.WriteLine("Enter the operative's skill level (1-100).");
     int skillLevel = Int32.Parse(Console.ReadLine());

     Console.WriteLine("Enter the percentage cut the operative demands for each mission.");
     int percentageCut = Int32.Parse(Console.ReadLine());
     
     if (!string.IsNullOrEmpty(name))
    {
        switch (specialty)
        {
            case 1:
                rolodex.Add(new Hacker()
                {
                    Name = name,
                    SkillLevel = skillLevel,
                    PercentageCut = percentageCut,
                });
                break;
            case 2:
                rolodex.Add(new Muscle()
                {
                    Name = name,
                    SkillLevel = skillLevel,
                    PercentageCut = percentageCut
                });
                break;
            case 3:
                rolodex.Add(new LockSpecialist()
                {
                    Name = name,
                    SkillLevel = skillLevel,
                    PercentageCut = percentageCut
                });
                break;
        }
    }
}
        Bank bigBank = new Bank();
        Random random = new Random();
        bigBank.AlarmScore = random.Next(0, 101);
        bigBank.VaultScore = random.Next(0, 101);
        bigBank.SecurityGuardScore = random.Next(0, 101);
        bigBank.CashOnHand = random.Next(50000, 1000001);

        Console.WriteLine($"The bank's alarm score is {bigBank.AlarmScore}");
        Console.WriteLine($"The bank's vault score is {bigBank.VaultScore}");
        Console.WriteLine($"The bank's security guard score is {bigBank.SecurityGuardScore}");
        Console.WriteLine($"The bank has {bigBank.CashOnHand} in cash on hand.");
        
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

        List<IRobber> crew = new List<IRobber>();
        int totalCut = 0;

        while(true){

        // int index = 0;
        // foreach (IRobber robber in rolodex)
        // {
        //     Console.WriteLine($"Name: {robber.Name}");
        //     Console.WriteLine($"Specialty: {robber.Specialty}");
        //     Console.WriteLine($"Skill Level: {robber.SkillLevel}");
        //     Console.WriteLine($"Percentage Cut: {robber.PercentageCut}");
        //     index++;
        //     Console.WriteLine($"Index #{index}");
        // } 

        for (int i= 0; i < rolodex.Count; i++)
        {
            if(!crew.Contains(rolodex[i]) && rolodex[i].PercentageCut + totalCut < 100){
            Console.WriteLine($"{i + 1} Name: {rolodex[i].Name}  Specialty: {rolodex[i].Specialty}  Skill Level: {rolodex[i].SkillLevel}  Percetage Cut: {rolodex[i].PercentageCut}");
            }
        }

        Console.WriteLine("Enter the index of the operative you'd like to add to your crew or press enter to start your heist.");

        string selection = Console.ReadLine();
        if (string.IsNullOrEmpty(selection))
        {
            break;
        }
        int indexSelection = Int32.Parse(selection);
        crew.Add(rolodex[indexSelection - 1]);
        totalCut = crew.Sum(robber => robber.PercentageCut);

        Console.WriteLine($"Your crew's total cut is {totalCut} and there are {crew.Count} members in your crew.");
        }

        foreach (IRobber crewMember in crew)
        {
            crewMember.PerformSkill(bigBank);
        }

        if(bigBank.IsSecure)
        {
            Console.WriteLine("You've failed to rob the bank!");
        }
        else
        {
            Console.WriteLine("You've successfully robbed the bank!");
            
            foreach (IRobber crewMember in crew)
            {
               crewCut = bigBank.CashOnHand 
        
    }

    }
}}