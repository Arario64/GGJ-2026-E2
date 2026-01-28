using UnityEngine;

public class PlayerMoveState : IState
{
  Player m_player;

  public void SetOwner(Player playerOwner)
  {
    CustomAssert.IsNotNull(playerOwner);
    m_player = playerOwner;
  }

  public void EnterState()
  {

  }

  public void Execute()
  {
    m_player.transform.Translate(m_player.MovingDir * m_player.MoveSpeed * Time.deltaTime);
  }

  public IState CheckExitConditions()
  {

    return this;
  }

  public void ExitState()
  {

  }
}
