using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    //For Command Pattern
    [SerializeField]
    private Rigidbody2D rb2d;
    private Command btnA, btnS, btnD, btnW, 
        btnLeftArrow, btnRightArrow, btnUpArrow, btnDownArrow, btnStop;
    [SerializeField]
    public float Speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        btnLeftArrow = new DoNothing();
        btnRightArrow = new DoNothing();
        btnUpArrow = new DoNothing();
        btnDownArrow = new DoNothing();

        btnA = new MoveLeft();
        btnS = new MoveDown();
        btnD = new MoveRight();
        btnW = new MoveUp();

        btnStop = new Stop();
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
    public void ChangeButtonMove(string buttonName)
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

            case "S":
                btnLeftArrow = new DoNothing();
                btnA = new MoveDown();
                break;
            case "DownArrow":
                btnA = new DoNothing();
                btnLeftArrow = new MoveDown();
                break;

            case "D":
                btnLeftArrow = new DoNothing();
                btnA = new MoveRight();
                break;
            case "RightArrow":
                btnA = new DoNothing();
                btnLeftArrow = new MoveRight();
                break;

            case "W":
                btnLeftArrow = new DoNothing();
                btnA = new MoveUp();
                break;
            case "UpArrow":
                btnA = new DoNothing();
                btnLeftArrow = new MoveUp();
                break;
            default:
                break;
        }
    }
}
