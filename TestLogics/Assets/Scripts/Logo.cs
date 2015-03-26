using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Logo : MonoBehaviour {
    public Image logo;
	// Use this for initialization
	void Start () {
        logo.CrossFadeAlpha(0.0f, 0.0f, false);
        logo.CrossFadeAlpha(1.0f, 3.0f, false);

        Invoke("NextScene", 5.0f);
	}

    void NextScene()
    {
        Application.LoadLevel(Application.loadedLevel + 1);
    }
	
}
