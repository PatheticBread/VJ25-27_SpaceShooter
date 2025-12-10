using UnityEngine;

public class Danmaku : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed = 1;
    [SerializeField] private int bulletdmg;
    void Start()
    {
        rb.linearVelocity = Vector2.up * speed;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Damageable enemy = collision.gameObject.GetComponent<Damageable>();

        if(enemy != null)
        {
            enemy.LoseLife(bulletdmg);
            Destroy(gameObject);
        }
        WALLOFDEATH deathbarrier = collision.gameObject.GetComponent<WALLOFDEATH>();
        {
            Destroy(gameObject);
        }  
    }

}
