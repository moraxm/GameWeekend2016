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
        BATTLE,
        COUNT,
    }
    GameState m_state;
    public GameState state
    {
        get { return m_state; }
    }
    int m_currentWave;
    public int currentWave
    {
        get { return m_currentWave; }
    }
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

    public void FinishMatch()
    {
        if (state == GameState.BATTLE)
        {
            m_state = GameState.SELECT_CARDS;
            IncrementWave();
        }
        else
        {
            Debug.LogWarning("Bad call to Select Cards state");
        }
    }

    void IncrementWave()
    {
        ++m_currentWave;
        if (m_currentWave >= WAVES)
        {
            m_finished = true;
        }
    }

    public void ToBattle()
    {
        if (state == GameState.SELECT_CARDS)
        {
            m_state = GameState.BATTLE;
        }
        else
        {
            Debug.LogWarning("Bad call to Select Cards state");
        }
    }

    
}
