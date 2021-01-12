using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FollowthePath : MonoBehaviour
{
    public Button botonPescar;

    //Array of waypoints to walk from one to the next one
    [SerializeField]
    private Transform[] waypoints;
    public Transform cesta;
    //Walk speed
    [SerializeField]
    private float moveSpeed = 2f;

    //Index of current waypoint from which boat walks to the next
    public int waypointIndex = 0;

    public bool activarBoat = false;

    public bool gotocesta = false;

    public bool inminigame;
    

    // Start is called before the first frame update
    void Start()
    {
        //Set position of Enemy as position of the first waypoint
        transform.position = waypoints[waypointIndex].transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        //Move boat
        Move();
    }

    //Methhod that actually make boat walk
    private void Move()
    {
        //If boat didn't reach last waypoint it can move
        //If reached last waypoint then it stops
        if (waypointIndex <= waypoints.Length - 1 && activarBoat)
        {
            if (!gotocesta)
            {
                if (!inminigame)
                {
                    if(waypointIndex == 2)
                    {
                        gameObject.GetComponent<SpriteRenderer>().flipY = false;
                        transform.rotation = Quaternion.Euler(0,0,0);
                    }
                    if (waypointIndex == 4)
                    {
                        gameObject.GetComponent<SpriteRenderer>().flipX = true;
                        transform.rotation = Quaternion.Euler(0, 0,90);

                    }
                    if(waypointIndex == 5)
                    {
                        gameObject.GetComponent<SpriteRenderer>().flipY = true;
                        gameObject.GetComponent<SpriteRenderer>().flipX = false;
                        transform.rotation = Quaternion.Euler(0, 0,180);
                    }




                    if (moveSpeed != 2)
                    {
                        moveSpeed = 2;

                    }
                }
                else
                {
                    if (moveSpeed != 5)
                    {
                        moveSpeed = 5;
                    }
                }

                //Move boat from current waypoint to the next one using MoveTowards method
                transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, moveSpeed * Time.deltaTime);

                //If boat reaches position of waypoint he walked towards then waypointIndex is increased by 1 and boat starts to walk to the next waypoint
                if (transform.position == waypoints[waypointIndex].transform.position)
                {
                    waypointIndex++;
                    if(waypointIndex == waypoints.Length)
                    {
                        waypointIndex = 0;
                        transform.position = waypoints[waypointIndex].transform.position;
                        if (!inminigame)
                        {
                            gameObject.SetActive(false);

                        }

                    }
                }
            }
            else
            {

                print("cesta");
                if (moveSpeed != 8)
                {
                    moveSpeed = 8;
                }
                transform.position = Vector2.MoveTowards(transform.position, cesta.position, moveSpeed * Time.deltaTime);
                //waypointIndex = 0;

                botonPescar.GetComponent<Button>().enabled = true;

                if(transform.position == cesta.position)
                {
                    Invoke("Restart", 0.5f);
                }
            }
        }
    }
    void Restart()
    {
        waypointIndex = 0;
        gotocesta = false;
        transform.position = waypoints [waypointIndex].transform.position;
        //GameObject.FindGameObjectWithTag("Pescador").GetComponent<UISpritesAnimation>().bajar = true ;
    }
}
