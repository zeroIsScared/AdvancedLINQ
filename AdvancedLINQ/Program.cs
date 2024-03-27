// See https://aka.ms/new-console-template for more information
using AdvancedLINQ;

using System.Net;
using System.Threading.Channels;

//Join

var users = ResourceManager.LoadUserData();
var posts= ResourceManager.LoadBlogsData();

var resultJoin = users.Join(posts,
    user => user.FullName,
    post => post.Author,
    (user, post) => new { Author = user.FullName, PointsAccumulated = user.Points, PstName = post.Title });

foreach (var result in resultJoin)
{
    Console.WriteLine($" {result.Author} - {result.PointsAccumulated}");
}


// GroupJoin
var groupJoinRes = users.GroupJoin(posts,
    user => user.FullName,
    post => post.Author,
    (user, post) => new { Author = user.FullName, Ponts = user.Points, Post = post });

//ZIP

var zipResult = users.Zip(posts, (u, p) => $"{p.Title} - {u.Points}");


foreach (var result in zipResult)
{
    Console.WriteLine(result);
}

//GroupBY
var authorGroup = posts.GroupBy(post => post.Author)
    .Select(x => new { 
        Name = x.Key,
        Count = x.Count(),
        Post = x.Select(p => p)
    }).ToList();

foreach (var group in authorGroup)
{    
    Console.WriteLine($"{group.Name} - {group.Count}");

    foreach(var result in group.Post)
    {
        Console.WriteLine(result.Title);
    }    
}
void Print(List<string> list)
{
    foreach (var i in list)
    {
        Console.WriteLine(i);
    }
}

void PrintInt(List<int> list)
{
    foreach (var i in list)
    {
        Console.WriteLine(i);
    }
}
//LINQ SET operators
List<string> list = new List<string> { "1", "2", "3", "4", "5", "Marry" };
List<string> list1 = new List<string> {"Marry", "Jhoanne", "Katy", "Ashan"};

var concat = list.Concat(list1).ToList();
Print(concat);

Console.WriteLine();

var intersect = list.Intersect(list1).ToList();
Print(intersect);

Console.WriteLine();

var union = list.Union(list1).ToList();
Print(union);

Console.WriteLine();

var except = list.Except(list1).ToList();
Print(except);


Console.WriteLine();

//LINQ Agregation methods
var count = list.Count();
Console.WriteLine(count);

Console.WriteLine();

var maxPoints = users.Max(user => user.Points);
Console.WriteLine(maxPoints);

Console.WriteLine();

var minPoints = users.Min(user => user.Points);
Console.WriteLine(minPoints);

Console.WriteLine();

var pointsSum = users.Sum(x => x.Points);
Console.WriteLine(pointsSum);

Console.WriteLine();

var averagePoints = users.Average(x => x.Points);
Console.WriteLine(averagePoints);

Console.WriteLine();


//LINQ Quantifiers methods

var itContains = list.Contains("Marry");
Console.WriteLine($"list contains Marry {itContains}");

var isThereAny = list.Any(x => x == "5");
Console.WriteLine($"is there 5 {isThereAny}");

var areTheyAll = list.All(x => x.Length > 5);
Console.WriteLine($"theire length is greater than 5 - {areTheyAll}");

var areEqual = list.SequenceEqual(list1);
Console.WriteLine($"they are equal {areEqual}");

//LINQ Element Operators

var first = list.First();
Console.WriteLine($"{first} is the first element in list");

var last = list.Last();
Console.WriteLine($"{last} is the last element in list");

var isJustOne = list.Single(x => x == "Marry");
Console.WriteLine($"there is just one Marry in list {isJustOne}");

var chosen = list.ElementAt(3);
Console.WriteLine($"at position 3 is element - {chosen}");

List<int> list2 = new List<int>();
var dEmpty = list2.DefaultIfEmpty().ToList();

foreach (var i in dEmpty)
{
    Console.WriteLine(i);
}

//LINQ Generation Operators

var empty = Enumerable.Empty<string>();

Console.WriteLine(empty.Count());

Console.WriteLine();

var repeat = Enumerable.Repeat(new Post(), 3);
Console.WriteLine(repeat.Count());

Console.WriteLine();

var range = Enumerable.Range(0, 20).ToList();
PrintInt(range);

Console.WriteLine();

var sql = (from u in users
           where u.Points == 10
           select new { u.FirstName, u.Points }).ToArray();

foreach (var result in sql)
{
    Console.WriteLine($" {result.FirstName} - {result.Points}");
}

Console.WriteLine();

var methodSyntax = users.Where(u => u.Points > 5).Select(u => u.Points).ToHashSet();

foreach (var result in methodSyntax)
{
    Console.WriteLine(result);
}