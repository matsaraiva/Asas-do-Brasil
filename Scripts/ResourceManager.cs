using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class ResourceManager : MonoBehaviour
{
    [SerializeField]
    private int feathers = 300; // Quantidade de "Penas".
    [SerializeField]
    private int eggs = 0; // Quantidade atual de "Ovos".
    [SerializeField]
    private int maxEggs = 0; // Quantidade máxima de "Ovos".
    [SerializeField]
    private int food = 0; // Quantidade de "Comida".
    [SerializeField]
    private int points = 0; // Pontuação do jogador.

    [SerializeField]
    private GameObject[] birdsInGreen = new GameObject[0]; // Quantidade de pássaros na área verde.
    [SerializeField]
    private GameObject[] birdsInYellow = new GameObject[0]; // Quantidade de pássaros na área amarela.
    [SerializeField]
    private GameObject[] birdsInBlue = new GameObject[0];// Quantidade de pássaros na área azul.



    public TextMeshProUGUI feathersText; // TextMeshProUGUI para exibir a quantidade de "Penas".
    public TextMeshProUGUI eggsText; // TextMeshProUGUI para exibir a quantidade de "Ovos".
    public TextMeshProUGUI foodText; // TextMeshProUGUI para exibir a quantidade de "Comida".
    public TextMeshProUGUI pointsText; // TextMeshProUGUI para exibir a pontuação.

    private void Start()
    {
        UpdateFeathersUI();
        UpdateEggsUI();
        UpdateFoodUI();
        UpdatePointsUI();
    }

    public int GetFeathers()
    {
        return feathers;
    }

    public int GetEggs()
    {
        return eggs;
    }

    public int GetMaxEggs()
    {
        return maxEggs;
    }

    public int GetFood()
    {
        return food;
    }

    public int GetPoints()
    {
        return points;
    }

    public GameObject[] GetBirdsInGreen()
    {
        return birdsInGreen;
    }

    public GameObject[] GetBirdsInYellow()
    {
        return birdsInYellow;
    }

    public GameObject[] GetBirdsInBlue()
    {
        return birdsInBlue;
    }

    public void AddFeathers(int amount)
    {
        feathers += amount;
        UpdateFeathersUI();
    }

    public void AddEggs(int amount)
    {
        eggs += amount;
        eggs = Mathf.Min(eggs, maxEggs); // Garante que a quantidade de ovos não excede o máximo.
        UpdateEggsUI();
    }

    public void AddMaxEggs(int amount)
    {
        maxEggs += amount;
        UpdateEggsUI();
    }

    public void AddFood(int amount)
    {
        food += amount;
        UpdateFoodUI();
    }

    public void AddPoints(int amount)
    {
        points += amount;
        UpdatePointsUI();
    }

    public void AddBirdInGreen(GameObject birdPrefab)
    {
        GameObject[] newBirdsInGreen = new GameObject[birdsInGreen.Length + 1];
        for (int i = 0; i < birdsInGreen.Length; i++)
        {
            newBirdsInGreen[i] = birdsInGreen[i];
        }
        newBirdsInGreen[newBirdsInGreen.Length - 1] = birdPrefab;
        birdsInGreen = newBirdsInGreen;

    }

    public void AddBirdInYellow(GameObject birdPrefab)
    {
        GameObject[] newBirdsInYellow = new GameObject[birdsInYellow.Length + 1];
        for (int i = 0; i < birdsInYellow.Length; i++)
        {
            newBirdsInYellow[i] = birdsInYellow[i];
        }
        newBirdsInYellow[newBirdsInYellow.Length - 1] = birdPrefab;
        birdsInYellow = newBirdsInYellow;
        
        
    }

    public void AddBirdInBlue(GameObject birdPrefab)
    {
        GameObject[] newBirdsInBlue = new GameObject[birdsInBlue.Length + 1];
        for (int i = 0; i < birdsInBlue.Length; i++)
        {
            newBirdsInBlue[i] = birdsInBlue[i];
        }
        newBirdsInBlue[newBirdsInBlue.Length - 1] = birdPrefab;
        birdsInBlue = newBirdsInBlue;

        
        
    }

    public bool SpendFeathers(int amount)
    {
        if (feathers >= amount)
        {
            feathers -= amount;
            UpdateFeathersUI();
            return true;
        }
        return false;
    }

    public bool SpendEggs(int amount)
    {
        if (eggs >= amount)
        {
            eggs -= amount;
            UpdateEggsUI();
            return true;
        }
        return false;
    }

    public bool SpendFood(int amount)
    {
        if (food >= amount)
        {
            food -= amount;
            UpdateFoodUI();
            return true;
        }
        return false;
    }

    public bool AcquireBird(int feathersAmount, int foodAmount, string color, GameObject birdPrefab)
    {
        int eggCost = 0;
        if (color == "Green" && birdsInGreen.Length >= 1)
        {
            eggCost = 1;
        }
        else if (color == "Yellow" && birdsInYellow.Length >= 1)
        {
            eggCost = 1;
        }
        else if (color == "Blue" && birdsInBlue.Length >= 1)
        {
            eggCost = 1;
        }

        if (eggs >= eggCost && feathers >= feathersAmount && food >= foodAmount)
        {
            eggs -= eggCost;
            feathers -= feathersAmount;
            food -= foodAmount;
            if (color == "Green")
            {
                AddBirdInGreen(birdPrefab);
            }
            else if (color == "Yellow")
            {
                AddBirdInYellow(birdPrefab);
            }
            else if (color == "Blue")
            {
                AddBirdInBlue(birdPrefab);
            }
            UpdateEggsUI();
            UpdateFeathersUI();
            UpdateFoodUI();
            return true;
        }
        return false;
        
    }

    private void UpdateFeathersUI()
    {
        if (feathersText != null)
        {
            feathersText.text = "Penas: " + feathers.ToString();
        }
    }

    private void UpdateEggsUI()
    {
        if (eggsText != null)
        {
            eggsText.text = "Ovos: " + eggs.ToString() + " / " + maxEggs.ToString();
        }
    }

    private void UpdateFoodUI()
    {
        if (foodText != null)
        {
            foodText.text = "Comida: " + food.ToString();
        }
    }

    public void UpdatePointsUI()
    {
        if (pointsText != null)
        {
            pointsText.text = "Pontuação: " + points.ToString();
        }
    }

}
