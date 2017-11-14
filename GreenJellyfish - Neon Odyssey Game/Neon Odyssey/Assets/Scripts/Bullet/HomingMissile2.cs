using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissile2 : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && !other.gameObject.GetComponent<Bullet>())
        {
            other.gameObject.GetComponent<Enemy>().ChangeHealth(-1);
            Destroy(gameObject);
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("Collisions") || other.gameObject.tag == "Door")
        {
            Destroy(gameObject);
        }
    }
}
