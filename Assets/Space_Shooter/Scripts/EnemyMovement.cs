using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {


    public float speed = 5f;
    public float nextFire = 3f;
    public GameObject enemyBullet;
    public Transform bulletSpawn;
    public GameObject explosion;
    public AudioClip deathSound;

    private Rigidbody rigid;
    private float timer;
    private AudioSource audio;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }


	void Update () {

        timer += Time.deltaTime;

        rigid.velocity = -transform.forward * speed;
        if(timer > nextFire)
        {
            Shoot();
        }

	}

    void Shoot()
    {
        Instantiate(enemyBullet,bulletSpawn.position, bulletSpawn.rotation);
        audio.Play();
        timer = 0f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Instantiate(explosion, transform.position, transform.rotation);
            ScoreManager.score += 10;            
            AudioSource.PlayClipAtPoint(deathSound, transform.position);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
       
    }



}
