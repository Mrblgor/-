using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Абстрактный базовый класс для банковского счета.
/// </summary>
public abstract class Account
{
    /// <summary>
    /// Внутренний номер счета (Приватное поле для инкапсуляции).
    /// </summary>
    private string _number;

    /// <summary>
    /// Владелец счета (Автосвойство).
    /// </summary>
    public string Owner { get; set; }

    /// <summary>
    /// Текущий баланс счета (Автосвойство).
    /// </summary>
    public decimal Balance { get; set; }

    /// <summary>
    /// Тип счета. Значение по умолчанию — Debit (Автосвойство с инициализатором).
    /// </summary>
    public AccountType Type { get; set; } = AccountType.Debit;

    /// <summary>
    /// Вычисляемое свойство: является ли клиент VIP (get-only, без backing-поля).
    /// </summary>
    public bool IsVip => Balance > 1000000;

    /// <summary>
    /// Конструктор, принимающий только владельца (Перегрузка конструкторов через this).
    /// </summary>
    public Account(string owner) : this("N/A", owner, 0)
    {
    }

    /// <summary>
    /// Основной конструктор со всеми параметрами.
    /// </summary>
    public Account(string number, string owner, decimal balance)
    {
        _number = number;
        Owner = owner;
        Balance = balance;
    }

    /// <summary>
    /// Защищенное свойство для безопасного доступа наследников к приватному номеру счета.
    /// </summary>
    protected string Number => _number;

    /// <summary>
    /// Абстрактный метод для отображения детальной информации о счете.
    /// </summary>
    public abstract void DisplayInfo();

    /// <summary>
    /// Переопределенный метод ToString для вывода базовой информации.
    /// </summary>
    public override string ToString()
    {
        return $"{_number}, {Owner}, {Balance}, type: {Type}";
    }
}
