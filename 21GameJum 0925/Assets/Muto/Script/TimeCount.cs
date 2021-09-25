using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TimeCount : MonoBehaviour
{
    [SerializeField] float m_setTime = 3.5f;
    [SerializeField] Text m_timerText = default;
    [SerializeField] UnityEvent m_event = default;

    float m_time;
    bool isTime;
    private void Start()
    {
        m_time = m_setTime;
    }
    private void Update()
    {
        if (!isTime)
        {
            m_timerText.text = m_time.ToString("F0");
            m_time -= Time.deltaTime;
        }

        if (m_time < 0.5)
        {
            isTime = true;
            m_event.Invoke();
        }
    }
}
