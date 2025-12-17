using UnityEngine;

public class Danmaku : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed = 1;
    [SerializeField] private int bulletdmg;
    [SerializeField] private GameObject HitFX;

    void Start()
    {
        rb.linearVelocity = Vector2.up * speed;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        Damageable enemy = collision.gameObject.GetComponent<Damageable>();

        if(enemy != null)
        {
            enemy.LoseLife(bulletdmg);
            if(HitFX !=null)
                {
                    GameObject HitInstance = Instantiate(HitFX,transform.position,Quaternion.identity);
                    Destroy(HitInstance,1);
                }
        } 
    }

    public void SetDamage(int newDamage)
    {
        bulletdmg = newDamage;
    }

}
