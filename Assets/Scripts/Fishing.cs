using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fishing : MonoBehaviour
{
    public GameObject fishingArea;
    FollowthePath pathSc;
    GameObject fisherman;
    public float cooldown;
    public List<GameObject> waypointsCheck;

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
        waypointsCheck.AddRange(GameObject.FindGameObjectsWithTag("Angio"));
        waypointsCheck.AddRange(GameObject.FindGameObjectsWithTag("BadResource"));
        foreach (GameObject waypoints in waypointsCheck)
        {
            if(waypoints.GetComponent<FollowthePath>().waypointIndex == 2)
            {
                print("pescar");
                waypoints.GetComponent<FollowthePath>().gotocesta = true;
                pathSc = waypoints.GetComponent<FollowthePath>();
            }
        }

        //Invoke("NetUp", cooldown);
        NetUp();
    }

    void NetUp()
    {
        if(pathSc != null)
        {
            if (pathSc.Destruir() == "Angio")
            {
                print("angio");
            }
        }

        fishingArea.SetActive(false);
    }
}
