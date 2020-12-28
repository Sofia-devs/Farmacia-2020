using System.Collections;
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
            if (hit.collider.gameObject.transform.parent != null /*&& hit.collider.gameObject.transform.parent.name == "Cities"*/)
            {
                switch (hit.collider.gameObject.name)
                {
                    case "Kidney":
                        UiCon.KidneyEnter();
                        //hit.collider.gameObject.transform.parent.parent.position = citiesPos[0]; //esta linea va depués del tutorial y activa los señores de la renina
                        this.gameObject.GetComponent<Tutorial>().ActivarTutorial();
                        hit.collider.gameObject.transform.GetChild(0).gameObject.SetActive(true);
                        break;     
                        
                    case "Liver":
                        hit.collider.gameObject.transform.parent.parent.position = citiesPos[1];
                        hit.collider.gameObject.transform.GetChild(0).gameObject.SetActive(true);
                        break;
                    case "People":
                        reninaSc.reninDiscovered = true;
                        break;
                    case "Fisherman":
                        SceneManager.LoadScene(2);
                        break;


                }
                Debug.Log(hit.collider.gameObject.name);
                MainCamera.GetComponent<Camera>().orthographicSize = 2;
            }

            if (hit.collider.gameObject.tag == "AumentoRenina" && velocidadProdRenina < 6)
            {

                velocidadProdRenina = MainCamera.GetComponent<Renin>().reninProdSpeed;


                velocidadProdRenina += 4;                                               //le sumamos 4 puntos a esa variable
                MainCamera.GetComponent<Renin>().reninProdSpeed = velocidadProdRenina; //deovlvemos esa información a la varibale reninProdSpeed del script Renin, ya que hasta el momento solo la habíamos cambiado en este script, 
                                                                                      //pero aún no se lo habíamos comunicado a dicho script

            }

            if (hit.collider.gameObject.tag == "EstabilizarRenina" && velocidadProdRenina >= 6)
            {

                velocidadProdRenina = MainCamera.GetComponent<Renin>().reninProdSpeed;


                velocidadProdRenina -= 4;                                               //le sumamos 4 puntos a esa variable
                MainCamera.GetComponent<Renin>().reninProdSpeed = velocidadProdRenina; //deovlvemos esa información a la varibale reninProdSpeed del script Renin, ya que hasta el momento solo la habíamos cambiado en este script, 
                                                                                      //pero aún no se lo habíamos comunicado a dicho script

            }

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


}
