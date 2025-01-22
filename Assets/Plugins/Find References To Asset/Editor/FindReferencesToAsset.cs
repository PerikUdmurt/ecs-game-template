//------------------------------------
//     Find References To Asset
//     Copyright© 2024 OmniShade     
//------------------------------------

using System.Diagnostics;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

/**
 * Editor tool to search for all references to an asset.
 **/
namespace FindReferencesToAsset {

    public class FindReferencesToAsset : EditorWindow {
        const string ToolName = "Find References To Asset";
        const string RipgrepKey = "rgCmd";
        const int MaxSelectable = 10;

        string rgCmd = "rg";
        bool isRgSupported = false;
        bool showResults = false;
        List<string> results = new();
        bool doAutoSearch = true;
        List<Object> objectsToFind = new();
        List<string> assetsInBuild = new();
        Vector2 scrollPos;

        // Static to preserve settings
        static bool excludeResultsNotInBuild = false;

        [MenuItem("Tools/" + ToolName + " %e")]
        public static void ShowWindow() {
            var window = GetWindow<FindReferencesToAsset>(ToolName);
            window.OnShow();
        }

        void OnShow() {           
            Reset();
            CheckIfRgSupported();
            RegisterSelectedObjects();
        }

        void Reset() {
            showResults = false;
            results.Clear();
            doAutoSearch = true;
        }

        void CheckIfRgSupported() {
            if (EditorPrefs.HasKey(RipgrepKey))
                rgCmd = EditorPrefs.GetString(RipgrepKey);
            else {  // Attempt to locate rg
#if UNITY_EDITOR_OSX || UNITY_EDITOR_LINUX
                const string BrewPath = "/opt/homebrew/bin/rg";
                if (File.Exists(BrewPath)) {
                    rgCmd = BrewPath;
                    EditorPrefs.SetString(RipgrepKey, rgCmd);
                }
#endif
            }

            try {  // Attempt to start rg
                Process.Start(rgCmd);
                isRgSupported = true;
            }
            catch {
                isRgSupported = false;
            }
        }

        void RegisterSelectedObjects() {
            objectsToFind.Clear();
            foreach (string guid in Selection.assetGUIDs) {
                string path = AssetDatabase.GUIDToAssetPath(guid);
                if (!string.IsNullOrEmpty(path)) {
                    var obj = AssetDatabase.LoadAssetAtPath<Object>(path);
                    if (obj != null && obj.GetType() != typeof(DefaultAsset)) {
                        objectsToFind.Add(obj);
                        if (objectsToFind.Count >= MaxSelectable)
                            break;
                    }
                }
            }
            // Sort
            if (objectsToFind.Count > 0)
                objectsToFind = objectsToFind.OrderBy(a => a.name).ToList();
            else  // Add null if nothing selected
                objectsToFind.Add(null);
        }

        void OnGUI() {
            EditorGUIUtility.labelWidth = 160;

            // Info
            EditorGUILayout.HelpBox("Search for all references to an asset.", MessageType.Info);
            EditorGUILayout.Separator();

            // Warning notice
            if (!isRgSupported) {
                var warningStyle = new GUIStyle();
                warningStyle.normal.textColor = Color.magenta;                
                EditorGUILayout.TextArea("ripgrep command 'rg' not found, please install it from:\n  https://github.com/BurntSushi/ripgrep", warningStyle);
                EditorGUILayout.Separator();
            }

            // rg path
            string rgPath = EditorPrefs.GetString(RipgrepKey);
            rgPath = EditorGUILayout.TextField(new GUIContent(text: "Full path to 'rg'",
                tooltip: "The full path to ripgrep command 'rg'. You can find this with 'which' on Mac, or 'where' on Windows."), rgPath);
            rgPath = rgPath.Trim();
            if (rgPath != rgCmd) {
                EditorPrefs.SetString(RipgrepKey, rgPath);
                OnShow();
            }
            EditorGUILayout.Separator();

            // Find
            objectsToFind[0] = EditorGUILayout.ObjectField("Find all references to", objectsToFind[0], typeof(Object), false);
            for (int i = 1; i < objectsToFind.Count; i++)
                objectsToFind[i] = EditorGUILayout.ObjectField(" ", objectsToFind[i], typeof(Object), false);
            // - + button
            GUILayout.BeginHorizontal();
            EditorGUILayout.LabelField(" ");
            if (objectsToFind.Count > 1) {
                if (GUILayout.Button("-", GUILayout.Width(20)))
                    objectsToFind.RemoveAt(objectsToFind.Count - 1);
            }
            if (objectsToFind.Count < MaxSelectable) {
                if (GUILayout.Button("+", GUILayout.Width(20)))
                    objectsToFind.Add(null);
            }
            GUILayout.EndHorizontal();

            // Exclude results
            excludeResultsNotInBuild = EditorGUILayout.Toggle(new GUIContent(text: "Exclude results not in build",
                tooltip: "If true, only shows results that are included in the build. Can slow down search results."), excludeResultsNotInBuild);
            EditorGUILayout.Separator();

            // Find all references button
            EditorGUI.BeginDisabledGroup(!IsInputValid());
            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            if (GUILayout.Button("Find all references", GUILayout.Height(30), GUILayout.Width(260)) ||
                ShouldAutoSearch()) {
                FindReferences(false);
            }
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            EditorGUI.EndDisabledGroup();
            EditorGUILayout.Separator();

            if (showResults) {
                if (results.Count > 0) {
                    // Find all references to previous result button
                    GUILayout.BeginHorizontal();
                    GUILayout.FlexibleSpace();
                    if (GUILayout.Button("Find all references to results", GUILayout.Height(30), GUILayout.Width(260)))
                        FindReferences(true);
                    GUILayout.FlexibleSpace();
                    GUILayout.EndHorizontal();
                    EditorGUILayout.Separator();

                    RenderResults();                    
                }
                else
                    EditorGUILayout.LabelField("No references found.", EditorStyles.boldLabel);
            }

            doAutoSearch = false;
        }

        void RenderResults() {
            int assetsLength = "Assets/".Length;
            string referenceStr = results.Count > 1 ? "references" : "reference";
            EditorGUILayout.LabelField(results.Count + " " + referenceStr + " found.", EditorStyles.boldLabel);
            scrollPos = EditorGUILayout.BeginScrollView(scrollPos);
            foreach (string match in results) {
                string shortName = match.Substring(assetsLength);
                if (GUILayout.Button(shortName, EditorStyles.textField)) {
                    var obj = AssetDatabase.LoadAssetAtPath<Object>(match);
                    if (obj != null)
                        EditorGUIUtility.PingObject(obj);
                }
            }
            EditorGUILayout.EndScrollView();
        }

        bool ShouldAutoSearch() {
            return objectsToFind[0] != null && isRgSupported && !showResults && doAutoSearch;
        }
        
        bool IsInputValid() {
            if (!isRgSupported)
                return false;

            foreach (Object obj in objectsToFind) {
                if (obj != null)
                    return true;
            }
            return false;
        }

        void FindReferences(bool useResults) {
            var guids = GetGUIDsObjectsToFind(useResults);
            if (guids.Count == 0)
                return;

            // Execute ripgrep
            EditorUtility.DisplayProgressBar("Finding all references", "Finding references in project...", 0.33f);
            string rgOutput = Ripgrep(guids);

            // Parse output paths to objects
            results.Clear();
            string[] matchedPaths = Regex.Split(rgOutput, "\r\n|\r|\n");
            foreach (string path in matchedPaths) {
                if (!string.IsNullOrEmpty(path) && !path.Contains(".meta")) {
                    string onlyPath = path.Split(":")[0];
                    if (!results.Contains(onlyPath))
                        results.Add(onlyPath);
                }
            }
            
            EditorUtility.DisplayProgressBar("Finding all references", "Excluding results not in build...", 0.66f);
            ExcludeResultsNotInBuild();
            results.Sort();

            EditorUtility.ClearProgressBar();
            showResults = true;            
        }

        List<string> GetGUIDsObjectsToFind(bool useResults) {
            var guids = new List<string>();
            if (useResults) {
                foreach (string path in results) {
                    var guid = AssetDatabase.GUIDFromAssetPath(path);
                    guids.Add(guid.ToString());
                }
            }
            else {  // Use selected objects
                foreach (Object obj in objectsToFind) {
                    if (obj != null) {
                        string guid = ObjectToGUID(obj);
                        if (!string.IsNullOrEmpty(guid))
                            guids.Add(guid);
                    }
                }
            }
            return guids;
        }

        void ExcludeResultsNotInBuild() {
            if (excludeResultsNotInBuild && results.Count > 0) {
                FetchAssetsIncludedInBuild();
                results = results.Intersect(assetsInBuild).ToList();
            }
        }

        void FetchAssetsIncludedInBuild() {
            // Cache the result so it's only run once per window load
            if (assetsInBuild.Count > 0)
                return;

            // Get all scenes
            var assetPathInBuild = new List<string>();
            foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes) {
                if (scene != null && !string.IsNullOrEmpty(scene.path) && scene.enabled)
                    assetPathInBuild.Add(scene.path);
            }

            // Get all asset bundle assets
            var assetBundleNames = AssetDatabase.GetAllAssetBundleNames();
            foreach (string assetBundleName in assetBundleNames) {
                var assetBundlePaths = AssetDatabase.GetAssetPathsFromAssetBundle(assetBundleName);
                foreach (string path in assetBundlePaths)
                    assetPathInBuild.Add(path);
            }

            // Get all assets in resources
            var resourceDirs = Directory.GetDirectories("Assets", "Resources", SearchOption.AllDirectories);
            foreach (string dir in resourceDirs) {
                var files = Directory.GetFiles(dir, "*.*", SearchOption.AllDirectories);
                foreach (string file in files) {
                    if (!file.EndsWith(".meta"))
                        assetPathInBuild.Add(file);
                }
            }

            // Get all dependencies on asset paths
            var scenePathsUnique = assetPathInBuild.Distinct().ToArray();
            assetsInBuild = AssetDatabase.GetDependencies(scenePathsUnique).ToList();
        }

        string ObjectToGUID(Object obj) {
            string assetPath = AssetDatabase.GetAssetPath(obj);
            if (string.IsNullOrEmpty(assetPath))
                return null;
            return AssetDatabase.AssetPathToGUID(assetPath);
        }

        string Ripgrep(List<string> search) {
            const string SearchFolder = "Assets";
            string searchPattern = string.Join<string>("|", search);
            var p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.FileName = rgCmd;
            string arguments = "\"" + searchPattern + "\" " + SearchFolder;
            p.StartInfo.Arguments = arguments;
            try {
                p.Start();
                string output = p.StandardOutput.ReadToEnd();
                p.WaitForExit();
                return output;
            }
            catch {
                isRgSupported = false;
                UnityEngine.Debug.LogError("Error executing 'rg', check it has permission to execute.");
                return string.Empty;
            }
        }
    }
}
