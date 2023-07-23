using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    GameControl m_gc;
    public ParticleSystem effect;
    private void Start()
    {
        m_gc = FindObjectOfType<GameControl>();
    }
    void OnMouseDown()
    {

        m_gc.Bomb();
        ParticleSystem explosionEffect = Instantiate(effect)
                                as ParticleSystem;
        explosionEffect.transform.position = transform.position;
        explosionEffect.Play();
        Destroy(gameObject);
    }
    
}
