﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickOnCity : MonoBehaviour
{
    public LayerMask layersHit;
    GameObject MainCamera;
    float velocidadProdRenina;
    public Vector3[] citiesPos;
    public Renin reninaSc;
    public MainUIController UiCon;
    float reninaValor;
    public float reninaEnviada;
    public GameObject mapa;



    private void Start()
    {
        MainCamera = this.gameObject;
    }

    

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            //MainCamera.GetComponent<Tutorial>().faseTutorial++;         //Poner condición para que solo funcione cuando se active el tutorial.

            



            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider.gameObject.transform.parent.name == "Cities" && UiCon.ciudadesActivadas)
            {
                mapa.GetComponent<Scroll>().incity = true;
                switch (hit.collider.gameObject.name)
                {
                    case "Kidney":
                        Kidney(hit.collider.gameObject);
                        break;     
                        
                    case "Liver":
                        Liver(hit.collider.gameObject);
                        
                        //hit.collider.gameObject.transform.GetChild(0).gameObject.SetActive(true);

                        break;
                    //case "People":
                    //    reninaSc.reninDiscovered = true;
                    //    break;
                    //case "Fisherman":
                    //    SceneManager.LoadScene(2);
                    //    break;


                }
                Debug.Log(hit.collider.gameObject.name);
                Camera.main.transform.position =new Vector3(hit.collider.gameObject.transform.position.x, hit.collider.gameObject.transform.position.y, -10);
                MainCamera.GetComponent<Camera>().orthographicSize = 2;
            }

            //if (hit.collider.gameObject.tag == "AumentoRenina" && velocidadProdRenina < 6)
            //{

            //    velocidadProdRenina = MainCamera.GetComponent<Renin>().reninProdSpeed;


            //    velocidadProdRenina += 4;                                               //le sumamos 4 puntos a esa variable
            //    MainCamera.GetComponent<Renin>().reninProdSpeed = velocidadProdRenina; //deovlvemos esa información a la varibale reninProdSpeed del script Renin, ya que hasta el momento solo la habíamos cambiado en este script, 
            //                                                                          //pero aún no se lo habíamos comunicado a dicho script

            //}

            //if (hit.collider.gameObject.tag == "EstabilizarRenina" && velocidadProdRenina >= 6)
            //{

            //    velocidadProdRenina = MainCamera.GetComponent<Renin>().reninProdSpeed;


            //    velocidadProdRenina -= 4;                                               //le sumamos 4 puntos a esa variable
            //    MainCamera.GetComponent<Renin>().reninProdSpeed = velocidadProdRenina; //deovlvemos esa información a la varibale reninProdSpeed del script Renin, ya que hasta el momento solo la habíamos cambiado en este script, 
            //                                                                          //pero aún no se lo habíamos comunicado a dicho script

            //}

            if (hit.collider.gameObject.tag == "SendToActivado" && reninaValor < 55) //Si: 1º - Se pulsa sobre un objeto con el tag designado y 2º reninaValor es menor de 55
            {

                reninaValor = MainCamera.GetComponent<Renin>().reninValue;          //igualamos reninaValor a la variable del script Renin : reninValue

                //Invocar un texto que diga "aún no tienes suficiente renina"
                
            }

            if (hit.collider.gameObject.tag == "SendToActivado" && reninaValor >= 55 && reninaValor <= 80) //Si 1º - Se pulsa sobre un objeto con el tag designado y reninaValor se encuentra entre 55 y 80 (ambos incluidos)
            {
                Debug.Log("Me han pulsado");

                reninaValor = MainCamera.GetComponent<Renin>().reninValue;                                //igualamos reninaValor con renin Value del script Renin

                reninaEnviada = reninaValor;                                                             //la renina enviada tendrá el mismo valor que reninaValor cuando pulse

                reninaValor = 0;                                                                        //al valor de la renina se le restará el valor que tenga en ese momento

            }
            //notas para Álvaro: Creo que esto no funciona porque tendría que estar guardando el valor de la variable justo en el momento que pulso en algún lado, pero no sé hacerlo
            //se me ha pasado por la cabeza que podría ser con algo que creo se lamaba player prefs, lo usamos con roberto para guardar la puntuación en el tirachinas o roll a ball
            //he pensado en crear una función en el script de renin, donde se haga este proceso para no saturar el update, no sé si sería correcto, ahora bien, necesito sacar el cómo hacer 
            //lo que quiero porque es más complicado de lo que pensaba XD


        }
        if (Input.GetMouseButtonDown(1) && MainCamera.GetComponent<Renin>().reninValue >= 55)
        {
            Debug.Log("Me han pulsado");

            reninaEnviada = MainCamera.GetComponent<Renin>().reninValue;                             //la renina enviada tendrá el mismo valor que reninaValor cuando pulse

            MainCamera.GetComponent<Renin>().reninValue = 0;                                        //al valor de la renina se le restará el valor que tenga en ese momento
        }

    }

    public void SalirCiudad()
    {
        mapa.GetComponent<Scroll>().incity = false;
    }

    public void Kidney(GameObject kindey)
    {
        UiCon.KidneyEnter();
        //this.gameObject.GetComponent<Tutorial>().ActivarTutorial();
        Camera.main.transform.position = kindey.transform.position;
        //kindey.transform.GetChild(0).gameObject.SetActive(true);
        UiCon.kidney.gameObject.SetActive(true);
        Camera.main.gameObject.GetComponent<Tutorial>().toglow = false;
        //llamas al script del tutorial, y dentro de él llamas al objeto que tiene la luz, dentro del él accedes al script y dentro de este script accedes a la variable de instensity
        Camera.main.gameObject.GetComponent<Tutorial>().kidneyFilterLight.GetComponent<UnityEngine.Experimental.Rendering.Universal.Light2D>().intensity = 0;
        Camera.main.gameObject.GetComponent<Tutorial>().PassDialog();
        //bajar presión

    }

    public void Liver(GameObject liver)
    {
        Camera.main.transform.position = liver.transform.position;
        Camera.main.gameObject.GetComponent<Tutorial>().IniTutoLiver();
        UiCon.LiverEnter();
        UiCon.liver.gameObject.SetActive(true);
    }


}
