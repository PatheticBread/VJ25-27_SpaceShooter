using UnityEngine;
using TMPro;

public class Damageable : MonoBehaviour
{
    [SerializeField] private float HP = 3;
     [SerializeField] private GameObject explosion;

     [SerializeField] private int DeathCount;
     [SerializeField] TMPro.TextMeshProUGUI HpDisp;
    
    public void LoseLife(float DMGMULT)
    {
        HP -= DMGMULT;
        HealthDisplay();

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
    public void HealthGain()
    {
        if(HP<5)
         HP += 1;
        HealthDisplay();
    }
    public void HealthDisplay()
    {
        if(HpDisp != null)
          HpDisp.text = "Lives = " + HP.ToString();
    }

}
