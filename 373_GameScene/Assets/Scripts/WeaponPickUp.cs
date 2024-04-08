using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUp : MonoBehaviour
{
    public Transform WeaponPos;
    public float distance = 10f;
    GameObject currentWeapon;
    GameObject wp;

    bool canGrab;
  

    // Update is called once per frame
    void Update()
    {
        CheckWeapons();
        if (canGrab)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                if (currentWeapon != null)
                {
                    drop();

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

    private void CheckWeapons()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position,Camera.main.transform.forward,out hit, distance))
        {
            if (hit.transform.tag == "WeaponPickUP")
            {
                Debug.Log("PickUPWeapon");
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
    }

    private void drop()
    {
        currentWeapon.transform.parent = null;
        currentWeapon.GetComponent<Rigidbody>().isKinematic = false;
        currentWeapon = null;
    }
}
