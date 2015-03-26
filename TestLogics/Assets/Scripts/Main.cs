using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Main : MonoBehaviour, IPauseNResume {
    bool isPause;
    void Start()
    {
        RegisterPauseManager();
    }
    void Update()
    {
        if(isPause == false)
            if (Input.GetMouseButtonDown(0)) NextScene();        
    }
    void OnDestroy()
    {
        UnRegisterPauseManager();
    }
    bool isLoad = false;
    void NextScene()
    {
        if (!isLoad) {
            isLoad = true;
            Application.LoadLevel(Application.loadedLevel + 1);
        }
    }


    public void Pause()
    {    
        isPause = true;
    }

    public void Resume()
    {
        isPause = false;
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
