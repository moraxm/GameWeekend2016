using UnityEngine;
using System.Collections;

public class ToBattle : MonoBehaviour {
    
    public void Battle()
    {
        GameManager.GetInstance().SetCardsPlayer1(SelectCard.selected[0], SelectCard.selected[1]);
    }
}
