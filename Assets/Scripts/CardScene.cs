using UnityEngine;
using System.Collections;

public class CardScene : MonoBehaviour {

   public GameObject m_win;
   public GameObject m_lose;

   public GameObject card;

	// Use this for initialization
	void Start () {
    GameManager gm = GameManager.GetInstance();
    Card goBet = null;
	  if(gm.player2points > gm.player1points)
    {
      m_win.SetActive(false);
      m_lose.SetActive(true);
      //goBet = gm.Player1Bet;
    }
    else
    {
      m_win.SetActive(true);
      m_lose.SetActive(false);
     //goBet = gm.Player2Bet;
    }

    goBet.transform.position = card.transform.position;

	}

  public void ExitScreen ()
  {

  }


}
