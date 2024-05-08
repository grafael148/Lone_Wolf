using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUp : MonoBehaviour
{
    public Transform WeaponPos;

    // distance of the raycast
    public float distance = 5f;

    GameObject currentWeapon;
    GameObject wp;

    public bool canGrab;
  

    // Update is called once per frame
    void Update()
    {
        // runs the raycast
        CheckWeapons();

        if (canGrab)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
               // pickUp();

               
                // checks if there's a weapon currently equipped or held by the player
                if (currentWeapon != null)
                {
                    drop();

                    //pickUp();
                } 
                
                // picks up the weapon
                if (Input.GetKeyDown(KeyCode.E) && canGrab)
                {
                    pickUp();
                }
            }
        }

        if (currentWeapon != null)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                drop();
            }

            
        }
    }

    private void CheckWeapons() // this code checks to see if the player collides with a weapon.
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position,Camera.main.transform.forward,out hit, distance))
        {
            if (hit.transform.tag == "WeaponPickUP")
            {
                Debug.Log("PickUPWeapon");

                // enables the player to grab the weapon.
                canGrab = true;
                wp = hit.transform.gameObject;
            }
        }

        else
            canGrab = false;    
    }

    private void pickUp()
    {
        currentWeapon = wp;
        currentWeapon.transform.position = WeaponPos.position;
        currentWeapon.transform.parent = WeaponPos;
        currentWeapon.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
        currentWeapon.GetComponent<Rigidbody>().isKinematic = true;

        //currentWeapon.GetComponent<_Magnum>().enabled = true;
    }

    private void drop()
    {
        currentWeapon.transform.parent = null;
        currentWeapon.GetComponent<Rigidbody>().isKinematic = false;
        currentWeapon = null;
    }
}
