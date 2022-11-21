using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Net.Sockets;
using System.Reflection;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SkalProj_Datastrukturer_Minne
{

    //Frågor: Ref: E-Learning material and GOOGLE
    //1. Hur fungerar stacken och heapen? Förklara gärna med exempel eller skiss på dess grundläggande funktion
    //Svar 1:
    /* Stack and Heap are different memory spaces. One is allocated to memory by the compiler and the other is allocated to another memory space at runtime.*/
    /*
    * Stack Memory *
      It is an array of memory.
      It is a LIFO (Last In First Out) data structure.
      In it data can be added to and deleted only from the top of it.

      Memory allocation is Static and variables can't be resized and access is fast.
      Block allocation is reserverd in LIFO most reserved block is always the next block to be freed.

      * Heap Memory *
      It is an area of memory where chunks are allocated to store certain kinds of data objects.
      In it data can be stored and removed in any order.

       Memory allocation is Dynamic and variables can be resized and access is slow.
       Its block allocation is free and done at any time.

   /* The main differences between Value versus Reference Types are that:
   1. Value type like int has a fixed size, allocated by the compiler on stack. The value is copied once on this memory location.
   2. Reference type like Object are always allocated on the Heap but the pointer value is copied once on the stack. 
   3. Refence type like Object can have multiple references on the stack for the same Object on the Heap */
    //2. Vad är Value Types repsektive Reference Types och vad skiljer dem åt?
    //Svar 2:

    //3. Följande metoder(se bild nedan) genererar olika svar.Den första returnerar 3, den andra returnerar 4, varför?
    //Svar 3:
    /*ReturnValue Method is using the Stack to store int on separate values for x and y.
    When declaring y = x; it doesn't affect the value return for x even if the y value is not equal to x.
    x = y will be declare on the stack like x = 3 and y = 4.
    ReturnValue2 Method is using the same reference name MyValue for x and y. When first assigning value on the stack for 
    x.MyValue and then making y = x implicitly y.MyValue will point to the same Object on the Heap.*/

    //TODO: Exception thrown: 'System.IndexOutOfRangeException' use Try Catch block for all Methods not only the Main()
    class Program
    {
        
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 5, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParanthesis"
                    + "\n5. ReverseText"
                    + "\n0. Exit the application");

                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '5':
                        ReverseText();
                        break;
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()

        /*
         * Loop this method untill the user inputs something to exit to main menue.
         * Create a switch statement with cases '+' and '-'
         * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
         * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
         * In both cases, look at the count and capacity of the list
         * As a default case, tell them to use only + or -
         * Below you can see some inspirational code to begin working.
        */

        //List<string> theList = new List<string>();
        //string input = Console.ReadLine();
        //char nav = input[0];
        //string value = input.substring(1);

        //switch(nav){...}

        //TODO: 1. Try the following method TrimExcess() after removing element from the list
        //     Sets the capacity to the actual number of elements in the System.Collections.Generic.List`1,
        //     if that number is less than a threshold value.
        //NOTE: If the capacity is significantly larger than the count and you want to reduce the memory used by the List<T>,
        //you can decrease capacity by calling the TrimExcess method or by setting the Capacity property explicitly to a lower value.
        //When the value of Capacity is set explicitly, the internal array is also reallocated to accommodate the specified capacity, and all the elements are copied. 
        {

            List<string> theList = new List<string>();
            //theList.Capacity = 10;//If the capacity is significantly larger than the count lower it and you will save memory
            bool goOn = true;
            Console.WriteLine("Examines the datastructure List: Using [+] or [-] before you type | [R] to resume");
            do
            {
                string input = Console.ReadLine()!;
                char nav = input[0];
                string value = input.Substring(1);
                switch (nav)
                {
                    case '+':
                        theList.Add(value);
                        Console.WriteLine($"Count: {theList.Count} Capacity: {theList.Capacity}");
                        break;
                    case '-':
                        theList.Remove(value);
                        Console.WriteLine($"Count: {theList.Count} Capacity: {theList.Capacity}");
                        theList.TrimExcess();//Capacity -2 from ex. 8 to 6 to 4. 
                        break;
                    case 'R':
                        theList.Clear();
                        Console.Clear();
                        goOn = false;
                        break;
                    default:
                        Console.WriteLine("Only + and - prefixes are valid");
                        break;
                }
            }
            while (goOn);

        }

        //2. När ökar listans kapacitet? (Alltså den underliggande arrayens storlek)
        //Svar: Efter att man har lagt till 4 elements i listan 
        //3. Med hur mycket ökar kapaciteten?
        //Svar: Med 4
        //4. Varför ökar inte listans kapacitet i samma takt som element läggs till?
        //Svar:Capacity is the number of elements that the List<T> can store before resizing is required,
        //whereas Count is the number of elements that are actually in the List<T>.
        //Capacity is always greater than or equal to Count.
        //If Count exceeds Capacity while adding elements, the capacity is increased by automatically reallocating the internal array before copying the old elements and adding the new elements.
        //Ref: https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.capacity?view=net-7.0
        //5. Minskar kapaciteten när element tas bort ur listan?
        //Svar: Nej
        //6. När är det då fördelaktigt att använda en egendefinierad array istället för en lista
        //Svar: När man vet kapaciten av en lista i förväg.

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */

            Queue<string> theQueue = new Queue<string>();
            //theQueue.Capacity = 10;//If the capacity is significantly larger than the count lower it and you will save memory
            bool goOn = true;
            Console.WriteLine("Examines the datastructure Queue: Using [+] or [-] before you type | [R] to resume");
            do
            {
                string input = Console.ReadLine()!;
                char nav = input[0];
                string value = input.Substring(1);
                switch (nav)
                {
                    case '+':
                        theQueue.Enqueue(value);
                        Console.WriteLine($"Count: {theQueue.Count}");
                        // A queue can be enumerated without disturbing its contents.
                        Console.WriteLine("\nContents of the Queue:");
                        foreach (string item in theQueue)
                        {
                            Console.WriteLine(item);
                        }
                        break;
                    case '-':
                        if (theQueue.Count > 0) //Make sure that the Queue is not empty
                            theQueue.Dequeue();

                        Console.WriteLine($"Count: {theQueue.Count}");
                        // A queue can be enumerated without disturbing its contents.
                        Console.WriteLine("\nContents of the Queue:");
                        foreach (string item in theQueue)
                        {
                            Console.WriteLine(item);
                        }
                        theQueue.TrimExcess();//Capacity ? 
                        break;
                    case 'R':
                        theQueue.Clear();
                        Console.Clear();
                        goOn = false;
                        break;
                    default:
                        Console.WriteLine("Only + and - prefixes are valid");
                        break;
                }
            }
            while (goOn);
        }

        // 2. Implementera metoden TestQueue.Metoden ska simulera hur en kö fungerar
        //genom att tillåta användaren att ställa element i kön(enqueue) och ta bort element
        //ur kön(dequeue). Använd Queue-klassen till hjälp för att implementera metoden.
        //Simulera sedan ICA-kön med hjälp av ditt program.

        //TODO: xUnit  1. Create a unit test project 2. Adding a unit test

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */

            Stack<string> theStack = new();
            bool goOn = true;
            Console.WriteLine("Examines the datastructure Stack: Using [+] or [-] before you type | [R] to resume");
            do
            {
                string input = Console.ReadLine()!;
                char nav = input[0];
                string value = input.Substring(1);
                switch (nav)
                {
                    case '+':
                        theStack.Push(value);
                        Console.WriteLine($"Count: {theStack.Count}");
                        // A queue can be enumerated without disturbing its contents.
                        Console.WriteLine("\nContents of the Queue:");
                        foreach (string item in theStack)
                        {
                            Console.WriteLine(item);
                        }
                        break;
                    case '-':
                        if (theStack.Count > 0) //Make sure that the Queue is not empty
                            theStack.Pop();

                        Console.WriteLine($"Count: {theStack.Count}");
                        // A queue can be enumerated without disturbing its contents.
                        Console.WriteLine("\nContents of the Stack:");
                        foreach (string item in theStack)
                        {
                            Console.WriteLine(item);
                        }
                        theStack.TrimExcess();//Capacity ? 
                        break;
                    case 'R':
                        theStack.Clear();
                        Console.Clear();
                        goOn = false;
                        break;
                    default:
                        Console.WriteLine("Only + and - prefixes are valid");
                        break;
                }
            }
            while (goOn);

        }
        //1. Simulera ännu en gång ICA-kön på papper.Denna gång med en stack.Varför är det inte så smart att använda en stack i det här fallet?
        //Svar: Först In Sist Ut (FILO) principen passar inte för ICAs kassa men när det uppstår arbetsbrist på en arbetsplats sker uppsägningarna enligt den turordning (LAS).

        //2. Implementera en ReverseText-metod som läser in en sträng från användaren och
        //med hjälp av en stack vänder ordning på teckenföljden för att sedan skriva ut den
        //omvända strängen till användaren.
        static void ReverseText()
        {

            Stack<char> charStack = new Stack<char>();
            Console.WriteLine("Type the text to reverse | [R] to resume");
            string s = Console.ReadLine()!;
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                charStack.Push(c);
            }
            Console.WriteLine("Text in revers:");
            foreach (char item in charStack)
            {
                Console.Write(item);
            }

            Console.ReadLine();
            Console.Clear();
        }
        /// <summary>
        /// Examines a string using Collections Queue or Stack and a Dictionary
        /// </summary>
        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

            //TODO: 1 Manual test failed to pass validation. Double check the logic!
            //REF: In the latest nightly build CheckParanthesis() returm incorrect for string "List<int> list = new List<int>() { 1, 2, 3, 4 };" 

            //1. Create a Dictionary Key type and Value Type 
            Dictionary<char, char> paranthesisDico = new Dictionary<char, char>()
            {
                { '(',')' },  { '{','}' },  { '[',']' }
            };


            /**********************************************************************/
            //Stack Collection in C#
            //Used when the data items need to be arranged in a LIFO (Last In First Out) manner.

            //Queue Collection in C#
            //Used when the data items need to be arranged in a FIFO (First In First Out) manner.
            /**********************************************************************/

            Stack<char> stackLeftParenthesis = new Stack<char>();//Define a stack for chars to be stored for retreiving left Parenthesis
            Stack<char> stackRightParenthesis = new Stack<char>();//Define a stack for chars to be stored for retreiving right Parenthesis

            Queue<char> queueLeftParenthesis = new Queue<char>();//Define a Queue for chars to be stored for retreiving left Parenthesis
            Queue<char> queueRightParenthesis = new Queue<char>();//Define a Queue for chars to be stored for retreiving right Parenthesis

            Console.WriteLine("Check if the paranthesis in a string is Correct or incorrect | [R] to resume");
            string str = Console.ReadLine()!;

            char[] ar = str.ToArray(); //Define an Char Array so we can hold the position of each char from the String 

            //Need to count the Left and Right parentheses
            //If the Left count is equal to the right count 
            //Need to found if they are identical
            char[] parenthesesArraylefts = new char[ar.Length];
            char[] parenthesesArrayrights = new char[ar.Length];
            char[] parenthesisArray = new char[ar.Length];

            bool isValid = false;

            for (int i = 0; i < ar.Length; ++i)//Loop over the char array
            {
                //1. entered into the 2 collections make a push to lefts or rights Parantheses if found in the string
                if (ar[i] == '(' || ar[i] == '[' || ar[i] == '{')
                {
                    stackLeftParenthesis.Push(ar[i]);//Found a left parathese push it to Stack left Parenthesis
                    queueLeftParenthesis.Enqueue(ar[i]);//Found a left parathese push it to Queue left Parenthesis
                    parenthesesArraylefts[i] = ar[i];//Position holder Array left
                }

                if (ar[i] == ')' || ar[i] == ']' || ar[i] == '}')
                {
                    stackRightParenthesis.Push(ar[i]);//Found a right parathese push it to Stack right Parenthesis
                    queueRightParenthesis.Enqueue(ar[i]);//Found a left parathese push it to Queue left Parenthesis
                    parenthesesArrayrights[i] = ar[i];//Position holder Array right
                }

            }

            Console.WriteLine((stackLeftParenthesis.Count != stackRightParenthesis.Count) ? "Wrong input: The number of left and right parenthesis are not equal" : $"Correct number of parenthesis in {str}");
            if (stackLeftParenthesis.Count == stackRightParenthesis.Count)
                isValid = true;

            /**********************************************************************/
            if (isValid)
            {
                //foreach (loop other the Dico)


                //for (int i = 0; i < queueLeftParenthesis.Count; i++)

                do
                { 

                    foreach (KeyValuePair<char, char> element in paranthesisDico)

                    {
                        //Console.WriteLine($"{element.Key} and {element.Value}");
                        if (queueLeftParenthesis.Any()) //IMPORTANT
                        {
                            //if ((queueLeftParenthesis.Peek() == element.Key && stackRightParenthesis.Peek() == element.Value)) //FIXED TODO: 2 Manual tests failed to pass validation. Double check the logic! Error introduce when using foreach (loop other the Dico)!!!
                            if ((queueLeftParenthesis.Peek() == '(') && (stackRightParenthesis.Peek() == ')') || (queueLeftParenthesis.Peek() == '{') && (stackRightParenthesis.Peek() == '}') || (queueLeftParenthesis.Peek() == '[') && (stackRightParenthesis.Peek() == ']'))                                                                                                //if ((queueLeftParenthesis.Peek() == '(') && (queueRightParenthesis.Peek() == ')') || (queueLeftParenthesis.Peek() == '{') && (queueRightParenthesis.Peek() == '}') || (queueLeftParenthesis.Peek() == '[') && (queueRightParenthesis.Peek() == ']'))
                            {
                                Console.WriteLine("The top value {0} was removed from the Left Queue", queueLeftParenthesis.Dequeue());
                                Console.WriteLine("The top value {0} was removed from the Right Stack", stackRightParenthesis.Pop());
                            }
                            else 
                            {
                                queueLeftParenthesis.Dequeue();
                                isValid = false;
                            }
                            
                            //}
                            Console.WriteLine("Current queue count is: {0}", queueLeftParenthesis.Count);
                        }
                    }
                        
                    } while (queueLeftParenthesis.Count > 0) ;
                    
                 }


            if (queueLeftParenthesis.Count == stackRightParenthesis.Count)
            { 
                isValid = true;
            }
              

            /**********************************************************************/
            Console.WriteLine((isValid is true) ? $"{str}: Is valid" : $"{str}: Not valid");
            Console.ReadKey();
            Console.Clear();

        }
        //Rekursion
        /// <summary>
        /// Övning 5: Rekursion
        /// </summary>
        //Denna metoden gör är att se efter om n är 1, om så returerar den det första udda talet 1.
        //Annars så anropar den sig själv för ett mindre n och lägger till två.
        static int RecusiveOds(int n)
        {
            
            if (n == 1)
            {
                return 1;
            }
            return RecusiveOds((n -1) + 2);
        }
        //Iteration
        /// <summary>
        /// Övning 6: Iteration
        /// </summary>
        // Denna metod börjar från 1 och adderar 2 till dess att resultat blir det n:te udda talet.
        static int IterativeOds(int n)
        {
            int result = 1;
            for (int i = 0; i < n - 1; i++)
            { 
                result += 2;
            }
            return result;
        }
    }
}