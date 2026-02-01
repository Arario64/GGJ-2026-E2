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
        Vector2 newPos = m_player.RB.position +
                     m_player.MovingDir * m_player.MoveSpeed * Time.fixedDeltaTime;
        m_player.RB.MovePosition(newPos);

    if (m_player.MovingDir != Vector2.zero)
      m_player.LastMovingDir = m_player.MovingDir;

    m_player.LastMovingDir.Normalize();

    m_player.Animator.SetFloat("speedX", m_player.LastMovingDir.x);
    m_player.Animator.SetFloat("speedY", m_player.LastMovingDir.y);

  }

  public IState CheckExitConditions()
  {
    if (m_player.MovingDir == Vector2.zero)
    {
      return m_player.IdleState;
    }

    return this;
  }

  public void ExitState()
  {

  }
}
