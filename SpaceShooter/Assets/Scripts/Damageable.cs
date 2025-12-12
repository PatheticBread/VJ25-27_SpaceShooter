using UnityEngine;

public class Damageable : MonoBehaviour
{
    [SerializeField] private int HP = 3;
     [SerializeField] private GameObject explosion;
    
    public void LoseLife(int DMGMULT)
    {
        HP -= DMGMULT;

        print(gameObject.name + "Owwie T-T - " + DMGMULT + " DMG Taken! = "+ HP);

        if(HP<=0)
        {
            Perish();
        }
    }
    public void Perish()
    {
        Destroy(gameObject); // DEATH
            
            if(explosion !=null)
            {
                GameObject explosionInstance = Instantiate(explosion,transform.position,Quaternion.identity);
                Destroy(explosionInstance, 1);
            }
    }
}
