namespace PreventingRaceConditions
{
    public class BankAccount
    {
        private int _balance;
        private readonly object _lockObject = new object();

        public BankAccount(int initialAmount)
        {
            _balance = initialAmount;
        }

        public void Deposit(int amount)
        {
            lock (_lockObject)
            {
                var tempBalance = _balance; // Legge il saldo corrente

                tempBalance += amount;  // Modifica il saldo temporaneo

                Thread.Sleep(1);             // Ritardo artificiale

                _balance = tempBalance;     // Aggiorna il saldo
            }
        }

        public void Withdraw(int amount)
        {
            lock (_lockObject)
            {
                var tempBalance = _balance; // Legge il saldo corrente

                tempBalance -= amount;  // Modifica il saldo temporaneo

                Thread.Sleep(1);             // Ritardo artificiale

                _balance = tempBalance;     // Aggiorna il saldo
            }
        }

        public int GetBalance()
        {
            lock (_lockObject)
            {
                return _balance;
            }
        }
    }

    public class Program
    {
        public static void Main()
        {
            var conto = new BankAccount(100);

            Thread thread1 = new Thread(() => {
                for (int i = 0; i < 100; i++)
                {
                    conto.Deposit(10);
                }
            });

            Thread thread2 = new Thread(() => {
                for (int i = 0; i < 100; i++)
                {
                    conto.Withdraw(10);
                }
            });

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();

            Console.WriteLine($"Saldo finale: {conto.GetBalance()}");
        }
    }



}
