using UnityEngine;
using System.Collections;

public class Battle 
{
    const int WAVES = 3;
    private Card m_betCard1;
    public Card betCardPlayer1
    {
        get { return m_betCard1; }
        set { m_betCard1 = value; }
    }
    private Card m_betCard2;
    public Card betCardPlayer2
    {
        get { return m_betCard2; }
        set { m_betCard2 = value; }
    }

    public enum GameState
    {
        SELECT_CARDS,
        SELECT_CARD,
        SHOWING_RESULT,
        COUNT,
    }
    GameState m_state;
    public GameState state
    {
        get { return m_state; }
    }
    int m_currentWave;
    private bool m_finished;
    public bool isFinished
    {
        get { return m_finished; }
    }

    public void Init()
    {
        m_currentWave = 0;
        m_finished = false;
        m_state = GameState.SELECT_CARDS;
    }

    public void NextState()
    {
        int iState = (int)state;
        ++iState;
        m_state = (GameState)(iState);
        if (state == GameState.COUNT)
        {
            m_state = GameState.SELECT_CARDS;
            ++m_currentWave;
            if (m_currentWave >= WAVES)
                m_finished = true;
        }
    }

    
}
