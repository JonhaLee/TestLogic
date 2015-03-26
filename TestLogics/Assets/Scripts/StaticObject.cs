using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StaticObject : MonoBehaviour {   
    private static StaticObject _instance;
    public static StaticObject Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType(typeof(StaticObject)) as StaticObject;

                if (_instance == null)
                {
                    Debug.LogError("Not Found StaticObject");
                }
            }
            return _instance;
        }
    }

    private List<IPauseNResume> pauseManager = new List<IPauseNResume>();
    private int pauseCount;

	// Use this for initialization
	void Start () {
        pauseCount = 0;
        DontDestroyOnLoad(gameObject);
	}

    void OnApplicationFocus(bool focus)
    {
        if (focus == false)
        {
            //background로 돌아감          
            Pause();
        }
        else
        {
            //다시 app으로 돌아옴           
            Resume();
        }
    }

    public void Pause()
    {
        pauseCount++;
        foreach (IPauseNResume IPR in pauseManager)
            IPR.Pause();
    }
    public void Resume()
    {
        pauseCount--;

        if (pauseCount <= 0)
        {
            pauseCount = 0;
            foreach (IPauseNResume IPR in pauseManager)
                IPR.Resume();
        }
    }
    public void RegisterPauseManager(IPauseNResume IPR)
    {
        pauseManager.Add(IPR);
    }
    public void UnRegisterPauseManager(IPauseNResume IPR)
    {
        pauseManager.Remove(IPR);
    }
}
