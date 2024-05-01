using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField]
    private GameObject Explosion;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("GrenadeTime");
    }


    private IEnumerator GrenadeTime()
    {
        yield return new WaitForSeconds(1.5f);
        Instantiate(Explosion, this.transform.position, this.transform.rotation);
        Destroy(this.gameObject);
    }

}
