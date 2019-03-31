using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement2 : MonoBehaviour {


    [Header("Düşman Gemisi özellikleri")]
    public float nextFire = 3f;
    public GameObject enemyBullet;
    public Transform bulletSpawn;
    public Transform startPos, pos1, pos2;
    public float speed;
    public GameObject explosion;
    public AudioClip deathSound;
 

    private Rigidbody rigid;
    private Vector3 nextPos;
    private AudioSource audio;
    private float timer;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }

    private void Start()
    {
        nextPos = startPos.position;
    }


    void Update () {

        timer += Time.deltaTime;

        if(transform.position == pos1.position)
        {
            nextPos = pos2.position;
        }
        if(transform.position == pos2.position)
        {
            nextPos = pos1.position;
        }


        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);

        if (timer > nextFire)
        {
            Shoot();
        }
        
    }

    void Shoot()
    {
        Instantiate(enemyBullet, bulletSpawn.position, bulletSpawn.rotation);
        audio.Play();
        timer = 0f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Instantiate(explosion, transform.position, transform.rotation);
            ScoreManager.score += 10;
            AudioSource.PlayClipAtPoint(deathSound, transform.position);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

}
