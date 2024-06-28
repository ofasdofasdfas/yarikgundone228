using System;

public class Order<T> : ICloneable, IComparable<Order<T>>
{
    public T PayerAccount { get; set; } // Расчетный счет плательщика
    public T ReceiverAccount { get; set; } // Расчетный счет получателя
    public decimal AmountInRubles { get; set; } // Перечисляемая сумма в рублях

    public Order(T payerAccount, T receiverAccount, decimal amountInRubles)
    {
        PayerAccount = payerAccount;
        ReceiverAccount = receiverAccount;
        AmountInRubles = amountInRubles;
    }

    // Реализация интерфейса ICloneable
    public object Clone()
    {
        return new Order<T>(PayerAccount, ReceiverAccount, AmountInRubles);
    }

    // Реализация интерфейса IComparable<Order<T>>
    public int CompareTo(Order<T> other)
    {
        // Сравниваем по расчетному счету плательщика (для сортировки)
        if (other == null) return 1;
        if (other.PayerAccount == null && PayerAccount == null) return 0;
        if (PayerAccount == null) return -1;
        if (other.PayerAccount == null) return 1;
        return PayerAccount.ToString().CompareTo(other.PayerAccount.ToString());
    }
}
