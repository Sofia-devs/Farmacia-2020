using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fishing : MonoBehaviour
{
    public GameObject fishingArea;
    GameObject fisherman;
    public float cooldown;
    // Start is called before the first frame update
    void Start()
    {
        fisherman = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Fish()
    {
        fishingArea.SetActive(true);
        Invoke("NetUp", cooldown);
    }

    void NetUp()
    {
        fishingArea.SetActive(false);
    }
}
