using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainUIController : MonoBehaviour
{
    [Header("PanelRecursos")]
    public Text resource;
    public Button increasedecrease;
    public Image resourceImage;
    [Range(0, 100)]
    public float resourcePercentage;
    public Renin reninSc;
    public string cityState;
    public Text increaseText;
    public Sprite increase;
    public Sprite decrease;

    [Header("PanelPause")]
    public Button botonPause;
    public Sprite pause;
    public Sprite play;
    public GameObject panelPauseDesplegable;
    bool panelPauseout;

    [Header("PanelSA")]
    public Button panelSAD;
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
    public GameObject farLiver;

    public Image kidney;
    public Image liver;
    public bool ciudadesActivadas = false;
    public Rect zoom;
    public GameObject pescador;
    public AudioClip riñon;
    public AudioClip mapa;
    public AudioClip liveraudio;


    private Tutorial tutorialSc;

    public Button playButton;
    public Button exitButton;

    public Text creditsText;
    public bool inminigame;

    public void Start()
    {
        tutorialSc = Camera.main.gameObject.GetComponent<Tutorial>();
        pressureState = "Estable";
        if (!inminigame)
        {
            pressurePercentage = 70;
            pressureImage.fillAmount = pressurePercentage / 100;
        }
        else
        {
            pressurePercentage = 0;
            pressureImage.fillAmount = pressurePercentage / 100;
        }
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
            botonPause.image.sprite = play;
            panelPauseDesplegable.SetActive(true);
        }
        else
        {
            botonPause.image.sprite = pause;
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
            if (increasedecrease.image.sprite == increase)
            {
                increasedecrease.image.sprite = decrease;
                reninSc.reninProdSpeed = 6;
            }
            else if (increasedecrease.image.sprite == decrease)
            {
                increasedecrease.image.sprite = increase;
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
    public void AlPulsarPescadorLiver()
    {
        SceneManager.LoadScene(2);

    }

    public void AlPulsarExitGame()
    {
        Application.Quit();
    }


    private void Update()
    {

        if (cityState == "Kidney" && !inminigame)
        {
            //activar el glow del botón de pause 
            if (tutorialSc.faseTutorial == 3)
            {
                tutorialSc.pauseGlow = true;
            }
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
                    panelSAD.gameObject.GetComponent<UISpritesAnimation>().enabled = false;
                }
                if (pressurePercentage >= 80)
                {
                    panelSAD.gameObject.GetComponent<UISpritesAnimation>().enabled = false;
                    currAvatar.sprite = avatares[1];

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
        gameObject.GetComponent<AudioSource>().clip = riñon;
        gameObject.GetComponent<AudioSource>().Play();
        gameObject.GetComponent<AudioSource>().volume = 0.6f;

    }

    public void LiverEnter()
    {
        farLiver.gameObject.SetActive(false);
        cityState = "Liver";
        gameObject.GetComponent<AudioSource>().clip = liveraudio;
        gameObject.GetComponent<AudioSource>().Play();

    }
    public void PulsarMinero()
    {
        if (tutorialSc.faseTutorial == 6)
        {
            Camera.main.gameObject.GetComponent<Renin>().reninDiscovered = true;
            tutorialSc.PassDialog();
            Camera.main.GetComponent<Tutorial>().mineroLight.GetComponent<UnityEngine.Experimental.Rendering.Universal.Light2D>().intensity = 0;
        }
    }
    public void SalirCiudad()
    {
        gameObject.GetComponent<AudioSource>().clip = mapa;
        gameObject.GetComponent<AudioSource>().Play();
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
        gameObject.GetComponent<AudioSource>().clip = mapa;
        reninSc.reninDiscovered = false;
        print(reninvalue);
        SalirCiudad();
        tutorialSc.OutCity();        
    }

    public void OngetAngio()
    {
        pressurePercentage += 20;
        pressureImage.fillAmount = pressurePercentage / 100;
    }

    public void OngetBadRes()
    {
        pressurePercentage -= 10;
        pressureImage.fillAmount = pressurePercentage / 100;
    }
}
