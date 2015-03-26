using UnityEngine;
using System.Collections;

/* Log
 * 카운트 다운 타이머 기능을 담당하는 스크립트
 * 생성자 : 이존하
 * 작업목록 
 * 2015.03.15 - 생성, start, stop함수 기본 구성  
 * 2015.03.16 - CountDown 코루틴 완성, 콜백함수 완성
 * 2015.03.17 - IPauseNResume 상속 구현.
 */
public class TimeCount :MonoBehaviour, IPauseNResume {
    public delegate void onCompleteDele();
    private onCompleteDele callBack;
    public float countTime { get; private set; }

    void Awake() {
        RegisterPauseManager();
    }
    public void TimeSetting(float time, onCompleteDele _callBack) {
        countTime = time;
        callBack = _callBack;
        if (countTime > 0.0f) {
            CountStart();
        }
        else Debug.LogError("countTime is downer than 0");

    }
    void CountStart() {
        Debug.Log("dddd");
        StartCoroutine("CountDown");
    }
    void CountStop() {
        StopAllCoroutines();
    }   
    IEnumerator CountDown() {
        //enter       
        yield return null;

        //excute
        do
        {
            //Debug.Log(countTime);
            yield return null;
            countTime -= Time.deltaTime;
        } while (countTime > 0.0f);
        countTime = 0.0f;
        callBack();      

        //end
        yield return null;       
        Destroy(gameObject);
    }
    void OnDestroy() {
        UnRegisterPauseManager();
    }

    bool isPause;
    public void Pause()  {
        CountStop();           
    }
    public void Resume() {
        CountStart();        
    }
    public void RegisterPauseManager() {
        StaticObject.Instance.RegisterPauseManager(this);
    }
    public void UnRegisterPauseManager()
    {
        StaticObject.Instance.UnRegisterPauseManager(this);
    }
}
