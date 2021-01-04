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
    public void PassDialog()
    {
        faseTutorial++;
    }

    public void Dialog(int phase)
    {
        faseTutorial = phase;
        dialogText.text = dialogPhraseTutorial[faseTutorial];
        Invoke("PassDialog", 0.5f);
    }

    //public void Dialog1()
    //{
    //    faseTutorial = 0;
    //    dialogText.text = dialogPhraseTutorial[faseTutorial];

    //    Invoke("Dialog2", 0.5f);

    //}

    //public void Dialog2()
    //{
    //    faseTutorial++;
    //    dialogText.text = dialogPhraseTutorial[faseTutorial];
    //    Invoke("Dialog3", 0.5f);

    //}

    //public void Dialog3()
    //{
    //    faseTutorial++;
    //    dialogText.text = dialogPhraseTutorial[faseTutorial];
    //    Invoke("Dialog4", 0.5f);

    //}

    //public void Dialog4()
    //{
    //    faseTutorial++;
    //    dialogText.text = dialogPhraseTutorial[faseTutorial];

    //    Invoke("Dialog5", 0.5f);

    //}

    //public void Dialog5()
    //{
    //    faseTutorial++;
    //    dialogText.text = dialogPhraseTutorial[faseTutorial];

    //    Invoke("Dialog6", 0.5f);

    //}

    //public void Dialog6()
    //{
    //    faseTutorial++;
    //    dialogText.text = dialogPhraseTutorial[faseTutorial];

    //    Invoke("Dialog7", 0.5f);

    //}

    //public void Dialog7()
    //{
    //    faseTutorial++;
    //    dialogText.text = dialogPhraseTutorial[faseTutorial];

    //    Invoke("Dialog8", 0.5f);

    //}

    //public void Dialog8()
    //{
    //    faseTutorial++;
    //    dialogText.text = dialogPhraseTutorial[faseTutorial];

    //    Invoke("Dialog9", 0.5f);

    //}

    //public void Dialog9()
    //{
    //    faseTutorial++;
    //    dialogText.text = dialogPhraseTutorial[faseTutorial];

    //    Invoke("Dialog10", 0.5f);

    //}

    //public void Dialog10()
    //{
    //    faseTutorial++;
    //    dialogText.text = dialogPhraseTutorial[faseTutorial];

    //    Invoke("Dialog11", 0.5f);

    //}

    //public void Dialog11()
    //{
    //    faseTutorial++;
    //    dialogText.text = dialogPhraseTutorial[faseTutorial];

    //    Invoke("Dialog12", 0.5f);

    //}

}
