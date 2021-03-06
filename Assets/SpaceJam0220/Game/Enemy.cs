﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
 public float speed = 5f;
    
    public bool canShoot;
    public bool canMove = true;
    
    public float bound_X = -11f;
    
    public Transform attack_Point;
    public GameObject bulletPrefab;
    
    public AudioSource explosionSound;
    
    // Start is called before the first frame update
    void Awake()
    {
            explosionSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = transform.position;
        temp.x -= speed * Time.deltaTime;
        transform.position = temp;
        
        if (temp.x < bound_X)
            gameObject.SetActive(false);
    }
    
    void TurnOffGameObject()
    {
        gameObject.SetActive(false);
    }
    
    void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Bullet") {
            canMove = false;
        }
        Invoke("TurnOffGameObject", 0.1f);
        explosionSound.Play();
    }
}
