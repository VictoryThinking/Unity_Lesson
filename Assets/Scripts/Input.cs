using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// input variable container or variables
[Serializable]
public struct PlayerInput
{
    public Vector2 left_stick;
    public bool jump_pressed;
    public bool attack_pressed;
    public bool jump_hold;
    public bool attack_hold;
    public bool mouse_held;


}
