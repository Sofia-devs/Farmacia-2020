using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fishing : MonoBehaviour
{
    FollowthePath pathSc;
    GameObject fisherman;
    public float cooldown;
    public List<GameObject> waypointsCheck;
    public Sprite[] pescadorSprites;
    SpriteRenderer pescadorSR;
    int numsprite = 0;
    public Button botonPescar;

    public AudioClip correcto;

    public AudioClip incorrecto;

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
                pathSc = waypoints.GetComponent<FollowthePath>();
                waypoints.GetComponent<FollowthePath>().gotocesta = true;
                GetComponent<AudioSource>().Play();

            }
        }

        NetUp();

        //numsprite = 0;
        //StartCoroutine(Anim());

    }

    public void NetUp()
    {
        GetComponent<UISpritesAnimation>().enabled = true;
        if(pathSc != null) //cuando pescamos algo sea bueno o malo
        {
           

            if (pathSc.Destruir() == "Angio") 
            {
                GetComponent<AudioSource>().clip = correcto;
                GetComponent<AudioSource>().Play();
                pathSc = null;
                print("angio");
            }

            botonPescar.GetComponent<Button>().enabled = false;
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
