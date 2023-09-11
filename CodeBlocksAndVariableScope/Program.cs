// bool flag = true;
// int value = 0;

// if (flag) {
//     value = 10;
//     Console.WriteLine($"Inside of code block: {value}");
// }
// Console.WriteLine($"Outside of code block: {value}");

//-------------------------------------knowledge check notes
// int val1 = 5;

// if (val1 > 0) {
//     int val2 = 6;
//     val1 = val2 += val1;
// }

// Console.WriteLine($"First integer: {val1}");

//---------------------------------------------------------single lines suck
// string name = "steve";
// if (name == "bob") Console.WriteLine("Found Bob");
// else if (name == "steve") Console.WriteLine("Found Steve");
// else Console.WriteLine("Found Chuck");

//--------make it readable
// string name = "bob";

// if (name == "bob")
//     Console.WriteLine("Found Bob");
// else if (name == "steve")
//     Console.WriteLine("Found Steve");
// else
//     Console.WriteLine("Found Chuck");

//----------------------------Microsoft Challenge: Variable Scope Challenge
// int[] numbers =  { 4, 8, 15, 16, 23, 42 };
// int total = 0;
// bool found = false;

// foreach (int number in numbers) {
//     total += number;

//     if (number == 42)
//     found = true;
// }

// if (found)
//     Console.WriteLine("Set contains 42");

// Console.WriteLine($"Total: {total}");
//-------------------------------------knowledge check notes
Console.Clear();

int val1 = 5;
bool flag = true;

if (flag) {
    int val2 = 3;
    val1 += val2;
}
Console.WriteLine($" Value: {val1}");
