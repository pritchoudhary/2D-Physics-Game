using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
    public float speed = 30;

    void Start() {
        // Initial Velocity
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
    }
    
    float hitFactor(Vector2 ballPos, Vector2 racketPos,float racketHeight)
    {
        return (ballPos.y - racketPos.y) / racketHeight;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
      
        // Hit the left Racket?
        if (col.gameObject.name == "RacketLeft")
        {
            // Calculate hit Factor
            float y = hitFactor(transform.position,col.transform.position,col.collider.bounds.size.y);

            // Calculate direction
            Vector2 dir = new Vector2(1, y).normalized;

            // Set Velocity
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }

        // Hit the right Racket?
        if (col.gameObject.name == "RacketRight")
        {
            // Calculate hit Factor
            float y = hitFactor(transform.position,col.transform.position,col.collider.bounds.size.y);

            // Calculate direction
            Vector2 dir = new Vector2(-1, y).normalized;
            
            // Set Velocity
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }
    }
}
