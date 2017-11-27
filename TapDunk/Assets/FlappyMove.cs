using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyMove : MonoBehaviour {
    [SerializeField]
    private string m_Input;
    [SerializeField]
    private float m_VerticalBumpAmount = 8.5f;
    [SerializeField]
    private float m_HorizontalBumpAmount = 2f;
    [SerializeField]
    private float m_GravityScale = 3f;

    private Rigidbody2D m_RigidBody;
    private bool m_bMoveLeft = false;

    // Use this for initialization
    void Start () {
        m_RigidBody = GetComponent<Rigidbody2D>();
        m_RigidBody.gravityScale = m_GravityScale;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetButtonDown(m_Input) && !Timer.instance.timeIsUp)
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
    }
    public void SetBumpDiretion(bool moveLeft)
    {
        m_bMoveLeft = moveLeft;
    }
}
