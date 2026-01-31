using UnityEngine;

public class PlayerIdleState : IState
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
    
  }

  public IState CheckExitConditions()
  {
    if (m_player.MovingDir != Vector2.zero)
    {
      return m_player.MoveState;
    }

    return this;
  }

  public void ExitState()
  {
    
  }
}
