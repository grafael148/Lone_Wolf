using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Magnum : MonoBehaviour
{
    public float bullet_Timer = 5;
    // Start is called before the first frame update

    private void Awake()
    {
        Destroy(gameObject, bullet_Timer);
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        //Destroy(collision.gameObject);
        Destroy(gameObject);
    } */
}
