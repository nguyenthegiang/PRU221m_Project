using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// [Object Pool Pattern - PooledObject]
/// 1 drop of rain water
/// </summary>
public class RainDrop : MonoBehaviour
{
    //using Action to handle logic for destroying the rain drop in the RainController script
    private Action<RainDrop> _killAction;

    //Control destroy time
    [SerializeField]
    const float fallingSeconds = 2f;
    Timer fallingTimer;

    //pass method in
    public void Init(Action<RainDrop> killAction)
    {
        _killAction = killAction;
    }

    void Start()
    {
        //create and start Timer
        fallingTimer = gameObject.AddComponent<Timer>();
        fallingTimer.Duration = fallingSeconds;
        fallingTimer.Run();
    }

    void Update()
    {
        //destroy rain drop when touch the ground (after falling for 2 seconds)
        if (fallingTimer.Finished)
        {
            _killAction(this);
        }
    }
}
