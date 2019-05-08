using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pakuru : MonoBehaviour
{
    public GameObject leftSign = null;
    public GameObject rightSign = null;
    public GameObject bothSign = null;

    int i;
    public void Start()
    {
        gameObject.SetActive(false);
    }

    public void NoteMaker()
    {
        i = Random.Range(0, 3);
        switch (i)
        {
            case 0:
                Instantiate(leftSign, GameObject.Find("Canvas").transform);
                break;
            case 1:
                Instantiate(rightSign, GameObject.Find("Canvas").transform);
                break;
            case 2:
                Instantiate(bothSign, GameObject.Find("Canvas").transform);
                break;
            default:
                //Add Error method
                break;
        }
    }
}
