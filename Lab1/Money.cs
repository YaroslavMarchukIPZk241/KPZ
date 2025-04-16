using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1;
namespace Lab1
{
    public interface IMoneyOperation
    {
        void Execute(int cash, int coin);
    }

    public class Money
    {
        public int Cash { get; private set; }
        public int Coin { get; private set; }
        public string Currency { get; }

        public Money(int cash, int coin, string currency)
        {
            if (cash < 0 || coin < 0) throw new ArgumentException("Cash and coin must be non-negative.");
            Cash = cash;
            Coin = coin;
            Currency = currency;
        }

        public void UpdateMoney(int cash, int coin)
        {
            if (cash < 0 || coin < 0) throw new ArgumentException("Cash and coin must be non-negative.");

            Cash = cash + (coin / 100);
            Coin = coin % 100;
        }

        public bool CanSubtract(int cash, int coin)
        {
            int totalCoins = (Cash * 100 + Coin) - (cash * 100 + coin);
            return totalCoins >= 0;
        }
    }

    public class MoneyOperationAdd : IMoneyOperation
    {
        private readonly Money _money;

        public MoneyOperationAdd(Money money)
        {
            _money = money ?? throw new ArgumentNullException(nameof(money));
        }

        public void Execute(int cash, int coin)
        {
            _money.UpdateMoney(_money.Cash + cash, _money.Coin + coin);
        }
    }

    public class MoneyOperationSubtract : IMoneyOperation
    {
        private readonly Money _money;

        public MoneyOperationSubtract(Money money)
        {
            _money = money ?? throw new ArgumentNullException(nameof(money));
        }

        public void Execute(int cash, int coin)
        {
            if (!_money.CanSubtract(cash, coin))
                throw new ArgumentException("Not enough money to complete the operation.");

            int totalCoins = (_money.Cash * 100 + _money.Coin) - (cash * 100 + coin);
            _money.UpdateMoney(totalCoins / 100, totalCoins % 100);
        }
    }
}