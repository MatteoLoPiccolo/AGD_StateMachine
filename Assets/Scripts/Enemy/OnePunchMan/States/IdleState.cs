using StatePattern.Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    public OnePunchManController Owner { get; set; }
    private OnePunchManStateMachine stateMachine;
    private float timer;

    public IdleState(OnePunchManStateMachine onePunchManStateMachine) => this.stateMachine = onePunchManStateMachine;

    public void OnStateEnter() => ResetTimer();

    public void Update() 
    {
        timer -= Time.time;
        if (timer <= 0)
            stateMachine.ChangeState(OnePunchManStates.ROTATING);
    }

    public void OnStateExit() => timer = 0;

    private void ResetTimer() => timer = Owner.Data.IdleTime;
}