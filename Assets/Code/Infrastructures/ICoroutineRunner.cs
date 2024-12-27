using System.Collections;
using UnityEngine;

namespace Code.Infrastructures
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator routine);
    }
}
