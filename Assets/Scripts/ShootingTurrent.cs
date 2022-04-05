using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingTurrent : MonoBehaviour
{
    
    public float Range;

    public Transform Target;

    bool Detected = false;

    Vector2 Direction;

    public GameObject Alarmlight;
    // Start is called before the first frame update
    public GameObject Gun;

    public GameObject Bullet;

    public float FireRate;

    float ConstantFire= 0;

    public Transform ShootPoint;

    public float Force;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 targetPos = Target.position;

        Direction = targetPos - (Vector2)transform.position;

        RaycastHit2D rayInfo = Physics2D.Raycast(transform.position, Direction, Range);

        if (rayInfo)
        {
            if (rayInfo.collider.gameObject.tag == "Player")
            {
                if (Detected == false)
                {
                    Detected = true;
                    Alarmlight.GetComponent<SpriteRenderer>().color = Color.red;

                }
            }
            else
            {

                if (Detected == true)
                {
                    Detected = false;
                    Alarmlight.GetComponent<SpriteRenderer>().color = Color.green;
                }

            }
        }
        if (Detected)
        {
            Gun.transform.up = Direction;
            if (Time.time > ConstantFire)
            {
                ConstantFire = Time.time + 1 / FireRate;
                shoot();
            }
        }

        void shoot()

        {
          GameObject BulletIns =  Instantiate(Bullet, ShootPoint.position, Quaternion.identity);
          BulletIns.GetComponent<Rigidbody>().AddForce(Direction* Force);
        }
}

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, Range);
    }
    }

