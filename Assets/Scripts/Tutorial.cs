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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
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

    public void Dialog()
    {
        panelAvatar.transform.GetChild(1).gameObject.SetActive(true); //activar dialogos
        dialogText.text = dialogPhraseTutorial[faseTutorial];
    }


}
