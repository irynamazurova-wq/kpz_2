#nullable disable
using System;
using System.Collections.Generic;

namespace BuilderPattern
{
    public class Character
    {
        public int Height { get; set; }
        public string Build { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public string Clothing { get; set; }
        public string Inventory { get; set; }
        public List<string> GoodDeeds { get; set; } = new List<string>();
        public List<string> EvilDeeds { get; set; } = new List<string>();

        public void ShowInfo(string role)
        {
            Console.WriteLine($"--- {role} ---");
            Console.WriteLine($"Зріст: {Height} см, Статура: {Build}");
            Console.WriteLine($"Волосся: {HairColor}, Очі: {EyeColor}");
            Console.WriteLine($"Одяг: {Clothing}");
            Console.WriteLine($"Інвентар: {Inventory}");
            
            if (GoodDeeds.Count > 0)
                Console.WriteLine($"Добрі справи: {string.Join(", ", GoodDeeds)}");
            if (EvilDeeds.Count > 0)
                Console.WriteLine($"Злі справи: {string.Join(", ", EvilDeeds)}");
            Console.WriteLine();
        }
    }

    public interface ICharacterBuilder
    {
        ICharacterBuilder SetHeight(int height);
        ICharacterBuilder SetBuild(string build);
        ICharacterBuilder SetHairColor(string color);
        ICharacterBuilder SetEyeColor(string color);
        ICharacterBuilder SetClothing(string clothing);
        ICharacterBuilder SetInventory(string inventory);
        ICharacterBuilder DoDeed(string deed);
        Character GetResult();
    }

    public class HeroBuilder : ICharacterBuilder
    {
        private Character _character = new Character();

        public ICharacterBuilder SetHeight(int height) { _character.Height = height; return this; }
        public ICharacterBuilder SetBuild(string build) { _character.Build = build; return this; }
        public ICharacterBuilder SetHairColor(string color) { _character.HairColor = color; return this; }
        public ICharacterBuilder SetEyeColor(string color) { _character.EyeColor = color; return this; }
        public ICharacterBuilder SetClothing(string clothing) { _character.Clothing = clothing; return this; }
        public ICharacterBuilder SetInventory(string inventory) { _character.Inventory = inventory; return this; }
        public ICharacterBuilder DoDeed(string deed) { _character.GoodDeeds.Add(deed); return this; }
        public Character GetResult() { return _character; }
    }

    public class EnemyBuilder : ICharacterBuilder
    {
        private Character _character = new Character();

        public ICharacterBuilder SetHeight(int height) { _character.Height = height; return this; }
        public ICharacterBuilder SetBuild(string build) { _character.Build = build; return this; }
        public ICharacterBuilder SetHairColor(string color) { _character.HairColor = color; return this; }
        public ICharacterBuilder SetEyeColor(string color) { _character.EyeColor = color; return this; }
        public ICharacterBuilder SetClothing(string clothing) { _character.Clothing = clothing; return this; }
        public ICharacterBuilder SetInventory(string inventory) { _character.Inventory = inventory; return this; }
        public ICharacterBuilder DoDeed(string deed) { _character.EvilDeeds.Add(deed); return this; }
        public Character GetResult() { return _character; }
    }

    public class Director
    {
        public void ConstructDreamHero(ICharacterBuilder builder)
        {
            builder.SetHeight(185)
                   .SetBuild("атлетична")
                   .SetHairColor("світле")
                   .SetEyeColor("блакитні")
                   .SetClothing("сяючі лицарські обладунки")
                   .SetInventory("меч світла, щит, зілля зцілення")
                   .DoDeed("врятував королівство")
                   .DoDeed("допоміг бідним");
        }

        public void ConstructNemesis(ICharacterBuilder builder)
        {
            builder.SetHeight(205)
                   .SetBuild("кремезна")
                   .SetHairColor("лисий")
                   .SetEyeColor("червоні")
                   .SetClothing("темний плащ із капюшоном")
                   .SetInventory("посох темряви, Отрута")
                   .DoDeed("викрав принцесу")
                   .DoDeed("зруйнував міст");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Director director = new Director();

            ICharacterBuilder heroBuilder = new HeroBuilder();
            director.ConstructDreamHero(heroBuilder);
            Character hero = heroBuilder.GetResult();
            hero.ShowInfo("Герой");

            ICharacterBuilder enemyBuilder = new EnemyBuilder();
            director.ConstructNemesis(enemyBuilder);
            Character enemy = enemyBuilder.GetResult();
            enemy.ShowInfo("Ворог");

            Console.ReadKey();
        }
    }
}