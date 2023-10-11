using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CardManager : Singleton2Manager<CardManager>
{
    private int randomID;
    private string cardName;
    private string cardBagName;
    private List<Card> cardBag = new List<Card>();
    private GameObject instantiatedCardBag;

    #region API
    /// <summary>
    /// ����CardBag����Ļ����
    /// </summary>
    /// <param name="position"></param>
    public void InstantiateCardBag()
    {
        if (instantiatedCardBag == null)
        {
            cardBagName = "CardBag";
            var cardBag = PathAndPrefabManager.Instance.GetCardBagPrefab(cardBagName);

            var position = GetScreenCenterWorldPosition(Camera.main);
            instantiatedCardBag = Instantiate(cardBag, new Vector2(position.x, position.y), Quaternion.identity);
        }
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

    private Vector3 GetScreenCenterWorldPosition(Camera camera)
    {
        Vector3 screenCenter = new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0);
        Vector3 worldPosition = camera.ScreenToWorldPoint(screenCenter);
        return worldPosition;
    }
}
