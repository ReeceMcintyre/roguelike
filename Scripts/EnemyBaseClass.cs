using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseClass : MonoBehaviour {

    public SpriteRenderer enemySprite;
    public Transform enemyTransform;
    public Transform bulletSpawn;
    public Rigidbody2D Bullet;
    public float fireForce = 30f;
    public float fireRate;

    float min = 3f;
    float max = 3f;
    private float nextFire;


    void Start()
    {
        //the minimum and maximum distances the character can move along the x axis
        min = transform.position.x;
        max = transform.position.x+3;
    }

    void Update()
    {
        transform.position = new Vector3(Mathf.PingPong(Time.time * 2, min - max) + min, //setting the transfrom to pingpong through a t value which is never larger than length, length being min - max
            transform.position.y, transform.position.z);

        //making the enemy have a firerate - if the time is less than the next fire (defined below) then call the Fire function
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate; //time inbetween shots

            Fire();
        }
        return;
    }

    void Fire()
    {
        Rigidbody2D bulletInstance = Instantiate(Bullet, bulletSpawn.position, bulletSpawn.rotation) as Rigidbody2D; //a rigidbody instance of the bullet prefab

        //apply a force to the instance of the bullet prefabs spawn position - then in the inspector lock the y pos to make it travel as wanted
        bulletInstance.AddForce(bulletSpawn.transform.position * fireForce); 
    }
}
