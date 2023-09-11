// Random dice = new Random();
// int roll1 = dice.Next(1, 7);
// int roll2 = dice.Next(1, 7);
// int roll3 = dice.Next(1, 7);
// int total = roll1 + roll2 + roll3;
// Console.WriteLine($"Dice roll: {roll1} + {roll2} + {roll3} = {total}");
//------------------------------------------------------------------------------------------implementing the doubles & triples point system
// We don't want these rules to "stack," meaning you either get one bonus or the other.
// Implement this via nested if statements and using 'else' to return the value of the base-case (the first 'if').

// Rule: "If two of the three dice are the same value, gain 2 bonus points."
// if ((roll1 == roll2) || (roll2 == roll3) || (roll1 == roll3)) {
// // Rule: "If all three dice are the same value, gain 6 bonus points."
//     if ((roll1 == roll2) && (roll2 == roll3)) {
//         Console.WriteLine("You rolled triples! + 6 bonus to total!");
//         total += 6;
//         Console.WriteLine($"New Score Total: {total}!");
//     } else {
//         Console.WriteLine("You rolled doubles! +2 bonus to total!");
//         total += 2;
//         Console.WriteLine($"New Score Total: {total}!");
//     }
// }
//-------------------------------------------------------------
// Let's alter our original win/lose cases to award prizes, using if, else, and else if statements B)
//------original win/lose scenarios:
// // if (total >= 15) {
// //     Console.WriteLine("You Win!");
// // }
// // if (total < 15) {
// //     Console.WriteLine("Sorry, you lose.");
// // }
//-------------updated using if, else, and if else statements:
// if (total >= 16) {
//     Console.WriteLine("You win a new car!");
// } else if (total >= 10) { // refinement
//     Console.WriteLine("You win a new laptop!");
// } else if (total == 7) { // refinement
//     Console.WriteLine("You win a trip for two!");
// } else { // else statements should always come last
//     Console.WriteLine("you win a kitten! :')");
// }
//-----------------------------------------------------------------Quick bool practice
// string message = "The quick brown fox jumps over the lazy dog.";
// bool result = message.Contains("dog");
// Console.WriteLine(result); //--> outputs: True

// if (message.Contains("fox")) {
//     Console.WriteLine("What does the fox say?");
// }
//------------------------------------------------Storing and Iterating through sequences of data using Arrays and the foreach statement
// string[] fraudulentOrderIds = new string[3];
// // first we tell the compiler to expect an array of the string data type, we then name the variable, then we use the new keyword to indicate the number of elements that array can hold
// fraudulentOrderIds[0] = "A123";
// fraudulentOrderIds[1] = "B456";
// fraudulentOrderIds[2] = "C789";
// // fraudulentOrderIds[3] = "D000";

// Console.WriteLine($"First: {fraudulentOrderIds[0]}");
// Console.WriteLine($"Second: {fraudulentOrderIds[1]}");
// Console.WriteLine($"Third: {fraudulentOrderIds[2]}");

// // reassigning an array element:
// fraudulentOrderIds[0] = "F000";
// Console.WriteLine($"Reassign First: {fraudulentOrderIds[0]}");
// Initializing an array during declaration just as we would a regular variable using {}:
// string[] fraudulentOrderIds = { "A123", "B456", "C789" };

// Console.WriteLine($"First: {fraudulentOrderIds[0]}");
// Console.WriteLine($"Second: {fraudulentOrderIds[1]}");
// Console.WriteLine($"Third: {fraudulentOrderIds[2]}");

// fraudulentOrderIds[0] = "F000";
// Console.WriteLine($"Reassign First: {fraudulentOrderIds[0]}");

// // .Length property
// Console.WriteLine($"There are {fraudulentOrderIds.Length} fraudulent orders to process.");

//--------------looping using .foreach

// // simple example:
// string[] names = { "Rowena", "Robin", "Bao" };
// foreach(string name in names) {
//     Console.WriteLine(name);
// }

// // Create and initialize an array of int:
// int[] inventory = { 200, 450, 700, 175, 250 };
// int sum = 0;
// int bin = 0;
// foreach(int items in inventory) {
//     sum += items;
//     bin++;
//     Console.WriteLine($"Bin {bin} = {items} items (Running total: {sum})");
// }

// Console.WriteLine($"We have {sum} items in inventory.");

//---------------Comments and whitespace in C#
// string firstName = "Bob";
// int widgetsPurchased = 7;
// // Testing a change to the message.
// // int widgetsSold = 7;
// // Console.WriteLine($"{firstName} sold {widgetsSold} widgets.");
// Console.WriteLine($"{firstName} purchased {widgetsPurchased} widgets.");

// Random random = new Random();
// string[] orderIDs = new string[5];
// // Loop through each blank order ID // low quality comment
// for (int i = 0; i < orderIDs.Length; i++) {
//     // Get a random value that equates to ASCII letters A through E // low quality comment
//     int prefixValue = random.Next(65, 70);
//     // Convert the random value into a char, then a string // low quality comment
//     string prefix = Convert.ToChar(prefixValue).ToString();
//     // Create a random number, pad with zeroes // low quality comment
//     string suffix = random.Next(1, 1000).ToString("000");
//     // Combine prefix and suffix together, then assign to current OrderID // low quality comment
//     orderIDs[i] = prefix + suffix;
// }
// // Print out each orderID // low quality comment
// foreach (var orderID in orderIDs) {
//     Console.WriteLine(orderID);
// }

// ---------------------------Remove low quality comments and update with a higher quality,
//                              purposeful code comment at the top of the section so as not to
//                               over clutter our code with not-quite-so-helpful comments.

/*
    The following code creates five random OrderIDs
    to tst the fraud detection process. OrderIDs
    consist of a letter from A to E, and a three
    digit number. Ex. A123
*/
// Random random = new Random();
// string [] orderIDs = new string[5];

// for (int i = 0; i < orderIDs.Length; i++) {
//     int prefixValue = random.Next(65, 70);
//     string prefix = Convert.ToChar(prefixValue).ToString();
//     string suffix = random.Next(1, 1000).ToString("000");

//     orderIDs[i] = prefix + suffix;
// }

// foreach(var orderID in orderIDs) {
//     Console.WriteLine(orderID);
// }
//---------------------------------------------------------White spacing:
// //Example 1: :c
// Console
// .
// WriteLine
// (
//     "Hello Example 1!"
// )
// ;
// //Example 2: :c
// string firstWord="Hello";string lastWord="Example 2";Console.WriteLine(firstWord+" "+lastWord+"!");
// //Example 3: :) technically it's standard to put curly braces, {}, on their own lines. My personal convention doesn't do that, so I will remain consistent.
// Random dice = new Random();

// int roll1 = dice.Next(1, 7);
// int roll2 = dice.Next(1, 7);
// int roll3 = dice.Next(1, 7);

// int total = roll1 + roll2 + roll3;
// Console.WriteLine($"Dice roll: {roll1} + {roll2} + {roll3} = {total}");

// if ((roll1 == roll2) || (roll2 == roll3) || (roll1 == roll3)) {
//     if ((roll1 == roll2) && (roll2 == roll3)) {
//         Console.WriteLine("You rolled triples! +6 bonus to total!");
//         total += 6;
//     } else {
//         Console.WriteLine("You rolled doubles! +2 bonus to total!");
//         total += 2;
//     }
// }
//---------------------------------------Exercise Challenge: Tidy Up This Code!
//Provided code:

// string str = "The quick brown fox jumps over the lazy dog.";
// // convert the message into a char array
// char[] charMessage = str.ToCharArray();
// // Reverse the chars
// Array.Reverse(charMessage);
// int x = 0;
// // count the o's
// foreach (char i in charMessage) { if (i == 'o') { x++; } }
// // convert it back to a string
// string new_message = new String(charMessage);
// // print it out
// Console.WriteLine(new_message);
// Console.WriteLine($"'o' appears {x} times.");

//Tidied up code:

/*
    First convert message string to a char array, then reverse the array.
    Iterate through array, counting each 'o'.
    Convert array back to a string and print to console.
*/
// string str = "The quick brown fox jumps over the lazy dog.";

// char[] charMessage = str.ToCharArray();
// Array.Reverse(charMessage);

// int x = 0;

// foreach (char i in charMessage) {
//     if (i == 'o') {
//         x++;
//     }
// }

// string new_message = new String(charMessage);

// Console.WriteLine(new_message);
// Console.WriteLine($"'o' appears {x} times.");