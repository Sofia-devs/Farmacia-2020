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
    public Text increaseText;

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
    private string pressureState;

    [Header("Ciudades")]
    public Image kidney;
    public Image liver;
    public bool ciudadesActivadas = false;
    public Rect zoom;
    public GameObject pescador;

    private Tutorial tutorialSc;

    public void Start()
    {
        tutorialSc = Camera.main.gameObject.GetComponent<Tutorial>();
        pressureState = "Estable";
        pressurePercentage = 70;
        pressureImage.fillAmount = pressurePercentage / 100;
    }
    public void AlPulsarSA()
    {

        if (!ciudadesActivadas)
        {
            ciudadesActivadas = true;
        }

        if (((tutorialSc.faseTutorial >= 2 && tutorialSc.faseTutorial <= 5) || tutorialSc.faseTutorial == 7 || tutorialSc.faseTutorial == 0) && cityState == "Kidney")
        {
            tutorialSc.PassDialog();
            if (tutorialSc.faseTutorial == 1)
            {

                print("glow");
                tutorialSc.toglow = true;
            }
            //pressure
            if (tutorialSc.faseTutorial == 4)
            {
                StartCoroutine(BajarPresion());
            }
        }
        if(cityState == "Liver")
        {
            tutorialSc.PassDialogLiver();
            liver.GetComponent<RectTransform>().sizeDelta = zoom.size;
            liver.GetComponent<RectTransform>().anchoredPosition = new Vector2(zoom.x, zoom.y);
            pescador.SetActive(true);
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

    public void AlPulsarIncrease()
    {
        if(tutorialSc.faseTutorial >= 8)
        {
            if(tutorialSc.faseTutorial == 8)
                tutorialSc.PassDialog();
            if (increaseText.text == "Increase")
            {
                increaseText.text = "Stabilize";
                reninSc.reninProdSpeed = 6;
            }
            else if (increaseText.text == "Stabilize")
            {
                increaseText.text = "Increase";
                reninSc.reninProdSpeed = 2;
            }
        }

    }

    public void AlPulsarSendTo()
    {
        if (tutorialSc.faseTutorial >= 9 && reninSc.reninValue >= 50)
        {
            if(reninSc.reninValue <= 80)
            {
                ReninSent(reninSc.reninValue);
                reninSc.reninValue = 0;
            }
            else
            {
                reninSc.reninValue -= 80;
                ReninSent(80);
            }

        }
    }

    public void AlPulsarPlayMenu()
    {
        SceneManager.LoadScene(1);
    }


    private void Update()
    {
        if (cityState == "Kidney")
        {
            //renin update
            resourcePercentage = reninSc.reninValue;
            resource.text = "Renin";
            if(resourcePercentage <= 100)
            {
                resourceImage.fillAmount = resourcePercentage/100;
            }
            if(resourcePercentage <= 100)
            {
                resourcePercentage = 100;
            }
            //pressure update
            if (pressurePercentage <= 100)
            {
                pressureImage.fillAmount = pressurePercentage / 100;
                if(tutorialSc.faseTutorial >= 6 && reninSc.reninValue >= 80 && pressureState != "Subiendo")
                {
                    pressureState = "Subiendo";
                    StartCoroutine(SubirPresion());
                }
                if(pressurePercentage < 50)
                {
                    currAvatar.sprite = avatares[2];
                }
            }
            else if(pressurePercentage >= 100)
            {
                pressurePercentage = 100;
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
    public void PulsarMinero()
    {
        if (tutorialSc.faseTutorial == 6)
        {
            Camera.main.gameObject.GetComponent<Renin>().reninDiscovered = true;
            tutorialSc.PassDialog();
        }
    }
    public void SalirCiudad()
    {
        kidney.gameObject.SetActive(false);
        GameObject.Find("Mapa").gameObject.GetComponent<Scroll>().incity = false;
        Camera.main.orthographicSize = 5;
    }

    IEnumerator BajarPresion()
    {
        while(pressurePercentage >= 40)
        {
            pressurePercentage -= 0.5f;
            yield return new WaitForSeconds(.1f);

        }
        while (pressurePercentage >= 30)
        {
            pressurePercentage -= 0.5f;
            yield return new WaitForSeconds(.25f);
        }

    }    
    
    IEnumerator SubirPresion()
    {
        while(pressurePercentage <= 90)
        {
            pressurePercentage += 0.5f;
            yield return new WaitForSeconds(.1f);
        }
        yield return null;
    }

    public void ReninSent(float reninvalue)
    {
        reninSc.reninDiscovered = false;
        print(reninvalue);
        SalirCiudad();
        tutorialSc.OutCity();        
    }
}
