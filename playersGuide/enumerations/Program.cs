Season current = Season.Fall;

if (current == Season.Summer || current == Season.Winter)
    Console.WriteLine("Happy Solstice!");
else
    Console.WriteLine("Happy Equinox!");

enum Season { Winter, Spring, Summer, Fall };