using System;

public class Order<T> : ICloneable, IComparable<Order<T>>
{
    public T PayerAccount { get; set; } // ��������� ���� �����������
    public T ReceiverAccount { get; set; } // ��������� ���� ����������
    public decimal AmountInRubles { get; set; } // ������������� ����� � ������

    public Order(T payerAccount, T receiverAccount, decimal amountInRubles)
    {
        PayerAccount = payerAccount;
        ReceiverAccount = receiverAccount;
        AmountInRubles = amountInRubles;
    }

    // ���������� ���������� ICloneable
    public object Clone()
    {
        return new Order<T>(PayerAccount, ReceiverAccount, AmountInRubles);
    }

    // ���������� ���������� IComparable<Order<T>>
    public int CompareTo(Order<T> other)
    {
        // ���������� �� ���������� ����� ����������� (��� ����������)
        if (other == null) return 1;
        if (other.PayerAccount == null && PayerAccount == null) return 0;
        if (PayerAccount == null) return -1;
        if (other.PayerAccount == null) return 1;
        return PayerAccount.ToString().CompareTo(other.PayerAccount.ToString());
    }
}
