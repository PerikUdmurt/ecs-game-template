using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Extensions
{
    public static class ArrayExtensions
    {
        public static T GetRandomItem<T>(this T[] _array)
        {
            if (_array == null)
                throw new System.IndexOutOfRangeException(
                    " [ array is null ] Cannot select a random item from null"
                );
            if (_array.Length == 0)
                throw new System.IndexOutOfRangeException(
                    " [ array is empty ] Cannot select a random item from an empty array"
                );
            return _array[Random.Range(0, _array.Length)];
        }

        public static List<T> GetMultipleRandomItems<T>(this T[] _array, int _itemCount)
        {
            if (_array == null)
                throw new System.IndexOutOfRangeException(
                    " [ array is null ] Cannot select a random item from null"
                );
            if (_array.Length == 0)
                throw new System.IndexOutOfRangeException(
                    " [ array is empty ] Cannot select a random item from an empty array"
                );
            if (_itemCount > _array.Length)
                throw new System.IndexOutOfRangeException(
                    " Items needed is greater than items available"
                );

            List<T> itemsToReturn = new();
            int maxIteration = 1000;

            while (itemsToReturn.Count < _itemCount)
            {
                maxIteration--;
                if (maxIteration <= 0)
                    throw new System.IndexOutOfRangeException(" Possible infinite loop detected");
                T newItemToAdd = _array.GetRandomItem();
                if (!itemsToReturn.Contains(newItemToAdd))
                    itemsToReturn.Add(newItemToAdd);
            }

            return itemsToReturn;
        }

        public static void ForEach<T>(this T[] array, System.Action<T> Action)
        {
            if (array == null)
                throw new System.ArgumentNullException(nameof(array), "Array cannot be null.");

            for (int i = 0; i < array.Length; i++)
            {
                Action?.Invoke(array[i]);
            }
        }

        public static void ForEach<T>(this T[] array, System.Action<int, T> Action)
        {
            if (array == null)
                throw new System.ArgumentNullException(nameof(array), "Array cannot be null.");

            for (int i = 0; i < array.Length; i++)
            {
                Action?.Invoke(i, array[i]);
            }
        }
    }
}