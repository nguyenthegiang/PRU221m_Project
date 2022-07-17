using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// [State Deisgn Pattern - Client: Main Character Movement]
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
    [SerializeField]
    private bool useArrowKey = false;   //to determine which buttons to use to move

    //For State Design Pattern
    //movementController for controlling Animation Transition of Character (using State Design Pattern)
    private MoveController _moveController;

    // Start is called before the first frame update
    void Start()
    {
        //For Command Pattern
        //Determine whether to use WASD or Arrow Key for Moving Commands
        if (useArrowKey)
        {
            ChangeButtonUp("UpArrow");
            ChangeButtonDown("DownArrow");
            ChangeButtonLeft("LeftArrow");
            ChangeButtonRight("RightArrow");
        } else
        {
            //Client: call to ChangeButton() methods to set buttons that call the Command
            ChangeButtonUp("W");
            ChangeButtonDown("S");
            ChangeButtonLeft("A");
            ChangeButtonRight("D");
        }
        btnStop = new Stop();   //Stop command won't need a button

        //For State Design Pattern
        //instantiate movement controller
        _moveController = GetComponent<MoveController>();
    }

    // Update is called once per frame
    void Update()
    {
        //For Command Pattern
        //Call to Execute() of each Command
        if (Input.GetKey(KeyCode.A))
        {
            btnA.Execute(rb2d, Speed, _moveController);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            btnS.Execute(rb2d, Speed, _moveController);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            btnD.Execute(rb2d, Speed, _moveController);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            btnW.Execute(rb2d, Speed, _moveController);
        } else
        {
            btnStop.Execute(rb2d, Speed, _moveController);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            btnLeftArrow.Execute(rb2d, Speed, _moveController);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            btnRightArrow.Execute(rb2d, Speed, _moveController);
        }
        else if(Input.GetKey(KeyCode.UpArrow))
        {
            btnUpArrow.Execute(rb2d, Speed, _moveController);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            btnDownArrow.Execute(rb2d, Speed, _moveController);
        }
    }

    //For Client to call: Change the button that will call the Command
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

    //For Client to call: Change the button that will call the Command
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

    //For Client to call: Change the button that will call the Command
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

    //For Client to call: Change the button that will call the Command
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
