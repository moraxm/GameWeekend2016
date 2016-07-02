using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
    

    static private GameManager m_instance;
    static public GameManager GetInstance()
    {
        return m_instance;
    }

    public int[][] fightTable;
    // Player data
    public Card[] cards;

    GamePlayerData m_player1;
    GamePlayerData m_player2;

    void Awake()
    {
        if (this != m_instance && m_instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            m_instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        
    }

    public void SetPlayers(GamePlayerData p1, GamePlayerData p2)
    {
        m_player1 = p1;
        m_player2 = p2;
    }

    void Start()
    {
        fightTable = new int[(int)Card.CardType.COUNT][];
        for (int i = 0; i < (int)Card.CardType.COUNT; ++i)
        {
            fightTable[i] = new int[(int)Card.CardType.COUNT];
        }

        // PIEDRA
        fightTable[(int)Card.CardType.PIEDRA][(int)Card.CardType.PIEDRA] = 0;
        fightTable[(int)Card.CardType.PIEDRA][(int)Card.CardType.PAPEL] = -1;
        fightTable[(int)Card.CardType.PIEDRA][(int)Card.CardType.TIJERA] = 1;
        fightTable[(int)Card.CardType.PIEDRA][(int)Card.CardType.LAGARTO] = 1;
        fightTable[(int)Card.CardType.PIEDRA][(int)Card.CardType.SPOCK] = -1;
        // PAPEL
        fightTable[(int)Card.CardType.PAPEL][(int)Card.CardType.PIEDRA] = 1;
        fightTable[(int)Card.CardType.PAPEL][(int)Card.CardType.PAPEL] = 0;
        fightTable[(int)Card.CardType.PAPEL][(int)Card.CardType.TIJERA] = -1;
        fightTable[(int)Card.CardType.PAPEL][(int)Card.CardType.LAGARTO] = -1;
        fightTable[(int)Card.CardType.PAPEL][(int)Card.CardType.SPOCK] = 1;
        // TIJERA
        fightTable[(int)Card.CardType.TIJERA][(int)Card.CardType.PIEDRA] = -1;
        fightTable[(int)Card.CardType.TIJERA][(int)Card.CardType.PAPEL] = 1;
        fightTable[(int)Card.CardType.TIJERA][(int)Card.CardType.TIJERA] = 0;
        fightTable[(int)Card.CardType.TIJERA][(int)Card.CardType.LAGARTO] = 1;
        fightTable[(int)Card.CardType.TIJERA][(int)Card.CardType.SPOCK] = -1;
        // LAGARTO
        fightTable[(int)Card.CardType.LAGARTO][(int)Card.CardType.PIEDRA] = -1;
        fightTable[(int)Card.CardType.LAGARTO][(int)Card.CardType.PAPEL] = 1;
        fightTable[(int)Card.CardType.LAGARTO][(int)Card.CardType.TIJERA] = -1;
        fightTable[(int)Card.CardType.LAGARTO][(int)Card.CardType.LAGARTO] = 0;
        fightTable[(int)Card.CardType.LAGARTO][(int)Card.CardType.SPOCK] = 1;
        // SPOCK
        fightTable[(int)Card.CardType.SPOCK][(int)Card.CardType.PIEDRA] = 1;
        fightTable[(int)Card.CardType.SPOCK][(int)Card.CardType.PAPEL] = -1;
        fightTable[(int)Card.CardType.SPOCK][(int)Card.CardType.TIJERA] = 1;
        fightTable[(int)Card.CardType.SPOCK][(int)Card.CardType.LAGARTO] = -1;
        fightTable[(int)Card.CardType.SPOCK][(int)Card.CardType.SPOCK] = 0;
    }

    public int Play()
    {
        int player1Result = 0;
        int player2Result = 0;
        for (int i = 0; i < m_player1.cards.Count; ++i)
        {
            if (m_player1.cards[1].Fight(m_player2.cards[i]) == 1)
            {
                // Player 1 wins
                ++player1Result;
            }
            else
            {
                // PLayer 2 wins
                ++player2Result;
            }
        }
        return player1Result > player2Result ? 1 : 2;
    }
}
