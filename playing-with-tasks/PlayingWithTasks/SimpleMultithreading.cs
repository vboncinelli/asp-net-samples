namespace PlayingWithTasks.Multithreading
{
    internal class SimpleMultithreading
    {
        static void Main(string[] args)
        {
            // Creazione del primo thread per eseguire la funzione PrintNumbers
            Thread thread1 = new Thread(PrintNumbers);
            thread1.Start();

            // Creazione del secondo thread per eseguire la funzione PrintLetters
            Thread thread2 = new Thread(PrintLetters);
            thread2.Start();

            // Attendere il completamento di entrambi i thread
            thread1.Join();
            thread2.Join();

            Console.WriteLine("Entrambi i thread hanno terminato l'esecuzione.");
        }

        static void PrintNumbers()
        {
            for (int i = 1; i <= 25; i++)
            {
                Console.WriteLine($"Numero: {i}");
                Thread.Sleep(500); // Simula un lavoro che richiede tempo
            }
        }

        static void PrintLetters()
        {
            for (char c = 'A'; c <= 'Z'; c++)
            {
                Console.WriteLine($"Lettera: {c}");
                Thread.Sleep(500); // Simula un lavoro che richiede tempo
            }
        }
    }

    public class ContatoreCondiviso
    {
        private int contatore = 0;
        private readonly object lockObject = new object();

        public void Incrementa()
        {
            lock (lockObject)
            {
                contatore++;
                Console.WriteLine($"Contatore incrementato a {contatore}");
            }
        }

        public void Decrementa()
        {
            lock (lockObject)
            {
                contatore--;
                Console.WriteLine($"Contatore decrementato a {contatore}");
            }
        }
    }

}
