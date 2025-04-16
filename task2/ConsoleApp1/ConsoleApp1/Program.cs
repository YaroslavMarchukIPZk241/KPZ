using System;

class Program
{
    public interface IHero
    {
        string GetDescription();
        int GetStats(); 
    }

    public class Warrior : IHero
    {
        public string GetDescription() => "Warrior";
        public int GetStats() => 100;
    }

    public class Mage : IHero
    {
        public string GetDescription() => "Mage";
        public int GetStats() => 80;
    }

    public class Palladin : IHero
    {
        public string GetDescription() => "Palladin";
        public int GetStats() => 90;
    }
    public abstract class HeroDecorator : IHero
    {
        protected IHero hero;

        public HeroDecorator(IHero hero)
        {
            this.hero = hero;
        }

        public virtual string GetDescription() => hero.GetDescription();
        public virtual int GetStats() => hero.GetStats();
    }

    public class Armor : HeroDecorator
    {
        public Armor(IHero hero) : base(hero) { }

        public override string GetDescription() => hero.GetDescription() + " + Armor";
        public override int GetStats() => hero.GetStats() + 20;
    }

    public class Weapon : HeroDecorator
    {
        public Weapon(IHero hero) : base(hero) { }

        public override string GetDescription() => hero.GetDescription() + " + Weapon";
        public override int GetStats() => hero.GetStats() + 30;
    }

    public class Artifact : HeroDecorator
    {
        public Artifact(IHero hero) : base(hero) { }

        public override string GetDescription() => hero.GetDescription() + " + Artifact";
        public override int GetStats() => hero.GetStats() + 15;
    }
    static void Main(string[] args)
    {
        IHero hero1 = new Warrior();
        hero1 = new Armor(hero1);
        hero1 = new Weapon(hero1);
        hero1 = new Artifact(hero1);
        hero1 = new Artifact(hero1); 

        Console.WriteLine(hero1.GetDescription());
        Console.WriteLine("Power hero: " + hero1.GetStats());

        IHero hero2 = new Mage();
        hero2 = new Artifact(hero2);
        hero2 = new Weapon(hero2);

        Console.WriteLine(hero2.GetDescription());
        Console.WriteLine("Power hero: " + hero2.GetStats());

        IHero hero3 = new Palladin();
        hero3 = new Armor(hero3);
        hero3 = new Armor(hero3);
        hero3 = new Weapon(hero3);

        Console.WriteLine(hero3.GetDescription());
        Console.WriteLine("Power hero: " + hero3.GetStats());

    }
}