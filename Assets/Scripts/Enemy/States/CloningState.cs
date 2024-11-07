using StatePattern.Main;
using StatePattern.StateMachine;

namespace StatePattern.Enemy
{
    public class CloningState<T> : IState where T : EnemyController
    {
        public EnemyController Owner { get; set; }
        private GenericStateMachine<T> stateMachine;

        public CloningState(GenericStateMachine<T> stateMachine) => this.stateMachine = stateMachine;

        public void OnStateEnter()
        {
            CreateClone();
        }

        public void Update() { }

        public void OnStateExit() { }

        private void CreateClone()
        {
            CloneManController cloneMan = GameService.Instance.EnemyService.CreateEnemy(Owner.Data) as CloneManController;
            cloneMan.SetCloneCount((Owner as CloneManController).CloneCountLeft - 1);
            cloneMan.Teleport();
            cloneMan.SetDefaultColor(EnemyColorType.Clone);
            cloneMan.ChangeColor(EnemyColorType.Clone);
            GameService.Instance.EnemyService.AddEnemy(cloneMan);
        }
    }
}