using System;
using System.Collections.Generic;

namespace FactoryMethod
{
    public abstract class Subscription
    {
        public double MonthlyFee { get; set; }
        public int MinPeriodMonths { get; set; }
        public List<string> Channels { get; set; } = new List<string>();
        public List<string> Features { get; set; } = new List<string>();

        public abstract string GetSubscriptionType();

        public void PrintInfo()
        {
            Console.WriteLine($"--- {GetSubscriptionType()} ---");
            Console.WriteLine($"Щомісячна плата: {MonthlyFee} грн");
            Console.WriteLine($"Мінімальний період: {MinPeriodMonths} міс.");
            Console.WriteLine($"Список каналів: {string.Join(", ", Channels)}");
            Console.WriteLine($"Особливості: {string.Join(", ", Features)}");
            Console.WriteLine(new string('-', 40));
        }
    }

    public class DomesticSubscription : Subscription
    {
        public DomesticSubscription()
        {
            MonthlyFee = 150.0;
            MinPeriodMonths = 1;
            Channels.AddRange(new[] { "UA:Перший", "1+1", "Новий Канал", "ICTV" });
            Features.Add("Базова якість HD");
        }
        public override string GetSubscriptionType() => "DomesticSubscription";
    }

    public class EducationalSubscription : Subscription
    {
        public EducationalSubscription()
        {
            MonthlyFee = 120.0;
            MinPeriodMonths = 3;
            Channels.AddRange(new[] { "Discovery Channel", "National Geographic", "Da Vinci" });
            Features.Add("Доступ до наукових тестів");
        }
        public override string GetSubscriptionType() => "EducationalSubscription";
    }

    public class PremiumSubscription : Subscription
    {
        public PremiumSubscription()
        {
            MonthlyFee = 400.0;
            MinPeriodMonths = 12;
            Channels.AddRange(new[] { "HBO HD", "Netflix Originals", "Megogo Футбол" });
            Features.Add("Якість 4K Ultra HD");
        }
        public override string GetSubscriptionType() => "PremiumSubscription";
    }

    public abstract class SubscriptionCreator
    {
        public abstract Subscription CreateSubscription(string type);
    }

    public class WebSite : SubscriptionCreator
    {
        public override Subscription CreateSubscription(string type)
        {
            Subscription sub = type.ToLower() switch
            {
                "domestic" => new DomesticSubscription(),
                "educational" => new EducationalSubscription(),
                _ => new PremiumSubscription()
            };

            sub.MonthlyFee *= 0.9;
            sub.Features.Add("підключай через веб-сайт");
            return sub;
        }
    }

    public class MobileApp : SubscriptionCreator
    {
        public override Subscription CreateSubscription(string type)
        {
            Subscription sub = type.ToLower() switch
            {
                "domestic" => new DomesticSubscription(),
                "educational" => new EducationalSubscription(),
                _ => new PremiumSubscription()
            };

            sub.Features.Add("підключай через мобільний застосунок (бонусний мобільний трафік)");
            return sub;
        }
    }

    public class ManagerCall : SubscriptionCreator
    {
        public override Subscription CreateSubscription(string type)
        {
            Subscription sub = type.ToLower() switch
            {
                "domestic" => new DomesticSubscription(),
                "educational" => new EducationalSubscription(),
                _ => new PremiumSubscription()
            };

            sub.MonthlyFee += 20;
            sub.Features.Add("оформлюй через дзвінок менеджеру");
            return sub;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            SubscriptionCreator website = new WebSite();
            SubscriptionCreator mobileApp = new MobileApp();
            SubscriptionCreator manager = new ManagerCall();

            Subscription sub1 = website.CreateSubscription("domestic");
            sub1.PrintInfo();

            Subscription sub2 = mobileApp.CreateSubscription("premium");
            sub2.PrintInfo();

            Subscription sub3 = manager.CreateSubscription("educational");
            sub3.PrintInfo();

            Console.ReadKey();
        }
    }
}