using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LV2 : MonoBehaviour
{
    public ParticleSystem effect;
    GameControl m_gc;
    private void Start()
    {
        m_gc = FindObjectOfType<GameControl>();
    }
    void OnMouseDown()
    {
        m_gc.I2();
        ParticleSystem explosionEffect = Instantiate(effect)
                                as ParticleSystem;
        explosionEffect.transform.position = transform.position;
        explosionEffect.Play();
        Destroy(gameObject);
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DeadZone"))
        {
            m_gc.SetGameover();
        }
    }
}
