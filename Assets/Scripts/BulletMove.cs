using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    // public float moveSpeed = 2f;

    Rigidbody rigidbody;
    public float power = 1000;

    public GameObject explosionFactory;
    public float explosionRange = 5;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(transform.up * power);
    }

    // Update is called once per frame
    void Update()
    {
        // transform.position += transform.up * moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Destroy(other.gameObject);
        GameObject explosion = Instantiate(explosionFactory);
        explosion.transform.position = transform.position;
        Destroy(explosion, 3);

        // if (other.gameObject.tag == "Obstacle")
        //     Destroy(other.gameObject);
        // ObstacleManager.instance.CheckExplosion(transform.position, explosionRange);


        Collider[] cols = Physics.OverlapSphere(transform.position, explosionRange);
        for (int i = cols.Length - 1; i >= 0; i--)
        {
            if (cols[i].gameObject.tag == "Obstacle")
            {
                Destroy(cols[i].gameObject);
            }
        }

        Destroy(gameObject);
    }
}

