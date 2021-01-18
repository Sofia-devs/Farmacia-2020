using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UISpritesAnimation : MonoBehaviour
{
    public float animvalocity;

    [SerializeField] private Sprite[] sprites;

    [SerializeField] private Sprite[] spritesHappy;

    [SerializeField] private Sprite[] spritesSad;

    [SerializeField] private Sprite[] spritesStressed;

    private Image image;
    private SpriteRenderer sr;
    private int index = 0;
    private float timer = 0;

    public bool sceneChecker;
    public string avatarEstado = "Happy";

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        image = GetComponent<Image>();
    }
    private void Update()
    {
        
        if (sceneChecker)
        {

            if(avatarEstado != null)
            {
                if(avatarEstado == "Happy")
                {
                    if ((timer += Time.deltaTime) >= (animvalocity / spritesHappy.Length) && image != null)
                    {
                        timer = 0;
                        image.sprite = spritesHappy[index];
                        index = (index + 1) % spritesHappy.Length;
                    }
                    else if ((timer += Time.deltaTime) >= (animvalocity / spritesHappy.Length) && sr != null)
                    {
                        timer = 0;
                        //index = (index + 1) % sprites.Length;
                        if ((index + 1) < spritesHappy.Length)
                        {
                            index++;
                            sr.sprite = spritesHappy[index];
                        }
                        else if ((index + 1) >= spritesHappy.Length)
                        {
                            index = 0;
                            sr.sprite = spritesHappy[index];
                            this.enabled = false;
                        }
                    }
                }
                else if (avatarEstado == "Sad")
                {
                    if ((timer += Time.deltaTime) >= (animvalocity / spritesSad.Length) && image != null)
                    {
                        timer = 0;
                        image.sprite = spritesSad[index];
                        index = (index + 1) % spritesSad.Length;
                    }
                    else if ((timer += Time.deltaTime) >= (animvalocity / spritesSad.Length) && sr != null)
                    {
                        timer = 0;
                        //index = (index + 1) % sprites.Length;
                        if ((index + 1) < spritesSad.Length)
                        {
                            index++;
                            sr.sprite = spritesSad[index];
                        }
                        else if ((index + 1) >= spritesSad.Length)
                        {
                            index = 0;
                            sr.sprite = spritesSad[index];
                            this.enabled = false;
                        }
                    }
                }
                else if (avatarEstado == "Stressed")
                {
                    if ((timer += Time.deltaTime) >= (animvalocity / spritesStressed.Length) && image != null)
                    {
                        timer = 0;
                        image.sprite = spritesStressed[index];
                        index = (index + 1) % spritesStressed.Length;
                    }
                    else if ((timer += Time.deltaTime) >= (animvalocity / spritesStressed.Length) && sr != null)
                    {
                        timer = 0;
                        //index = (index + 1) % sprites.Length;
                        if ((index + 1) < spritesStressed.Length)
                        {
                            index++;
                            sr.sprite = spritesStressed[index];
                        }
                        else if ((index + 1) >= spritesStressed.Length)
                        {
                            index = 0;
                            sr.sprite = spritesStressed[index];
                            this.enabled = false;
                        }
                    }
                }
            }

        }
        else
        {
            if ((timer += Time.deltaTime) >= (animvalocity / sprites.Length) && image != null)
            {
                timer = 0;
                image.sprite = sprites[index];
                index = (index + 1) % sprites.Length;
            }
            else if ((timer += Time.deltaTime) >= (animvalocity / sprites.Length) && sr != null)
            {
                timer = 0;
                //index = (index + 1) % sprites.Length;
                if ((index + 1) < sprites.Length)
                {
                    index++;
                    sr.sprite = sprites[index];
                }
                else if ((index + 1) >= sprites.Length)
                {
                    index = 0;
                    sr.sprite = sprites[index];
                    this.enabled = false;
                }
            }
        }
 

    }

   
}
