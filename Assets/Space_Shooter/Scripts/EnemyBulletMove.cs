using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletMove : MonoBehaviour {

    public float speed;

    private Rigidbody rigid;


    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }


    void Update()
    {


        rigid.velocity = -transform.forward * speed;
    }



}
