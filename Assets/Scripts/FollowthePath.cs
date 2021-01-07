using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowthePath : MonoBehaviour
{
    //Arry of waypoints to walk from one to the next one
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

    //Methhod that actualluy make boat walk
    private void Move()
    {
        //If boat didn't reach last waypoint it can move
        //If reached last waypoint then it stops
        if (waypointIndex <= waypoints.Length - 1 && activarBoat)
        {
            if (!gotocesta)
            {
                if(moveSpeed != 2)
                {
                    moveSpeed = 2;
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

                    }
                }
            }
            else
            {
                print("cesta");
                if (moveSpeed != 5)
                {
                    moveSpeed = 5;
                }
                transform.position = Vector2.MoveTowards(transform.position, cesta.position, moveSpeed * Time.deltaTime);
                //waypointIndex = 0;
                if(transform.position == cesta.position)
                {
                    Invoke("Restart", 1);
                }
            }
        }
    }

    public string Destruir()
    {
        return (gameObject.tag);
    }

    void Restart()
    {
        waypointIndex = 0;
        gotocesta = false;
        transform.position = waypoints [waypointIndex].transform.position;
    }
}
