using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    public float speed = 10;
    public bool canHold = true;
    public GameObject prop;
    public Transform guide;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!canHold)
                throw_drop();
            else
                Pickup();
        }

        if (!canHold && prop)
            prop.transform.position = guide.position;

    }//update

    //We can use trigger or Collision
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Prop")
            if (!prop) // if we don't have anything holding
                prop = col.gameObject;
    }

    //We can use trigger or Collision
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Prop")
        {
            if (canHold)
                prop = null;
        }
    }


    private void Pickup()
    {
        if (!prop)
            return;

        //We set the object parent to our guide empty object.
        prop.transform.SetParent(guide);

        //Set gravity to false while holding it
        prop.GetComponent<Rigidbody>().useGravity = false;
        prop.GetComponent<Rigidbody>().freezeRotation = true;
        //we apply the same rotation our main object (Player) has.
        prop.transform.localRotation = transform.rotation;
        //We re-position the prop on our guide object 
        prop.transform.position = guide.position;

        canHold = false;
    }

    private void throw_drop()
    {
        if (!prop)
            return;

        //Set our Gravity to true again.
        prop.GetComponent<Rigidbody>().useGravity = true;
        prop.GetComponent<Rigidbody>().freezeRotation = false;
        // we don't have anything to do with our prop field anymore
        prop = null;
        //Apply velocity on throwing
        guide.GetChild(0).gameObject.GetComponent<Rigidbody>().velocity = transform.forward * speed;

        //Unparent our prop
        guide.GetChild(0).parent = null;
        canHold = true;
    }
}//class

