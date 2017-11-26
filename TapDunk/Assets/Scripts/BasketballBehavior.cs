using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketballBehavior : MonoBehaviour {
    [SerializeField]
    private float m_VerticalBumpAmount = 6f;
    [SerializeField]
    private float m_HorizontalBumpAmount = 2f;
    [SerializeField]
    private ManageHoops m_HoopManager;
    [SerializeField]
    private bool m_bMoveLeft = false;
    private Rigidbody2D m_RigidBody;
    private float m_BorderBuffer = 10f;

	// Use this for initialization
	void Start () {
        m_RigidBody = GetComponent<Rigidbody2D>();
	}
	
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

        if (Input.GetMouseButtonDown(0) && !Timer.instance.timeIsUp)
        {
            Bump();
        }
    }

    private void Bump()
    {
        m_RigidBody.velocity = Vector2.zero;
        if (m_bMoveLeft)
        {
            m_RigidBody.AddForce((Vector3.up * m_VerticalBumpAmount + Vector3.right * -m_HorizontalBumpAmount), ForceMode2D.Impulse);
        }
        else
        {
            m_RigidBody.AddForce((Vector3.up * m_VerticalBumpAmount + Vector3.right * m_HorizontalBumpAmount), ForceMode2D.Impulse);
        }
    }

    public void ToggleBumpDirection()
    {
        m_bMoveLeft = !m_bMoveLeft;
        m_HoopManager.ShiftHoops();
    }
}
