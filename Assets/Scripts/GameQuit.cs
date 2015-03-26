using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameQuit : MonoBehaviour {
    public UIScaleAnimation UI_popup;
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (UI_popup.openNclose() == 0)
            {
                StaticObject.Instance.Resume();
            }
            else
            {
                StaticObject.Instance.Pause();
            }
        }
	
	}

    public void Quit()
    {
        Application.Quit();
    }
    public void Cancle()
    {
        StaticObject.Instance.Resume();
        UI_popup.close();
    }
}
