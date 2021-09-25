using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] int m_magnification = 3;
    [SerializeField] float m_speedUp = 0.5f;
    [SerializeField] float m_moveSpeed = 1f;
    [SerializeField] float m_jumpSpeed = 0f;
    [SerializeField] string m_groundTag = " ";
    [SerializeField] string m_damageTag = " ";
    [SerializeField] UnityEvent m_event = default;
    [SerializeField] StageManager SM;

    bool isJump;
    int m_count = 0;

    Vector2 m_vectorH = Vector2.right;
    Vector2 m_vectorV = Vector2.up;
    Rigidbody2D m_rb;

    private void Start()
    {
        m_rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        MoveUpDate();
    }
    void MoveUpDate()
    {
        m_rb.velocity = new Vector2(m_moveSpeed, m_rb.velocity.y);
    }
    public void InputJump()
    {
        if (!isJump)
        {
            m_rb.velocity= new Vector2(m_rb.velocity.x, m_jumpSpeed);
            isJump = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == m_groundTag)
        {
            isJump = false;
        }

        if (collision.gameObject.tag == m_damageTag)
        {
            m_event.Invoke();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MapGenerator")
        {
            SM.CreateStage();
            m_count++;
            if (m_count % m_magnification == 0 && m_count != 0)
            {
                m_moveSpeed += m_speedUp;
            }
        }
    }

}
