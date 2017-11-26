using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour {
    public static Timer instance;
    public Image timerBar;
    public Text scoreText;
    public bool timeIsUp = false;
    public float timePerShot = 5f;
    private float m_CurrentTime;
    private int m_Score = 0;
    private bool m_IsTiming = false;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }
    private void Start()
    {
        ResetTimer();
        m_IsTiming = true;
    }
    // Update is called once per frame
    void Update () {

        if (m_IsTiming)
        {
            m_CurrentTime -= Time.deltaTime;
        }

        if (m_CurrentTime < 0f)
            timeIsUp = true;

        timerBar.fillAmount = Mathf.Lerp(0, 1, Mathf.InverseLerp(0, timePerShot, m_CurrentTime));
		
	}

    public void ResetTimer()
    {
        timeIsUp = false;
        m_CurrentTime = timePerShot;
    }

    public int score { get { return m_Score; }
        set {
            m_Score = value;
            UpdateScoreDisplay();
        } }
    private void UpdateScoreDisplay()
    {
        scoreText.text = m_Score.ToString();
    }
}
