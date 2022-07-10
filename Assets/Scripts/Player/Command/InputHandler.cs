using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public Rigidbody2D character;
    private Command btnA, btnS, btnD, btnW, btnL, btnR, btnU, btnD2;
    protected float _moveDistance = 1f;

    // Start is called before the first frame update
    void Start()
    {
        btnL = new DoNothing();
        btnR = new DoNothing();
        btnU = new DoNothing();
        btnD2 = new DoNothing();

        btnA = new MoveLeft();
        btnS = new MoveDown();
        btnD = new MoveRight();
        btnW = new MoveUp();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            btnA.Execute(character);
        }else if (Input.GetKeyDown(KeyCode.S))
        {
            btnS.Execute(character);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            btnD.Execute(character);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            btnW.Execute(character);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            btnL.Execute(character);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            btnR.Execute(character);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            btnU.Execute(character);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            btnD2.Execute(character);
        }
    }
    public void ChangeButtonMove(string buttonName)
    {
        switch (buttonName)
        {
            case "A":
                btnL = new DoNothing();
                btnA = new MoveLeft();
                break;
            case "LeftArrow":
                btnA = new DoNothing();
                btnL = new MoveLeft();
                break;

            case "S":
                btnL = new DoNothing();
                btnA = new MoveDown();
                break;
            case "DownArrow":
                btnA = new DoNothing();
                btnL = new MoveDown();
                break;

            case "D":
                btnL = new DoNothing();
                btnA = new MoveRight();
                break;
            case "RightArrow":
                btnA = new DoNothing();
                btnL = new MoveRight();
                break;

            case "W":
                btnL = new DoNothing();
                btnA = new MoveUp();
                break;
            case "UpArrow":
                btnA = new DoNothing();
                btnL = new MoveUp();
                break;
            default:
                break;
        }
    }
}
