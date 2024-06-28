using System;
using System.Collections.Generic;

public class AmountComparer<T> : IComparer<Order<T>>
{
    public int Compare(Order<T> x, Order<T> y)
    {
        if (x == null || y == null)
            throw new ArgumentNullException("One or both orders are null.");

        return x.AmountInRubles.CompareTo(y.AmountInRubles);
    }
}
