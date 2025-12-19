
using UnityEngine;
using System.Collections;
using TMPro;

public class Player : Damageable
{
    [SerializeField] float speed = 1;
    [SerializeField] Danmaku bullet;
    [SerializeField] float ASPD = 1;
    [SerializeField] float P1Dmg = 1;
    [SerializeField] int BombCooldown = 20;
    [SerializeField] GameObject TheBomb;
    [SerializeField] TMPro.TextMeshProUGUI BOMBCOOLD;
    private bool CanBomb = true;
     
    Vector2 destination;
    void Start()
    {
        InvokeRepeating("Danmaku",0,ASPD);
    }
    void Update()
    {
       Shmoving();
       Bomb();
    }

    void FixedUpdate()
    {
        Vector2 InBetweens = Vector2.Lerp(transform.position, destination, speed*Time.fixedDeltaTime);
        transform.position = InBetweens; // A - C and returns B
    }

    void Danmaku()
    {
        Danmaku newbullet = Instantiate(bullet,transform.position, Quaternion.identity);
        newbullet.SetDamage(P1Dmg);
    }

    public void Increment(StatType stat)
    {
        if(stat == StatType.Damage)
        {
            P1Dmg += 0.5f;
        }
        if(stat == StatType.HP)
        {
            HealthGain();
        }
        if(stat == StatType.BombCD)
        {
            BombCooldown -= 2 ;
            if(BombCooldown < 2)
             BombCooldown = 2;
        }
    }

    void Shmoving()
    {
         Camera cam = Camera.main;

          
        if (Input.touchSupported && Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Vector3 worldPos = cam.ScreenToWorldPoint(new Vector3(
                touch.position.x,
                touch.position.y,
                cam.nearClipPlane  
            ));

            worldPos.z = transform.position.z;

            destination = worldPos;
        }

       
        else if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = cam.ScreenToWorldPoint(new Vector3(
                Input.mousePosition.x,
                Input.mousePosition.y,
                cam.nearClipPlane
            ));

            mousePos.z = transform.position.z;

            transform.position = mousePos;
        }
        else
        {
            destination = transform.position;
        }
    }

    void Bomb()
    {
        if( CanBomb && Input.GetMouseButtonDown(0) || CanBomb && Input.touchSupported && Input.touchCount > 0)
        {
            GameObject BombInstance = Instantiate(TheBomb,transform.position,Quaternion.identity);
            Destroy(BombInstance,1);
            print("Bombed!");
            StartCoroutine("BombCycle");
        }

    }
    IEnumerator BombCycle()
    {
        CanBomb = false;

        for(int i = BombCooldown; i >= 0; i--)
        {
            BOMBCOOLD.text = "Bomb? Cooldown = " + i.ToString();
            yield return new WaitForSeconds(1f);
        }
        CanBomb = true;
    }
}
