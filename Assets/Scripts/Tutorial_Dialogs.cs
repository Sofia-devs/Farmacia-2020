using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial_Dialogs : MonoBehaviour
{
    public string DialogTutorial1 = "Hi! Welcom to Kidney Valley, you must be the new river supervisor";
    public string DialogTutorial2 = "So that you can review each city, click on them";
    public string DialogTutorial3 = "Here we get rid of impurities in the rivers and produce renin when necessary";
    public string DialogTutorial4 = "Remember to take breaks during work";
    public string DialogTutorial5 = "Hey, look! It seems that the pressure of the river is dropping too low”";
    public string DialogTutorial6 = "The river is the sustenance of this world, something must be done";
    public string DialogTutorial7 = "Let’s extract the renin from the mines, the adrenal glands generate it from the top constantly";
    public string DialogTutorial8 = "Now you just have to wait until you have enough. And be careful not to go overboard!";
    public string DialogTutorial9 = "You can increase or decrease production";
    public string DialogTutorial10 = "We’re going to send her on the boat to Liver Gorge. They will follow with the rest";
    public string DialogTutorial11 = "On going!";
    public string DialogTutorial12 = "Stop there! This is the Liver Gorge";
    public string DialogTutorial13 = "Here are the most thorough analysts, they don’t let anything pass through their customs";
    public string DialogTutorial14 = "We need Angiotensin I, talk to the fishermen";
    public string DialogTutorial15 = "Angiotensinogen will pass through this current flow, click on “FISH!” when it is on the fishing net";
    public string DialogTutorial16 = "Avoid fishing for other things or we won’t get Angiotensin I, catch it!";
    public string DialogTutorial17 = "Try again";
    public string DialogTutorial18 = "Great! Angiotensin I has been formed";

    public Text dialog;

    public bool nextDialog = true;

    // Start is called before the first frame update
    void Start()
    {
        GameObject DialogBoard = GameObject.Find("DialogBoard");
        dialog = DialogBoard.GetComponent<Text>();
        dialog.text = DialogTutorial1;

        nextDialog = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.anyKey)
        {
            dialog.text = DialogTutorial2;
            StartCoroutine(WaitingCoroutine());
            
            if (Input.anyKey)
            {
                dialog.text = DialogTutorial2;
                StartCoroutine(WaitingCoroutine());

                if (Input.anyKey)
                {
                    dialog.text = DialogTutorial3;
                    StartCoroutine(WaitingCoroutine());

                    if (Input.anyKey)
                    {
                        dialog.text = DialogTutorial4;
                        StartCoroutine(WaitingCoroutine());

                        if (Input.anyKey)
                        {
                            dialog.text = DialogTutorial5;
                            StartCoroutine(WaitingCoroutine());

                            if (Input.anyKey)
                            {
                                dialog.text = DialogTutorial6;
                                StartCoroutine(WaitingCoroutine());

                                if (Input.anyKey)
                                {
                                    dialog.text = DialogTutorial7;
                                    StartCoroutine(WaitingCoroutine());

                                    if (Input.anyKey)
                                    {
                                        dialog.text = DialogTutorial8;
                                        StartCoroutine(WaitingCoroutine());

                                        if (Input.anyKey)
                                        {
                                            dialog.text = DialogTutorial9;
                                            StartCoroutine(WaitingCoroutine());

                                            if (Input.anyKey)
                                            {
                                                dialog.text = DialogTutorial10;
                                                StartCoroutine(WaitingCoroutine());

                                                if (Input.anyKey)
                                                {
                                                    dialog.text = DialogTutorial11;
                                                    StartCoroutine(WaitingCoroutine());

                                                    if (Input.anyKey)
                                                    {
                                                        dialog.text = DialogTutorial12;
                                                        StartCoroutine(WaitingCoroutine());

                                                        if (Input.anyKey)
                                                        {
                                                            dialog.text = DialogTutorial13;
                                                            StartCoroutine(WaitingCoroutine());

                                                            if (Input.anyKey)
                                                            {
                                                                dialog.text = DialogTutorial14;
                                                                StartCoroutine(WaitingCoroutine());

                                                                if (Input.anyKey)
                                                                {
                                                                    dialog.text = DialogTutorial15;
                                                                    StartCoroutine(WaitingCoroutine());

                                                                    if (Input.anyKey)
                                                                    {
                                                                        dialog.text = DialogTutorial16;
                                                                        StartCoroutine(WaitingCoroutine());

                                                                        if (Input.anyKey)
                                                                        {
                                                                            dialog.text = DialogTutorial17;
                                                                            StartCoroutine(WaitingCoroutine());

                                                                            if (Input.anyKey)
                                                                            {
                                                                                dialog.text = DialogTutorial18;
                                                                                StartCoroutine(WaitingCoroutine());

                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        */
        /*if (Input.anyKey && nextDialog == true)
        {
            nextDialog = false;
            dialog.text = "1";
            StartCoroutine(WaitingCoroutine());
        }
        if (Input.anyKey && nextDialog == true)
        {
            nextDialog = false;
            dialog.text = "2";
            StartCoroutine(WaitingCoroutine());
        }
        if (Input.anyKey && nextDialog == true)
        {
            nextDialog = false;
            dialog.text = "3";
            StartCoroutine(WaitingCoroutine());
        }*/
    }

    IEnumerator WaitingCoroutine()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(1);

        //continue bool
        nextDialog = true;

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);

    }
}
