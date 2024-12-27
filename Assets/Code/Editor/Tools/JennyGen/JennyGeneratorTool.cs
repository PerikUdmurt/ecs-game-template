#if UNITY_EDITOR
using System.Diagnostics;
using System.Drawing;
using UnityEditor;

public class JennyGeneratorTool : Editor
{
    [MenuItem("Tools/GenerateCode")]
    public static void GenerateCode()
    {
        Process proccess = Process.Start("Jenny-Gen.bat" ,"C:/Users/perev/card-fusion-template/Jenny");
        proccess.WaitForExit();
    }
}
#endif