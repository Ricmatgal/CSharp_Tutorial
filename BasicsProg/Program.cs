﻿// This is how we import required libraries in C#
using System;
using System.Collections.Generic;
using System.IO;

// Shortcuts
// When copy/pasting some code and the code indentation is broken, then you need to format your document with : Ctrl+E & Crtl+D
// Build and Run : F5
// Block comment : Ctrl+K & Ctrl+C
// Block uncomment : Ctrl+K & Ctrl+U
/* 
You can also
comment a block like this 
*/

// A namespace is optional, but it is better to put your code inside a namespace if you need to share your code.
namespace BasicsProg
{
	class Program
	{
		// 1. This function is the entry point of the program.
		// static means it can be called without the need to instantiate an object of type Program.
		static void Main(string[] args)
		{
			// args is an array of all arguments coming from the command line.
			// to pass some parameters to the application.

			// 2. Write some text to the console.
			// An instruction in C# always terminates with ";".
			Console.WriteLine("Hello World!");
			// Tests : uncomment the desired test to run it. 
			//VariablesTest(); // 4
			//StringTest(); // 5
			//OperationsTest(); // 6
			//ConditionalsTest(); // 7
			//ArrayTest(); // 8
			//ListTest(); // 9
			//DictionnaryTest(); // 10
			//LoopsTest(); // 11
			//CopyVsReferenceTest(); // 12
			//MethodsTest(); // 13
			//ClassTest(); // 14
			//FileTest(); // 15

			WaitForQuit();
		}

		// 3. Our first function
		static void WaitForQuit()
		{
			Console.WriteLine("Press Enter to quit...");
			// Read input text from the console while Enter is not pressed.
			Console.ReadLine();
		}

		// 4. Variables & Types
		static void VariablesTest()
		{
			Console.WriteLine("====Variables Test====");
			// These are variables.
			bool myBoolean = true;
			Console.WriteLine("myBoolean : " + myBoolean + " (memory size : " + sizeof(bool) * 8 + " bits)");
			byte myByte = byte.MaxValue; // 8 bits, max value : 255
			Console.WriteLine("myByte : " + myByte + " (memory size : " + sizeof(byte) * 8 + " bits)");
			int myInt = int.MinValue; // 32 bits
			Console.WriteLine("myInt : " + myInt + " (memory size : " + sizeof(int) * 8 + " bits)");
			float myFloat = 1.3f; // 32 bits
			Console.WriteLine("myFloat : " + myFloat + " (memory size : " + sizeof(float) * 8 + " bits)");
			double myDouble = 1.75; // 64 bits
			Console.WriteLine("myDouble : " + myDouble + " (memory size : " + sizeof(double) * 8 + " bits)");
			char myChar = 'a'; // 16 bits
			Console.WriteLine("myChar : " + myChar + " (memory size : " + sizeof(char) * 8 + " bits)");
			string myName = "John"; // string is an array of chars
			Console.WriteLine("myName : " + myName);

			// EXERCISE : DEFINE THREE VARIABLES:
			// A string named productName equal to TV.
			// An integer named productYear equal to 2021.
			// A float named productPrice equal to 499.99f.
			#region CORRECTION
			Console.WriteLine("====EXERCISE====");
			string productName = "TV";
			int productYear = 2021;
			float productPrice = 499.99f;
			Console.WriteLine("productName : " + productName);
			Console.WriteLine("productYear : " + productYear);
			Console.WriteLine("productPrice : " + productPrice);
			#endregion

			// Scope of Variables.
			// EXPLAIN HERE THE COPY MECHANISM WITH A SCHEMA OF MEMORY
			Console.WriteLine("====Variables Scope Test====");
			int a = 3;
			{
				Console.WriteLine("a : " + a);
				int b = 5;
				Console.WriteLine("b : " + b);
				a = b;
				Console.WriteLine("a=b");
			}// b destroyed here (end bracket = end of scope)
			Console.WriteLine("b is destroyed");
			Console.WriteLine("a : " + a);

		} // All others variables are destroyed here (end bracket = end of scope).

		// 5. String operations
		static void StringTest()
		{
			// Declare string and assign a value.
			Console.WriteLine("====String Test====");
			string myString = "A string.";
			Console.WriteLine("myString : " + myString);
			// Empty string
			string emptyString = String.Empty;
			Console.WriteLine("emptyString : " + emptyString);
			string anotherEmptyString = "";
			Console.WriteLine("anotherEmptyString : " + anotherEmptyString);
			// Concatenation
			string firstName = "John";
			string lastName = "Smith";
			string fullName = firstName + " " + lastName;
			Console.WriteLine("fullName : " + fullName);
			string sentence = "I like to play ";
			sentence += "chess.";
			Console.WriteLine("sentence : " + sentence);
			// String Substring
			string sentence2 = sentence.Substring(1); // returns a string starting at index 1 until the end => 'I' is removed.
			Console.WriteLine("sentence2 : " + sentence2);
			sentence2 = fullName + sentence2; // "John Smith like to play chess."
			Console.WriteLine("sentence2 : " + sentence2);
			// Search
			int cPos = sentence2.IndexOf('c'); // returns the index of 'c' in the string
			// Remove
			sentence2 = sentence2.Substring(0, cPos - 1) + '.'; // returns a string with "chess." removed
			Console.WriteLine("sentence2 : " + sentence2);
			// Replace
			sentence2 = sentence2.Replace("Smith", "Carter");
			Console.WriteLine("sentence2 : " + sentence2);
			// string formating
			string numbers = string.Format("Numbers : {0} ; {1} ; {2}", 11, 22, 33); // "Numbers : 11 ; 22 ; 33"
			Console.WriteLine("numbers : " + numbers);

			// EXERCISE
			// Use string formatting to format the variables firstName, lastName to form the following sentence:
			// John Smith is 27 years old.
			// You can also create a variable age to store the age.
			#region CORRECTION
			Console.WriteLine("====EXERCISE====");
			int age = 27;
			string result = string.Format("{0} {1} is {2} years old.", firstName, lastName, age);
			Console.WriteLine("result : " + result);
			#endregion
		}

		// 6. Operations
		static void OperationsTest()
		{
			// LESSONS LEARN:
			// - Take care of overflow
			// - Do operations using the same type of variables as possible, to not lose precision.
			Console.WriteLine("====Operations Test====");
			byte myByte = byte.MaxValue; // 8 bits, max value : 255
			Console.WriteLine("myByte : " + myByte);
			int myInt = int.MinValue; // 32 bits
			Console.WriteLine("myInt : " + myInt);
			float myFloat = 1.3f; // 32 bits
			Console.WriteLine("myFloat : " + myFloat);
			double myDouble = 1.75; // 64 bits
			Console.WriteLine("myDouble : " + myDouble);

			// Take care to never overflow the min & max theoric value of any type !!!
			// The majority of program bugs & computation errors come from overflow.
			Console.WriteLine("====Overflow Test====");
			myByte += 3; // 255 + 3 should be 258 but it is not because we overflow the 8-bit capacity of the byte type.
			Console.WriteLine("myByte + 3 : " + myByte + " => Overflow !!! (result should be : 258)");
			myInt -= 3; // -2 147 483 648 - 3 should be -2 147 483 651 but it is not because we overflow the 32-bit capacity of the int type.
			Console.WriteLine("myInt - 3 : " + myInt + " => Overflow !!! (result should be : -2 147 483 651)");

			// Basic Operations.
			Console.WriteLine("====Operations Test====");
			int x = 3;
			int y = 10;
			Console.WriteLine(string.Format("x = {0} ; y = {1}", x, y));
			int sum = x + y;
			Console.WriteLine("X + Y = " + sum);
			int diff = x - y;
			Console.WriteLine("X - Y = " + diff);
			int product = x * y;
			Console.WriteLine("X * Y = " + product);
			int quotient = x / y; // integral types truncate the result by default.
			Console.WriteLine("X / Y = " + quotient);
			int remainder = x % y; // "modulus" operation gives the remainder of the division.
			Console.WriteLine("X % Y = " + remainder);

			// Conversions
			Console.WriteLine("====Conversion Test====");
			// We can convert a float to a double directly (32 bits => 64 bits).
			double myFloatAsDouble = myFloat;
			Console.WriteLine("myfloat as double : " + myFloatAsDouble);
			// We can convert a double to a float using a cast
			float myDoubleAsFloat = (float)myDouble; // cast is mandatory because this conversion is dangerous : high risk of overflow (64 bits => 32 bits).
			Console.WriteLine("myDouble as float : " + myDoubleAsFloat);
			// We can convert float to int (32 bits => 32 bits) but we will lose the decimal part.
			int myFloatAsInt = (int)myFloat; // cast is mandatory
			Console.WriteLine("myFloat as int : " + myFloatAsInt);
			Console.WriteLine("myFloat as int (floor) : " + Math.Floor(myFloat));
			Console.WriteLine("myFloat as int (ceiling) : " + Math.Ceiling(myFloat));
			Console.WriteLine("myFloat as int (rounding) : " + Math.Round(myFloat));
			// EXERCISE : convert double to int.
			// This conversion is dangerous (64 bits => 32 bits) and we will lose the decimal part.
			#region CORRECTION
			Console.WriteLine("====EXERCISE====");
			int myDoubleAsInt = (int)myDouble; // cast is mandatory because this conversion is dangerous.
			Console.WriteLine("myDouble as int : " + myDoubleAsInt);
			#endregion

			Console.WriteLine("====Conversion Test====");
			Console.WriteLine("myDouble as int (floor) : " + Math.Floor(myDouble));
			Console.WriteLine("myDouble as int (ceiling) : " + Math.Ceiling(myDouble));
			Console.WriteLine("myDouble as int (rounding) : " + Math.Round(myDouble));
			// IS THERE ANY DIFFERENCE BETWEEN FLOAT TO INT AND DOUBLE TO INT CONVERSIONS ?

			// Here C# converts automatically res to a double (= the largest of the two operands types).
			var res = myFloat + myDouble; // "var" let the compiler infer the type : avoid using "var" as possible.
			Console.WriteLine("(myFloat + myDouble) as double : " + res);
			// The second result is more accurate because we use the same type for both operands.
			float res2 = myFloat + 1.75f;
			Console.WriteLine("(myFloat + 1.75f) : " + res2);
			// Use Convert to keep precision.
			float res3 = myFloat + Convert.ToSingle(myDouble);
			Console.WriteLine("(myFloat + Convert.ToSingle(myDouble)) : " + res3);

			// String to number test
			string myStringNum = "10";
			int myNum = int.Parse(myStringNum);
			Console.WriteLine("myNum (int) from String : " + myNum);
			myStringNum = "10.000";
			float myFloatNum = float.Parse(myStringNum);
			Console.WriteLine("myNum (float) from String : " + myFloatNum.ToString("f3")); // "f3" => prints 3 decimals after the '.'

			// EXERCISE : Cast sum/diff/product/quotient/remainder to float.
			#region CORRECTION
			Console.WriteLine("====EXERCISE====");
			float sumAsFloat = (float)sum;
			Console.WriteLine("sumAsFloat : " + sumAsFloat);
			float diffAsFloat = (float)diff;
			Console.WriteLine("diffAsFloat : " + diffAsFloat);
			float quotientAsFloat = (float)quotient;
			Console.WriteLine("quotientAsFloat : " + quotientAsFloat);
			float remainderAsFloat = (float)remainder;
			Console.WriteLine("remainderAsFloat : " + remainderAsFloat);
			// How to get the accurate decimal value of quotient ?
			float accurateQuotientAsFloat = (float)x / (float)y; // int to float conversion is implicit, but here we need the accuracy of a division with 2 floats.
			Console.WriteLine("accurateQuotientAsFloat : " + accurateQuotientAsFloat);
			#endregion
		}

		// 7. Conditions
		static void ConditionalsTest()
		{
			Console.WriteLine("====Boolean Test====");
			int a = 4;
			int b = 5;
			Console.WriteLine(string.Format("a = {0} ; b = {1}", a, b));
			bool result;
			result = a < b; // true
			Console.WriteLine("a < b : " + result);
			result = a > b; // false
			Console.WriteLine("a > b : " + result);
			result = a <= 4; // a smaller or equal to 4 - true
			Console.WriteLine("a <= 4 : " + result);
			result = b >= 6; // b bigger or equal to 6 - false
			Console.WriteLine("b >= 6 : " + result);
			result = a == b; // a equal to b - false
			Console.WriteLine("a == b : " + result);
			result = a != b; // a is not equal to b - true
			Console.WriteLine("a != b : " + result);
			result = a > b || a < b; // Logical or - true
			Console.WriteLine("a > b || a < b : " + result);
			result = 3 < a && a < 6; // Logical and - true
			Console.WriteLine("3 < a && a < 6 : " + result);
			result = !result; // Logical not - false
			Console.WriteLine("!result : " + result);

			Console.WriteLine("====If/Else Test====");
			// Simple if
			if (a != b)
			{
				Console.WriteLine("a != b");
			}

			// if / else
			if (a == b)
			{
				// Sorry this is not true.
			}
			else
			{
				Console.WriteLine("Again : a != b");
			}

			// if / else if / else
			// You can add as many "else if" as you want.
			if (a == b)
			{
				// Sorry this is not true.
			}
			else if (a == 6)
			{
				// Sorry this is not true.
			}
			else
			{
				Console.WriteLine("Sorry, nothing is true");
			}

			// Switch
			Console.WriteLine("====Switch Test====");
			int c = b;
			// switch works with integers, enums, and strings.
			switch (c)
			{
				case 4: Console.WriteLine("c=4"); break; // this line is executed if c == 4
				case 5: Console.WriteLine("c=5"); break; // this line is executed if c == 5
				default: Console.WriteLine("c=" + c); break; // this line is executed only if no other "case" is executed.
			}

			// EXERCISE
			// In this exercise, you must construct an if statement that checks if the number guess is equal to 500.
			// If that is the case, use Console.WriteLine to display "You Win!" or "You Loose !".
			#region CORRECTION
			Console.WriteLine("====EXERCISE====");
			Console.WriteLine("Guess the number ? (you have only one chance)");
			int guess = int.Parse(Console.ReadLine());
			if (guess == 500)
			{
				Console.WriteLine("You Win !");
			}
			else
			{
				Console.WriteLine("You Loose !");
				Console.WriteLine("The number was 500");
			}
			#endregion
		}

		// 8. Arrays
		static void ArrayTest()
		{
			Console.WriteLine("====Array Test====");
			// Define an array.
			// Size of an array is fixed.
			// To change the size of an array you need to create a new array.
			int[] nums = { 1, 2, 3, 4, 5 };
			int first = nums[0]; // zero based index.
			int second = nums[1];
			int third = nums[2];
			int fourth = nums[3];
			int fifth = nums[4];
			//int sixth = nums[5]; // Out of range.
			Console.WriteLine(string.Format("nums : {0} ; {1} ; {2} ; {3} ; {4}", first, second, third, fourth, fifth));
			third = nums[2] = 10; // change the third number (index 2 in the array)
			Console.WriteLine("nums[2] = 10;");
			Console.WriteLine(string.Format("nums : {0} ; {1} ; {2} ; {3} ; {4}", first, second, third, fourth, fifth));

			// Define an empty array of size 10.
			// "new" is a keyword to allocate memory. Here we ask to allocate 10 x 32 bits (int).
			// The garbage collector will free this allocated memory automatically when the array object will not be referenced anywhere (at the end of the ArrayTest method in this situation).
			int[] nums2 = new int[10];
			Console.WriteLine("nums2 length : " + nums2.Length);

			Console.WriteLine("====Multidimensional Array Test====");
			// Declare a matrix (= 2D Array).
			// Size is fixed (set once for all) in all dimensions.
			// An array can have a maximum of 32 dimensions.
			int[,] matrix = new int[2, 3];
			// Then fill it.
			matrix[0, 0] = 41;
			matrix[0, 1] = 22;
			matrix[0, 2] = 35;
			matrix[1, 0] = -4;
			matrix[1, 1] = 59;
			matrix[1, 2] = 97;
			// Declare and fill at the same time.
			int[,] predefinedMatrix = new int[2, 3] { { 11, 42, 27 }, { 54, 25, 36 } };
			Console.WriteLine("predefinedMatrix dimensions : {0} x {1}", predefinedMatrix.GetLength(0), predefinedMatrix.GetLength(1));
			Console.WriteLine("predefinedMatrix[1, 2] : " + predefinedMatrix[1, 2]);

			Console.WriteLine("====Jagged Array Test====");
			// Jagged Arrays are multidimensional arrays where each subarray is an independent array.
			// It can have subarrays of different lengths.
			// Use a separate set of square brackets for each dimension of the array.
			int[][] jaggedArray = new int[3][];
			jaggedArray[0] = new int[] { 10, 20, 30 };
			jaggedArray[1] = new int[] { 40, 50, 60, 70 };
			jaggedArray[2] = new int[] { 80, 90, 100, 110, 120 };
			Console.WriteLine("jaggedArray[2, 4] : " + jaggedArray[2][4]);
			//Console.WriteLine("jaggedArray[1, 4] : " + jaggedArray[1][4]); // out of range.

			// EXERCISE : Define an array called fruits that holds the following strings: "apple", "banana", and "orange".
			#region CORRECTION
			Console.WriteLine("====EXERCISE====");
			string[] fruits = { "apple", "banana", "orange" };
			Console.WriteLine("fruits : {0} ; {1} ; {2}", fruits[0], fruits[1], fruits[2]);
			#endregion

			// DEBUGGER INTRODUCTION
			// HOW TO ADD/REMOVE A BREAKPOINT
			// F5 (Execute) / F10 (Step) / F11 (Step into)
			// Explore the values of nums, matrix, predefinedMatrix, jaggedArray while debugging.
		}

		// 9. Lists
		static void ListTest()
		{
			// Lists are Arrays with the possibility to change the size dynamically.
			Console.WriteLine("====List Test====");
			List<int> nums = new List<int>();
			// Adds some numbers to the list using Add().
			nums.Add(1);
			nums.Add(2);
			nums.Add(3);
			Console.WriteLine(string.Format("nums : {0} ; {1} ; {2}", nums[0], nums[1], nums[2]));
			Console.WriteLine(string.Format("nums has {0} elements.", nums.Count));
			// Adds an array of numbers to the list directly with AddRange().
			int[] array = { 4, 5, 6 };
			nums.AddRange(array);
			Console.WriteLine(string.Format("nums : {0} ; {1} ; {2} ; {3} ; {4} ; {5}", nums[0], nums[1], nums[2], nums[3], nums[4], nums[5]));
			Console.WriteLine(string.Format("nums has {0} elements.", nums.Count));

			// List of string
			List<string> fruits = new List<string>();
			// add fruits
			fruits.Add("apple");
			fruits.Add("banana");
			fruits.Add("orange");
			Console.WriteLine(string.Format("fruits : {0} ; {1} ; {2}", fruits[0], fruits[1], fruits[2]));
			Console.WriteLine(string.Format("fruits has {0} elements.", fruits.Count));
			// Remove
			if (fruits.Remove("banana")) // remove the "banana" element from the list if present.
			{
				Console.WriteLine("banana removed.");
			}
			Console.WriteLine(string.Format("fruits has {0} elements.", fruits.Count));
			fruits.Add("banana");
			Console.WriteLine("banana is back.");
			Console.WriteLine(string.Format("fruits has {0} elements.", fruits.Count));
			// RemoveAt
			fruits.RemoveAt(0); // remove element at index 0
			Console.WriteLine("apple removed.");
			Console.WriteLine(string.Format("fruits has {0} elements.", fruits.Count));
			Console.WriteLine(string.Format("fruits : {0} ; {1}", fruits[0], fruits[1]));

			// Concatenation.
			List<string> vegetables = new List<string>();
			vegetables.Add("tomato");
			vegetables.Add("carrot");
			Console.WriteLine(string.Format("vegatables : {0} ; {1}", vegetables[0], vegetables[1]));
			List<string> food = new List<string>();
			food.AddRange(fruits);
			food.AddRange(vegetables);
			Console.WriteLine("food : {0} ; {1} ; {2} ; {3}", food[0], food[1], food[2], food[3]);

			// Search
			int tomatoIndex = food.IndexOf("tomato");
			if (tomatoIndex != -1) // -1 means : element not found
			{
				Console.WriteLine("tomato found at index : " + tomatoIndex);
			}

			// EXERCISE : Construct a list of the first 5 prime numbers(2, 3, 5, 7, 11) called primeNumbers
			// Then remove the first and last elements.
			#region CORRECTION
			Console.WriteLine("====EXERCISE====");
			List<int> primeNumbers = new List<int>();
			primeNumbers.AddRange(new int[] { 2, 3, 5, 7, 11 });
			Console.WriteLine("Prime numbers : {0} ; {1} ; {2} ; {3} ; {4}", primeNumbers[0], primeNumbers[1], primeNumbers[2], primeNumbers[3], primeNumbers[4]);
			// Add elements one by one.
			//primeNumbers.Add(2);
			//primeNumbers.Add(3);
			//primeNumbers.Add(5);
			//primeNumbers.Add(7);
			//primeNumbers.Add(11);
			primeNumbers.RemoveAt(0); // remove first element
			primeNumbers.RemoveAt(primeNumbers.Count - 1); // remove last element
			Console.WriteLine("Prime numbers : first and last elements removed.");
			Console.WriteLine("Prime numbers : {0} ; {1} ; {2}", primeNumbers[0], primeNumbers[1], primeNumbers[2]);
			#endregion
		}

		// 10. Dictionnaries
		static void DictionnaryTest()
		{
			Console.WriteLine("====Dictionnary Test====");
			// A Dictionnary store pairs [Key, Value]
			// Key and Value could be any type.
			// Duplicate keys are not allowed.
			Dictionary<string, long> phonebook = new Dictionary<string, long>();
			// Adds a pair.
			phonebook.Add("Alex", 4154346543);
			Console.WriteLine("Alex's number is " + phonebook["Alex"]);
			// Another way to add a pair.
			// This method adds a pair if key not already exists.
			// Otherwise the existing value is overriden.
			phonebook["Jessica"] = 4159484588;
			Console.WriteLine("phonebook has {0} elements.", phonebook.Count);
			//phonebook.Add("Alex", 0654249543); // Throw an excception : because of duplicate key.
			// Overriding an existing value is allowed.
			phonebook["Alex"] = 4154249543;
			// Search
			if (phonebook.ContainsKey("Alex"))
			{
				Console.WriteLine("Alex's new number is " + phonebook["Alex"]);
			}
			// Another fastest way to search.
			// "out" keyword means the parameter is an output of the function.
			if (phonebook.TryGetValue("Jessica", out long number))
			{
				// This is executed only if key "Jessica" exists (with its associated value).
				Console.WriteLine("Jessica's number is " + number);
			}
			// Remove
			if(phonebook.Remove("Jessica"))
			{
				Console.WriteLine("Jessica has been removed");
			}
			if (!phonebook.ContainsKey("Jessica"))
			{
				Console.WriteLine("I can confirm Jessica has been removed");
			}
			Console.WriteLine("phonebook has {0} elements.", phonebook.Count);

			// EXERCISE
			// Create a new dictionary called inventory that holds 3 names of fruits, and the quantity they are in stock.
			// Here is the inventory specification:
			// 3 of type apple
			// 5 of type orange
			// 2 of type banana
			// 
			// Then check how many ananas there are in the inventory.
			// You can create a variable called fruitToCheck to use to check the quantity of any fruit.
			#region CORRECTION
			Console.WriteLine("====EXERCISE====");
			Dictionary<string, int> inventory = new Dictionary<string, int>();
			inventory.Add("apple", 3);
			inventory.Add("orange", 5);
			inventory.Add("banana", 2);
			// Check quantity of any fruit.
			string fruitToCheck = "ananas";
			if(inventory.TryGetValue(fruitToCheck, out int quantity))
			{
				Console.WriteLine(fruitToCheck + " quantity : " + quantity);
			}
			else
			{
				Console.WriteLine(fruitToCheck + " not found in the inventory !");
			}
			#endregion
		}

		// 11. Loops
		static void LoopsTest()
		{
			Console.WriteLine("====For Loops Test====");
			// Typical for loop.
			{
				int i;
				// (iterator initialization; stop condition; iterator increment)
				// ++i / i++ / i+=1 are equivalent.
				for (i = 0; i < 10; ++i)
				{
					Console.WriteLine("i outside : " + i); // call for i [0;9]
				}
			}// i is destroyed here.

			// C# allows to declare the i variable directly in the for statement.
			for (int i = 0; i < 10; ++i)
			{
				Console.WriteLine("i local to for loop: " + i);
			}

			// Break keyword
			for (int i = 0; i < 16; ++i)
			{
				Console.WriteLine("i (break): " + i);
				if (i == 12)
				{
					break; // break exit the for loop directly
				}
			}

			// Continue keyword
			for (int i = 0; i < 16; ++i)
			{
				if (i % 2 == 1)
				{
					continue; // continue go directly to the next iteration.
				}
				Console.WriteLine("i (continue): " + i); // this is not executed when i % 2 == 1, so only even numbers from 0 to 15 are printed
			}

			// EXERCISE
			// Print the even numbers from 2 to 100 without using an if statement.
			#region CORRECTION
			Console.WriteLine("====EXERCISE====");
			for (int i = 2; i < 101; i += 2)
			{
				Console.WriteLine("even number : " + i);
			}
			#endregion

			Console.WriteLine("====Foreach Loops Test====");
			int[] array = { 1, 2, 3, 4, 5 };
			// Loop through all the elements in the array
			foreach (int item in array)
			{
				Console.WriteLine("item : " + item);
			}
			// Loop through all the elements in the array
			string[] programming = { "C++", "C#", "Python", "C", "Java", "JavaScript" };
			foreach (string language in programming)
			{
				Console.WriteLine("language : " + language);
			}

			// EXERCISE
			// In this exercise, you must find if "Python" is present in the array programming using a foreach loop.
			#region CORRECTION
			Console.WriteLine("====EXERCISE====");
			bool pythonFound = false;
			foreach (string language in programming)
			{
				if (language == "Python")
				{
					pythonFound = true;
					// Don't need to look further. Stops the loop.
					break;
				}
			}
			Console.WriteLine("Python found : " + pythonFound);
			#endregion

			Console.WriteLine("====While Loops Test====");
			int n = 0; // Using while loops, you need to initialize an iterator first.
			// A "while" loop contains only a stop condition.
			while (n < 2) // stop condition
			{
				// Don't forget to increment the iterator, to not loop infinitely.
				Console.WriteLine("n (while): " + (n++)); // n++ : give the value of n, then increment n.
			}

			// A "do while" loop is executed at least once, because the stop condition happens after the first iteration.
			n = 0;
			do
			{
				// Don't forget to increment the iterator, to not loop infinitely.
				Console.WriteLine("n (do while): " + (++n)); // ++n : increment n, then give the value of n.
			} while (n < 2); // stop condition

			// EXERCISE
			// 1. Print programming languages using a while loop.
			// 2. Print programming languages using a for loop.
			#region CORRECTION
			Console.WriteLine("====EXERCISE====");
			// 1.
			Console.WriteLine("Loops with while :");
			n = 0;
			while (n < programming.Length)
			{
				Console.WriteLine("language : " + programming[n++]);
			}
			// 2.
			Console.WriteLine("Loops with for :");
			for (int i = 0; i < programming.Length; ++i)
			{
				Console.WriteLine("language : " + programming[i]);
			}
			#endregion

			// REMARK : "while" and "for" loops are faster than "foreach" loops.
		}

		// 12. Copy Vs Reference
		static void CopyVsReferenceTest()
		{
			Console.WriteLine("====Copy Test====");
			int a = 2;
			int b = 5;
			Console.WriteLine("a : " + a);
			Console.WriteLine("b : " + b);
			a = b; // a get the value of b : 5 => "a" is a "copy" of "b"
			Console.WriteLine("a=b");
			Console.WriteLine("a : " + a);
			Console.WriteLine("b : " + b);
			a = 3; // a get the value 3
			Console.WriteLine("a=3");
			Console.WriteLine("a : " + a);
			Console.WriteLine("b : " + b); // b keeps its value : 5
			// COPY IS THE DEFAULT BEHAVIOUR FOR ALL "struct" TYPES
			// All primitives types are "struct" types : bool, char, short, int, long, float, double, ...
			// SHOW A SIMPLE SCHEMA OF MEMORY FOR a & b

			Console.WriteLine("====Reference Test====");
			int[] nums = { 2, 3 }; // nums is a "reference" to the memory slot allocated for the array { 2, 3 } => nums contains the memory address of the first element of the array.
			int[] nums2 = { 4, 5 }; // nums2 is a "reference" to the memory slot allocated for the array { 4, 5 } => nums2 contains the memory address of the first element of the array.
			Console.WriteLine("nums : {0} ; {1}", nums[0], nums[1]);
			Console.WriteLine("nums2 : {0} ; {1}", nums2[0], nums2[1]);
			Console.WriteLine("nums=nums2");
			// there is no copy of arrays here : only the memory address pointed by nums2 is copied to nums !
			nums = nums2; // => nums is a "reference" to nums2
			// nums & nums2 now point to the exact same memory slot.
			// So printing nums is now the same as printing nums2.
			Console.WriteLine("nums : {0} ; {1}", nums[0], nums[1]);
			Console.WriteLine("nums2 : {0} ; {1}", nums2[0], nums2[1]);
			// And modifying nums is the same as modifying nums2.
			nums[0] = 10; // nums2[0] is also modified here.
			Console.WriteLine("nums[0]=10");
			Console.WriteLine("nums : {0} ; {1}", nums[0], nums[1]);
			Console.WriteLine("nums2 : {0} ; {1}", nums2[0], nums2[1]);
			// REFERENCE IS THE DEFAULT BEHAVIOUR FOR ALL "class" TYPES
			// Examples of "class" types : String, Array, List, Disctionary, ...
			// EXPLAIN THE REFERENCE MECHANISM WITH A SCHEMA OF MEMORY

			// EXERCISE : Swap the references nums3 & nums4 without copying any of their array values.
			// int[] nums3 = { 30, 35 };
			// int[] nums4 = { 40, 45 };
			#region CORRECTION
			Console.WriteLine("====EXERCISE====");
			int[] nums3 = { 30, 35 };
			int[] nums4 = { 40, 45 };
			Console.WriteLine("nums3 : {0} ; {1}", nums3[0], nums3[1]);
			Console.WriteLine("nums4 : {0} ; {1}", nums4[0], nums4[1]);
			int[] tmp = nums3; // tmp references nums3 array
			nums3 = nums4; // nums3 references nums4 array
			nums4 = tmp; // nums4 references tmp array which references initial nums3 array
			Console.WriteLine("nums3 & nums4 references swapped !");
			Console.WriteLine("nums3 : {0} ; {1}", nums3[0], nums3[1]);
			Console.WriteLine("nums4 : {0} ; {1}", nums4[0], nums4[1]);
			#endregion
			// REMARK : swaping references is a mechanism which avoids time-consuming copy of different blocks of data.
			// Real-life example in computer graphics : the double-buffer swap mechanism.
			// Let's say a buffer is a matrix of pixels colors, like this one : byte[1920,1080,3] where each pixel has Red/Green/Blue values of type byte [0;255].
			// At any one time, the "front" buffer is actively being displayed by the monitor, while the other, the "background" buffer is being drawn (pixels are getting their new colors).
			// When the "background" buffer is complete, the roles of the two buffers are switched (swap of references), which avoids a huge copy of their respective data.
			// Thus the "background" buffer becomes the "front" buffer and it can now be displayed, while the "front" buffer becomes the "background" buffer and it can now store the new pixel colors.
			// The swap is typically accomplished by modifying a hardware register in the video display controller (the value of a pointer to the beginning of the display data in the video memory),
			// during each vertical refresh of the monitor (typically at 60Hz).
		}

		// 13. Methods
		// A simple method returning an integer, with no parameters.
		static int IntegerTest()
		{
			return 0;
		}

		// A method returning an integer as the product of its two parameters : a & b.
		static int Multiply(int a, int b)
		{
			return a * b;
		}

		// Another method called "Multiply", returning an integer, but as the product of 3 parameters : a & b & c.
		static int Multiply(int a, int b, int c)
		{
			return a * b * c;
		}

		static void MethodsTest()
		{
			Console.WriteLine("====Methods Test====");
			Console.WriteLine("MethodTest returns : " + IntegerTest());
			Console.WriteLine("Multiply({0}, {1}) returns : {2}", 4, 5, Multiply(4, 5)); // Multiply(a, b) is called here.
			Console.WriteLine("Multiply({0}, {1}, {2}) returns : {3}", 4, 5, 6, Multiply(4, 5, 6)); // Multiply(a, b, c) is called here.

			// EXERCISE
			// Create a method which take 2 parameters : an array of integer values, and a integer value to check if it is present in the array.
			// The method must return the index of the integer value if found in the array, otherwise it returns -1.
			#region CORRECTION INDEXOF
			Console.WriteLine("====EXERCISE====");
			int[] values = { 1, -2, 3, 44, int.MinValue, 6, 9, int.MaxValue, 101, 56 };
			Console.WriteLine("IndexOf(6) : " + IndexOf(values, 6));
			#endregion

			// Copy Vs Reference
			Console.WriteLine("====Copy Test====");
			// "a" keeps its value (5) because a copy of "a" is passed to the CopyTest() method.
			// this behaviour applies to all "value" types (=struct types).
			int a = 5;
			Console.WriteLine("a : " + a);
			CopyTest(a);
			Console.WriteLine("a : " + a);

			Console.WriteLine("====Reference Test====");
			// the array "values" is passed as a reference, so it is modified by the ReferenceTest() method.
			// this behaviour applies to all "reference" types (=class types).
			Console.WriteLine("values[0] : " + values[0]);
			ReferenceTest(values);
			Console.WriteLine("values[0] : " + values[0]);
			
			Console.WriteLine("====Reference Test2====");
			a = 5; // Reset a to 5.
			Console.WriteLine("a : " + a);
			// We can also pass struct types as reference using the keyword "ref".
			ReferenceTest2(ref a); // "ref" means : the function is going to modify the value of the parameter.
			Console.WriteLine("a : " + a);

			Console.WriteLine("====Reference Test3====");
			// We can also pass struct types as reference using the keyword "out".
			// b should be not initialized using the keyword "out".
			ReferenceTest3(out int b); // "out" means : the function is going to return a value through the parameter.
			Console.WriteLine("b : " + b);


			// EXERCISE
			// What's wrong with the Compute method below.
			//static int Compute(int[] pValues)
			//{
			//	int val1, val2;
			//	for (int i = 0; i <= pValues.Length; ++i)
			//	{
			//		if (val1 > pValues[i])
			//		{
			//			val1 = pValues[i];
			//		}
			//
			//		if (val2 < pValues[i])
			//		{
			//			val2 = pValues[i];
			//		}
			//	}
			//	return val1 - val2;
			//}
			#region CORRECTION COMPUTE
			Console.WriteLine("====EXERCISE====");
			Console.WriteLine("RangeOfValues({2, 5, 10}) : " + RangeOfValues(new int[] { 2, 5, 10 })); // Test only positive values
			Console.WriteLine("RangeOfValues({-2, 5, 10}) : " + RangeOfValues(new int[] { -2, 5, 10 })); // Test a mix of positive & negative values
			Console.WriteLine("RangeOfValues({-2, 5, -10}) : " + RangeOfValues(new int[] { -2, 5, -10 })); // Test only negative values
			Console.WriteLine("RangeOfValues(null) : " + RangeOfValues(null)); // Test Edge case 5 : array is null
			Console.WriteLine("RangeOfValues({ }) : " + RangeOfValues(new int[] { })); // Test Edge case 5 : array length is 0.
			Console.WriteLine("RangeOfValues({2}) : " + RangeOfValues(new int[] { 2 })); // Test Edge case 6 : array length is 1.
			Console.WriteLine("RangeOfValues({ int.Min, 2, int.Max }) : " + RangeOfValues(new int[] { int.MinValue, 2, int.MaxValue })); // Test Edge case 7 : array contains int.Min or int.Max
			#endregion
		}

		#region CORRECTION INDEXOF
		static int IndexOf(int[] pValues, int pVal)
		{
			for (int i = 0; i < pValues.Length; ++i)
			{
				if (pVal == pValues[i])
				{
					return i; // pVal found
				}
			}
			return -1; // pVal not found.
		}
		#endregion

		// struct-type parameters are always passed by copy.
		// example:
		// int a = 2;
		// CopyTest(a); 
		// a value is still 2.
		static void CopyTest(int pTest)
		{
			Console.WriteLine("pTest : " + pTest);
			pTest = 3; // pTest = 3 done locally but not the parameter passed to the function.
			// This is because variable "pTest" is a copy of variable "a".
			Console.WriteLine("pTest : " + pTest);
		}

		// class-type (Array, List, etc...) parameters are always passed by reference.
		// example:
		// int[] nums = { 1, 2 };
		// ReferenceTest(nums);
		// nums[0] is now 3.
		static void ReferenceTest(int[] pValues)
		{
			Console.WriteLine("pValues[0] : " + pValues[0]);
			pValues[0] = 3; // nums[0] is modified because "nums" & "pValues" reference the exact same memory slot.
			Console.WriteLine("pValues[0] : " + pValues[0]);
		}

		// the keyword "ref" allow us to pass any type (struct types included) by reference.
		// example:
		// int a = 2;
		// ReferenceTest2(a);
		// a value is now 3
		static void ReferenceTest2(ref int pTest2)
		{
			Console.WriteLine("pTest2 : " + pTest2);
			pTest2 = 3; // "a" is modified because "a" & "pTest2" reference the exact same memory slot.
			Console.WriteLine("pTest2 : " + pTest2);
		}

		// the keyword "out" do the same as keyword "ref" but you are obliged to pass a non-initialized parameter to the function when you call it.
		// example:
		// int a; // non-initialized.
		// ReferenceTest3(a); 
		// a value is now 3
		static void ReferenceTest3(out int pTest3)
		{
			//Console.WriteLine("pTest3 : " + pTest3); // cannot print a non-initialized variable !
			pTest3 = 3; // "a" is modified because "a" & "pTest3" reference the exact same memory slot.
			Console.WriteLine("pTest3 : " + pTest3);
		}

		#region CORRECTION COMPUTE
		// COMPUTE METHOD FIXES (= GOOD CODING PRACTICES):
		// 1. Naming of functions and variables because it is not obvious to understand their meaning.
		// => Always name things (function, variables, ...) to be self-explanatory !
		// It will be easier to understand for everyone and shouldn't require lot of documentation.
		// 2. val1 & val2 are not initialized !
		// => Always initialize your variables with the best "default" value for your current algorithm !
		// 3. for loop is going out of range with stop condition : i <= pValues.Length
		// => Checks for infinite loops !
		// 4. Algorithm is wrong :
		//    - if(val1 > pValues[i]) => if(pValues[i] > val1)
		//    - if(val2 < pValues[i]) => if(pValues[i] < val2)
		// => Checks the logic !
		// 5. Edge case : should return 0 in case pValues is null or pValues.Count == 0.
		// => Anticipate any case where your function could return a wrong result (edge cases) !
		// 6. Edge case : if only one element in the array, we can consider : element = min = max => Default value for min & max : pValues[0].
		// 7. Edge case : returning an int value can overflow in case pValues array contains int.Min or int.Max : using a uint can handle the maximal theoretical value (int.Max - int.Min).
		// 8. Algorithm can be optimized :
		//    - for loop starting from index 1, instead of 0
		//    - "else if" statement, instead of 2x "if" (the 2x "if" are always executed)
		// => Optimizing your code should always be the last step to do, after you already checked :
		// - naming,
		// - initialization,
		// - errors (infinite loops, overflows, bad logic, wrong algorithms),
		// - edge cases.
		static uint RangeOfValues(int[] pValues)
		{
			// 5. Edge case
			// swapping the two conditions can crash => always check for nullity first !
			if (pValues == null || pValues.Length == 0)
			{
				return 0u;
			}

			int min, max;
			min = max = pValues[0]; // 6. Edge case : if pValues.Length == 1 => (max - min) = 0 (expected result).
			for (int i = 1; i < pValues.Length; ++i)
			{
				if (pValues[i] > max)
				{
					max = pValues[i];
				}
				else if (pValues[i] < min)
				{
					min = pValues[i];
				}
			}
			// 7. Edge case
			int range = max - min; // this value can overflow because we only have 31 bits of data in a int (the 32th bit is reserved for the sign).
			return (uint)range; // uint type is safe because it can handle the maximum theoretical value (int.Max - int.Min), thanks to its 32 bits of data.
		}
		#endregion

		// 14. Class
		// You can declare a class inside another class.
		// Here we declare the class MyFirstClass inside the class Program.
		// Different levels of accessibility : 
		// - internal : you can access from the same dll
		// - public : you can access from everywhere
		// - private : you can access from within the class only
		// - protected : you call access from the class and its children classes.
		public class MyFirstClass
		{
			// "public" Keyword allow us to access from the outside of this class.
			public string name = "default"; // an instance attribute.
			// "private" doesn't allow access from the outside of this class.
			private int _instanceNumber = 0; // another instance attribute.

			private static int _instancesCount = 0; // a static attribute is not related to any instances.

			// Constructor
			// The purpose of the Constructor is to initialize instance's attributes.
			// By default, the compiler already creates a Constructor which initialize attributes with their given values (or default value if no given value).
			// So, declaring a constructor is optional unless you really need it.
			// The constructor is called when creating instances of the class.
			// Example : MyFirstClass instance = new MyFirstClass();
			public MyFirstClass()
			{
				_instanceNumber = ++_instancesCount; // _instancesCount is incremented each time an object of type MyFirstClass is instantiated.
			}

			public void InstanceMethod()
			{
				Console.WriteLine(string.Format("InstanceMethod called on instance {0} with name {1}", _instanceNumber, name));
			}

			public static void StaticMethod()
			{
				Console.WriteLine("StaticMethod not called from an instance !");
			}
		}

		static void ClassTest()
		{
			Console.WriteLine("====Class Test====");
			// Instantiation of "an object of type MyFirstClass" (= an instance of type MyFirstClass).
			// The "new" keyword is asking the Operating System to allocate the memory required to handle the data of an object of type MyFirstClass.
			MyFirstClass instance1 = new MyFirstClass();
			instance1.InstanceMethod(); // name has value "default".
			instance1.name = "thales"; // we can modify the attribute name because it is publicly accessible.
			instance1.InstanceMethod(); // name has value "thales".
			// Create a second instance
			MyFirstClass instance2 = new MyFirstClass();
			instance2.InstanceMethod(); // name has value "default".
			instance2.name = "pythagore"; // we can modify the attribute name because it is publicly accessible.
			instance2.InstanceMethod(); // name has value "pythagore".
			// Here there is no copy, because class type uses reference mechanism by default.
			instance2 = instance1; // instance2 now points to the same block of memory as instance1.
			// The block of memory allocated initially to store instance2 data, is no longer referenced anywhere !
			// So we can say that instance2 data is lost (=unreferenced memory).
			// Fortunately, the C# Garbage Collector is in charge to automatically release unreferenced memory.
			// Thus, as C# programmers, we don't need to take care to release the memory allocated using the "new" keyword.
			// But we should take care to not allocate memory too much frequently,
			// because it will make the C# Garbage Collector working too much and can lead to slow performance of the application.
			Console.WriteLine("instance2 = instance1");
			instance2.InstanceMethod(); // name has value "thales" (the name of instance1).
			// EXPLAIN AGAIN THE REFERENCE MECHANISM WITH A SCHEMA OF MEMORY

			// Static method cannot be called from an instance.
			// But we can call static methods directly, like this.
			MyFirstClass.StaticMethod();

		}// instance1 & instance2 objects destroyed here (=memory released by the C# Garbage Collector)

		// 15. File
		static void FileTest()
		{
			Console.WriteLine("====File Test====");
			// Create a file.
			string filepath = "./TestFile.txt";
			string filecontent = "This is my first file.\nAnd I'm proud of it !";
			File.WriteAllText(filepath, filecontent);
			// Check if the file exists.
			if(File.Exists(filepath))
			{
				// Read the file
				string filename = Path.GetFileName(filepath); // get the filename without the path.
				Console.WriteLine("File \"" + filename + "\" opened successfully:");
				Console.WriteLine(File.ReadAllText(filepath)); // print filecontent to the console.
			}
		}
	}
}
