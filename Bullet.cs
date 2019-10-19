using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb2D;
    public float selfDestructionTime = 5f;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.velocity = transform.right * speed;
        Destroy(gameObject, selfDestructionTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("obstacle")){
            Destroy(gameObject);
        }
    }

}
