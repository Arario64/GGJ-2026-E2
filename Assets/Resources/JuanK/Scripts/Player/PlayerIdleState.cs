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

    m_player.LastMovingDir *= 0.1f;

  }

  public void Execute()
  {
    m_player.Animator.SetFloat("speedX", m_player.LastMovingDir.x);
    m_player.Animator.SetFloat("speedY", m_player.LastMovingDir.y);
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
