using System.Data;
using UnityEngine;

public class DMGBooster : MonoBehaviour
{
  [SerializeField] StatType type;
    void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if(player != null)
        {
            player.Increment(type);
            Destroy(gameObject);
        }
    }
}

public enum StatType
{
    Damage,
    HP,
    BombCD
}
