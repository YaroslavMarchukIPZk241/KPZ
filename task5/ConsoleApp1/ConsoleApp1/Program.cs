using System;
using System.Collections.Generic;

namespace BuilderPatternExample
{
    public class Character
    {
        public string Name { get; set; }
        public int Height { get; set; }           
        public string Build { get; set; }       
        public string HairColor { get; set; }     
        public string EyeColor { get; set; }    
        public string Outfit { get; set; }      
        public List<string> Inventory { get; set; }  
        public List<string> GoodDeeds { get; set; }    
        public List<string> EvilDeeds { get; set; }    

        public Character()
        {
            Inventory = new List<string>();
            GoodDeeds = new List<string>();
            EvilDeeds = new List<string>();
        }

        public override string ToString()
        {
            var result = $"Name: {Name}\n" +
                         $"Height: {Height} см\n" +
                         $"Build: {Build}\n" +
                         $"Hair Color: {HairColor}\n" +
                         $"Eye Color: {EyeColor}\n" +
                         $"Outfit: {Outfit}\n" +
                         $"Inventory: {(Inventory.Count > 0 ? string.Join(", ", Inventory) : "None")}\n";

            if (GoodDeeds.Count > 0)
                result += $"Good Deeds: {string.Join(", ", GoodDeeds)}\n";
            if (EvilDeeds.Count > 0)
                result += $"Evil Deeds: {string.Join(", ", EvilDeeds)}\n";

            return result;
        }
    }

    // Базовий інтерфейс
    public interface ICharacterBuilder
    {
        Character Build();
    }

    // Інтерфейс для героя
    public interface IHeroBuilder : ICharacterBuilder
    {
        IHeroBuilder SetName(string name);
        IHeroBuilder SetHeight(int height);
        IHeroBuilder SetBuild(string build);
        IHeroBuilder SetHairColor(string hairColor);
        IHeroBuilder SetEyeColor(string eyeColor);
        IHeroBuilder SetOutfit(string outfit);
        IHeroBuilder SetInventory(List<string> inventory);
        IHeroBuilder AddGoodDeed(string deed);
    }

    // Інтерфейс для ворога
    public interface IEnemyBuilder : ICharacterBuilder
    {
        IEnemyBuilder SetName(string name);
        IEnemyBuilder SetHeight(int height);
        IEnemyBuilder SetBuild(string build);
        IEnemyBuilder SetHairColor(string hairColor);
        IEnemyBuilder SetEyeColor(string eyeColor);
        IEnemyBuilder SetOutfit(string outfit);
        IEnemyBuilder SetInventory(List<string> inventory);
        IEnemyBuilder AddEvilDeed(string deed);
    }

    
    public class HeroBuilder : IHeroBuilder
    {
        private Character character = new Character();

        public IHeroBuilder SetName(string name)
        {
            character.Name = name;
            return this;
        }

        public IHeroBuilder SetHeight(int height)
        {
            character.Height = height;
            return this;
        }

        public IHeroBuilder SetBuild(string build)
        {
            character.Build = build;
            return this;
        }

        public IHeroBuilder SetHairColor(string hairColor)
        {
            character.HairColor = hairColor;
            return this;
        }

        public IHeroBuilder SetEyeColor(string eyeColor)
        {
            character.EyeColor = eyeColor;
            return this;
        }

        public IHeroBuilder SetOutfit(string outfit)
        {
            character.Outfit = outfit;
            return this;
        }

        public IHeroBuilder SetInventory(List<string> inventory)
        {
            character.Inventory = inventory;
            return this;
        }

        public IHeroBuilder AddGoodDeed(string deed)
        {
            character.GoodDeeds.Add(deed);
            return this;
        }

        public Character Build()
        {
            return character;
        }
    }


    public class EnemyBuilder : IEnemyBuilder
    {
        private Character character = new Character();

        public IEnemyBuilder SetName(string name)
        {
            character.Name = name;
            return this;
        }

        public IEnemyBuilder SetHeight(int height)
        {
            character.Height = height;
            return this;
        }

        public IEnemyBuilder SetBuild(string build)
        {
            character.Build = build;
            return this;
        }

        public IEnemyBuilder SetHairColor(string hairColor)
        {
            character.HairColor = hairColor;
            return this;
        }

        public IEnemyBuilder SetEyeColor(string eyeColor)
        {
            character.EyeColor = eyeColor;
            return this;
        }

        public IEnemyBuilder SetOutfit(string outfit)
        {
            character.Outfit = outfit;
            return this;
        }

        public IEnemyBuilder SetInventory(List<string> inventory)
        {
            character.Inventory = inventory;
            return this;
        }

        public IEnemyBuilder AddEvilDeed(string deed)
        {
            character.EvilDeeds.Add(deed);
            return this;
        }

        public Character Build()
        {
            return character;
        }
    }

    public class CharacterDirector
    {
        public Character CreateHero(IHeroBuilder builder)
        {
            return builder
                .SetName("Аріана")
                .SetHeight(170)
                .SetBuild("Атлетична")
                .SetHairColor("Блондинка")
                .SetEyeColor("Блакитні")
                .SetOutfit("Лицарська броня")
                .SetInventory(new List<string> { "Меч", "Щит", "Зілля" })
                .AddGoodDeed("Врятувала село")
                .AddGoodDeed("Перемогла дракона")
                .Build();
        }

        public Character CreateEnemy(IEnemyBuilder builder)
        {
            return builder
                .SetName("Дракон")
                .SetHeight(190)
                .SetBuild("М'язистий")
                .SetHairColor("Чорний")
                .SetEyeColor("Червоні")
                .SetOutfit("Темний плащ")
                .SetInventory(new List<string> { "Темний меч", "Отрута" })
                .AddEvilDeed("Руйнував місто")
                .AddEvilDeed("Пленив героя")
                .Build();
        }
    }


    public class Program
    {
        public static void Main(string[] args)
        {
            CharacterDirector director = new CharacterDirector();
            IHeroBuilder heroBuilder = new HeroBuilder();
            IEnemyBuilder enemyBuilder = new EnemyBuilder();

            Character hero = director.CreateHero(heroBuilder);
            Console.WriteLine("Герой:");
            Console.WriteLine(hero.ToString());

            Character enemy = director.CreateEnemy(enemyBuilder);
            Console.WriteLine("Ворог:");
            Console.WriteLine(enemy.ToString());
        }
    }
}
