using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TutorialMinigame : MonoBehaviour
{
    public GameObject panelAvatar; //imagen del avatar

    public int faseTutorial; //según sumemos el valor de esta variable podremos avanzar al siguiente diálogo del array

    public string[] dialogPhraseTutorial; //aquí almacenamos todos los diálogos por los que irá avanzando el tutorial

    public Text dialogText; //nos permitirá crear textos

    bool activarGlowRio = false;

    [Header("TutorialMinijuego")]
    public string avatarState;
    public Sprite[] avatares;
    public Image currAvatar;

    [Header("PanelPause")]
    public GameObject panelPauseDesplegable;
    bool panelPauseout;

    [Header("GlowEffects")]
    public GameObject riverPointLight;
        



    // Start is called before the first frame update
    void Start()
    {
        Invoke("AvatarApareceTM", 2);

           


    }



    public void AvatarApareceTM()
    {
        panelAvatar.SetActive(true);
        Invoke("DialogMinijuego", 0.5f);


    }

    public void DialogMinijuego()
    {
        panelAvatar.transform.GetChild(1).gameObject.SetActive(true); //activar dialogos
        dialogText.text = dialogPhraseTutorial[faseTutorial];         //en base a la base del tutorial que nos encontremos, se reproducirá el diálogo correspondiente
        activarGlowRio = true;

    }


    public void AlPulsarTM()
    {
        faseTutorial++;                                             //al pulsar el botón del avatar, se sumará 1 a la variable de la fase del tutorial
        dialogText.text = dialogPhraseTutorial[faseTutorial];       //con esto, actualizamos el nuevo valor de la variable, dde tal forma, que en la linea 46, sigue funcionando
    }

    public void AlPulsarPause()
    {
        if (!panelPauseout)
        {
            panelPauseout = true;
            panelPauseDesplegable.SetActive(true);
        }
        else
        {
            panelPauseout = false;
            panelPauseDesplegable.SetActive(false);
        }
    }

    public void Avatar(string state)
    {
        avatarState = state;
        switch (state)
        {
            case "Happy":
                currAvatar.sprite = avatares[0];
                break;
            case "Stressed":
                currAvatar.sprite = avatares[1];
                break;
                //añadir más estados
        }
    }


    // Update is called once per frame
    void Update()
    {

        if (faseTutorial == 0 && activarGlowRio) //cuando la fase del tuto sea 0 y la bool activarGlowRio este en true -- No hace falta poner true, porque lo asume, para que ocurriera en flase con poner una !delante valdría
        {
              
            riverPointLight.GetComponent<UnityEngine.Experimental.Rendering.Universal.Light2D>().intensity = Mathf.PingPong(Time.time / 3, 0.35f); 

        }
        else
        {
            riverPointLight.GetComponent<UnityEngine.Experimental.Rendering.Universal.Light2D>().intensity = 0;
            activarGlowRio = false;
        }
    }
}






