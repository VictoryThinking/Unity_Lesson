using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    public string stateName;
    public virtual void OnEnter()
    {

    }
    public virtual void UpdateState()
    {

    }

    public virtual void OnExit()
    {

    }

    public virtual State CheckTransition()
    {
        return null;
    }
}
