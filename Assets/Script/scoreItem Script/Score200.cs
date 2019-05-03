
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Score200 : MonoBehaviour, ICollisionAction
{

    private int scroe = 1000;

    public void CollisionAction(GameObject ob)
    {
        ob.GetComponent<GameController>().subScore(scroe);
        Destroy(this.gameObject);
    }

}
