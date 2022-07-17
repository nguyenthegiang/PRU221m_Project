using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// [State Deisgn Pattern: Main Character Movement]
/// Controlling all the states using Context
/// </summary>
public class MoveController : MonoBehaviour
{
    //Different Sprites for each state to use
    public Sprite MoveUpSprite;
    public Sprite MoveDownSprite;
    public Sprite MoveLeftSprite;
    public Sprite MoveRightSprite;

    //for States to change Sprite of GameObject
    public SpriteRenderer SpriteRenderer;

    // states of movement
    private IMoveState _moveDownState, _moveUpState, _moveLeftState, _moveRightState;

    //context class
    private MoveStateContext _moveStateContext;

    void Awake()
    {
        //instantiate spriteRenderer
        SpriteRenderer = GetComponent<SpriteRenderer>();

        //init state context and move states
        _moveStateContext = new MoveStateContext(this);
        //assign move states to gameObject
        _moveDownState = gameObject.AddComponent<MoveDownState>();
        _moveUpState = gameObject.AddComponent<MoveUpState>();
        _moveLeftState = gameObject.AddComponent<MoveLeftState>();
        _moveRightState = gameObject.AddComponent<MoveRightState>();

        //set default state
        _moveStateContext.Transition(_moveRightState);
    }

    //change to move up animation
    public void MoveUpAnimation()
    {
        _moveStateContext.Transition(_moveUpState);
    }

    //change to move down animation
    public void MoveDownAnimation()
    {
        _moveStateContext.Transition(_moveDownState);
    }

    //change to move left animation
    public void MoveLeftAnimation()
    {
        _moveStateContext.Transition(_moveLeftState);
    }

    //change to move right animation
    public void MoveRightAnimation()
    {
        _moveStateContext.Transition(_moveRightState);
    }
}
