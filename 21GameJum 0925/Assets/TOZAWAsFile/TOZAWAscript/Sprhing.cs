using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprhing : MonoBehaviour
{
    Animator m_SphringAnim = default;
    
    private void Start()
    {
        m_SphringAnim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        m_SphringAnim.SetBool("DoSphring", true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        m_SphringAnim.SetBool("DoSphring", false);
    }
    
}
