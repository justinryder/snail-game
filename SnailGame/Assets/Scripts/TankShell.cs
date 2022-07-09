using UnityEngine;
using System.Collections;

public class TankShell : MonoBehaviour 
{
    public GameObject Explosion;

    void OnCollisionEnter()
    {
        if (Explosion != null)
        {
            GameObject.Instantiate(Explosion, transform.position, Quaternion.identity);
        }

        AudioHandler.PlayExplosion();

        Destroy(gameObject);

        Collider[] colliders = Physics.OverlapSphere(transform.position, 3f);
        
        foreach(Collider collided in colliders)
        {
            Snail snail = collided.gameObject.GetComponent<Snail>();
            
            if(snail != null)
            {
                snail.Attack();
            }
        }
    }
}
