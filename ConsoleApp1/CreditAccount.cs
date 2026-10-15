using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

/// <summary>
/// Кредитный счет с установленным лимитом ухода в минус.
/// </summary>
public class CreditAccount : Account
{
    /// <summary>
    /// Приватное поле класса — комиссия за овердрафт.
    /// </summary>
    private decimal _overdraftFeeRate;

    /// <summary>
    /// Максимальный лимит кредитных средств (Автосвойство).
    /// </summary>
    public decimal CreditLimit { get; set; }

    /// <summary>
    /// Вычисляемое свойство: доступный остаток средств (get-only, без backing-поля).
    /// </summary>
    public decimal AvailableCredit => Balance + CreditLimit;

    /// <summary>
    /// Конструктор кредитного счета.
    /// </summary>
    public CreditAccount(string number, string owner, decimal balance, decimal creditLimit)
        : base(number, owner, balance)
    {
        Type = AccountType.Credit;
        CreditLimit = creditLimit;
        _overdraftFeeRate = 0.015m; // 1.5% комиссия
    }

    /// <summary>
    /// Метод снятия средств для кредитного счета (вызывается напрямую, не через интерфейс).
    /// </summary>
    public void Withdraw(decimal amount)
    {
        if (AvailableCredit >= amount)
        {
            Balance -= amount;
            Console.WriteLine($"Счет {Number}: списание кредитных средств на сумму {amount}.");
        }
        else
        {
            Console.WriteLine($"Счет {Number}: превышен кредитный лимит. Операция отклонена.");
        }
    }

    /// <summary>
    /// Реализация абстрактного метода вывода информации.
    /// </summary>
    public override void DisplayInfo()
    {
        Console.WriteLine($"Информация о кредитном счете: {Number}");
    }

    /// <summary>
    /// Переопределенный метод ToString, использующий специфичные поля класса.
    /// </summary>
    public override string ToString()
    {
        return $"[CreditAccount] {base.ToString()}, limit: {CreditLimit}\nvip: {IsVip}";
    }
}
