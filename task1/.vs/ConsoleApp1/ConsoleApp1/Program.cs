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
                Console.WriteLine("User issues through the Website");
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
                Console.WriteLine("User issues through the MobileApp");
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
                Console.WriteLine("User issues through the Manager");
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
                    Console.WriteLine("Your subscription has expired, please continue paying to access the content.");
                }
                else
                {
                    Console.WriteLine($"Time left to subscribe: {subscriptionDuration - userSubscriptionTime} day");
                }
            }
            public void RenewSubscription(double userPayment)
            {
                if (userPayment < tarif)
                {
                    Console.WriteLine("You do not have enough funds to continue your subscription.");
                }
                else
                {
                    Console.WriteLine("subscription updated!");
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
                    Console.WriteLine("Sorry, you have exceeded the limit.");
                }
            }
            public void DisplayChannels()
            {
                Console.WriteLine("Available channels:");
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
                    Console.WriteLine("Your subscription has expired, please continue paying to access the content.");
                }
                else
                {
                    Console.WriteLine($"Time left to subscribe: {subscriptionDuration - userSubscriptionTime} day");
                }
            }
            public void RenewSubscription(double userPayment)
            {
                if (userPayment < tarif)
                {
                    Console.WriteLine("You do not have enough funds to continue your subscription.");
                }
                else
                {
                    Console.WriteLine("subscription updated!");
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
                    Console.WriteLine("Sorry, you have exceeded the limit.");
                }
            }
            public void DisplayChannels()
            {
                Console.WriteLine("Available channels:");
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
                    Console.WriteLine("Your subscription has expired, please continue paying to access the content.");
                }
                else
                {
                    Console.WriteLine($"Time left to subscribe: {subscriptionDuration - userSubscriptionTime} day");
                }
            }
            public void RenewSubscription(double userPayment)
            {
                if (userPayment < tarif)
                {
                    Console.WriteLine("You do not have enough funds to continue your subscription.");
                }
                else
                {
                    Console.WriteLine("subscription updated!");
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
                    Console.WriteLine("Sorry, you have exceeded the limit.");
                }
            }
            public void DisplayChannels()
            {
                Console.WriteLine("Available channels:");
                foreach (var channel in tvChannels)
                {
                    Console.WriteLine(channel);
                }
            }
        }

    static void Main()
    {
            FCreateSubscription subscriptionMethod = new WebSite();
            Console.WriteLine("Chuse Rang subscription");
            string User = Console.ReadLine();
            ISubscription subscription = subscriptionMethod.BuySubscription(User);
            subscription.CheckSubscriptionStatus();
            subscription.RenewSubscription(1000);
            subscription.DisplayChannels();
            Console.WriteLine("enter the channels you want to add");
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