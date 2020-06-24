using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XLua;

[Hotfix]
public class SnakeMove : MonoBehaviour {
    private float velocity = 0.35f;
    public float step;
    public GameObject SnakeHead;
    private Vector3 SnakeHead_pos;
    private float x;
    private float y;
    public Sprite[] SnakeSkin =new  Sprite[2];
    public GameObject SnakeBodyPrefab;
    private List<Transform> SnakeBodys = new List<Transform>();
    public Transform Snake;
    public GameObject ExpFbx;
    private bool isdie = false;


    private void Awake()
    {
        gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>(PlayerPrefs.GetString("sh", "sh02"));
        SnakeSkin[0] = Resources.Load<Sprite>(PlayerPrefs.GetString("sb01", "sb0201"));
        SnakeSkin[1] = Resources.Load<Sprite>(PlayerPrefs.GetString("sb02", "sb0202"));
    }
    void Start () {
        InvokeRepeating("Move", 0, velocity);
        x = 0; y = step;
	}
	
	
	void Update () {
        KeyController();
    }  

    [LuaCallCSharp]
    void KeyController()
    {

        //if (Input.GetKeyDown(KeyCode.Space) && MainUIController.Instance.isPause == false && isdie == false)
        //{
        //    CancelInvoke();
        //    InvokeRepeating("Move", 0, velocity - 0.2f);
        //}

        //if (Input.GetKeyUp(KeyCode.Space) && MainUIController.Instance.isPause == false && isdie == false)
        //{
        //    CancelInvoke();
        //    InvokeRepeating("Move", 0, velocity);
        //}

        //if (Input.GetKey(KeyCode.W) && y != -step && MainUIController.Instance.isPause == false && isdie == false)
        //{
        //    SnakeHead.transform.localRotation = Quaternion.Euler(0, 0, 0);
        //    x = 0;
        //    y = step;
        //}

        //if (Input.GetKey(KeyCode.S) && y != step && MainUIController.Instance.isPause == false && isdie == false)
        //{
        //    SnakeHead.transform.localRotation = Quaternion.Euler(0, 0, 180);
        //    x = 0;
        //    y = -step;
        //}

        //if (Input.GetKey(KeyCode.A) && x != step && MainUIController.Instance.isPause == false && isdie == false)
        //{
        //    SnakeHead.transform.localRotation = Quaternion.Euler(0, 0, 90);
        //    x = -step;
        //    y = 0;
        //}

        //if (Input.GetKey(KeyCode.D) && x != -step && MainUIController.Instance.isPause == false && isdie == false)
        //{
        //    SnakeHead.transform.localRotation = Quaternion.Euler(0, 0, -90);
        //    x = step;
        //    y = 0;
        //}
    }

    [LuaCallCSharp]
    void Move()
    {
        //SnakeHead_pos = SnakeHead.transform.localPosition;
        //SnakeHead.transform.localPosition = new Vector3(SnakeHead_pos.x + x, SnakeHead_pos.y + y, SnakeHead_pos.z);
        //if (SnakeBodys.Count > 0)
        //{
        //    for (int i = SnakeBodys.Count - 2; i >= 0; i--)
        //    {
        //        SnakeBodys[i + 1].localPosition = SnakeBodys[i].localPosition;
        //    }
        //    SnakeBodys[0].localPosition = SnakeHead_pos;
        //}
    }  

    [LuaCallCSharp]
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.tag == "Food")
        //{     
        //    grow();
        //    FoodMaker.Instance.MakeFood(Random.Range(1, 100) <20? true:false);
        //    Destroy(collision.gameObject);
        //    MainUIController.Instance.UpdateUI();
        //}

        //if (collision.tag == "Reward")
        //{
        //    grow();
        //    Destroy(collision.gameObject);
        //    MainUIController.Instance.UpdateUI(Random.Range(1,15)*10,1);
        //}
        //if (collision.tag == "Wall" && MainUIController.Instance.hasboder == false)
        //{
        //    if (collision.gameObject.name == "Up")
        //    {

        //        SnakeHead.transform.localPosition = new Vector3(SnakeHead.transform.localPosition.x, -SnakeHead.transform.localPosition.y + 30, SnakeHead.transform.localPosition.z);
        //    }
        //    if (collision.gameObject.name == "Down")
        //    {
        //        SnakeHead.transform.localPosition = new Vector3(SnakeHead.transform.localPosition.x, -SnakeHead.transform.localPosition.y - 40, SnakeHead.transform.localPosition.z);
        //    }
        //    if (collision.gameObject.name == "Left")
        //    {
        //        SnakeHead.transform.localPosition = new Vector3(-SnakeHead.transform.localPosition.x - 30, SnakeHead.transform.localPosition.y, SnakeHead.transform.localPosition.z);
        //    }
        //    if (collision.gameObject.name == "Right")
        //    {
        //        SnakeHead.transform.localPosition = new Vector3(-SnakeHead.transform.localPosition.x + 30, SnakeHead.transform.localPosition.y, SnakeHead.transform.localPosition.z);
        //    }
        //}
        //else if(collision.tag == "Wall")
        //{
        //    Die();
        //}
        //if (collision.tag == "SnakeBody")
        //{
        //    Die();
        //}

    }  //检测碰撞到的物体

    [LuaCallCSharp]
    void Grow()
    {
        int index = (SnakeBodys.Count % 2 == 0) ? 0 : 1;
        GameObject Snakebody = Instantiate(SnakeBodyPrefab,new Vector3(2000, 2000, 0), Quaternion.identity);
        Snakebody.GetComponent<Image>().sprite = SnakeSkin[index];
        Snakebody.transform.SetParent(Snake, false);
        SnakeBodys.Add(Snakebody.transform);
       
    }  //吃食物增长蛇身

    [LuaCallCSharp]
    void Die()
    {
        isdie = true;
        CancelInvoke();
        Instantiate(ExpFbx);
        PlayerPrefs.SetInt("lastl", MainUIController.Instance.length);
        PlayerPrefs.SetInt("lasts", MainUIController.Instance.score);
        if (PlayerPrefs.GetInt("bestl", 0) < MainUIController.Instance.length)
        {
            PlayerPrefs.SetInt("bestl", MainUIController.Instance.length);
        }
        if (PlayerPrefs.GetInt("bests", 0) < MainUIController.Instance.score)
        {
            PlayerPrefs.SetInt("bests", MainUIController.Instance.score);
        }

        StartCoroutine(GameOver());
    }

    public IEnumerator GameOver()
    {
        yield return new WaitForSeconds(2);
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);                                         //重载本场景
    }
}
