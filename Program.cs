using DotnetUz;


bool repeat = true;
ForTesting test = new ForTesting();

Nishon:
Console.WriteLine("Create:C, Update:U, Delete:D, GetUserById:G, Exit: X, Clear: L");
ConsoleKeyInfo? comparison = Console.ReadKey();
if (comparison is not null)
{
    Console.WriteLine("\n");
    test.GetAllUsers();
    switch (comparison.Value.Key)
    {
        case ConsoleKey.C:
            test.CreateUser();
            break;
        case ConsoleKey.D:
            test.DeleteUser();
            break;
        case ConsoleKey.G:
            test.GetUser();
            break;
        case ConsoleKey.U:
            test.UpdateUser();
            break;
        case ConsoleKey.X:
            repeat = false;
            break;
        case ConsoleKey.L:
            Console.Clear();
            break;
        default:
            repeat = false;
            break;
    }

}

if (repeat)
{
    goto Nishon;
}
