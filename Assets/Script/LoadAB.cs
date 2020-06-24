using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadAB : MonoBehaviour
{
    public static Dictionary<string, Sprite> snakeBody = new Dictionary<string, Sprite>();

    public static Dictionary<string, Sprite> snakeHead = new Dictionary<string, Sprite>();

    public static Dictionary<string, GameObject> fbx = new Dictionary<string, GameObject>();

    public Image a;

    string path = @"E:\Unity_Project\Snake\AssetBundles\";

    // Start is called before the first frame update
    void Start()
    {
        AssetBundle ab = AssetBundle.LoadFromFile(path + "AssetBundles");
         string[] a = ab.GetAllAssetNames();
        foreach (var b in a)
        {
            Debug.Log(b);
        }
    }

    public Sprite LoadABObject(string name)
    {
        AssetBundle ab = AssetBundle.LoadFromFile(path + name + ".unity3d");

        return ab.LoadAsset<Sprite>(name + ".png");
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            a.sprite = LoadABObject("sh01");
        }
    }
}
