using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Bird : MonoBehaviour
{
    public string birdName; // Nome do pássaro.
    public string color; // Cor do habitat do pássaro
    public int featherCost; // Custo em "Penas" para colocar o pássaro.
    public int foodCost; // Custo em "Comida" para colocar o pássaro.
    public int maxEggs; // Máximo de "Ovos" que o pássaro pode ter.
    public float wingSize; // Tamanho das asas do pássaro.
    //public int featherGainPerSecond; // Ganho de "Penas" a cada x segundos.
    public int pointValue; // Valor em pontos do pássaro.
    public string description; // Descrição do pássaro.
    public string curiosity; // Curiosidade sobre o pássaro.
    public Texture2D birdImage; // Imagem do pássaro.

    public Bird(string name, string color, int featherCost, int foodCost, int maxEggs, float wingSize, int featherGainPerSecond, int pointValue, string description, string curiosity, Texture2D image)
    {
        this.birdName = name;
        this.color = color;
        this.featherCost = featherCost;
        this.foodCost = foodCost;
        this.maxEggs = maxEggs;
        this.wingSize = wingSize;
        //this.featherGainPerSecond = featherGainPerSecond;
        this.pointValue = pointValue;
        this.description = description;
        this.curiosity = curiosity;
        this.birdImage = image;
    }
}
