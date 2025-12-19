
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : Damageable
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed = 1;
    [SerializeField] private int collisionDamage = 1;
    [SerializeField] private Vector2 direction = Vector2.down;
   // [SerializeField] private UIManager UIMan;
    
    void Start()
    {
        rb.linearVelocity = direction * speed;
        rb.transform.Rotate(0f,0f,180f);
        // int totalScore = UIMan.totalScore; // isto n funciona simplesmente e do que noto não é necessário pra o projecto, logo omiti.
        // if(totalScore == 20000)
         // speed++;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Damageable player = collision.gameObject.GetComponent<Damageable>();

        if(player != null)
        {
            player.LoseLife(collisionDamage);
            LoseLife(1);
        }
        else if(collision.gameObject.CompareTag("Bullet") == false)
        {
            Perish();
        }
    }
}
