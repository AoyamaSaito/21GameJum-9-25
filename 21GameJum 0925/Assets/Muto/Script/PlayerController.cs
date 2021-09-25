using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] float m_moveSpeed = 1f;
    [SerializeField] float m_jumpSpeed = 0f;
    [SerializeField] string m_groundTag = " ";
    [SerializeField] string m_damageTag = " ";
    [SerializeField] UnityEvent m_event = default;

    bool isJump;

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
        m_rb.AddForce(m_vectorH * m_moveSpeed, ForceMode2D.Force);
    }
    public void InputJump()
    {
        if (!isJump)
        {
            m_rb.AddForce(m_vectorV * m_jumpSpeed, ForceMode2D.Impulse);
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
}
