using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BattleManager : MonoBehaviour
{

    GameManager gm;

    public GameObject[] positions;

    public GameObject centerPositionPlayer1;
    public GameObject centerPositionPlayer2;
    float timeAnimation = 2;

    public Text player1Text;
    public Text player2Text;

    public CardUI[] player1Cards;
    public CardUI[] player2Cards;
    public Transform outPositionPlayer1;
    public Transform outPositionPlayer2;

    void Start()
    {
        gm = GameManager.GetInstance();
        //GamePlayerData p1 = gm.GetPlayer(1);
        //GamePlayerData p2 = gm.GetPlayer(2);

        for (int i = 0; i < gm.cardsPlayer1.Length; ++i)
        {
            player1Cards[i].fillUI(gm.cardsPlayer1[i]);
        }
        for (int i = 0; i < gm.cardsPlayer2.Length; ++i)
        {
            player2Cards[i].fillUI(gm.cardsPlayer2[i]);
        }

        player1Text.text = gm.player1points.ToString();
        player2Text.text = gm.player2points.ToString();

    }

    public void SelectedCard(int pos)
    {
        Card c = gm.cardsPlayer1[pos];
        gm.currentCardPlayer1 = pos;
        gm.currentCardPlayer2 = Random.Range(0, 2);
        int victory = gm.Play();
        StartCoroutine(StartAnimation(victory));
    }

    private IEnumerator StartAnimation(int victory)
    {
        float timeAcum = 0;
        float deltaTime = 0.1f;

        //GameObject go1 = gm.GetCurrentCard(1);
        //GameObject go2 = gm.GetCurrentCard(2);
        GameObject go1 = player1Cards[gm.currentCardPlayer1].gameObject;
        GameObject go1Other = player1Cards[(gm.currentCardPlayer1 + 1) % 2].gameObject;
        GameObject go2 = player2Cards[gm.currentCardPlayer2].gameObject;
        GameObject go2Other = player2Cards[(gm.currentCardPlayer2 + 1) % 2].gameObject;
        GameObject goWin;

        if (victory == 1)
        {
            SetMoreLayer(go1, go2);
            goWin = go1;
        }
        else
        {
            SetMoreLayer(go2, go1);
            goWin = go2;
        }
        Vector3 outOther1 = go1Other.transform.position;
        outOther1.y = outPositionPlayer1.position.y;
        Vector3 outOther2 = go2Other.transform.position;
        outOther2.y = outPositionPlayer2.position.y;
        while (timeAcum < timeAnimation)
        {
            timeAcum += deltaTime;
            go1.transform.position = Vector3.Lerp(go1.transform.position, centerPositionPlayer1.transform.position, timeAcum / timeAnimation);
            go2.transform.position = Vector3.Lerp(go2.transform.position, centerPositionPlayer2.transform.position, timeAcum / timeAnimation);

            go1Other.transform.position = Vector3.Lerp(go1Other.transform.position, outOther1, timeAcum * 2 / timeAnimation);
            go2Other.transform.position = Vector3.Lerp(go2Other.transform.position, outOther2, timeAcum * 2 / timeAnimation);

            yield return new WaitForSeconds(deltaTime);
        }
        yield return new WaitForSeconds(0.5f);

        timeAcum = 0;


        Vector3 finalScale = go1.transform.localScale * 2;

        while (timeAcum < timeAnimation)
        {
            timeAcum += deltaTime;
            goWin.transform.localScale = Vector3.Lerp(go1.transform.localScale, finalScale, timeAcum / timeAnimation);
            yield return new WaitForSeconds(deltaTime);
        }
        GameManager.GetInstance().FinishMatch();

        if (GameManager.GetInstance().isBattleFinished)
        {
            SceneManager.LoadScene("Card");
            GameManager.GetInstance().FinishBattle();
        }
        else
            SceneManager.LoadScene("SelectCards");
    }

    private void SetMoreLayer(GameObject front, GameObject back)
    {
        back.transform.SetParent(front.transform.parent);
        front.transform.SetAsLastSibling();
    }

}
