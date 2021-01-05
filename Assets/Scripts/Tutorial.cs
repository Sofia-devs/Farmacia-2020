using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public GameObject panelAvatar;
    public int faseTutorial;
    public string[] dialogPhraseTutorial;
    public string[] dialogPhraseTutorialLiver;
    public Text dialogText;
    public bool borroso;
    public GameObject kidneyFilterLight;
    public bool toglow = false;
    private GameObject liver;
    public GameObject minero;
    private GameObject mineroLight;
    public GameObject barco;

    private void Start()
    {
        liver = GameObject.Find("Liver");
        liver.GetComponent<Collider2D>().enabled = false;

        mineroLight = minero.transform.GetChild(0).gameObject;
        ActivarTutorial();
    }
    public void ActivarTutorial()
    {
        Invoke("AvatarAparece", 2);
    }
    //aparecer avatar
    //fondo blur
    private void Update()
    {
        if(toglow)
            kidneyFilterLight.GetComponent<UnityEngine.Experimental.Rendering.Universal.Light2D>().intensity = Mathf.PingPong(Time.time, 1);

        if(faseTutorial == 6)
        {
            mineroLight.GetComponent<UnityEngine.Experimental.Rendering.Universal.Light2D>().intensity = Mathf.PingPong(Time.time, 1);

        }

    }
    public void AvatarAparece()
    {
        panelAvatar.SetActive(true);
        Invoke("Dialog", 0.5f);
    }
    public void PassDialog()
    {
        faseTutorial++;
        Dialog();
    }
    public void Dialog()
    {
        //faseTutorial = phase;
        panelAvatar.transform.GetChild(0).gameObject.SetActive(true); //activar dialogo
        dialogText.text = dialogPhraseTutorial[faseTutorial];
        //if (faseTutorial >= 3 && faseTutorial <=6 || faseTutorial == 8)
        //{
        //    Invoke("PassDialog", 0.5f);
        //}
    }

    public void PassDialogLiver()
    {
        faseTutorial++;
        DialogLiver();
    }   
    public void DialogLiver()
    {
        dialogText.text = dialogPhraseTutorialLiver[faseTutorial];

    }
    public void ActivarLiver()
    {
        liver.GetComponent<Collider2D>().enabled = true;

    }

    public void IniTutoLiver()
    {
        barco.SetActive(false);
        liver.GetComponent<Collider2D>().enabled = false;
        faseTutorial = 0;
        DialogLiver();
    }

    public void OutCity()
    {
        barco.SetActive(true);
        barco.GetComponent<FollowthePath>().activarBoat = true;
        Invoke("LlegadaBarco", 2);

    }

    public void LlegadaBarco()
    {
        liver.GetComponent<Collider2D>().enabled = true;
    }

    //poner estres con moñeco azul
    //fase 3 señalar botón pause (postpuesto)
    //fase 4 presión baja (hecho)
    //fase 6 señalar minero (hecho)
    //fase 6 + pulsar minero = activar renina (hecho)
    //activar collider + activar barco (hecho)
}
