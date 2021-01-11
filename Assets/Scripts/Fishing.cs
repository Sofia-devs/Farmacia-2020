using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    public MainUIController uiCon;
    public float Timer;
    public bool active = false;

    // Start is called before the first frame update
    void Start()
    {
        fisherman = gameObject;
        pescadorSR = GetComponent<SpriteRenderer>();
        
        
    }
    private void Update()
    {
        if (active)
        {
            if (uiCon.pressurePercentage < 100 && Timer <= 40)
            {
                Timer += Time.deltaTime; //Un simple cronómetro
            }
            else
            {
                if (uiCon.pressurePercentage >= 100)
                {
                    Fin(true);
                }
                else
                {
                    Fin(false);
                }
            }
        }
        
    }


    public void Fish()
    {

       
        
        waypointsCheck.AddRange(GameObject.FindGameObjectsWithTag("Angio"));
        waypointsCheck.AddRange(GameObject.FindGameObjectsWithTag("BadResource"));
        foreach (GameObject waypoints in waypointsCheck)
        {
            print("pescar");
            if (waypoints.GetComponent<FollowthePath>().waypointIndex == 2)
            {
                pathSc = waypoints.GetComponent<FollowthePath>();
                waypoints.GetComponent<FollowthePath>().gotocesta = true;
                GetComponent<AudioSource>().Play();

            }
        }

        NetUp();
        pathSc = null;
        waypointsCheck.Clear();

    //numsprite = 0;
    //StartCoroutine(Anim());

    }

    public void NetUp()
    {
        GetComponent<UISpritesAnimation>().enabled = true;
        if(pathSc != null) //cuando pescamos algo sea bueno o malo
        {
            botonPescar.GetComponent<Button>().enabled = false;
            if (pathSc.gameObject.tag == "Angio") 
            {
                GetComponent<AudioSource>().clip = correcto;
                GetComponent<AudioSource>().Play();
                print("angio");
                uiCon.OngetAngio();
            }
            else if(pathSc.gameObject.tag == "BadResource")
            {
                GetComponent<AudioSource>().clip = incorrecto;
                GetComponent<AudioSource>().Play();
                print("bad");
                uiCon.OngetBadRes();
            }
        }
    }

    void Fin(bool pass)
    {
        if (pass)
        {

        }
        else
        {
            SceneManager.LoadScene("Fin");
        }
    }


}
