using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Депозитный сберегательный счет с процентной ставкой.
/// </summary>
public class DepositAccount : Account
{
    /// <summary>
    /// Приватное поле класса — срок вклада в месяцах.
    /// </summary>
    private int _termInMonths;

    /// <summary>
    /// Процентная ставка по депозиту (Автосвойство).
    /// </summary>
    public double InterestRate { get; set; }

    /// <summary>
    /// Вычисляемое свойство: прогнозируемая годовая доходность (get-only, без backing-поля).
    /// </summary>
    public decimal ProjectedAnnualYield => Balance * (decimal)(InterestRate / 100.0);

    /// <summary>
    /// Конструктор депозитного счета.
    /// </summary>
    public DepositAccount(string number, string owner, decimal balance, double interestRate)
        : base(number, owner, balance)
    {
        Type = AccountType.Deposit;
        InterestRate = interestRate;
        _termInMonths = 12; // По умолчанию на 12 месяцев
    }

    /// <summary>
    /// Реализация абстрактного метода вывода информации.
    /// </summary>
    public override void DisplayInfo()
    {
        Console.WriteLine($"Информация о депозитном счете: {Number}");
    }

    /// <summary>
    /// Переопределенный метод ToString, использующий специфичные поля класса.
    /// </summary>
    public override string ToString()
    {
        return $"[DepositAccount] {base.ToString()}\nvip: {IsVip}";
    }
}
