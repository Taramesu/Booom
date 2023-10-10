using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGenerator : Singleton2Manager<CardGenerator>
{
    private List<List<CardUnit>> cardShape = new List<List<CardUnit>>();
    public void GenerateCard(int id)
    {
        switch (id)
        {
            case 1:
                break;
            case 2:
                break;
        }
    }

    private void Paint_1_Card()
    {
        for(int i = 0; i < 3; i++)
        {
            cardShape.Add(new List<CardUnit>());
            for(int j = 0; j < 3; j++)
            {
                
            }
        }
    }
}
