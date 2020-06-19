using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCheck : MonoBehaviour
{
    public float m_RayDistance =0f;
    public bool diaryMax01=true;

    void Update()
    {
        ObjectCheckByRay();
    }
    private void ObjectCheckByRay()
    {
        Vector3 mouseDownPos;
        RaycastHit hit;
        Ray ray;
        mouseDownPos = Input.mousePosition;
        ray = Camera.main.ScreenPointToRay(mouseDownPos);
        Debug.DrawRay(ray.origin, ray.direction * 50, Color.red);
        if (Input.GetMouseButtonDown(0))
        { 
            if (diaryMax01)
            {
                if (Physics.Raycast(ray, out hit, m_RayDistance, 1 << LayerMask.NameToLayer("MNQ")))
                {
                    Diary01();
                    diaryMax01 = false;
                    Debug.Log("DiaryContent Can Open & Close");
                }               
            }
            
        }
    }
    private void Diary01()
    {        
        GameObject diary = GameObject.FindWithTag("Diary");
        diary.transform.Translate(new Vector3(-1f, -0.2f, -0.3f));
        diary.transform.Rotate(0, 0, 90);
    }
}
