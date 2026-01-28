using UnityEngine;

public interface IState
{
  void EnterState();
  void Execute();
  IState CheckExitConditions();
  void ExitState();
}
