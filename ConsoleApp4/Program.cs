using System.Diagnostics;

class Program
{
    //алгоритм Евклида для нахождения наибольшего общего делителя двух чисел
    static int FindGCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    //определен массив  numbers
    static void Main()
    {
        Random random = new Random();
        int[] numbers = new int[5];
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = random.Next(1, 100);
        }

        int gcd = 0;
        Stopwatch stopwatch = new Stopwatch();

        Thread thread1 = new Thread(() =>
        {
            stopwatch.Start();
            gcd = FindGCD(numbers[0], numbers[1]);
            Console.WriteLine("Greatest common divisor: " + gcd);
            Console.WriteLine("Thread execution time: " + stopwatch.ElapsedMilliseconds + " mls");
            stopwatch.Stop();
        });

        Thread thread2 = new Thread(() =>
        {
            stopwatch.Start();
            gcd = FindGCD(numbers[2], numbers[3]);
            Console.WriteLine("Greatest common divisor: " + gcd);
            Console.WriteLine("Thread execution time: " + stopwatch.ElapsedMilliseconds + " mls");
            stopwatch.Stop();
        });

        Thread thread3 = new Thread(() =>
        {
            stopwatch.Start();
            gcd = FindGCD(numbers[3], numbers[4]);
            Console.WriteLine("Greatest common divisor: " + gcd);
            Console.WriteLine("Thread execution time: " + stopwatch.ElapsedMilliseconds + " mls");
            stopwatch.Stop();
        });

        thread1.Start();
        thread1.Join();
        thread2.Start();
        thread2.Join();
        thread3.Start();
        thread3.Join();
    }
}