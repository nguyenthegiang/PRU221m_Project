using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//1 state of a movement
public class MoveLeftState : MonoBehaviour, IMoveState
{
    // to access variables of main character and make changes to it
    private MoveController _moveController;

    public void Handle(MoveController moveController)
    {
        //instantiate the controller if needed
        if (!_moveController)
        {
            _moveController = moveController;
        }

        //set the suitable sprite for the object
        _moveController.SpriteRenderer.sprite = _moveController.MoveLeftSprite;
    }
}
