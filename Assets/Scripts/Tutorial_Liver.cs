using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial_Liver : MonoBehaviour
{
    public GameObject panelAvatar;
    public int faseTutorial;
    public string[] dialogPhraseTutorial;
    public Text dialogText;

    public gameObject liverMinigamePlayButtom;

    // Start is called before the first frame update
    void Start()
    {
        //dialogos
        dialogPhraseTutorial =
            "Stop there! This is the Liver Gorge", 
            "Here are the most thorough analysts, they don’t let anything pass through their customs", 
            "We need Angiotensin I, talk to the fishermen", 
            "Angiotensinogen will pass through this current flow, click on “FISH!” when it is on the fishing net", 
            "Avoid fishing for other things or we won’t get Angiotensin I, catch it!", 
            "Try again", 
            "Great! Angiotensin I has been formed";
    }

    // Update is called once per frame
    void Update()
    {
        if (waitForClickFisher && Input.Jump)
        {
            Invoke("Dialog4", 0.5f);

        }
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

        Invoke("Dialog1", 0.5f);

    }

    public void Dialog1()
    {
        faseTutorial = 0;
        dialogText.text = dialogPhraseTutorial[faseTutorial];

        Invoke("Dialog2", 0.5f);

    }

    public void Dialog2()
    {
        faseTutorial++;
        dialogText.text = dialogPhraseTutorial[faseTutorial];

        Invoke("Dialog3", 0.5f);

    }

    public void Dialog3()
    {
        faseTutorial++;
        dialogText.text = dialogPhraseTutorial[faseTutorial];

        public bool waitForClickFisher = true;

    }

    public void Dialog4()
    {
        faseTutorial++;
        dialogText.text = dialogPhraseTutorial[faseTutorial];

        Invoke("Dialog5", 0.5f);

    }

    public void Dialog5()
    {
        faseTutorial++;
        dialogText.text = dialogPhraseTutorial[faseTutorial];
        liverMinigamePlayButtom.SetActive(true);

    }

    public void Dialog6()
    {
        faseTutorial++;
        dialogText.text = dialogPhraseTutorial[faseTutorial];

        Invoke("Dialog7", 0.5f);

    }

    public void Dialog7()
    {
        faseTutorial++;
        dialogText.text = dialogPhraseTutorial[faseTutorial];

    }

}
