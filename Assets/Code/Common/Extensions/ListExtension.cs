using System.Collections.Generic;
using UnityEngine;

namespace Extensions
{
    public static class ListExtension
    {
        public static T GetRandomItem<T>(this IList<T> list)
        {
            if (list == null)
                throw new System.IndexOutOfRangeException(
                    " [ list is null ] Cannot select a random item from null"
                );
            if (list.Count == 0)
                throw new System.IndexOutOfRangeException(
                    " [ list is empty ] Cannot select a random item from an empty list"
                );
            return list[Random.Range(0, list.Count)];
        }

        public static void RemoveLastItem<T>(this IList<T> source, int n = 1)
        {
            for (int i = 0; i < n; i++)
            {
                source.RemoveAt(source.Count - 1);
            }
        }

        public static void RemoveNulls<T>(this List<T> list)
            where T : class
        {
            list.RemoveAll(item => item == null);
        }

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = Random.Range(0, n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public static T GetItemAndRemove<T>(this IList<T> list, int index)
        {
            T item = list[index];
            list.RemoveAt(index);
            return item;
        }

        public static T GetRandomItemAndRemove<T>(this IList<T> list)
        {
            if (list.Count == 0)
                return default;
            int index = Random.Range(0, list.Count);
            return list.GetItemAndRemove(index);
        }

        public static bool IsNullOrEmpty<T>(this IList<T> list)
        {
            return list == null || list.Count == 0;
        }

        public static List<T> GetRandomItems<T>(this IList<T> list, int count)
        {
            if (count > list.Count)
                throw new System.ArgumentException("Requested count is larger than list size");

            List<T> result = new List<T>();
            List<T> tempList = new List<T>(list);
            for (int i = 0; i < count; i++)
            {
                int index = Random.Range(0, tempList.Count);
                result.Add(tempList[index]);
                tempList.RemoveAt(index);
            }
            return result;
        }
    }
}
