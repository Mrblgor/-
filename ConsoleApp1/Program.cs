using System;
using System.Collections.Generic;
using System.Security.Principal;

/// <summary>
/// Главный класс программы для демонстрации полиморфизма.
/// </summary>
class Program
{
    /// <summary>
    /// Точка входа в приложение.
    /// </summary>
    static void Main(string[] args)
    {
        // Создаем коллекцию базового типа Account
        List<Account> accounts = new List<Account>();

        // Наполнение коллекции объектами-наследниками (Тестовые данные из ТЗ)
        accounts.Add(new DebitAccount("40817810001", "Иванов", 250000, 50000));
        accounts.Add(new CreditAccount("40817810002", "Петров", -50000, 200000));

        // Обход коллекции через foreach (запрещено использовать LINQ по ТЗ)
        foreach (Account account in accounts)
        {
            // 1. Вывод ToString()
            Console.WriteLine(account.ToString());

            // 2. Вызов абстрактного метода
            account.DisplayInfo();

            // 3. Проверка типов во время выполнения через is и pattern matching
            if (account is IWithdrawable withdrawableAccount)
            {
                withdrawableAccount.Withdraw(1000);
            }
            else if (account is CreditAccount creditAccount)
            {
                // Если объект не реализует интерфейс, но это CreditAccount — вызываем его метод напрямую
                creditAccount.Withdraw(300000);
            }

            Console.WriteLine(); // Пустая строка для разделения вывода, как в примере
        }
    }
}