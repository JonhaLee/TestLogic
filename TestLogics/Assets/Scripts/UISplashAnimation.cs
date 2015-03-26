using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UISplashAnimation : MonoBehaviour, IPauseNResume {
    //public float frequency; //빈도
    public bool isCanPause;
    public float OnceCycleSpeed;
    private Graphic graphic;

	// Use this for initialization
	void Start () {
        graphic = GetComponent<Graphic>();
        if (isCanPause) RegisterPauseManager();
        Init();
        
        
	}	

    void Unvisible() {
        graphic.CrossFadeAlpha(0.0f, OnceCycleSpeed / 2.0f, false);
    }

    void Visible() {
        graphic.CrossFadeAlpha(1.0f, OnceCycleSpeed / 2.0f, false);
    }
    void Init()
    {
        InvokeRepeating("Unvisible", 0.0f, OnceCycleSpeed);
        InvokeRepeating("Visible", OnceCycleSpeed / 2.0f, OnceCycleSpeed);
    }
    void OnDestroy()
    {
        if (isCanPause) UnRegisterPauseManager();
    }
    public void Pause()
    {
        Debug.Log("dd");
        CancelInvoke();
    }

    public void Resume()
    {
        Init();
    }

    public void RegisterPauseManager()
    {
        StaticObject.Instance.RegisterPauseManager(this);
    }

    public void UnRegisterPauseManager()
    {
        StaticObject.Instance.UnRegisterPauseManager(this);
    }
}
