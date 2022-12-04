using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gator : MonoBehaviour
{
    public Transform[] positions;//Array which contains enemy's patrol positions

    [Header("Speed")]
    public float speed;
    public float speedMax;
    public float speedMovement;
    public float factorSpeedAttack;

    [Header("Attack")]
    public int damage;
    public float timeToAttackPlayer;
    public GameObject player;

    Vector3[] points;//array which I'm going to save the positions from the Transform array
    Vector3 posToGo;
    SpriteRenderer spriteRenderer;
    CircleCollider2D circleCollider;
    int i;
    float timer;
    bool attacking;
    PlayerHealth playerHealth;

    // Start is called before the first frame update
    private void Awake()
    {        
        spriteRenderer = GetComponent<SpriteRenderer>();
        circleCollider = GetComponent<CircleCollider2D>();
        playerHealth = player.GetComponent<PlayerHealth>();   
        //playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();   
    }
    private void Start()
    {
        speed = speedMovement;
        points = new Vector3[positions.Length];
        for (int i = 0; i < positions.Length; i++)
        {
            points[i] = positions[i].position;
        }
        posToGo = points[0];
    }
    // Update is called once per frame
    void Update()
    {
        //transform.position = 
    }
}
