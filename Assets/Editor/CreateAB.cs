using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;


public class CreateAB : MonoBehaviour
{
    [MenuItem("AssetBundles/Build AssetBundles")]
    static void BuildAssetBundle()
    {
        string dir = "AssetBundles";

        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
        BuildPipeline.BuildAssetBundles(dir, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows64);
    }
}
