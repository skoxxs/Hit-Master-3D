using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int upForce = 1000;
    [SerializeField] private int Force = 1000;
    [SerializeField] private int damage = 50;


    private bool live = true;
  

    private void OnCollisionEnter(Collision collision)
    {
        if (!live) return;
        live = false;
        EnemyHeals en = collision.transform.gameObject.GetComponentInParent<EnemyHeals>();
        if (en != null) en.TakeDamage(damage);
        Rigidbody rb = collision.transform.gameObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(0, upForce, 0);
            rb.AddForce(Vector3.forward* Force);
        }


        Destroy(this.gameObject);
    }
}
