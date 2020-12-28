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

    [Header("TutorialMinijuego")]
    public GameObject panelTM;
    public Text tA1;
    bool panelTMout;
    public string avatarState;
    public Sprite[] avatares;
    public Image currAvatar;

    


    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void ActivarTutorialMinijuego()
    {
        Invoke("AvatarAparece", 2);


    }


    public void DialogMinijuego()
    {
        panelAvatar.transform.GetChild(1).gameObject.SetActive(true); //activar dialogos
        dialogText.text = dialogPhraseTutorial[faseTutorial];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
