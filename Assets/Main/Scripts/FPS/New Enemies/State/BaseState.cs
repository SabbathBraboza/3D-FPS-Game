public abstract class BaseState
{
      public Robot_Enemy enemy;

      public StateMachine StateMachine;

      public abstract void Enter();
      public abstract void Perform();
      public abstract void Exit();
            
}
