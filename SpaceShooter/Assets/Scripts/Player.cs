using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Damageable
{
    [SerializeField] float speed = 1;
    [SerializeField] GameObject Bullet;
    [SerializeField] float ASPD = 1;
     
    Vector2 destination;
    void Start()
    {
        InvokeRepeating("Danmaku",0,ASPD);
    }
    void Update()
    {
       Shmoving();
    }

    void FixedUpdate()
    {
        Vector2 InBetweens = Vector2.Lerp(transform.position, destination, speed*Time.fixedDeltaTime);
        transform.position = InBetweens; // A - C and returns B
    }

    void Danmaku()
    {
        Instantiate(Bullet,transform.position, Quaternion.identity);
        

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
}
