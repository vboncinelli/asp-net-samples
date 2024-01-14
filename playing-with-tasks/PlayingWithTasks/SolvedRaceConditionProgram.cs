namespace PlayingWithTasks.RaceConditions.Solved
{
    internal class SolvedRaceConditionProgram
    {
        static void Main(string[] args)
        {
            var account = new BankAccount(100);

            Thread thread1 = new Thread(() => {
                for (int i = 0; i < 100; i++)
                {
                    account.Deposit(1);
                }
            });

            Thread thread2 = new Thread(() => {
                for (int i = 0; i < 100; i++)
                {
                    account.Withdraw(1);
                }
            });

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();

            Console.WriteLine($"Saldo finale: {account.GetBalance()}");
        }
    }

    public class BankAccount
    {
        private int _balance;
        private readonly object lockObject = new object();

        public BankAccount(int intialAmount)
        {
            _balance = intialAmount;
        }

        public void Deposit(int amount)
        {
            lock (lockObject)
            {
                var tempBalance = _balance; // Legge il saldo corrente
                tempBalance += amount;  // Modifica il saldo temporaneo
                Thread.Sleep(1);             // Ritardo artificiale
                _balance = tempBalance;     // Aggiorna il saldo
            }
        }

        public void Withdraw(int amount)
        {
            lock (lockObject)
            {
                var tempBalance = _balance; // Legge il saldo corrente
                tempBalance -= amount;  // Modifica il saldo temporaneo
                Thread.Sleep(1);             // Ritardo artificiale
                _balance = tempBalance;     // Aggiorna il saldo
            }
        }

        public int GetBalance()
        {
            lock (lockObject)
            {
                return _balance;
            }
        }
    }
}
