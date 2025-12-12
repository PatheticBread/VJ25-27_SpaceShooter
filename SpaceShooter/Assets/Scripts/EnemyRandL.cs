using UnityEngine;

public class EnemyRandL : Damageable
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed = 1;
    [SerializeField] private int collisionDamage = 1;
    [SerializeField] private bool IsLeft = true;
    
    void Start()
    {
        if(IsLeft == true)
        {
            rb.linearVelocity = Vector2.left * speed;
        }
        else
        {
            rb.linearVelocity = Vector2.right * speed;
        }
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
