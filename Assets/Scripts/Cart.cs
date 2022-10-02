using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cart : MonoBehaviour
{
    [SerializeField] float speed = 3f;
    [SerializeField] GameObject spawner;
    Rigidbody2D rb;
    float lifespan = 7.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spawner = transform.parent.gameObject;
        if (spawner.GetComponent<CartSpawner>().shootLeft) {
            GetComponent<Transform>().localScale = new Vector3(-1, 1, 1);
            rb.velocity = new Vector2(-speed, 0);
        }
        else 
        {
            rb.velocity = new Vector2(speed, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        lifespan -= Time.deltaTime;
         if (lifespan < 0)
         {
            Destroy(this.gameObject);
         }
    }
}
