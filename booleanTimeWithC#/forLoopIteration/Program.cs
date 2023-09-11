// for (int i = 0; i <= 10; i++) {
//     Console.WriteLine(i);
// }

// for (int i = 10; i >= 0; i--) {
//     Console.WriteLine(i);
// }

// for (int i = 0; i < 10; i += 3) {
//     Console.WriteLine(i);
// }

// for (int i = 0; i < 10; i++) {
//     Console.WriteLine(i);
//     if (i == 7) break;
// }
//---------------------------------------------------------arrays
// string [] names = { "Alex", "Eddie", "David", "Michael" };
// for (int i = 0; i < names.Length; i++) {
// // for (int i = names.Length - 1; i >= 0; i--) { // iterate through the array backwards
//     Console.WriteLine(names[i]);
// }
//----------Compare the might & power of `for` as opposed to `foreach`:

// string[] names = { "Alex", "Eddie", "David", "Michael" };

// // foreach:

// foreach (var name in names) {
//     // Can't do this:
//     if (name == "David") name = "Sammy";
//     Console.WriteLine(name);
//     // Because: You can't reassign the value of name because it is part of the foreach iteration's inner implementation.
// }

/*
    Heads up:
        Many developers find this style difficult to read.
        While others prefer this abbreviated style because it helps them write more succinctly and more expressively.
*/

// string[] names = { "Alex", "Eddie", "David", "Michael" };

// // for:

// for (int i = 0; i < names.Length; i++)
//     if (names[i] == "David") names[i] = "Sammy";

// foreach (var name in names) Console.WriteLine(name);
//--------------------------------------------------------FizzBuzz
Console.WriteLine("__________________________________________\n|\tValue\t\tResult\t\t |\n==========================================");

for (int i = 1; i <= 100; i++) {
    if (i % 15 == 0) {
        Console.WriteLine($"|`{i}`\t\t`FizzBuzz`\t\t`|\n_________________________________________");
    } else if (i % 5 == 0) {
        Console.WriteLine($"|`{i}`\t\t`Buzz`\t\t\t`|\n_________________________________________");
    } else if (i % 3 == 0) {
        Console.WriteLine($"|`{i}`\t\t`Fizz`\t\t\t`|\n_________________________________________");
    } else {
        Console.WriteLine($"|`{i}`\t\t`Nothing to see here.`\t`|\n_________________________________________");
    }
}