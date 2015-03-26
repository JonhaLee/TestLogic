using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
/* Log
 * 게임플레이 화면의 전체적인 흐름을 담당하는 매니저
 * 생성자 : 이존하
 * 작업목록 
 * 2015.03.15 - 생성
 * 2015.03.16 - UI등록, 상태 선언
 */
public class GameManager : MonoBehaviour {
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType(typeof(GameManager)) as GameManager;

                if (_instance == null)
                {
                    Debug.LogError("Not Found GameManager");                 
                }
            }
            return _instance;
        }
    }

    

    public GameObject timeCountPrefab;
    public GameObject lb_CountDown;
    public GameObject bt_ReStart, bt_BackHome;
    public UIScaleAnimation ui_Setting;


    private GameObject timeCountObj;
    private TimeCount tc;
    private GameMode mode;
    public CardManager cm;


    public enum GameState {
        idle,
        playing,
        end,
    }
    GameState gameState;

	// Use this for initialization
	void Start () {
        gameState = GameState.idle;
        GameSetting();
	}
	
	// Update is called once per frame
	void Update () {
        if (gameState == GameState.playing)
        {
            lb_CountDown.GetComponent<Text>().text = tc.countTime.ToString();
        }
	}

    void GameSetting()
    {
        bt_ReStart.SetActive(false);
        bt_BackHome.SetActive(false);


        mode = new NormalMode();

        cm.Init();

        DestroyObject(timeCountObj);
        timeCountObj =  GameObject.Instantiate(timeCountPrefab) as GameObject;         
        tc = timeCountObj.GetComponent<TimeCount>();  
        tc.TimeSetting(100.0f, TimeOver);

        gameState = GameState.playing;
    }

    void TimeOver()
    {
        Debug.Log("TimeOver");
        bt_ReStart.SetActive(true);
        bt_BackHome.SetActive(true);
    }
    public void GameClear()
    {
        StaticObject.Instance.Pause();
        bt_ReStart.SetActive(true);
        bt_BackHome.SetActive(true); 
    }
    public void ReStart()
    {
        StaticObject.Instance.Resume();
        GameSetting();
    }
    public void BackHome()
    {
        Application.LoadLevel(Application.loadedLevel - 1);
    }
    public void Setting()
    {
        //pause
        StaticObject.Instance.Pause();
        //ui open
        ui_Setting.open();
    }
    public void Return()
    {
        StaticObject.Instance.Resume();
        ui_Setting.close();
    }

}
