﻿namespace Methods
{
    using System;
    using System.Linq;

    class Methods
    {
        public static void SayHello01(string userName)
        {
            Console.WriteLine("Hello, " + userName + "!");
        }

        public static string AsksForName01()
        {
            string userName = Console.ReadLine();
            return userName;
        }

        public static int GetMax02(int firstNumber, int secondNumber)
        {
            return firstNumber >= secondNumber ? firstNumber : secondNumber;
        }

        public static string EnglishDigit03(int lastDigit)
        {
            switch (GetLastDigit03(lastDigit))
            {
                case 0: return "Zero";
                case 1: return "One";
                case 2: return "Two";
                case 3: return "Three";
                case 4: return "Four";
                case 5: return "Five";
                case 6: return "Six";
                case 7: return "Seven";
                case 8: return "Eight";
                case 9: return "Nine";

                default: return "Something went wrong! Try again!";
            }

        }

        public static int GetLastDigit03(int number)
        {
            return number % 10;
        }

        public static int AppearanceCount04(int[] numbers, int numberCheckedForAppearance)
        {
            int countAppearance = 0;

            for (int i = 0; i < numbers.GetLength(0); i++)
            {
                if (numberCheckedForAppearance == numbers[i])
                {
                    countAppearance++;
                }
            }
            return countAppearance;
        }

        public static void FillArray(ref int[] numbers)
        {
            int arraySize = int.Parse(Console.ReadLine());

            numbers = Console.ReadLine()
                           .Split(new char[] { ' ' }, arraySize, StringSplitOptions.RemoveEmptyEntries)
                           .Select(item => int.Parse(item))
                           .ToArray();
        }

        public static int LargerThanNeighbours05(int[] largerThanNeighbourArray)
        {
            int countLargerThanNeighbours = 0;

            for (int i = 0; i < largerThanNeighbourArray.GetLength(0); i++)
            {
                if (i != 0 && i != largerThanNeighbourArray.GetLength(0) - 1)
                {
                    if (largerThanNeighbourArray[i] > largerThanNeighbourArray[i - 1] && largerThanNeighbourArray[i] > largerThanNeighbourArray[i + 1])
                    {
                        countLargerThanNeighbours++;
                    }
                }
                /* Check if first and last numbers are larger than their only neighbour
                else if (i == 0)
                {
                    if (largerThanNeighbourArray[i] > largerThanNeighbourArray[i + 1])
                    {
                        countLargerThanNeighbours++;
                    }
                }
                else if (i == largerThanNeighbourArray.GetLength(0) - 1)
                {
                    if (largerThanNeighbourArray[i] > largerThanNeighbourArray[i - 1])
                    {
                        countLargerThanNeighbours++;
                    }
                }
                */
            }
            return countLargerThanNeighbours;
        }

        public static int FirstLargerThanNeighbours06(int[] largerThanNeighbourArray)
        {
            for (int i = 0; i < largerThanNeighbourArray.GetLength(0); i++)
            {
                if (i != 0 && i != largerThanNeighbourArray.GetLength(0) - 1)
                {
                    if (largerThanNeighbourArray[i] > largerThanNeighbourArray[i - 1] && largerThanNeighbourArray[i] > largerThanNeighbourArray[i + 1])
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        public static decimal ReverseDecimalNumber07(string numberToBeReversed)
        {
            string[] parts = numberToBeReversed.Split('.');
            int wholeNumberPart = int.Parse(parts[0]);
            int decimalNumberPart = int.Parse(parts[1]);

            string reversedNumber = ReverseIntNumber(decimalNumberPart).ToString() + "." + ReverseIntNumber(wholeNumberPart).ToString();

            return decimal.Parse(reversedNumber);
        }

        public static int ReverseIntNumber(int numberToBeReversed)
        {
            int reversedNumber = 0;

            for (int i = numberToBeReversed.ToString().Length - 1; i >= 0; i--)
            {
                reversedNumber += (int)((numberToBeReversed % 10) * Math.Pow(10, i));
                numberToBeReversed /= 10;
            }
            return reversedNumber;
        }

        public static int CountZerosInBeggining(string number)
        {
            int zeroCount = 0;

            for (int i = 0; i < number.Length; i++)
            {
                if (number[i] != '0')
                {
                    return zeroCount;
                }

                zeroCount++;
            }
            return 0;
        }

        public static void NumberAsArray08()
        {
            int[] arrayLengths = Console.ReadLine()
                                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(item => int.Parse(item))
                                .ToArray();

            int firstArrayLength = arrayLengths[0];
            int secondArrayLegth = arrayLengths[1];

            int[] firstArray = new int[firstArrayLength];
            firstArray = Console.ReadLine()
                           .Split(new char[] { ' ' }, firstArrayLength, StringSplitOptions.RemoveEmptyEntries)
                           .Select(item => int.Parse(item))
                           .ToArray();

            int[] secondArray = new int[secondArrayLegth];
            secondArray = Console.ReadLine()
                           .Split(new char[] { ' ' }, secondArrayLegth, StringSplitOptions.RemoveEmptyEntries)
                           .Select(item => int.Parse(item))
                           .ToArray();

            string concatFirstArray = "";
            for (int i = 0; i < firstArray.Length; i++)
            {
                concatFirstArray += firstArray[i];
            }

            int firstAddend = int.Parse(concatFirstArray);
            firstAddend = ReverseIntNumber(firstAddend);

            if (CountZerosInBeggining(concatFirstArray) > 0)
            {
                firstAddend *= (int)Math.Pow(10, CountZerosInBeggining(concatFirstArray));
            }

            string concatSecondArray = "";
            for (int i = 0; i < secondArray.Length; i++)
            {
                concatSecondArray += secondArray[i];
            }

            int secondAddend = int.Parse(concatSecondArray);
            secondAddend = ReverseIntNumber(secondAddend);

            if (CountZerosInBeggining(concatSecondArray) > 0)
            {
                secondAddend *= (int)Math.Pow(10, CountZerosInBeggining(concatSecondArray));
            }

            int arraysSum = firstAddend + secondAddend;
            string sumArray = ReverseIntNumber(arraysSum).ToString();

            for (int i = 0; i < sumArray.Length; i++)
            {
                Console.Write("{0,2}", sumArray[i]);
            }
        }

        public static int MaxElementFromArray(int[] arrayToBeSorted, int startingIndex/* = 0*/, int endIndex/* = arrayToBeSorted.Length*/)
        {
            //arrayToBeSorted.Max();
            int maximalElement = int.MinValue;

            for (int i = startingIndex; i < endIndex; i++)
            {
                if (arrayToBeSorted[i] > maximalElement)
                {
                    maximalElement = arrayToBeSorted[i];
                }
            }
            return maximalElement;
        }

        public static int GetIndex(int[] array, int numIdxSeeked)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == numIdxSeeked)
                {
                    return i;
                }
            }
            return -1;
        }

        public static int Partition(int[] arr, int low, int high)
        {
            int pivot = MaxElementFromArray(arr, low, high + 1);
            int pivotIdx = GetIndex(arr, pivot);

            int i = (low - 1);
            for (int j = low; j < high; j++)
            {
                if (arr[j] <= pivot)
                {
                    i++;

                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }

            int temp1 = arr[i + 1];
            arr[i + 1] = arr[pivotIdx];
            arr[pivotIdx] = temp1;

            return i + 1;
        }

        public static void QuickSort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                int pi = Partition(arr, low, high);

                QuickSort(arr, low, pi - 1);
                //QuickSort(arr, pi + 1, high);  Don't need that
            }
        }

        public static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
        }

        public static void MultiplyDigitsOfNumberByAnother(int numberToBeRepresentedAsArray, int multiplier)
        {
            int numberLength = numberToBeRepresentedAsArray.ToString().Length;
            int[] numberAsArray = new int[numberLength];

            for (int i = numberLength - 1; i >= 0; i--)
            {
                numberAsArray[i] = (numberToBeRepresentedAsArray % 10) * multiplier;
                numberToBeRepresentedAsArray /= 10;
            }

            for (int i = 0; i < numberAsArray.Length; i++)
            {
                Console.Write("{0,3}", numberAsArray[i]);
            }
        }

        public static int Factorial10(int number)
        {
            int factorial = number;

            for (int i = number - 1; i >= 1; i--)
            {
                factorial *= i;
            }
            return factorial;
        }

        public static int FactorialRecursion10(int number)
        {
            if (number == 1)
            {
                return number;
            }
            return number * FactorialRecursion10(--number);
        }

        public static void AddingPolynomials11()
        {
            int arraySize = int.Parse(Console.ReadLine());

            int[] firstPolinom = Console.ReadLine()
                           .Split(new char[] { ' ' }, arraySize, StringSplitOptions.RemoveEmptyEntries)
                           .Select(item => int.Parse(item))
                           .ToArray();

            int[] seconPolinom = Console.ReadLine()
                           .Split(new char[] { ' ' }, arraySize, StringSplitOptions.RemoveEmptyEntries)
                           .Select(item => int.Parse(item))
                           .ToArray();

            for (int i = 0; i < arraySize; i++)
            {
                Console.Write("{0, -3}", firstPolinom[i] + seconPolinom[i]);
            }
        }

        public static void SubtractPolynomials12()
        {
            int arraySize = int.Parse(Console.ReadLine());

            int[] firstPolinom = Console.ReadLine()
                           .Split(new char[] { ' ' }, arraySize, StringSplitOptions.RemoveEmptyEntries)
                           .Select(item => int.Parse(item))
                           .ToArray();

            int[] seconPolinom = Console.ReadLine()
                           .Split(new char[] { ' ' }, arraySize, StringSplitOptions.RemoveEmptyEntries)
                           .Select(item => int.Parse(item))
                           .ToArray();

            for (int i = 0; i < arraySize; i++)
            {
                Console.Write("{0, -3}", firstPolinom[i] - seconPolinom[i]);
            }
        }

        public static int[] MultiplyPolynomials12(int[] polyOne, int[] polyTwo, int polyOneLen, int polyTwoLen)
        {
            int[] product = new int[polyOneLen + polyTwoLen - 1];

            for (int i = 0; i < polyOneLen + polyTwoLen - 1; i++)
            {
                product[i] = 0;
            }

            for (int i = 0; i < polyOneLen; i++)
            {
                for (int j = 0; j < polyTwoLen; j++)
                {
                    product[i + j] += polyOne[i] * polyTwo[j];
                }
            }
            return product;
        }

        public static void PrintPolinom12(int[] poly, int polyLen)
        {
            for (int i = polyLen - 1; i >= 0; i--)
            {
                Console.Write(poly[i]);
                if (i != 0)
                {
                    Console.Write("x^" + i);
                }
                if (i != 0)
                {
                    Console.Write(" + ");
                }
            }
        }

        public static void SolveTasks13(int choice)
        {
            switch (choice)
            {
                case 1:
                    Console.Write("Enter decimal number: ");
                    decimal numberToBeReversed = decimal.Parse(Console.ReadLine());

                    if (numberToBeReversed < 0)
                    {
                        break;
                    }

                    Console.WriteLine(ReverseDecimalNumber07(numberToBeReversed.ToString()));
                    break;
                case 2:
                    Console.Write("Enter sequence of numbers separated by a space: ");
                    int[] numbersSequence = Console.ReadLine()
                           .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                           .Select(item => int.Parse(item))
                           .ToArray();

                    decimal average = 0;

                    foreach (var number in numbersSequence)
                    {
                        average += number;
                    }

                    average /= numbersSequence.Length;
                    Console.WriteLine(average);
                    break;
                case 3:
                    Console.Write("Enter parameter a (a should not be equal to 0): ");
                    int paramA = int.Parse(Console.ReadLine());

                    Console.Write("Enter parameter b: ");
                    int paramB = int.Parse(Console.ReadLine());

                    Console.WriteLine(paramA + " * x + " + paramB + " = 0");

                    int x;
                    if (paramB % paramA == 0)
                    {
                        x = -paramB / paramA;
                        Console.WriteLine("x = " + x);
                    }
                    else
                    {
                        Console.WriteLine("x = -" + paramB + "/" + paramA);
                    }
                    break;
                default:
                    Console.WriteLine("You should choose between 1, 2 or 3");
                    break;
            }
        }

        public static void IntegerCalculations14()
        {
            int[] numbersSequence = Console.ReadLine()
                                    .Split(new char[] { ' ' }, 5, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(item => int.Parse(item))
                                    .ToArray();

            int minNum = int.MaxValue;
            int maxNum = int.MinValue;
            double average;
            int sum = 0;
            int product = 1;

            for (int i = 0; i < 5; i++)
            {
                sum += numbersSequence[i];

                product *= numbersSequence[i];

                if (numbersSequence[i] < minNum)
                {
                    minNum = numbersSequence[i];
                }

                if (numbersSequence[i] > maxNum)
                {
                    maxNum = numbersSequence[i];
                }
            }

            average = sum / 5d;
            Console.WriteLine(minNum + "\n" + maxNum);
            Console.WriteLine("{0:0.00}", average);
            Console.WriteLine(sum + "\n" + product);
        }

        class NumberSequence<T> where T : IComparable
        {
            private T[] numbers;

            public NumberSequence(T[] numbers)
            {
                this.numbers = numbers;
                GetResults();
            }

            public T Min { get; private set; }
            public T Max { get; private set; }
            public T Sum { get; private set; }
            public T Product { get; private set; }
            public decimal Average { get; private set; }

            private void GetResults()
            {
                this.Min = this.numbers.Min();
                this.Max = this.numbers.Max();
                dynamic product = 1;
                dynamic sum = 0;

                foreach (var number in numbers)
                {
                    product *= number;
                    sum += number;
                }

                this.Product = (T)product;
                this.Sum = (T)sum;
                this.Average = decimal.Parse(Sum.ToString()) / this.numbers.Length;
            }

            public override string ToString()
            {
                return string.Format(" MIN:  {0} \n MAX:  {1}  \n AVG:  {4:0.00} \n SUM:  {2} \n PROD: {3}"
                                    , this.Min, this.Max, this.Sum, this.Product, this.Average);
            }
        }
        static void Main()
        {
            /* Task 1
             string userName = AsksForName01();
             SayHello01(userName);
            //SayHello01(AsksForName01());
            */

            /* Task 2
            int[] numbers = Console.ReadLine()
                           .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                           .Select(item => int.Parse(item))
                           .ToArray();

            int firstNumber = numbers[0];
            int secondNumber = numbers[1];
            int thirdNumber = numbers[2];

            Console.WriteLine(GetMax02(GetMax02(firstNumber, secondNumber), thirdNumber));
            */

            /* Task 3 
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine(EnglishDigit03(GetLastDigit03(number)));
            */

            /* Task 4
            int[] numbers = Array.Empty<int>();

            FillArray(ref numbers);

            int numberCheckedForAppearance = int.Parse(Console.ReadLine());

            Console.WriteLine(AppearanceCount04(numbers, numberCheckedForAppearance));
            */

            /* Task 5
            int[] largerThanNeighbourArray = Array.Empty<int>();

            FillArray(ref largerThanNeighbourArray);

            Console.WriteLine(LargerThanNeighbours05(largerThanNeighbourArray));
            */

            /* Task 6 
            int[] firstLargerThanNeighbourArray = Array.Empty<int>();

            FillArray(ref firstLargerThanNeighbourArray);

            Console.WriteLine(FirstLargerThanNeighbours06(firstLargerThanNeighbourArray));
            */

            /* Task 7
            string numberToBeReversed = Console.ReadLine();
            Console.WriteLine(ReverseDecimalNumber07(numberToBeReversed));
            */

            /* Task 8 
            NumberAsArray08();
            */

            /* Task 9 
            int[] max = new int[] { 500, 18, 14, 16, 19, 203, -2, 432, 45 };
            Console.WriteLine(MaxElementFromArray(max, 0, max.Length));
            Console.WriteLine(MaxElementFromArray(max, 3, max.Length));

            int arrayLen = int.Parse(Console.ReadLine());
            int[] arrayToBeSorted = Console.ReadLine()
                                    .Split(new char[] { ' ' }, arrayLen, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(item => int.Parse(item))
                                    .ToArray();
            arrayLen = arrayToBeSorted.Length;

            QuickSort(arrayToBeSorted, 0, arrayLen - 1);

            PrintArray(arrayToBeSorted);
            */

            /* Task 10 - Part1
            int numberToBeRepresentedAsArray = int.Parse(Console.ReadLine());
            int multiplier = int.Parse(Console.ReadLine());
            MultiplyDigitsOfNumberByAnother(numberToBeRepresentedAsArray, multiplier);
                       - Part2
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine(Factorial10(number));
            Console.WriteLine(FactorialRecursion10(number));
            */

            /* Task 11 
            AddingPolynomials11();
            */

            /* Task 12 
            SubtractPolynomials12();

            // Task 2 - part 2    
            int[] firstPolinom = Console.ReadLine()
                           .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                           .Select(item => int.Parse(item))
                           .ToArray();

            int[] secondPolinom = Console.ReadLine()
                           .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                           .Select(item => int.Parse(item))
                           .ToArray();

            Console.Write("(");
            PrintPolinom12(firstPolinom, firstPolinom.Length);
            Console.Write(") * (");
            PrintPolinom12(secondPolinom, secondPolinom.Length);
            Console.Write(") = ");

            int[] prod = MultiplyPolynomials12(firstPolinom, secondPolinom, firstPolinom.Length, secondPolinom.Length);

            PrintPolinom12(prod, firstPolinom.Length + secondPolinom.Length - 1);
            */

            /* Task 13 
            Console.WriteLine("Which task you want to solve? \n Enter 1 to Reverses the digits of a number" + 
                                                            "\n Enter 2 to Calculates the average of a sequence of integers" +
                                                            "\n Enter 3 to Solves a linear equation a * x + b = 0");
            int choice = int.Parse(Console.ReadLine());

            SolveTasks13(choice);
            */

            /* Task 14 
            IntegerCalculations14();
            */
            /* Task 15 */
            int[] integerArr = Console.ReadLine()
                              .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                              .Select(item => int.Parse(item))
                              .ToArray();
            NumberSequence<int> integerSequence = new NumberSequence<int>(integerArr);
            Console.WriteLine(integerSequence);

            double[] doubleArr = Console.ReadLine()
                                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(item => double.Parse(item))
                                .ToArray();
            NumberSequence<double> doubleSequence = new NumberSequence<double>(doubleArr);
            Console.WriteLine(doubleSequence);

            short[] shortArr = Console.ReadLine()
                              .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                              .Select(item => short.Parse(item))
                              .ToArray();
            NumberSequence<short> shortSequence = new NumberSequence<short>(shortArr);
            Console.WriteLine(shortSequence);
            
        }
    }
}