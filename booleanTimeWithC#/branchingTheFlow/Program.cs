using System;
//-------------------------------------------------------------------------Switch Statement
/*
**:Each switch section is defined by a case pattern.
***:Case patterns are Boolean (true/false) expressions.
***:If true(=="It's a match"): The case executes a small number of code lines.
****:Switch statements typically have upwards to 3+ cases.

*: Best used when:
-:You have a single value (variable or expression) that you want to match against many possible values.
-: For any given match, you need to execute (at most) a couple of lines of code.
*/


// string fruit = "cherry";

// switch (fruit) {
//     case "apple":
//         Console.WriteLine($"App will display information for {fruit}.");
//         break;
    
//     case "banana":
//         Console.WriteLine($"App will display information for {fruit}.");
//         break;
    
//     case "cherry":
//         Console.WriteLine($"App will display information for cherry.");
//         break;
//     case "butt":
//         Console.WriteLine($"App will display information for {fruit}");
//         break;
// }
//------------------------------------------------------------------------------------------

// int employeeLevel = 150; // We'll use this variable as the bool-check for our switch statement (see line 39)
// string employeeName = "John Smith";

// string title = "";

// switch (employeeLevel) {
//     case 100:
//         title = "Junior Associate";
//         break;
//     case 200:
//         title = "Senior Associate";
//         break;
//     case 300:
//         title = "Manager";
//         break;
//     case 400:
//         title = "Senior Manager";
//         break;
//     default:
//         title = "Associate";
//         break;
// }
//----------------------------------------------Refactored to include multiple case labels in a switch section
// switch (employeeLevel) {
//     case 100:
//     case 200:
//         title = "Senior Associate";
//         break;
//     case 300:
//         title = "Manager";
//         break;
//     case 400:
//         title = "Senior Manager";
//         break;
//     default:
//         title = "Associate";
//         break;
// }
// Each case label must provide a value type that matches the type specified in the switch expression;
// Console.WriteLine($"{employeeName}, {title}");
//----------------------------------------------Microsoft Challenge - Convert to Switch Statements Challenge
// Re-write an if-elseif-else construct as a switch statement.

// SKU = Stock Keeping Unit.
// SKU value format: <product #>-<2-letter color code>-<size code>
Console.Clear();

string sku = "01-MN-L";

string[] product = sku.Split('-');

string type = "";
string color = "";
string size = "";

// if (product[0] == "01") {
//     type = "Sweat Shirt";
// } else if (product[0] == "02") {
//     type = "T-Shirt";
// } else if (product[0] == "03") {
//     type = "Sweat pants";
// }
// else
// {
//     type = "Other";
// }
//----------------------refactor above to switch
switch (product[0])
{
    case "01":
        type = "Sweat Shirt";
        break;
    case "02":
        type = "T-Shirt";
        break;
    case "03":
        type = "Sweat Pants";
        break;
    default:
        type = "Other";
        break;
}

// if (product[1] == "BL") {
//     color = "Black";
// } else if (product[1] == "MN") {
//     color = "Maroon";
// }
// else
// {
//     color = "White";
// }
//----------------------refactor above to switch


switch (product[1])
{
    case "BL":
        color = "Black";
        break;
    case "MN":
        color = "Maroon";
        break;
    default:
        color = "White";
        break;
}


// if (product[2] == "S") {
//     size = "Small";
// } else if (product[2] == "M") {
//     size = "Medium";
// } else if (product[2] == "L") {
//     size = "Large";
// }
// else
// {
//     size = "One Size Fits All";
// }
//----------------------refactor above to switch

switch (product[2])
{
    case "S":
        size = "Small";
        break;
    case "M":
        size = "Medium";
        break;
    case "L":
        size = "Large";
        break;
    default:
        size = "Once Size Fits All";
        break;
}

Console.WriteLine($"Products: {size} {color} {type}");