using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// create menu for creating character specs 
[CreateAssetMenu(fileName = "CharacterSpec", menuName = "Character/PlayerSpec", order = 1)]
public class PlayerSpec : ScriptableObject
{
    public Color player_color;
    public Vector3 player_scale;
    public float player_speed;
}

