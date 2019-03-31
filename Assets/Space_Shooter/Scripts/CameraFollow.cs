using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform player;
    public float speed;

    private Vector3 offset;
    
    // Use this for initialization
	void Start () {
        offset = transform.position - player.position;
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 fixedPos = player.position + offset;
        Vector3 nextPos = Vector3.Lerp(transform.position, fixedPos, speed * Time.deltaTime);
        transform.position = nextPos;



	}
}
