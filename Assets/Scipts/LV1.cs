using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LV1 : MonoBehaviour
{
    public ParticleSystem effect;
    GameControl m_gc;
    private void Start()
    {
        m_gc=FindObjectOfType<GameControl>();
    }

    public void OnMouseDown()
    {
        m_gc.I1();
        ParticleSystem explosionEffect = Instantiate(effect)
                                as ParticleSystem;
        explosionEffect.transform.position = transform.position;
        explosionEffect.Play();
        Destroy(gameObject);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("DeadZone"))
        {
            m_gc.SetGameover();
        }
    }
}
