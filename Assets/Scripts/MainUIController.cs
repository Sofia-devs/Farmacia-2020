using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainUIController : MonoBehaviour
{
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

    [Header("Ciudades")]
    public Image kidney;
    public bool ciudadesActivadas = false;

    private Tutorial tutorialSc;

    public void Start()
    {
        tutorialSc = Camera.main.gameObject.GetComponent<Tutorial>();
    }
    public void AlPulsarSA()
    {

        if (!ciudadesActivadas)
        {
            ciudadesActivadas = true;
        }
        if((tutorialSc.faseTutorial >= 2 && tutorialSc.faseTutorial <= 5) || tutorialSc.faseTutorial == 7 || tutorialSc.faseTutorial == 0)
        {
            tutorialSc.PassDialog();
            if (tutorialSc.faseTutorial == 1)
            {

                print("glow");
                tutorialSc.toglow = true;
            }
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

    private void Update()
    {
        if(cityState == "Kidney")
        {
            
            resourcePercentage = reninSc.reninValue;
            resource.text = "Renin";
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

    public void KidneyEnter()
    {
        cityState = "Kidney";
    }

    public void SalirCiudad()
    {
        kidney.gameObject.SetActive(false);
    }
}
