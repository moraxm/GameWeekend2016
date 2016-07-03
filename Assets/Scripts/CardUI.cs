using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CardUI : MonoBehaviour {

    public Text name;

    public Image image;

    public Image type;

    public Text description;

    public Text collection;

    public Card card;

    public void fillUI(Card card)
    {
        this.card = card;
        name.text = card.name;
        description.text = card.description;
        image.sprite = card.image;
        collection.text = card.collection + (card.collectionNumber + 1) + " of 10";
        type.sprite = GameManager.GetInstance().spriteTypes[(int)card.type];
    }
}
