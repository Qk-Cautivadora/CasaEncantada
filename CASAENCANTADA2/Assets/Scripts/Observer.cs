using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    float MomentoDeteccion = 0f;
    public AudioSource SonidoAlerta;
    public Transform player;
    public GameEnding gameEnding;

    bool m_IsPlayerInRange;

    public void Start()
    {
        SonidoAlerta = this.gameObject.GetComponent<AudioSource>();
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = true;
            MomentoDeteccion = Time.time;
            SonidoAlerta.PlayOneShot(SonidoAlerta.clip);
        }
    }

    void OnTriggerExit (Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = false;
            

        }
    }

    void Update ()
    {
        if (m_IsPlayerInRange)
        {
          
            {
                Vector3 direction = player.position - transform.position + Vector3.up;
                Ray ray = new Ray(transform.position, direction);
                RaycastHit raycastHit;

                if (Physics.Raycast(ray, out raycastHit))
                {
                    if (raycastHit.collider.transform == player)
                    {

                        if (Time.time >= MomentoDeteccion + 2f)
                            gameEnding.CaughtPlayer();
                    }
                }
            }
        }
    }
}
