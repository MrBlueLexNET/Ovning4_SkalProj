using System;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SkalProj_Datastrukturer_Minne
{

    //Frågor: Ref: E-Learning material and 
    //1. Hur fungerar stacken och heapen? Förklara gärna med exempel eller skiss på dess grundläggande funktion
    //Svar 1:
    /* Stack and Heap are different memory spaces. One is allocated to memory by the compiler and the other is allocated to another memory space at runtime.*/
    //2. Vad är Value Types repsektive Reference Types och vad skiljer dem åt?
    //Svar 2:
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
    //3. Följande metoder(se bild nedan) genererar olika svar.Den första returnerar 3, den andra returnerar 4, varför?
    //Svar 3:
    /*ReturnValue Method is using the Stack to store int on separate values for x and y.
    When declaring y = x; it doesn't affect the value return for x even if the y value is not equal to x.
    x = y will be declare on the stack like x = 3 and y = 4.
    ReturnValue2 Method is using the same reference name MyValue
    for x and y.When first assigning value on the stack for 
    x.MyValue and then making y = x implicitly y.MyValue will point to the same Object on the Heap.*/

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
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParanthesis"
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
            theList.Capacity = 10;//If the capacity is significantly larger than the count lower it and you will save memory
            bool goOn = true;
            Console.WriteLine("Examines the datastructure List: Using + or - before you type Using [R] to resume");
            do {
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
        }

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
        }

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

        }

    }
}