using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public enum CardType
    {
        PIEDRA = 0,
        PAPEL,
        TIJERA,
        LAGARTO,
        SPOCK,
        COUNT,
    }
    public enum Collection
    {
        POLITICIAN,
        CINEMA,
        MUSIC,
        SPORTS,
        TV,
    }

    public string name;
    public string description;
    public CardType type;
    public int collectionNumber;
    public Collection collection;
    public Sprite image;

    public int Fight(Card other)
    {
        int result = 0;
        if (type == other.type) return 0;

        //switch (type)
        //{
        //    case CardType.FUCKER:
        //        if (other.type == CardType.FREAK) result = 1;
        //        else result = -1;
        //        break;
        //    case CardType.ROCKSTAR:
        //        if (other.type == CardType.FUCKER) result = 1;
        //        else result = -1;
        //        break;
        //    case CardType.FREAK:
        //        if (other.type == CardType.ROCKSTAR) result = 1;
        //        else result = -1;
        //        break;
        //    default:
        //        break;
        //}
        return result;
    }
}
