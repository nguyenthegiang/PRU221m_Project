using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// [State Design Pattern - Client]
/// [Command Pattern]
/// Define Movement of Main Character
/// </summary>
public class InputHandler : MonoBehaviour
{
    //For Command Pattern
    [SerializeField]
    private Rigidbody2D rb2d;
    private Command btnA, btnS, btnD, btnW, 
        btnLeftArrow, btnRightArrow, btnUpArrow, btnDownArrow, btnStop;
    [SerializeField]
    public float Speed = 10f;

    //For State Design Pattern
    //movementController for controlling Animation Transition of Character (using State Design Pattern)
    private MoveController _moveController;

    // Start is called before the first frame update
    void Start()
    {
        //For Command Pattern
        ChangeButtonUp("W");
        ChangeButtonDown("S");
        ChangeButtonLeft("A");
        ChangeButtonRight("D");

        btnStop = new Stop();

        //For State Design Pattern
        //instantiate movement controller
        _moveController = GetComponent<MoveController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            btnA.Execute(rb2d, Speed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            btnS.Execute(rb2d, Speed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            btnD.Execute(rb2d, Speed);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            btnW.Execute(rb2d, Speed);
        } else
        {
            btnStop.Execute(rb2d, Speed);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            btnLeftArrow.Execute(rb2d, Speed);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            btnRightArrow.Execute(rb2d, Speed);
        }
        else if(Input.GetKey(KeyCode.UpArrow))
        {
            btnUpArrow.Execute(rb2d, Speed);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            btnDownArrow.Execute(rb2d, Speed);
        }
    }


    public void ChangeButtonLeft(string buttonName)
    {
        switch (buttonName)
        {
            case "A":
                btnLeftArrow = new DoNothing();
                btnA = new MoveLeft();
                break;
            case "LeftArrow":
                btnA = new DoNothing();
                btnLeftArrow = new MoveLeft();
                break;
            default:
                break;
        }
    }

    public void ChangeButtonRight(string buttonName)
    {
        switch (buttonName)
        {
            case "D":
                btnRightArrow = new DoNothing();
                btnD = new MoveRight();
                break;
            case "RightArrow":
                btnD = new DoNothing();
                btnRightArrow = new MoveRight();
                break;
            default:
                break;
        }
    }

    public void ChangeButtonUp(string buttonName)
    {
        switch (buttonName)
        {
            case "W":
                btnUpArrow = new DoNothing();
                btnW = new MoveUp();
                break;
            case "UpArrow":
                btnW = new DoNothing();
                btnUpArrow = new MoveUp();
                break;
            default:
                break;
        }
    }

    public void ChangeButtonDown(string buttonName)
    {
        switch (buttonName)
        {
            case "S":
                btnDownArrow = new DoNothing();
                btnS = new MoveDown();
                break;
            case "DownArrow":
                btnS = new DoNothing();
                btnDownArrow = new MoveDown();
                break;
            default:
                break;
        }
    }
}
