using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Public Variables")]

    public float speedMove = 0.001f;
    public float forceJump = 0.001f;

    [Header("Private Variables")]

    [SerializeField]
    private float inputHorizontal = 0.0f;
    [SerializeField]
    private bool jumpAble = false;

    private Rigidbody2D rb2d;
    private Collider2D col;

    private void Awake()
    {
        rb2d = gameObject.AddComponent<Rigidbody2D>();
        col = gameObject.AddComponent<BoxCollider2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        inputHorizontal = Input.GetAxis("Horizontal");
        // inputVertical = Input.GetAxis("Vertical");
        
        //var xPos = inputHorizontal * speedMove;
        //var yPos = inputVertical * forceJump;

        //move
        transform.Translate(Vector2.right * inputHorizontal * speedMove * Time.deltaTime);
        //jump twice
        if(Input.GetAxis("Jump") > 0 && jumpAble)
        {
            rb2d.AddForce(transform.up * forceJump);
            jumpAble = false;
           
        }
       
        //turn round
        if(inputHorizontal < 0)
        {
            transform.localScale = new Vector2(-1, transform.localScale.y);
        }
        if(inputHorizontal > 0)
        {
            transform.localScale = new Vector2(1, transform.localScale.y);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //jumpCount clear
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("HitGround");
            jumpAble = true;
        }
    }

}
