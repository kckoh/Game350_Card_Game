using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animation_front : MonoBehaviour
{
    bool allow;
    
    public float local_size;
    

    void Start()
    {
        allow = true;
    }

    private void OnMouseOver()
    {
        
            StartCoroutine(enlarge());
        
    }

    private void OnMouseExit()
    {
        StartCoroutine(small());
    }


    IEnumerator small()
    {
        
        Vector2 x = new Vector2(local_size, local_size);

        if (transform.localScale.x <= x.x)
        {

        }
        else
        {
            for (int i = 0; i < 5; i += 1)
            {

                transform.localScale = new Vector2(
                    (Mathf.Lerp(transform.localScale.x, transform.localScale.x - 0.005f, Mathf.SmoothStep(0f, 1f, 1))),
                    (Mathf.Lerp(transform.localScale.y, transform.localScale.y - 0.005f, Mathf.SmoothStep(0f, 1f, 1))));
                yield return new WaitForSeconds(0.005f);
            }
        }

    }

    IEnumerator enlarge()
    {
        
        Vector2 x = new Vector2(local_size, local_size);
        
        if(transform.localScale.x >  x.x)
        {

        }
        else
        {
            // got this piece of code from https://www.youtube.com/watch?v=0qlxrnD_8DQ
            for (int i = 0; i < 5; i += 1)
            {

                transform.localScale = new Vector2(
                    (Mathf.Lerp(transform.localScale.x, transform.localScale.x + 0.005f, Mathf.SmoothStep(0f, 1f, 1))),
                    (Mathf.Lerp(transform.localScale.y, transform.localScale.y + 0.005f, Mathf.SmoothStep(0f, 1f, 1))));
                yield return new WaitForSeconds(0.005f);
            }
        }
        
        
       
    }
}
