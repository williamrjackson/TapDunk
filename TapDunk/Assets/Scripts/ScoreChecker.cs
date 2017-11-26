using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreChecker : MonoBehaviour {
    
    public OverlapReporter BottomCheck;
    public BasketballBehavior Ball;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == Ball.gameObject && !BottomCheck.isOverlapping)
        {
            Timer.instance.score++;
            Ball.ToggleBumpDirection();
            Timer.instance.ResetTimer();
        }
    }
}
