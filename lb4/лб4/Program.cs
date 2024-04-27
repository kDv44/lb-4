using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static Dictionary<string, string> users = new Dictionary<string, string>(); // Зберігаємо пари "ім'я користувача - пароль"

    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8; // Встановлюємо кодування UTF-8 для виведення в консоль

        bool isExit = false;
        bool isLoggedIn = false;
        string currentUser = "";

        while (!isExit)
        {
            Console.WriteLine("Виберіть опцію:");
            Console.WriteLine("1. Увійти в систему");
            Console.WriteLine("2. Зареєструватися");
            Console.WriteLine("3. Вийти з системи");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    if (isLoggedIn)
                    {
                        Console.WriteLine("Ви вже увійшли в систему!");
                    }
                    else
                    {
                        isLoggedIn = Login();
                        if (isLoggedIn)
                        {
                            currentUser = GetUsername();
                        }
                    }
                    break;
                case "2":
                    if (isLoggedIn)
                    {
                        Console.WriteLine("Спершу вийдіть з поточного облікового запису!");
                    }
                    else
                    {
                        Register();
                    }
                    break;
                case "3":
                    if (isLoggedIn)
                    {
                        isLoggedIn = false;
                        currentUser = "";
                        Console.WriteLine("Вихід з системи успішно виконано.");
                    }
                    else
                    {
                        Console.WriteLine("Ви вже не увійшли в систему!");
                    }
                    break;
                default:
                    Console.WriteLine("Некоректний ввід. Будь ласка, введіть число від 1 до 3.");
                    break;
            }

            if (isLoggedIn)
            {
                Console.WriteLine($"Ласкаво просимо, {currentUser}!");
            }
            else
            {
                Console.WriteLine("Будь ласка, увійдіть в систему.");
            }

            Console.WriteLine("Ви хочете продовжити роботу з системою? (так/ні)");
            string continueInput = Console.ReadLine();
            if (continueInput.ToLower() != "так")
            {
                isExit = true;
            }
        }
    }

    static bool Login()
    {
        Console.Write("Введіть ім'я користувача: ");
        string username = Console.ReadLine();
        Console.Write("Введіть пароль: ");
        string password = Console.ReadLine();

        if (users.ContainsKey(username) && users[username] == password)
        {
            Console.WriteLine("Успішний вхід в систему!");
            return true;
        }
        else
        {
            Console.WriteLine("Помилка: неправильне ім'я користувача або пароль.");
            return false;
        }
    }

    static void Register()
    {
        Console.Write("Введіть нове ім'я користувача: ");
        string newUsername = Console.ReadLine();
        Console.Write("Введіть новий пароль: ");
        string newPassword = Console.ReadLine();

        if (!users.ContainsKey(newUsername))
        {
            users.Add(newUsername, newPassword);
            Console.WriteLine("Реєстрація успішно завершена!");
        }
        else
        {
            Console.WriteLine("Помилка: користувач з таким ім'ям вже існує.");
        }
    }

    static string GetUsername()
    {
        Console.Write("Введіть ім'я користувача: ");
        return Console.ReadLine();
    }
}
