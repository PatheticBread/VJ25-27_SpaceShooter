using UnityEngine;

public class Danmaku : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed = 1;
    [SerializeField] private float bulletdmg;
    [SerializeField] private GameObject HitFX;
    [SerializeField] private float Rotation;

    void Start()
    {
        rb.transform.Rotate(0f,0f,Rotation);
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

    public void SetDamage(float newDamage)
    {
        bulletdmg = newDamage;
    }

}
