using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    public Vector3 yarnPos;
    public GameObject resetYarn;
    public Rigidbody yarnRB;


    public Vector3 playerPos;
    public GameObject resetPlayer;
    public Rigidbody playerRB;

    
    
    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "Yarn")
        {
           Debug.Log("hit");
            resetYarn.GetComponent<Rigidbody>().velocity = Vector3.zero;
            resetYarn.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            resetYarn.transform.position = yarnPos;
        }

        if (col.gameObject.tag == "Player")
        {
            Debug.Log("hit");
            resetPlayer.GetComponent<Rigidbody>().velocity = Vector3.zero;
            resetPlayer.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            resetPlayer.transform.position = playerPos;
        }
    }
    void Start()
    {
        yarnPos = resetYarn.transform.position;
        playerPos = resetPlayer.transform.position;
    }

   
}