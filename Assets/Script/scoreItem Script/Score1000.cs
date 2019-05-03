using UnityEngine;
using System.Collections;

public class Score1000 : MonoBehaviour , ScoreItemAction
{
    private int scroe = 1000;

    public int getScore() {
        return scroe;
    }
}
