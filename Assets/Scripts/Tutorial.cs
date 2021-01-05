using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public GameObject panelAvatar;
    public int faseTutorial;
    public string[] dialogPhraseTutorial;
    public Text dialogText;
    public bool borroso;
    public GameObject kidneyFilterLight;
    public bool toglow = false;
    private GameObject liver;

    private void Start()
    {
        liver = GameObject.Find("Liver");
        liver.GetComponent<Collider2D>().enabled = false;
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
    public void ActivarLiver()
    {
        liver.GetComponent<Collider2D>().enabled = true;

    }
}
