using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class looptest : MonoBehaviour, IVirtualButtonEventHandler {

    GameObject vb;
    GameObject zombie1;
    GameObject zombie2;
    GameObject zombie3;
    int i;

    void Start () {

        vb = GameObject.Find("actionbutton");

        vb.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        Debug.Log("Before FOR loop!!!");    
        
    }

    public void OnButtonPressed(VirtualButtonAbstractBehaviour v)
    {
        Debug.Log("button pressed !!!!!!!! ");
        zombie1 = GameObject.Find("zombie1");
        zombie2 = GameObject.Find("zombie2");
        zombie3 = GameObject.Find("zombie3");

        for (i = 1; i <= 3; i++)
        {
            if (i == 1)
            {
                
                StartCoroutine(Delaying1());
            }
            if (i == 2)
            {
               
                StartCoroutine(Stopping1());
                StartCoroutine(Delaying2());

            }
            if(i == 3)
            {

                StartCoroutine(Stopping2());
                StartCoroutine(Delaying3());
               
            }
          
        }

        StartCoroutine(Stopping3());
        Debug.Log("END OF FOR-LOOP");
        
    }

    private IEnumerator Delaying1()
    {

        Debug.Log("1st Moving!!!!!!!!!!!!!");
        yield return new WaitForSeconds(0.5f);
        zombie1.GetComponent<Animation>().Play();

    }

    private IEnumerator Delaying2()
    {
        Debug.Log("2nd Moving!!!!!!!!!!!!!");
        yield return new WaitForSeconds(7.5f);
        zombie2.GetComponent<Animation>().Play();

    }

    private IEnumerator Delaying3()
    {
        Debug.Log("3rd Moving!!!!!!!!!!!!!");
        yield return new WaitForSeconds(13.5f);
        zombie3.GetComponent<Animation>().Play();

    }


    private IEnumerator Stopping1()
    {

        Debug.Log("1st STOP==============");
        yield return new WaitForSeconds(7f);
        zombie1.GetComponent<Animation>().Stop();

    }
    private IEnumerator Stopping2()
    {

        Debug.Log("2nd STOP==============");
        yield return new WaitForSeconds(13f);
        zombie2.GetComponent<Animation>().Stop();

    }

    private IEnumerator Stopping3()
    {
        Debug.Log("3rd STOP==============");
        yield return new WaitForSeconds(20f);
        zombie3.GetComponent<Animation>().Stop();

    }


    public void OnButtonReleased(VirtualButtonAbstractBehaviour v)
    {
        Debug.Log("button released------------"); 
       zombie1.GetComponent<Animation>().Stop();
       zombie2.GetComponent<Animation>().Stop();
       zombie3.GetComponent<Animation>().Stop();
    }
     
}