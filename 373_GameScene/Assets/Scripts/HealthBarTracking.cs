using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBarTracking : MonoBehaviour
{

    public GameObject ShieldIndicator;
    public GameObject HealthIndicator;
    [SerializeField]
    private int shield;
    [SerializeField]
    private float currentshield;
    [SerializeField]
    private int HP;
    [SerializeField]
    private float currenthealth;
    private int Ammo = 100;
    private int Grenades = 3;
    [SerializeField]
    private TMP_Text AmmoCounter;
    [SerializeField]
    private TMP_Text GrenadeCounter;
    private bool Shootable;
    [SerializeField]
    private GameObject GrenadePrefab;
    [SerializeField]
    private GameObject GrenadePoint;

    // Start is called before the first frame update
    void Start()
    {
        Ammo = 100;
        Grenades = 3;
        Shootable = true;
    }

    // Update is called once per frame
    void Update()
    {

        currentshield = shield * 300 / 100;
        currenthealth = HP * 202 / 100;
        ShieldIndicator.GetComponent<RectTransform>().sizeDelta = new Vector2(currentshield, 80);
        HealthIndicator.GetComponent<RectTransform>().sizeDelta = new Vector2(currenthealth, 40);


        if (Input.GetMouseButton(0))
        {
            if (Shootable && Ammo > 0) 
            {
                Ammo--;
                AmmoCounter.text = Ammo.ToString();
                Shootable = false;
                StartCoroutine("ResetAttack");
            }
            
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (Grenades > 0)
            {
                Grenades--;
                GrenadeCounter.text = Grenades.ToString();
                GameObject CurrentNade = Instantiate(GrenadePrefab, GrenadePoint.transform.position, GrenadePoint.transform.rotation);
                CurrentNade.GetComponent<Rigidbody>().AddForce(transform.forward * 10, ForceMode.Impulse);
            }
        }
    }

    IEnumerator ResetAttack()
    {
        yield return new WaitForSeconds(0.1f);
        Shootable = true;
    }


}
