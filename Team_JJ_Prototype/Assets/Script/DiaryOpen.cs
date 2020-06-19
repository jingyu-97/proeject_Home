using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiaryOpen : MonoBehaviour
{
    public Image DiaryContent01;
    public Image DiaryContent02;   
    public FishBreadFirst fishBreadFirst;
    public ScarfFirst scarfFirst;
    public bool mNQMove = false;    

    public bool fishScarf = false;    

    void Start()
    {
        DiaryContent01.GetComponent<Image>().enabled = false;
        DiaryContent02.GetComponent<Image>().enabled = false;

    }
    void Update()
    {
        DiaryCheck();
    }
    void DiaryCheck()
    {
        Vector3 mouseDownPos;
        Ray ray;
        RaycastHit hit;
        mouseDownPos = Input.mousePosition;
        ray = Camera.main.ScreenPointToRay(mouseDownPos);
        GameObject DiaryCon01 = GameObject.FindWithTag("Diary");
        ObjectCheck objectCheck = GameObject.Find("Player").GetComponent<ObjectCheck>();

        if (objectCheck.diaryMax01 == false) //MNQ를 한 번이라도 눌렀는가? Diary를 켜기 위한 조건
        {
            if (Input.GetMouseButtonDown(0)) //Diary 켜는 방법
            {
                if (Physics.Raycast(ray, out hit, 1f) && hit.collider.tag == "Diary")        //Ray의 충돌이 있다고 충돌된 콜라이더의 태그가 Diary 라면
                {
                    
                    DiaryContent01.GetComponent<Image>().enabled = true; //UI 온
                    fishScarf = true;                       // 붕어빵, 목도리하고 상호작용 가능하게 한다.
                    Debug.Log("Diary Open");
                }                
            }
            //FishScarf 이후
            if (fishBreadFirst.mMNQFish == true && scarfFirst.mNQScarf == true) //마네킹을 이동시킬 수 있는 조건 달성으로 DiaryContent02보여주기.
            {               
                if (Input.GetMouseButtonDown(0)) //Diary 켜는 방법
                {
                    if (Physics.Raycast(ray, out hit, 1f) && hit.collider.tag == "Diary")        //Ray의 충돌이 있다고 충돌된 콜라이더의 태그가 Diary 라면
                    {
                       
                        DiaryContent01.GetComponent<Image>().enabled = false;
                        DiaryContent02.GetComponent<Image>().enabled = true; //UI 온
                        mNQMove = true; //마네킹 움직이는 조건 달성
                        Debug.Log("Diary02 Open");
                    }
                }
            }
            if (Input.GetMouseButtonDown(1)) //Diary를 닫는 방법
            {
                DiaryContent01.GetComponent<Image>().enabled = false; //UI 오프
                DiaryContent02.GetComponent<Image>().enabled = false;
                
                Debug.Log("Diary Close");
            }            
        }
    }
}

            
    

