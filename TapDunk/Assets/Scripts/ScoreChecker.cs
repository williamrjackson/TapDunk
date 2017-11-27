using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreChecker : MonoBehaviour {
    
    public OverlapReporter bottomOverlapReporter;
    public FlappyMove ball;
    public ManageHoops hoopManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == ball.gameObject && !bottomOverlapReporter.isOverlapping)
        {
            Timer.instance.score++;
            ball.ToggleBumpDirection();
            Timer.instance.ResetTimer();
            hoopManager.ShiftHoops();
        }
    }
}
