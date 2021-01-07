using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fishing : MonoBehaviour
{
    FollowthePath pathSc;
    GameObject fisherman;
    public float cooldown;
    public List<GameObject> waypointsCheck;
    public Sprite[] pescadorSprites;
    SpriteRenderer pescadorSR;
    int numsprite = 0;
    // Start is called before the first frame update
    void Start()
    {
        fisherman = gameObject;
        pescadorSR = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }


    public void Fish()
    {
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

        //numsprite = 0;
        //StartCoroutine(Anim());
        
        NetUp();
    }

    void NetUp()
    {
        GetComponent<UISpritesAnimation>().enabled = true;
        if(pathSc != null)
        {
            if (pathSc.Destruir() == "Angio")
            {
                print("angio");
            }
        }
    }

    //IEnumerator Anim()
    //{
    //    while (numsprite <= (pescadorSprites.Length-1))
    //    {
    //        pescadorSR.sprite = pescadorSprites[numsprite];
    //        numsprite++;

    //    }
    //    //yield return null;
    //    yield return null;
    //}
}
