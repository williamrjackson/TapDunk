using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlapReporter : MonoBehaviour {
    public bool isOverlapping = false;
    // Use this for initialization
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<BasketballBehavior>())
        {
            isOverlapping = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<BasketballBehavior>())
        {
            isOverlapping = false;
        }
    }

}
