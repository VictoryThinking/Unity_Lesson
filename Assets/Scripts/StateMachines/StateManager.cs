using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public State[] states;
    public State currentState;
    public State previousState;


    void Start()
    {

    }


    void Update()
    {

    }

    public void DisableStates()
    {
        foreach (State state in states)
        {
            state.enabled = false;
        }
    }

    public void DisableStates(State ignore)
    {
        foreach (State state in states)
        {
            if (state.stateName == ignore.stateName)
            {
                state.enabled = true;
            }
            else
            {
                state.enabled = false;
            }
        }
    }

    public void ChangeState(State changing)
    {
        previousState = currentState;

        DisableStates(changing);
        currentState = changing;
        previousState.OnExit();
        currentState.OnEnter();
    }

    public void UpdateStates()
    {
        foreach (State state in states)
        {
            if (state.enabled)
            {
                state.UpdateState();
            }
        }
    }
}
