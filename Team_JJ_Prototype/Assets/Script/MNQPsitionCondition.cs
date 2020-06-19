using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MNQPsitionCondition : MonoBehaviour
{
    public bool isMNQ1 = false;
    GameObject mNQ;
    GameObject door;

    void Awake()
    {
        mNQ = GameObject.FindGameObjectWithTag("MNQ");
        door = GameObject.FindGameObjectWithTag("Door");
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == mNQ)
        {
            door.SetActive(false);
            isMNQ1 = true;            
        }
    }
}
