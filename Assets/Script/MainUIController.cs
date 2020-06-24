using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XLua;

[Hotfix]
public class MainUIController : MonoBehaviour {

    public bool hasboder = true;
    public int score = 0;
    public int length = 0;
    public Text scoreText;
    public Text lengthText;
    public Text msgText;
    public Image bgimage;
    public Image pausebutton;
    public Sprite[] pause;
    private Color tempColor;
    public bool isPause = false;


    private static MainUIController _instance;
    public static MainUIController Instance
    {
        get
        {
            return _instance;
        }
    }
    private void Start()
    {
        if (PlayerPrefs.GetInt("boder", 1) == 0)
        {
            hasboder = false;
            foreach (Transform t in bgimage.gameObject.transform)
            {
                t.gameObject.GetComponent<Image>().enabled = false;
            }
        }
    }
    private void Awake()
    {
        _instance = this;
    }
    public void Update()
    {
        switch (score / 100)
        {
            case 0:
            case 1:
                break;
            case 2:
                ColorUtility.TryParseHtmlString("#CCEEFFFF", out tempColor);
                bgimage.color = tempColor;
                msgText.text = "阶段" + 2;
                break;
            case 3:
            case 4:
                ColorUtility.TryParseHtmlString("#CCFFDBFF", out tempColor);
                bgimage.color = tempColor;
                msgText.text = "阶段" + 3;
                break;
            case 5:
            case 6:
                ColorUtility.TryParseHtmlString("#EBFFCCFF", out tempColor);
                bgimage.color = tempColor;
                msgText.text = "阶段" + 4;
                break;
            case 7:
            case 8:
                ColorUtility.TryParseHtmlString("#FFF3CCFF", out tempColor);
                bgimage.color = tempColor;
                msgText.text = "阶段" + 5;
                break;
            default:
                ColorUtility.TryParseHtmlString("#FFDACCFF", out tempColor);
                bgimage.color = tempColor;
                msgText.text = "无尽模式";
                break;
        }
    }
    public void UpdateUI(int s = 5,int l = 1)
    {
        score = score + s;
        length = length + l;
        scoreText.text = "得分:\n" + score;
        lengthText.text = "长度:\n" + length;
    }

    public void Pause()
    {
     
        isPause = !isPause;
        if (isPause)
        {
            Time.timeScale = 0;
            pausebutton.sprite = pause[0];
        }
        else
        {
            Time.timeScale = 1;
            pausebutton.sprite = pause[1];
        }
    }

    public void Home()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }



}
