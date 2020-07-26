using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mvmt : MonoBehaviour
{
    public float moveSpeed = 0.1f;
    
    [SerializeField]
    private GameObject player_Bullet;
    
    [SerializeField]
    private Transform attack_point;
    
    public float attack_Timer = 0.35f;
    private float current_Attack_Timer;
    private bool canAttack;
    
    private AudioSource laserAudio;
    
    void Awake()
    {
        laserAudio = GetComponent<AudioSource>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        current_Attack_Timer = attack_Timer;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        Vector3 mov = new Vector3(0f, Input.GetAxis("Vertical"),  0f);
        if (transform.position.x < 9.5 || transform.position.x > -5.8) {
        transform.position += movement * Time.deltaTime * moveSpeed;
        }
        if (transform.position.x > 9.5 || transform.position.x < -5.8) {
        transform.position -= movement * Time.deltaTime * moveSpeed;
        }
        if (transform.position.y < 1.4 || transform.position.y > -9.5) {
        transform.position += mov * Time.deltaTime * moveSpeed;
        }
        if (transform.position.y > 1.4 || transform.position.y < -9.5) {
        transform.position -= mov * Time.deltaTime * moveSpeed;
        }
        Attack();
    }
    
    void Attack()
    {
        attack_Timer += Time.deltaTime;
        if (attack_Timer > current_Attack_Timer) {
        canAttack = true;
        }
        
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (canAttack) {
                canAttack = false;
                attack_Timer = 0f;
                
                Instantiate(player_Bullet, attack_point.position, Quaternion.identity);
                
                laserAudio.Play();
            }
        }
    }
}