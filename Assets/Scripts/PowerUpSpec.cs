using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// create menu for creating Power Up specs 
[CreateAssetMenu(fileName = "PowerUpSpec", menuName = "Character/PowerUpSpec", order = 2)]
public class PowerUpSpec : ScriptableObject
{
    public PlayerSpec defaultSpec;
    public PowerUpTypes.Types myType;
    public PlayerSpec[] combinations;


}

