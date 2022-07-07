using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //for movement
    float horizontalMove = 0f;
    float verticalMove = 0f;
    [SerializeField]
    private Rigidbody2D rb;
    //movement speed
    [SerializeField]
    public float Speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //get input movement
        verticalMove = Input.GetAxisRaw("Vertical");
        horizontalMove = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        //move character
        rb.velocity = new Vector2(horizontalMove * Speed, verticalMove * Speed);
    }
}
