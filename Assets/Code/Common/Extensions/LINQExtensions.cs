using System;
using System.Collections.Generic;
using System.Linq;

public static class LINQExtensions
{
    public static T FindMax<T, TResult>(this IEnumerable<T> collection, Func<T, TResult> func) =>
        collection.OrderByDescending(c => func(c)).First();
}