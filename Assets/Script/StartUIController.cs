using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XLua;

[Hotfix]
public class StartUIController : MonoBehaviour {

    public Text last;
    public Text best;
    public Toggle skinBlue;
    public Toggle skinYello;
    public Toggle modeOne;
    public Toggle modeTwo;

    // Use this for initialization
    public void Start()
    {
        if (PlayerPrefs.GetString("sh", "sh01") == "sh01")
        {
            skinBlue.isOn = true;
        }
        else
        {
            skinYello.isOn = true;
        }

        if (PlayerPrefs.GetInt("boder", 1) == 1)
        {
            modeOne.isOn = true;
        }
        else
        {
            modeTwo.isOn = true;
        }
    }

    [LuaCallCSharp]
    public void Blue(bool ison)
    {
        //if (ison == true)
        //{
        //    PlayerPrefs.SetString("sh","sh01");
        //    PlayerPrefs.SetString("sb01", "sb0101");
        //    PlayerPrefs.SetString("sb02", "sb0102");
        //}
    }

    [LuaCallCSharp]
    public void Yellow(bool ison)
    {
        //if (ison == true)
        //{
        //    PlayerPrefs.SetString("sh", "sh02");
        //    PlayerPrefs.SetString("sb01", "sb0201");
        //    PlayerPrefs.SetString("sb02", "sb0202");  
        //}
    }

    [LuaCallCSharp]
    public void HaveBoder(bool ison)
    {
        //if (ison == true)
        //{
        //    PlayerPrefs.SetInt("boder", 1);
        //}
    }

    [LuaCallCSharp]
    public void NoHaveBoder(bool ison)
    {
        //if (ison == true)
        //{
        //    PlayerPrefs.SetInt("boder", 0);
        //}
    }


    private void Awake()
    {
        last.text = "上次：长度" + PlayerPrefs.GetInt("lastl", 0) + "，分数" + PlayerPrefs.GetInt("lasts", 0);
        best.text = "最好：长度" + PlayerPrefs.GetInt("bestl", 0) + "，分数" + PlayerPrefs.GetInt("bests", 0);
    }

    [LuaCallCSharp]
    public void GameStart()
    {
        //UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
