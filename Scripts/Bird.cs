using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Bird : MonoBehaviour
{
    public string birdName; // Nome do p�ssaro.
    public string color; // Cor do habitat do p�ssaro
    public int featherCost; // Custo em "Penas" para colocar o p�ssaro.
    public int foodCost; // Custo em "Comida" para colocar o p�ssaro.
    public int maxEggs; // M�ximo de "Ovos" que o p�ssaro pode ter.
    public float wingSize; // Tamanho das asas do p�ssaro.
    //public int featherGainPerSecond; // Ganho de "Penas" a cada x segundos.
    public int pointValue; // Valor em pontos do p�ssaro.
    public string description; // Descri��o do p�ssaro.
    public string curiosity; // Curiosidade sobre o p�ssaro.
    public Texture2D birdImage; // Imagem do p�ssaro.

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
