using UnityEngine;

public class Bombish : MonoBehaviour
{
    [SerializeField] private float BombDMG = 200;

    void OnTriggerEnter2D(Collider2D collision)
    {
        Damageable enemy = collision.gameObject.GetComponent<Damageable>();

        if(enemy != null)
        {
            enemy.LoseLife(BombDMG);
        } 
    }
}
