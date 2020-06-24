 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XLua;

[Hotfix]
public class FoodMaker : MonoBehaviour {
    private static FoodMaker instance;
    public static FoodMaker Instance
    {
        get
        {
            return instance;
        }
    }
    public List<Sprite> FoodSkin;
    public GameObject Foodprefab;
    public GameObject rewardPrefab;
    public Transform foodHolder;
    private float xlmit = 17;
    private float ylmit = 6;
    private float xoffset = 8;

    void Awake()
    {
        instance = this;
        AddFood();
    }
    private void Start()
    {
        MakeFood(false);
    }

    [LuaCallCSharp]
    public void AddFood()
    {
        FoodSkin.Add(HotFixScript.LoadResourceSprite("icecream-03.png", "food3.unity3d"));
    }


    [LuaCallCSharp]
    public void MakeFood(bool isreward)
    {
        //GameObject food = Instantiate (Foodprefab);
        //food.GetComponent<Image>().sprite = FoodSkin[Random.Range(0,10)];
        //food.transform.SetParent(foodHolder, false);
        //float x = Random.Range(-xlmit+xoffset, xlmit);
        //float y = Random.Range(-ylmit, ylmit);
        //food.transform.localPosition = new Vector3(x * 30, y * 30, 0);

        //if (isreward == true)
        //{
        //    GameObject reward = Instantiate(rewardPrefab);
        //    reward.transform.SetParent(foodHolder, false);
        //    x = Random.Range(-xlmit + xoffset, xlmit);
        //    y = Random.Range(-ylmit, ylmit);
        //    reward.transform.localPosition = new Vector3(x * 30, y * 30, 0);
        //}
    }
    
}
