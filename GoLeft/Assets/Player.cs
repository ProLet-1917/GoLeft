using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Variables")]

    public float speedMove = 0.001f;
    public float forceJump = 0.001f;

    [HideInInspector]

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float inputHorizonal = Input.GetAxis("Horizontal");
        float inputVertical = Input.GetAxis("Vertical");
        var xPos = inputHorizonal * speedMove;
        var yPos = inputVertical * forceJump;

        transform.position += new Vector3(xPos, yPos, 0);
        transform.localScale = new Vector2(inputHorizonal < 0 ? -1 : 1, transform.localScale.y);
    }
}
