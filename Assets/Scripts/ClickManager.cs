using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
public class ClickManager : MonoBehaviour
{

    System.Random random = new System.Random();
    string current_state;
    public List<Animator> animators;
    List<string> ranList;
    int numMatchedCard = 0;
    public int endScore;

    //go to menu function
    IEnumerator goToMenu()
    {
        yield return new WaitForSeconds(1.7f);
        SceneManager.LoadScene("MenuScene");
    }

    // Start is called before the first frame update
    void Start()
    {

        current_state = "first";
        ranList = new List<string> { "flip", "flip", "flip2", "flip2", "flip", "flip" };
        int n = ranList.Count;
        //randomnize the lists
        //https://stackoverflow.com/questions/273313/randomize-a-listt

        while (n > 1)
        {
            n--;
            int k = random.Next(n + 1);
            string value = ranList[k];
            ranList[k] = ranList[n];
            ranList[n] = value;
        }

    }

    //play function
    public void playAnimation(string cardName)
    {
        int clicked_state = Int32.Parse(cardName);

        animators[clicked_state].Play(ranList[clicked_state]);

        if (ranList[clicked_state] == "matched")
        {

        }
        else if (current_state == cardName)
        {

        }

        else if (current_state == "first")
        {
            current_state = cardName;
        }
        else
        {
            int current_now = Int32.Parse(current_state);


            if (ranList[clicked_state] == ranList[current_now])
            {
                animators[clicked_state].SetTrigger("isMatched");

                animators[current_now].SetTrigger("isMatched");

                ranList[clicked_state] = "matched";
                ranList[current_now] = "matched";

                current_state = "first";
                numMatchedCard++;

                // scenemanagement
                if (numMatchedCard == endScore)
                {
                    StartCoroutine(goToMenu());

                }
            }

            else
            {
                animators[clicked_state].SetTrigger("notMatched");

                animators[current_now].SetTrigger("notMatched");


                current_state = "first";
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        //when the card is clicked, it plays the animation given
        if (Input.GetMouseButtonDown(0))
        {
            //click event using raycast
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.name == "return")
                {
                    SceneManager.LoadScene("MenuScene");
                }

                if (hit.collider.gameObject.name == "0")
                {
                    playAnimation(hit.collider.gameObject.name);


                }


                if (hit.collider.gameObject.name == "1")
                {

                    playAnimation(hit.collider.gameObject.name);


                }

                if (hit.collider.gameObject.name == "2")
                {
                    playAnimation(hit.collider.gameObject.name);
                }


                if (hit.collider.gameObject.name == "3")
                {
                    playAnimation(hit.collider.gameObject.name);
                }

                if (hit.collider.gameObject.name == "4")
                {
                    playAnimation(hit.collider.gameObject.name);
                }
                if (hit.collider.gameObject.name == "5")
                {
                    playAnimation(hit.collider.gameObject.name);
                }



            }
        }
    }
}
