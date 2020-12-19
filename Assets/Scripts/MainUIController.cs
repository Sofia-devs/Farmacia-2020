using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainUIController : MonoBehaviour
{
    [Header("EscenaMenu")]
    public Image confirmExitImage;
    bool confirmExitImageDespl = false;

    [Header("PanelRecursos")]
    public Text resource;
    public Image resourceImage;
    [Range(0, 100)]
    public float resourcePercentage;
    public Renin reninSc;
    public string cityState;

    [Header("PanelPause")]
    public GameObject panelPauseDesplegable;
    bool panelPauseout;

    [Header("PanelSA")]
    public GameObject panelSAD;
    public Text tA1;
    public Text tA2;
    public Text tA3;
    bool panelSADout;
    public string avatarState;
    public Sprite[] avatares;
    public Image currAvatar;

    [Header("PanelPresión")]
    [Range(0, 100)]
    public float pressurePercentage;
    public Image pressureImage;



    public void AlPulsarSA()
    {
        if (!panelSADout)
        {
            panelSADout = true;
            panelSAD.SetActive(true);
        }
        else
        {
            panelSADout = false;
            panelSAD.SetActive(false);
        }
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

    public void AlPulsarPlayMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void AlPulsarDesplegarExitMenu()
    {
        if (confirmExitImageDespl)
        {
            confirmExitImageDespl = false;
            confirmExitImage.gameObject.SetActive(false);
        }
        else
        {
            confirmExitImageDespl = true;
            confirmExitImage.gameObject.SetActive(true);
        }
    }
    //public void AlPulsarCancelExitMenu()
    //{

    //}
    public void AlPulsarConfirmExitMenu()
    {
        print("Quit game");
        Application.Quit();

    }

    private void Update()
    {
        if(cityState == "Kidney")
        {
            
            resourcePercentage = reninSc.reninValue;
            if(resourcePercentage <= 100)
            {
                resourceImage.fillAmount = resourcePercentage/100;
            }
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
}
