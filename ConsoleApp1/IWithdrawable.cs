using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Интерфейс для счетов с возможностью снятия средств.
/// </summary>
public interface IWithdrawable
{
    /// <summary>
    /// Снимает указанную сумму со счета.
    /// </summary>
    /// <param name="amount">Сумма для снятия.</param>
    void Withdraw(decimal amount);
}
