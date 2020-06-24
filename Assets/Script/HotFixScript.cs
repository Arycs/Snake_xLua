using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using XLua;

public class HotFixScript : MonoBehaviour
{
    private LuaEnv luaEnv;
    /// <summary>
    /// 存储AB包加载出来的预制体
    /// </summary>
    public static Dictionary<string, GameObject> prefabDict = new Dictionary<string, GameObject>();

    private void Awake()
    {
        luaEnv = new LuaEnv();
        luaEnv.AddLoader(MyLoader);
        DontDestroyOnLoad(this);

        luaEnv.DoString("require 'snake'");
        //Debug.Log(Application.dataPath);
    }

    private byte[] MyLoader(ref string filePath)
    {
        string absPath = Application.dataPath+"/HotFix/" + filePath + ".lua.txt";
        return System.Text.Encoding.UTF8.GetBytes(File.ReadAllText(absPath));
    }

    private void OnDisable()
    {
        luaEnv.DoString("require 'snakeDispose'");
    }

    private void OnDestroy()
    {
        luaEnv.Dispose();
    }

    static string path = @"E:\Unity_Project\Snake\AssetBundles\";
    /// <summary>
    /// 调用AB包相关
    /// </summary>
    [LuaCallCSharp]
    public static Sprite LoadResourceSprite(string resName, string filePath)
    {
        AssetBundle ab = AssetBundle.LoadFromFile(path + filePath);
        return ab.LoadAsset<Sprite>(resName);
    }


    [LuaCallCSharp]
    public static GameObject GetGameObject(string goName)
    {
        return prefabDict[goName];
    }

}
