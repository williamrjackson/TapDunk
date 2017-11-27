using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopHorizontalBorders : MonoBehaviour {
    [SerializeField]
    private float m_BorderBuffer = 10f;

	// Update is called once per frame
	void Update () {
        Vector2 ballPos = Camera.main.WorldToScreenPoint(transform.position);
        if (ballPos.x > Screen.width + m_BorderBuffer)
        {
            transform.position =
                Camera.main.ScreenToWorldPoint(new Vector3(-m_BorderBuffer, ballPos.y, transform.position.z - Camera.main.transform.position.z));

        }
        else if (ballPos.x < -m_BorderBuffer)
        {
            transform.position =
                Camera.main.ScreenToWorldPoint(new Vector3(Screen.width + m_BorderBuffer, ballPos.y, transform.position.z - Camera.main.transform.position.z));
        }

        if (ballPos.y < 0f)
        {
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(ballPos.x, 0f, 0f));
        }
    }
}
