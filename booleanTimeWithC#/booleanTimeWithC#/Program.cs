using System;

//---------------------------------------------------------------------Boolean Expressions B)

// Console.WriteLine("a" == "a "); // outputs true // with space: false
// Console.WriteLine("a" == "A"); // outputs false
// Console.WriteLine(1 == 2); // outputs false

// string myValue = "a";
// Console.WriteLine(myValue == "a"); // outputs true

//--------------------------------'massaging' our data

// string value1 = " a";
// string value2 = "A ";
// // as of now these would be unequal --> output false
// Console.WriteLine(value1.Trim().ToLower() == value2.Trim().ToLower()); // outputs true!

//---------------------The 'bang' operator (!) for inverse checks

// Console.WriteLine("a" != "a"); // outputs false
// Console.WriteLine("a" != "A"); // outputs true
// Console.WriteLine(1 != 2); // outputs true

// string myValue = "a";
// Console.WriteLine(myValue != "a"); // outputs false

//---------------------Comparison operators (>, <, >=, <=)

// Console.WriteLine(1 > 2); // outputs false
// Console.WriteLine(1 < 2); // outputs true
// Console.WriteLine(1 >= 1); // outputs true
// Console.WriteLine(1 <= 1); // outputs true

//----------------------------Methods that return a Boolean value
/*
    Some data types have methods that perform helpful utility tasks. The String data type has many of these.
    Several return a Boolean value including Contains(), StartsWith(), and EndsWith().
    You can learn more about them in the Microsoft Learn module "Manipulate alphanumeric data using String class methods in C#".
*/

// string pangram = "The quick brown fox jumps over the lazy dog.";
// Console.WriteLine(pangram.Contains("fox")); // outputs true
// Console.WriteLine(pangram.Contains("cow")); // outputs false

//------------------------------------Logical Negation
/*
    When you place the ! operator before a conditional expression (or any code that's evaluated to either true or false),
    it forces your code to ensure that the expression is false.
*/

// string pangram = "The quick brown fox jumps over the lazy dog.";
// // These two lines of code will create the same output!
// Console.WriteLine(pangram.Contains("fox") == false); // outputs false
// Console.WriteLine(!pangram.Contains("fox")); // outputs false

// Console.WriteLine(!pangram.Contains("fox")); // outputs false
// Console.WriteLine(!pangram.Contains("cow")); // outputs true
//------------------------------------------------------------------------------------------------------------------------------
//--------Microsoft Exercise: Implement the conditional operator B) The ternary returns!
// int saleAmount = 1001; // discount will be 100.
// int saleAmount = 999; // discount will be 50.
// int discount = saleAmount > 1000 ? 100 : 50;
// Console.WriteLine($"Discount: {discount}");
//-------------------------------------------using the conditional operator inline - don't forget the ()!
// int saleAmount = 1001; // discount will be 100.
// int saleAmount = 999; // discount will be 50.
// Console.WriteLine($"Discount: {(saleAmount > 1000 ? 100 : 50)}");

//---------------------Challenge: Simulate a coin flip

// Random coin = new Random();
// //my solution:
// // int flip = coin.Next(0, 2);
// // Console.WriteLine($"Flipping a coin! {flip} == {(flip > 0 ? "heads" : "tails")}");

// //additional solution from challenge: Remove the temporary 'flip' and perform the random, value check, and ternary in one line!
// Console.WriteLine((coin.Next(0, 2) == 0) ? "heads" : "tails");
//---------------------Challenge: Decision Logic: Business Rules B)
// ---------------------------------my attempts(420):
// string permission = "Admin|Manager";
// int level = 19;

// string message = (permission == "Admin|Manager" && level > 55) ? "Welcome, Super Admin user." : "Welcome, Admin user.";
// if (permission == "Manager" && level >= 20) {
//     message = "Contact an Admin for access.";
// }
// if (permission.Contains("Manager") && level < 20) {
//     message = "You do not have sufficient access.";
// }
// if (!permission.Contains("Admin|Manager")) {
//     message = "you do not have sufficient access. (due to your permission settings)";
// }
// Console.Write(message);
//---------------------------
Console.Clear();
//-----------------------------------------------------------solution:
string permission = "Admin|Manager";
int level = 56;

if (permission.Contains("Admin")) {
    if (level > 55) {
        Console.WriteLine("Welcome, Super Admin user.");
    } else {
        Console.WriteLine("Welcome, Admin user.");
    }
}
else if (permission.Contains("Manager")) {
    if (level >= 20) {
        Console.WriteLine("Contact an Admin for access.");
    } else {
        Console.WriteLine("You do not have sufficient privileges.");
    }
} else {
    Console.WriteLine("You do not have sufficient privileges due to your permissions.");
}