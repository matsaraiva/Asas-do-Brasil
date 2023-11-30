using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionsManager : MonoBehaviour
{
    [SerializeField]
    private BirdCardSpawner birdCardSpawner;
    [SerializeField]
    private ResourceManager resourceManager;

    [SerializeField]
    private int actionCost = 100;

    public void DrawBirds()
    {
        GameObject[] birdsInBlue = resourceManager.GetBirdsInBlue();
        if (resourceManager.GetFeathers() >= actionCost)
        {
            birdCardSpawner.SpawnCard();

            for (int i = 0; i < birdsInBlue.Length; i++)//escala com a quantidade de birds in blue
            {
                int random = Random.Range(0, 100);
                if (random < 50)
                {
                    birdCardSpawner.SpawnCard();
                }
            }

            //ativa todas as skills dos passaros no azul
            for (int i = 0; i < birdsInBlue.Length; i++)
            {
                birdsInBlue[i].GetComponent<BirdBehavior>().ActivateSkill();
            }




            resourceManager.SpendFeathers(actionCost);
        }
        
    }

    public void LayEggs()
    {
        GameObject[] birdsInYellow = resourceManager.GetBirdsInYellow();

        if (resourceManager.GetFeathers() >= actionCost)
        {
            resourceManager.AddEggs(1);

            for (int i = 0; i < birdsInYellow.Length; i++)//escala com a quantidade de birds in yellow
            {
                int random = Random.Range(0, 100);
                if (random < 50)
                {
                    resourceManager.AddEggs(1);
                }
            }

            resourceManager.SpendFeathers(actionCost);
        }
        
    }

    public void GainFood()
    {
        GameObject[] birdsInGreen = resourceManager.GetBirdsInGreen();

        if (resourceManager.GetFeathers() >= actionCost)
        {
            resourceManager.AddFood(10);

            for (int i = 0; i < birdsInGreen.Length; i++)//escala com a quantidade de birds in green
            {
                int random = Random.Range(0, 100);
                if (random < 50)
                {
                    resourceManager.AddFood(10);
                }
            }

            resourceManager.SpendFeathers(actionCost);
        }
        
    }
}
