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
        //dialogos
        dialogPhraseTutorial = 
            "Hi! Welcom to Kidney Valley, you must be the new river supervisor", 
            "So that you can review each city, click on them", 
            "Here we get rid of impurities in the rivers and produce renin when necessary", 
            "Remember to take breaks during work", 
            "Hey, look! It seems that the pressure of the river is dropping too low”", 
            "The river is the sustenance of this world, something must be done", 
            "Let’s extract the renin from the mines, the adrenal glands generate it from the top constantly", 
            "Now you just have to wait until you have enough. And be careful not to go overboard!", 
            "You can increase or decrease production", 
            "We’re going to send her on the boat to Liver Gorge. They will follow with the rest", 
            "On going!", 
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

        Invoke("Dialog4", 0.5f);

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

        Invoke("Dialog6", 0.5f);

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

        Invoke("Dialog8", 0.5f);

    }

    public void Dialog8()
    {
        faseTutorial++;
        dialogText.text = dialogPhraseTutorial[faseTutorial];

        Invoke("Dialog9", 0.5f);

    }

    public void Dialog9()
    {
        faseTutorial++;
        dialogText.text = dialogPhraseTutorial[faseTutorial];

        Invoke("Dialog10", 0.5f);

    }

    public void Dialog10()
    {
        faseTutorial++;
        dialogText.text = dialogPhraseTutorial[faseTutorial];

        Invoke("Dialog11", 0.5f);

    }

    public void Dialog11()
    {
        faseTutorial++;
        dialogText.text = dialogPhraseTutorial[faseTutorial];

        Invoke("Dialog12", 0.5f);

    }

    public void Dialog12()
    {
        faseTutorial++;
        dialogText.text = dialogPhraseTutorial[faseTutorial];

        Invoke("Dialog13", 0.5f);

    }

    public void Dialog13()
    {
        faseTutorial++;
        dialogText.text = dialogPhraseTutorial[faseTutorial];

        Invoke("Dialog14", 0.5f);

    }

    public void Dialog14()
    {
        faseTutorial++;
        dialogText.text = dialogPhraseTutorial[faseTutorial];

        Invoke("Dialog15", 0.5f);

    }

    public void Dialog15()
    {
        faseTutorial++;
        dialogText.text = dialogPhraseTutorial[faseTutorial];

        Invoke("Dialog16", 0.5f);

    }

    public void Dialog16()
    {
        faseTutorial++;
        dialogText.text = dialogPhraseTutorial[faseTutorial];

        Invoke("Dialog17", 0.5f);

    }

    public void Dialog17()
    {
        faseTutorial++;
        dialogText.text = dialogPhraseTutorial[faseTutorial];

        Invoke("Dialog18", 0.5f);

    }

    public void Dialog18()
    {
        faseTutorial++;
        dialogText.text = dialogPhraseTutorial[faseTutorial];

    }

}
