#if UNITY_EDITOR
using Code.Common.Extensions;
using UnityEditor;
using UnityEngine;

namespace Code.Editor.Tools.Progress
{
    public class ProgressTools : UnityEditor.Editor
    {
        [MenuItem("Tools/ClearProgressData")]
        public static void ClearProgressData()
        {
            System.IO.DirectoryInfo directory = new System.IO.DirectoryInfo(Application.persistentDataPath);
            directory.Empty();
            Debug.Log($"[PROGRESS_TOOLS]: Cleared all progress data from {Application.persistentDataPath}]");
        }
    }
}
#endif