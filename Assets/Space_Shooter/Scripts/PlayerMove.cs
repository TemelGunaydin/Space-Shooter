using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour {
    public float speed = 3f;
    public float minX, maxX, minZ, maxZ;
    public float rot;
    public GameObject bullet;
    public Transform bulletSpawnPos;
    public float nextFire = 1f;
    public GameObject explosion;
    public AudioClip deathSound;
    public GameObject gameOverImg, gameOverText,restart,mainMenu;
    
    private CameraFollow cam;
    private Vector3 movement;
    private Rigidbody rigid;
    private AudioSource audio;
    private float timer;
   
    void Start () {
        rigid = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>();
	}

    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Move(h, v);
        if(( Input.GetButton("Fire1") || Input.GetKey(KeyCode.Space)) && timer > nextFire)
        {
            Shoot();
        }
    }

    void Move(float h, float v)
    {
        movement.Set(h, 0, v);
        // movement = new Vector3(h, 0, v);
        movement = movement * speed * Time.deltaTime;
        Vector3 input = movement.normalized;
        float magnitude = input.magnitude;
        rigid.MovePosition(transform.position + movement);
        rigid.position = new Vector3(Mathf.Clamp(rigid.position.x, minX, maxX), 0, Mathf.Clamp(rigid.position.z, minZ, maxZ));
       
        rigid.rotation = Quaternion.Euler(0, 0, -movement.x * rot);
    }

    void Shoot()
    {
        Instantiate(bullet, bulletSpawnPos.position, bulletSpawnPos.rotation);
        audio.Play();
        timer = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            Instantiate(explosion, transform.position, transform.rotation);
            gameOverImg.SetActive(true);
            gameOverText.SetActive(true);
            restart.SetActive(true);
            mainMenu.SetActive(true);
            AudioSource.PlayClipAtPoint(deathSound, transform.position);
            cam.enabled = false;    
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
