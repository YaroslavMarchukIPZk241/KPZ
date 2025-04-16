using System;
using System.Reflection.Metadata;
using System.Threading.Channels;

namespace ConsoleApp1
{
static class Program
 {
        public interface ISubscription
        {
            void RenewSubscription(double userPayment);
            void CheckSubscriptionStatus();
            void DisplayChannels();
        }
        public interface ICostomizateChanel
        {
            void AddChannels(List<string> channels);
        }
       public abstract class FCreateSubscription
        {
            public abstract ISubscription BuySubscription(string subscriptionType);
        }
    public class WebSite : FCreateSubscription
     {
            public override ISubscription BuySubscription(string subscriptionType)
            {
                Console.WriteLine("користувач оформлює через сайт");
                switch (subscriptionType.ToLower())
                {
                    case "premium":
                        return new PremiumSubscription();
                    case "domestic":
                        return new DomesticSubscription();
                    case "educational":
                        return new EducationalSubscription();
                    default:
                        throw new Exception("Unknown subscription type");
                }
            }
        }
    public class MobileApp : FCreateSubscription
     {
            public override ISubscription BuySubscription(string subscriptionType)
            {
                Console.WriteLine("користувач оформлює через сайт");
                switch (subscriptionType.ToLower())
                {
                    case "premium":
                        return new PremiumSubscription();
                    case "domestic":
                        return new DomesticSubscription();
                    case "educational":
                        return new EducationalSubscription();
                    default:
                        throw new Exception("Unknown subscription type");
                }
            }
        }
    public class ManagerCall : FCreateSubscription
     {
            public override ISubscription BuySubscription(string subscriptionType)
            {
                Console.WriteLine("користувач оформлює через сайт");
                switch (subscriptionType.ToLower())
                {
                    case "premium":
                        return new PremiumSubscription();
                    case "domestic":
                        return new DomesticSubscription();
                    case "educational":
                        return new EducationalSubscription();
                    default:
                        throw new Exception("Unknown subscription type");
                }
            }
        }

        public class PremiumSubscription : ISubscription, ICostomizateChanel
        {
            private static int limit = 90; 
            private TimeSpan subscriptionDuration = TimeSpan.FromDays(limit);
            private TimeSpan userSubscriptionTime;

            private double tarif = 350.0; 

            private List<string> tvChannels = new List<string>();
            private int UserChanelLimit; 
            public void SetUserSubscriptionTime(int timeInDays)
            {
                userSubscriptionTime = TimeSpan.FromDays(timeInDays);
                UserChanelLimit = 0;
            }
            public void CheckSubscriptionStatus()
            {
                if (userSubscriptionTime > subscriptionDuration)
                {
                    Console.WriteLine("Термін вашої підписки завершився, будь ласка, продовжіть оплату для доступу до контенту.");
                }
                else
                {
                    Console.WriteLine($"Залишилось часу на підписку: {subscriptionDuration - userSubscriptionTime} днів.");
                }
            }
            public void RenewSubscription(double userPayment)
            {
                if (userPayment < tarif)
                {
                    Console.WriteLine("У вас недостатньо коштів для продовження підписки.");
                }
                else
                {
                    Console.WriteLine("Підписку оновлено!");
                    subscriptionDuration = subscriptionDuration.Add(userSubscriptionTime);
                }
            }
            int limitChanel = int.MaxValue;
            public void AddChannels(List<string> channels)
            {
                if (limitChanel < UserChanelLimit)
                {
                    tvChannels.AddRange(channels);
                    UserChanelLimit++;
                }
                else
                {
                    Console.WriteLine("вибачте ви перевершили ліміт");
                }
            }
            public void DisplayChannels()
            {
                Console.WriteLine("Доступні канали:");
                foreach (var channel in tvChannels)
                {
                    Console.WriteLine(channel);
                }
            }
        }
        public class DomesticSubscription : ISubscription, ICostomizateChanel
        {
            private static int limit = 30;
            private TimeSpan subscriptionDuration = TimeSpan.FromDays(limit);
            private TimeSpan userSubscriptionTime;

            private double tarif = 100.0;

            private List<string> tvChannels = new List<string>();
            private int UserChanelLimit;
            public void SetUserSubscriptionTime(int timeInDays)
            {
                userSubscriptionTime = TimeSpan.FromDays(timeInDays);
                UserChanelLimit = 0;
            }
            public void CheckSubscriptionStatus()
            {
                if (userSubscriptionTime > subscriptionDuration)
                {
                    Console.WriteLine("Термін вашої підписки завершився, будь ласка, продовжіть оплату для доступу до контенту.");
                }
                else
                {
                    Console.WriteLine($"Залишилось часу на підписку: {subscriptionDuration - userSubscriptionTime} днів.");
                }
            }
            public void RenewSubscription(double userPayment)
            {
                if (userPayment < tarif)
                {
                    Console.WriteLine("У вас недостатньо коштів для продовження підписки.");
                }
                else
                {
                    Console.WriteLine("Підписку оновлено!");
                    subscriptionDuration = subscriptionDuration.Add(userSubscriptionTime);
                }
            }
            int limitChanel = 100;
            public void AddChannels(List<string> channels)
            {
                if (limitChanel < UserChanelLimit)
                {
                    tvChannels.AddRange(channels);
                    UserChanelLimit++;
                }
                else
                {
                    Console.WriteLine("вибачте ви перевершили ліміт");
                }
            }
            public void DisplayChannels()
            {
                Console.WriteLine("Доступні канали:");
                foreach (var channel in tvChannels)
                {
                    Console.WriteLine(channel);
                }
            }
        }
        public class EducationalSubscription : ISubscription
        {
            private static int limit = 360;
            private TimeSpan subscriptionDuration = TimeSpan.FromDays(limit);
            private TimeSpan userSubscriptionTime;

            private double tarif = 50.0;

            private List<string> tvChannels = new List<string>();
            private int UserChanelLimit;
            public void SetUserSubscriptionTime(int timeInDays)
            {
                userSubscriptionTime = TimeSpan.FromDays(timeInDays);
                UserChanelLimit = 0;
            }
            public void CheckSubscriptionStatus()
            {
                if (userSubscriptionTime > subscriptionDuration)
                {
                    Console.WriteLine("Термін вашої підписки завершився, будь ласка, продовжіть оплату для доступу до контенту.");
                }
                else
                {
                    Console.WriteLine($"Залишилось часу на підписку: {subscriptionDuration - userSubscriptionTime} днів.");
                }
            }
            public void RenewSubscription(double userPayment)
            {
                if (userPayment < tarif)
                {
                    Console.WriteLine("У вас недостатньо коштів для продовження підписки.");
                }
                else
                {
                    Console.WriteLine("Підписку оновлено!");
                    subscriptionDuration = subscriptionDuration.Add(userSubscriptionTime);
                }
            }
            int limitChanel = 2;
            private void AddChannels()
            {
                if (limitChanel < UserChanelLimit)
                {
                    tvChannels.Add("Education");
                    tvChannels.Add("History");
                }
                else
                {
                    Console.WriteLine("вибачте ви перевершили ліміт");
                }
            }
            public void DisplayChannels()
            {
                Console.WriteLine("Доступні канали:");
                foreach (var channel in tvChannels)
                {
                    Console.WriteLine(channel);
                }
            }
        }

    static void Main()
    {
            FCreateSubscription subscriptionMethod = new WebSite();
            Console.WriteLine("оберіть рівень підписки");
            string User = Console.ReadLine();
            ISubscription subscription = subscriptionMethod.BuySubscription(User);
            subscription.CheckSubscriptionStatus();
            subscription.RenewSubscription(1000);
            subscription.DisplayChannels();
            Console.WriteLine("введіть канали які хочите додати");
            List<string> channels = new List<string>();
            string channel;
            while (true)
            {
                channel = Console.ReadLine();
                if(channel == "exit")
                {
                    break;
                }
                channels.Add(channel);
            }
            if (subscription is ICostomizateChanel customizable)
            {
                customizable.AddChannels(channels);
            }



        }
 }
      
}