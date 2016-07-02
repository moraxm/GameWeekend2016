using UnityEngine;
using System.Collections;

public class BattleManager: MonoBehaviour {

  GameManager gm;

  public GameObject[] positions;

  public GameObject centerPosition;
  float timeAnimation = 2;

	void Start()
  {
    GamePlayerData p1 = gm.GetPlayer(1);
    GamePlayerData p2 = gm.GetPlayer(2);

    for(int i = 0; i < p1.cards.Count; ++i)
    {
      GameObject go = gm.InstantiateCard(p1.cards[i]);
      ColocateCard(go, 0 + i);
    }
    for (int i = 0; i < p2.cards.Count; ++i)
    {
      GameObject go = gm.InstantiateCard(p1.cards[i]);
      ColocateCard(go, 2 + i);
    }

  }
  private void ColocateCard(GameObject go, int pos)
  {
    go.transform.position = positions[pos].transform.position;

  }

  public void SelectedCard(int pos)
  {
    Card c = gm.GetPlayer(1).cards[pos];
    gm.SetCurrentCard(c, 1);
    gm.SetCurrentCard(gm.GetPlayer(2).cards[Random.Range(0, 2)],2);
    int victory = gm.Play();
    StartCoroutine(StartAnimation(victory));
  }

  private IEnumerator StartAnimation(int victory)
  {
    float timeAcum = 0;
    float deltaTime = 0.1f;

    GameObject go1 = gm.GetCurrentCard(1);
    GameObject go2 = gm.GetCurrentCard(2);
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
