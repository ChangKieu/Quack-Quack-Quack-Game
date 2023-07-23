using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rainbow : MonoBehaviour
{
    GameControl m_gc;
    private void Start()
    {
        m_gc = FindObjectOfType<GameControl>();
    }
    void OnMouseDown()
    {
        m_gc.Rainbow();
        Destroy(gameObject);
    }
}
