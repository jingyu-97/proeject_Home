using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MNQMoveControl : MonoBehaviour
{
    GameObject player;
    GameObject playerEquipPoint;
    Player_MoveCtrl moveCtrl;
    DiaryOpen diaryOpen;

    Vector3 forceDirection;
    bool isPlayerEnter;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerEquipPoint = GameObject.FindGameObjectWithTag("EquipPoint");
        moveCtrl = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_MoveCtrl>();
        diaryOpen = GameObject.FindGameObjectWithTag("Diary").GetComponent<DiaryOpen>();
    }

    void Update() 
    {
        if(diaryOpen.mNQMove == true && Input.GetMouseButtonDown(0) && isPlayerEnter)
        {
            transform.SetParent(playerEquipPoint.transform);
            transform.localPosition = Vector3.zero;
            transform.rotation = new Quaternion(0, 0, 0, 0);

            moveCtrl.PickUp(gameObject);
            isPlayerEnter = false;
        }        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
        {
            isPlayerEnter = true;
        }
    }
    /*void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            isPlayerEnter = true;
        }
    }*/

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject == player)
        {
            isPlayerEnter = false;
        }
    }

    /*void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            isPlayerEnter = false;
        }
    }*/
}
