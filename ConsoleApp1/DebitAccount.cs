using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

/// <summary>
/// Дебетовый счет с поддержкой интерфейса снятия средств.
/// </summary>
public class DebitAccount : Account, IWithdrawable
{
    /// <summary>
    /// Приватное поле класса для отслеживания даты последней операции.
    /// </summary>
    private DateTime _lastTransactionDate;

    /// <summary>
    /// Дневной лимит на снятие средств (Автосвойство).
    /// </summary>
    public decimal DailyLimit { get; set; }

    /// <summary>
    /// Вычисляемое свойство: можно ли снять еще средства (get-only, без backing-поля).
    /// </summary>
    public bool CanWithdrawMore => Balance > 0;

    /// <summary>
    /// Конструктор дебетового счета.
    /// </summary>
    public DebitAccount(string number, string owner, decimal balance, decimal dailyLimit)
        : base(number, owner, balance)
    {
        Type = AccountType.Debit;
        DailyLimit = dailyLimit;
        _lastTransactionDate = DateTime.Now;
    }

    /// <summary>
    /// Реализация интерфейса IWithdrawable. Снятие средств.
    /// </summary>
    public void Withdraw(decimal amount)
    {
        if (Balance >= amount)
        {
            Balance -= amount;
            _lastTransactionDate = DateTime.Now;
            Console.WriteLine($"Счёт {Number} успешное снятие суммы {amount}.");
        }
        else
        {
            Console.WriteLine($"Счет {Number}: недостаточно средств для снятия.");
        }
    }

    /// <summary>
    /// Реализация абстрактного метода вывода информации.
    /// </summary>
    public override void DisplayInfo()
    {
        Console.WriteLine($"Информация о дебетовом счете: {Number}");
    }

    /// <summary>
    /// Переопределенный метод ToString, использующий специфичные поля класса.
    /// </summary>
    public override string ToString()
    {
        return $"[DebitAccount] {base.ToString()}\nvip: {IsVip}";
    }
}
