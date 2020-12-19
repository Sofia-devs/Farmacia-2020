using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Renin : MonoBehaviour
{

    public float reninValue = 0f;
    public float reninProdSpeed = 2f;
    public float delayAmount = 1;
    public bool reninDiscovered = false;
    public float Timer;

    public GameObject RiverBarrierContainer;
    //public GameObject RiverBarrier1;
    //public GameObject RiverBarrier2;
    public float barriersDistance;

    public MainUIController uiCon;


    Animator anim;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {

        //anim = RiverBarrierContainer.GetComponent<Animator>();



    }

    // Update is called once per frame
    void Update()
    {

        //barriersDistance = Vector2.Distance(RiverBarrier1.transform.position, RiverBarrier2.transform.position);


        Timer += Time.deltaTime; //Un simple cronómetro

        if(reninDiscovered == true) //Con esta booleana activamos la producción de renina en el tutorial
        {

            if (Timer >= delayAmount) //Si el valor del Timer es mayor que el valor de DelayAmount
            {
                Timer = 0f; //Reseteamos el Timer a 0 para que vuelva a empezar a contar y la función tenga sentido

                reninValue += reninProdSpeed; //Sumamos 2 unidades al valor de la Renina

            }

            if (reninValue >= 50 && uiCon.avatarState != "Stressed")
            {

                uiCon.Avatar("Stressed");
                //anim.SetBool("reninValueCounter", true);

                //reninValueCounter = true;

                //Vector2 RB1 = RiverBarrier1.transform.position;
                //Vector2 RB2 = RiverBarrier2.transform.position;

                //initialDistance = RB1 - RB2;

                //RiverBarrier1.transform.position = RiverBarrier2.transform.position - (0, 1);



            }

        }

      
    


    }
}
