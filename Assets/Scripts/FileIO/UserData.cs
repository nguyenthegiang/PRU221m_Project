using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// [File I/O]
/// Store the data of user
/// </summary>
public class UserData
{
    //Amount of Money user has
    public int Money;

    //All Seeds user has
    public Queue<Plant> seeds;

    public UserData()
    {
    }
}
