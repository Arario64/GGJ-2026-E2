using UnityEngine;

public class FSM
{
  private IState m_currState;

  public void Init(IState initState)
  {
    m_currState = initState;
    m_currState.EnterState();
  }

  public void Update()
  {
    m_currState.Execute();

    IState nextState = m_currState.CheckExitConditions();
    if (m_currState != nextState && nextState != null)
    {
      m_currState.ExitState();
      m_currState = nextState;
      m_currState.EnterState();
    }
  }
}
