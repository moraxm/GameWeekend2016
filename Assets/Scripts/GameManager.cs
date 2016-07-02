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
    // Player 1
    int m_player1points;
    public int player1points
    {
        get { return m_player1points; }
    }
    Card[] m_cardsPlayer1 = new Card[2];
    public Card[] cardsPlayer1
    {
        get { return m_cardsPlayer1; }
    }
    public void SetCardsPlayer1(Card card1, Card card2)
    {
        DestroyChilds();
        cardsPlayer1[0] = card1;
        card1.transform.SetParent(transform);
        cardsPlayer1[1] = card2;
        card2.transform.SetParent(transform);
    }
    int m_currentCardPlayer1;
    public int currentCardPlayer1
    {
        get { return m_currentCardPlayer1; }
        set { m_currentCardPlayer1 = value; }
    }

    // Player 2
    int m_player2points;
    public int player2points
    {
        get { return m_player2points; }
    }

    
    Card[] m_cardsPlayer2 = new Card[2];
    public Card[] cardsPlayer2
    {
        get { return m_cardsPlayer2; }
    }
    public void SetCardsPlayer2(Card card1, Card card2)
    {
        DestroyChilds();
        cardsPlayer2[0] = card1;
        card1.transform.SetParent(transform);
        cardsPlayer2[1] = card2;
        card2.transform.SetParent(transform);
    }
    int m_currentCardPlayer2;
    public int currentCardPlayer2
    {
        get { return m_currentCardPlayer2; }
        set { m_currentCardPlayer2 = value; }
    }

    public int[][] fightTable;

    // Player data
    public Card[] cards;
    Battle currentBattle;

    void DestroyChilds()
    {
        foreach (Transform t in transform)
        {
            Destroy(t.gameObject);
        }
    }

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

        currentBattle = new Battle();
        currentBattle.Init();
    }

    public int Play()
    {
        Card currentCardPlayer1 = cardsPlayer1[m_currentCardPlayer1];
        Card currentCardPlayer2 = cardsPlayer2[m_currentCardPlayer2];
        if (!currentCardPlayer1 || !currentCardPlayer1) return -1;
        if (currentBattle.isFinished) return -1;
        
        int result = fightTable[(int)currentCardPlayer1.type][(int)currentCardPlayer1.type];
        int toReturn = -1;
        switch (result)
        {
            case 1:
                // Player 1 wins
                toReturn = 1;
                break;
            case 0:
                toReturn = 0;
                break;
            case -1:
                // Player 2 wins
                toReturn = 2;
                break;
            default:
                break;
        }

        currentBattle.NextState();
        return toReturn;

    }

    public bool isBattleFinished
    {
        get { return currentBattle.isFinished; }
    }

}
