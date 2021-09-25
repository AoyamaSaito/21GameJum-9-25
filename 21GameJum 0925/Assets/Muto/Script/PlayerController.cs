using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] float m_moveSpeed = 1f;
    [SerializeField] float m_jumpSpeed = 0f;
    [SerializeField] string m_groundTag = " ";

    bool isJump;

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
        m_rb.AddForce(this.transform.right * m_moveSpeed, ForceMode2D.Force);
    }
    public void InputJump()
    {
        if (!isJump)
        {
            m_rb.AddForce(this.transform.up * m_jumpSpeed, ForceMode2D.Impulse);
            isJump = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == m_groundTag)
        {
            isJump = false;
        }
    }
}
