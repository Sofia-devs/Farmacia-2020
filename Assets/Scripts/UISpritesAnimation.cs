using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UISpritesAnimation : MonoBehaviour
{
    public float animvalocity;

    [SerializeField] private Sprite[] sprites;

    private Image image;
    private SpriteRenderer sr;
    private int index = 0;
    private float timer = 0;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        image = GetComponent<Image>();
    }
    private void Update()
    {
        if ((timer += Time.deltaTime) >= (animvalocity / sprites.Length) && image != null)
        {
            timer = 0;
            image.sprite = sprites[index];
            index = (index + 1) % sprites.Length;
        }
        else if((timer += Time.deltaTime) >= (animvalocity / sprites.Length) && sr != null)
        {
            timer = 0;
            //index = (index + 1) % sprites.Length;
            if ((index + 1) < sprites.Length)
            {
                index++;
                sr.sprite = sprites[index];
            }
            else if((index + 1) >= sprites.Length)
            {
                index = 0;
                sr.sprite = sprites[index];
                this.enabled = false;
            }
        }
    }

   
}
