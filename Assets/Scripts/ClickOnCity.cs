using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickOnCity : MonoBehaviour
{
    public LayerMask layersHit;
    GameObject MainCamera;
    float velocidadProdRenina;
    public Vector3[] citiesPos;
    public Renin reninaSc;

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

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider.gameObject.transform.parent != null && hit.collider.gameObject.transform.parent.name == "Cities")
            {
                switch (hit.collider.gameObject.name)
                {
                    case "Kidney":
                        hit.collider.gameObject.transform.parent.parent.position = citiesPos[0];
                        break;     
                        
                    case "Liver":
                        hit.collider.gameObject.transform.parent.parent.position = citiesPos[1];
                        break;
                    case "People":
                        reninaSc.reninDiscovered = true;
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

        }
    }


}
