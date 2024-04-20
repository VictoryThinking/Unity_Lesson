using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// create menu for creating Power Up specs 
[CreateAssetMenu(fileName = "PowerUpSpec", menuName = "Character/PowerUpSpec", order = 2)]
public class PowerUpSpec : ScriptableObject
{
    //Spec we are giving to the player
    public PlayerSpec defaultSpec;
    public PowerUpTypes.Types myType;
    //Spec we give if player already has power up
    public PlayerSpec[] combinations;


}

