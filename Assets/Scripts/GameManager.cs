using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
    static private GameManager m_instance;
    static public GameManager GetInstance()
    {
        return m_instance;
    }

    // Current game stadistics
    int m_player1points;
    int m_player2points;

    Card[] m_cardsPlayer1 = new Card[2];
    Card[] m_cardsPlayer2 = new Card[2];
    Card m_currentCardPlayer1;
    Card m_currentCardPlayer2;


    public int[][] fightTable;

    // Player data
    public Card[] cards;

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
        if (!m_currentCardPlayer1 || !m_currentCardPlayer2) return -1;

        int result = fightTable[(int)m_currentCardPlayer1.type][(int)m_currentCardPlayer2.type];
        switch (result)
        {
            case 1:
                // Player 1 wins
                return 1;
                break;
            case 0:
                return 0;
                break;
            case -1:
                // Player 2 wins
                return 2;
                break;
            default:
                break;
        }

        return -1;

    }
    
    public GamePlayerData GetPlayer(int pos)
    {
      if (pos == 1)
      {
        return m_player1;
      }
      else
      {
        return m_player2;
      }

    }

    public GameObject InstantiateCard(Card c)
    {
      return new GameObject(c.name);
    }

    public void SetCurrentCard(Card c, int player)
    {

    }

}
