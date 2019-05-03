using UnityEngine;
using System.Collections;

public class Score1000 : MonoBehaviour , ICollisionAction
{
    private int scroe = 1000;

    public void CollisionAction(GameObject ob) {
        ob.GetComponent<GameController>().subScore(scroe);
        Destroy(this.gameObject);
    }
}
