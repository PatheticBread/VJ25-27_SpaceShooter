using UnityEngine;

public class Enemy : Damageable
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed = 1;
    [SerializeField] private int collisionDamage = 1;
    
    void Start()
    {
        rb.linearVelocity = Vector2.down * speed;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Damageable player = collision.gameObject.GetComponent<Damageable>();

        if(player != null)
        {
            player.LoseLife(collisionDamage);
        }
    }
}
