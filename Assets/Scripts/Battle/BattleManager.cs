using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{

    GameManager gm;

    public GameObject[] positions;

    public GameObject centerPosition;
    float timeAnimation = 2;

    public Text player1Text;
    public Text player2Text;


    void Start()
    {
        gm = GameManager.GetInstance();
        //GamePlayerData p1 = gm.GetPlayer(1);
        //GamePlayerData p2 = gm.GetPlayer(2);

        for (int i = 0; i < gm.cardsPlayer1.Length; ++i)
        {
            GameObject go = gm.cardsPlayer1[i].gameObject;
            ColocateCard(go, 0 + i);
        }
        for (int i = 0; i < gm.cardsPlayer2.Length; ++i)
        {
            GameObject go = gm.cardsPlayer2[i].gameObject;
            ColocateCard(go, 2 + i);
        }

        player1Text.text = gm.player1points.ToString();
        player1Text.text = gm.player2points.ToString();

    }

    private void ColocateCard(GameObject go, int pos)
    {
        go.transform.position = positions[pos].transform.position;
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
        GameObject go1 = gm.cardsPlayer1[gm.currentCardPlayer1].gameObject;
        GameObject go2 = gm.cardsPlayer1[gm.currentCardPlayer1].gameObject;
        GameObject goWin;

        if (victory == 1)
        {
            Vector3 v = go1.transform.position;
            v.z = 10;
            go1.transform.position = v;
            goWin = go1;
        }
        else
        {
            Vector3 v = go2.transform.position;
            v.z = 10;
            go2.transform.position = v;
            goWin = go2;
        }

        while (timeAcum < timeAnimation)
        {
            timeAcum += deltaTime;
            go1.transform.position = Vector3.Lerp(go1.transform.position, centerPosition.transform.position, timeAcum / timeAnimation);
            go2.transform.position = Vector3.Lerp(go2.transform.position, centerPosition.transform.position, timeAcum / timeAnimation);

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
    }


}
