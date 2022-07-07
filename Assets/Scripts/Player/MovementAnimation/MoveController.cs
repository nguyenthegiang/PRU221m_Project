using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controlling all the states using Context
/// </summary>
public class MoveController : MonoBehaviour
{
    //Different Sprites for each state to use
    public Sprite MoveUpSprite { get; set; }
    public Sprite MoveDownSprite { get; set; }
    public Sprite MoveLeftSprite { get; set; }
    public Sprite MoveRightSprite { get; set; }

    //for States to change Sprite of GameObject
    public SpriteRenderer SpriteRenderer { get; set; }

    void Awake()
    {
        //instantiate
        SpriteRenderer = GetComponent<SpriteRenderer>();        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
