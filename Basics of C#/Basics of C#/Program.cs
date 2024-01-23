namespace Basics_of_C_
{
    internal class Program
    {

        static void Main(string[] args)
        {
            int[] numbers;
            int enteredHigh_Numb;
            int totalAdded = 0;


            Console.WriteLine("Please enter a low number");
            var low_NumbStr = Console.ReadLine();
            Console.WriteLine("Please Enter a high number");
            var high_NumbStr = Console.ReadLine();

            if (int.TryParse(low_NumbStr, out int low_Numb) && int.TryParse(high_NumbStr, out int high_Numb))
            {
                numbers = new int[high_Numb - low_Numb - 1];
                var diff = high_Numb - low_Numb;
                Console.WriteLine("The difference between the two is: {0}", diff);

                for (int i = 0; i < numbers.Length; i++)
                {
                    numbers[i] = low_Numb + i + 1;
                }
                Array.Reverse(numbers);

                File.WriteAllLines("numbers.txt", numbers.Select(num => num.ToString()).ToArray());
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter valid integers for low and high numbers,");
                return;
            }
          

            do
            {
                Console.WriteLine("Please enter a positive low number");
               
                while (!int.TryParse(Console.ReadLine(), out low_Numb) || low_Numb <= 0)
                {
                    Console.WriteLine("Invalid input. Please enter a valid positive low number");
                }

            } while (low_Numb% 2 != 0);

            Console.WriteLine("Positive number entered");


            do
            {
                Console.WriteLine("Please enter a number bigger then the low number");

                while (!int.TryParse(Console.ReadLine(), out enteredHigh_Numb) && enteredHigh_Numb <= low_Numb)
                {
                    Console.WriteLine("Number is lower then requested");
                }
            } while (enteredHigh_Numb <= low_Numb);

            Console.WriteLine("Number accepted");


            using (var readText = new StreamReader("numbers.txt"))
            {
                string readStr;
                while ((readStr = readText.ReadLine()) != null)
                { 
                    if (int.TryParse(readStr, out int readInt))
                    {
                        totalAdded += readInt;

                    }
                }
            }
            Console.WriteLine("The sum of the numbers between the first small and large numbers are {0} ", totalAdded);
            




        }
    }
}
