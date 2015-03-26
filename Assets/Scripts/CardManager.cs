using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

/* Log
 * 화면에 비추어질 카드들을 섞거나, 바꾸거나, 맞추는 확인을 해주는 스크립트
 * 생성자 : 이존하
 * 작업목록 
 * 2015.03.16 - 생성, Init, clickBtn함수 구현
 * 
 */
public class CardManager : MonoBehaviour {
    public List<CardPackage> cardPackageList = new List<CardPackage>();

    public Image preview;
    public List<GameObject> btns = new List<GameObject>();


    private int currentNumber;
    private int totalViewingNumber;
    private int lastNumber;
    private CardObj[] cardobjList, cardobjShuffleList;
 

    void Awake()
    {
        //Init();
    }
  
    public void Init(){
        //select Package
        CardPackage cp = cardPackageList[0];
        //get Count of Card in Package
        lastNumber = cp.transform.childCount + 1;
        //get CardInfo in selected Package
        cardobjList = new CardObj[lastNumber - 1];
        cardobjShuffleList = new CardObj[lastNumber - 1];
        for (int i = 0; i < cardobjList.Length; i++)
        {
            cardobjList[i] = cp.transform.GetChild(i).GetComponent<CardObj>();
            cardobjShuffleList[i] = cp.transform.GetChild(i).GetComponent<CardObj>();
        }

        //gameSetting
        currentNumber = 1;
        totalViewingNumber = 25;
        preview.sprite = cardobjList[0].cardSprite;

        //shuffle
        shuffle();

        //create btns
        int cnt = 0;
        foreach (GameObject obj in btns)
        {

            obj.SetActive(true);
            Destroy(obj.GetComponent<CardObj>());
            CardObj co = StaticMethod.CopyComponent<CardObj>(cardobjShuffleList[cnt++], obj);
            obj.GetComponent<Image>().sprite = co.cardSprite;
			obj.SetActive(true);
        }
    }
    void change(int basis, int changed)
    {
        CardObj tmp = cardobjShuffleList[basis];
        cardobjShuffleList[basis] = cardobjShuffleList[changed];
        cardobjShuffleList[changed] = tmp;
    }
    void shuffle()
    {
        //tmp algolism
        for (int i = 0; i < totalViewingNumber; i++)
        {
            int rand = Random.Range(0, totalViewingNumber);
            change(i, rand);
        }
        for (int i = totalViewingNumber; i < lastNumber - 1; i++)
        {
            int rand = Random.Range(totalViewingNumber, lastNumber - 1);
            change(i, rand);
        }		
    }

    public void clickBtn(GameObject go)
    {
        CardObj co = go.GetComponent<CardObj>();
                
        if(co.number == currentNumber)
        {   
            if (co.number == lastNumber - 1)
            {
                GameManager.Instance.GameClear();
                //Init();
            }

            Destroy(co);
            int range = currentNumber + totalViewingNumber - 1;
            if (range >= lastNumber - 1)
            {
                go.SetActive(false);
            }
            else
            {
                co = StaticMethod.CopyComponent<CardObj>(cardobjList[range], go);
                go.GetComponent<Image>().sprite = co.cardSprite;
                   
            }
            if(currentNumber < lastNumber - 1)
                preview.sprite = cardobjList[++currentNumber - 1].cardSprite;           
        }
    }
}
