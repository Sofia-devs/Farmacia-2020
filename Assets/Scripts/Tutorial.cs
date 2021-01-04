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

    private void Start()
    {
        ActivarTutorial();
    }
    public void ActivarTutorial()
    {
        Invoke("AvatarAparece", 2);
    }
    //aparecer avatar
    //fondo blur

    public void AvatarAparece()
    {
        panelAvatar.SetActive(true);
        panelAvatar.transform.GetChild(0).gameObject.SetActive(true); //activar borroso
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
        panelAvatar.transform.GetChild(1).gameObject.SetActive(true);
        dialogText.text = dialogPhraseTutorial[faseTutorial];
        if (faseTutorial >= 3 && faseTutorial <=6 || faseTutorial == 8)
        {
            Invoke("PassDialog", 0.5f);
        }
    }
}
