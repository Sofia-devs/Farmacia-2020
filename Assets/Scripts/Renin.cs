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

    public GameObject kidneyFilterLight;
    //bool activarKidneyFilter = false;
    public MainUIController uiCon;


    Animator anim;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {

        anim = RiverBarrierContainer.GetComponent<Animator>();



    }

    // Update is called once per frame
    void Update()
    {




        Timer += Time.deltaTime; //Un simple cronómetro

        if (reninDiscovered == true) //Con esta booleana activamos la producción de renina en el tutorial
        {

            if (Timer >= delayAmount) //Si el valor del Timer es mayor que el valor de DelayAmount
            {
                Timer = 0f; //Reseteamos el Timer a 0 para que vuelva a empezar a contar y la función tenga sentido

                reninValue += reninProdSpeed; //Sumamos 2 unidades al valor de la Renina

            }

            if (reninValue > 80)
            {

                //activarKidneyFilter = true;

                kidneyFilterLight.GetComponent<UnityEngine.Experimental.Rendering.Universal.Light2D>().color = Color.red;
                kidneyFilterLight.GetComponent<UnityEngine.Experimental.Rendering.Universal.Light2D>().intensity = Mathf.PingPong(Time.time, 1);
    
                if (uiCon.avatarState != "Stressed") // esto es para que solamente cambie una vez de avatar
                {

                    uiCon.Avatar("Stressed");

                }
                
                //anim.SetBool("reninValueCounter", true); //Con esta acción se va a triggerear la animación que estrechará los ríos.
              
            }

            else
            {
                if (uiCon.avatarState != "Happy")
                {
                    kidneyFilterLight.GetComponent<UnityEngine.Experimental.Rendering.Universal.Light2D>().color = Color.white;

                    uiCon.Avatar("Happy");
                }


                    kidneyFilterLight.GetComponent<UnityEngine.Experimental.Rendering.Universal.Light2D>().intensity = 0;
                //activarKidneyFilter = true;
            }

        }





    }
}

