using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// [State Deisgn Pattern: Farm]
/// 1 state of farm
/// </summary>
public class FarmSeedState : MonoBehaviour, IFarmState
{
    // to access variables of Farm Plot and make changes to it
    private FarmController _farmController;

    public void Handle(FarmController farmController)
    {
        //instantiate the controller if needed
        if (!_farmController)
        {
            _farmController = farmController;
        }

        //set the suitable sprite for the object
        _farmController.SpriteRenderer.sprite = _farmController.SeedPlotSprite;
    }
}
