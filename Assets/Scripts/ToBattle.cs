using UnityEngine;
using System.Collections;

public class ToBattle : MonoBehaviour {
    
    public void Battle()
    {
        GameManager gm = GameManager.GetInstance();
        gm.SetCardsPlayer1(SelectCard.selected[0], SelectCard.selected[1]);
        gm.SetCardsPlayer2(gm.GetRivalRandomCard(), gm.GetRivalRandomCard());
        gm.ToBattle();
    }
}
