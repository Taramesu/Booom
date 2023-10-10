using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CardManager : Singleton2Manager<CardManager>
{
    private int randomID;
    private string cardName;
    private string cardPoolName;
    private List<Card> cardBag = new List<Card>();

    #region API
    /// <summary>
    /// ��position�����ɿ���
    /// </summary>
    /// <param name="position"></param>
    public void InstantiateCardPool(Vector2 position)
    {
        cardPoolName = "CardPool";
        var cardPool = PathAndPrefabManager.Instance.GetCardPoolPrefab(cardPoolName);
        Instantiate(cardPool,new Vector3(position.x, position.y, 0),Quaternion.identity);
    }

    /// <summary>
    /// ָ���������ĺͼ����������3�ſ���
    /// </summary>
    /// <param name="centerCardPosition"></param>
    /// <param name="offset"></param>
    public void InstantiateCards(Vector2 centerCardPosition, float offset)
    {
        GameObject[] cards = GetRandomCard();
        Instantiate(cards[0],new Vector3(centerCardPosition.x-offset,centerCardPosition.y,0),Quaternion.identity);
        Instantiate(cards[1],new Vector3(centerCardPosition.x,centerCardPosition.y,0),Quaternion.identity);
        Instantiate(cards[2],new Vector3(centerCardPosition.x+offset,centerCardPosition.y,0),Quaternion.identity);
    }

    /// <summary>
    /// ��ȡ������ɵ��б����Ʊ�����
    /// </summary>
    /// <returns></returns>
    public List<Card> GetCardBagList()
    {
        return cardBag;
    }

    /// <summary>
    /// �򱳰������һ�ſ���
    /// </summary>
    /// <param name="card"></param>
    public void AddCardToBag(Card card)
    {
        cardBag.Add(card);
    }

    /// <summary>
    /// �Ƴ��������Ŀ���
    /// </summary>
    /// <param name="card"></param>
    public void DeleteCardFromBag(Card card)
    {
        cardBag.Remove(card);
    }

    #endregion
    private GameObject[] GetRandomCard()
    {   
        GameObject[] cards = new GameObject[3];
        for(int i = 0; i < 3; i++)
        {
            randomID = Random.Range(1, 11);
            cards[i] = GetCardPrefab();
        }

        if(cards != null)
        {
            return cards;
        }
        else
        {
#if UNITY_EDITOR
            Debug.Log("Can't get cards");
#endif
            return null;
        }
    }

    private GameObject GetCardPrefab()
    {
        cardName = "Card_" + randomID.ToString();
        return PathAndPrefabManager.Instance.GetCardPrefab(cardName);
    }
}
