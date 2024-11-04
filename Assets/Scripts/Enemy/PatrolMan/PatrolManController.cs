using StatePattern.Enemy;
using StatePattern.Player;
using StatePattern.StateMachine;

public class PatrolManController : EnemyController
{
    private PatrolManStateMachine stateMachine;

    private void CreateStateMachine() => stateMachine = new PatrolManStateMachine(this);

    public PatrolManController(EnemyScriptableObject enemyScriptableObject) : base(enemyScriptableObject)
    {
        enemyView.SetController(this);
        CreateStateMachine();
        stateMachine.ChangeState(States.IDLE);
    }

    public override void UpdateEnemy()
    {
        if (currentState == EnemyState.DEACTIVE)
            return;

        stateMachine.Update();
    }

    public override void PlayerEnteredRange(PlayerController targetToSet)
    {
        base.PlayerEnteredRange(targetToSet);
        stateMachine.ChangeState(States.CHASING);
    }

    public override void PlayerExitedRange() => stateMachine.ChangeState(States.IDLE);
}