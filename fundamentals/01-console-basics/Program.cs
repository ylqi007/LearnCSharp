// See https://aka.ms/new-console-template for more information

using ConsoleBasics.Models;

string name = "Alex";
Console.WriteLine($"Hello, {name}!");

// List
List<string> skills = [
    "Java", 
    "TypeScript",
    "C#"
];

foreach (var skill in skills)
{
    Console.WriteLine(skill);
}


// Class
var person = new Person
{
    Name = "Alex",
    Age = 34
};

Console.WriteLine(person.Name);