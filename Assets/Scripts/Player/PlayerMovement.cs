using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// [State Design Pattern - Client]
/// Define Movement of Main Character
/// </summary>
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

    //movementController for controlling Animation Transition of Character (using State Design Pattern)
    private MoveController _moveController;

    // Start is called before the first frame update
    void Start()
    {
        //instantiate movement controller
        _moveController = GetComponent<MoveController>();
    }

    // Update is called once per frame
    void Update()
    {
        //get input movement
        verticalMove = Input.GetAxisRaw("Vertical");
        horizontalMove = Input.GetAxisRaw("Horizontal");

        //change Animation following move Direction (using Controller - State Design Pattern)
        if (verticalMove > 0)
        {
            _moveController.MoveUpAnimation();
        } else if (verticalMove < 0)
        {
            _moveController.MoveDownAnimation();
        }
        if (horizontalMove > 0)
        {
            _moveController.MoveRightAnimation();
        } else if (horizontalMove < 0)
        {
            _moveController.MoveLeftAnimation();
        }
        
    }

    private void FixedUpdate()
    {
        //Move character: may end up going around
        rb.velocity = new Vector2(horizontalMove * Speed, verticalMove * Speed);
        //Alternative: if get flipped -> movement gets wrong
        //transform.Translate(new Vector2(horizontalMove, verticalMove) * Speed * Time.deltaTime);
    }
}
