using DotnetUz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetUz
{
    public class ForTesting
    {
        //  Ў   ў   Қ   қ   Ғ   ғ
        private readonly IUserRepository? repository;
        public ForTesting()
        {
            repository = new UserRepository();
        }
        private void GetUsersCount()
        {
            Console.Write($"Жами фойдаланувчилар сони : {repository?.Count} та");
        }

        public void CreateUser()
        {
            Console.Write("Янги фойдаланувчининг исми:");
            string? name = Console.ReadLine();
            Console.Write("Янги фойдаланувчининг ёши:");
            int age = int.Parse(Console.ReadLine() ?? "0");
            int id = repository?.MaxId() ?? 1;
            User user = new User { Id = id, Age = age, Name = name };
            repository?.Create(user);
        }
        public void UpdateUser()
        {
            Console.Write("Ўзгартирмоқчи бўлган фойдаланувчи идси:");
            int id = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("Ўзгартирмоқчи бўлган фойдаланувчининг исми:");
            string? name = Console.ReadLine();
            Console.Write("Ўзгартирмоқчи бўлган фойдаланувчининг ёши:");
            int age = int.Parse(Console.ReadLine() ?? "0");
            User user = new User { Id = id, Name = name, Age = age };
            repository?.Update(user);
        }
        public void DeleteUser()
        {
            Console.Write("Ўчирмоқчи бўлган фойдаланувчи идси:");
            int id = int.Parse(Console.ReadLine() ?? "0");
            repository?.Delete(id);
        }
        public void GetAllUsers()
        {
            GetUsersCount();
            Console.WriteLine("\n");
            List<User>? user = repository?.GetUsers() ?? new List<User> { };
            foreach (User? item in user)
            {
                Show(item);
            }
        }
        public void GetUser()
        {
            Console.Write("Қидирмоқчи бўлган фойдаланувчи идси:");
            int id = int.Parse(Console.ReadLine() ?? "0");
            Show(repository?.Get(id));
        }
        private void Show(User? user)
        {
            Console.WriteLine($"Ид : {user?.Id}");
            Console.WriteLine($"Исми : {user?.Name}");
            Console.WriteLine($"Ёши : {user?.Age}");
            Console.WriteLine("\n");
        }
    }
}
