namespace Heist
{
public class Hacker : IRobber
{
    public string Name { get; set; }
    public int SkillLevel { get; set; }
    public int PercentageCut { get; set; }
    public int Index { get; set; }
    public string Specialty { get; set; }= "Hacker";
    public void PerformSkill(Bank bank)
    {
        bank.AlarmScore -= SkillLevel;
        Console.WriteLine($"{Name} is hacking the alarm system. Decreased security {SkillLevel} points");
        if (bank.AlarmScore <= 0)
        {
            Console.WriteLine($"{Name} has disabled the alarm system!");
        }
    }
}

public class Muscle : IRobber
{
    public string Name { get; set; }
    public int SkillLevel { get; set; }
    public int PercentageCut { get; set; }
     public int Index { get; set; }
     public string Specialty {get; set;} = "Muscle";
    public void PerformSkill(Bank bank)
    {
        bank.SecurityGuardScore -= SkillLevel;
        Console.WriteLine($"{Name} is taking out the security guards. Decreased security {SkillLevel} points");
        if (bank.SecurityGuardScore <= 0)
        {
            Console.WriteLine($"{Name} has disabled the security guards!");
        }
    }
}

public class LockSpecialist : IRobber
{
    public string Name { get; set; }
    public int SkillLevel { get; set; }
    public int PercentageCut { get; set; }
     public int Index { get; set; }
     public string Specialty {get; set; } = "Lock Specialist";
    public void PerformSkill(Bank bank)
    {
        bank.VaultScore -= SkillLevel;
        Console.WriteLine($"{Name} is cracking the vault. Decreased security {SkillLevel} points");
        if (bank.VaultScore <= 0)
        {
            Console.WriteLine($"{Name} has cracked the vault!");
        }
    }
}
}