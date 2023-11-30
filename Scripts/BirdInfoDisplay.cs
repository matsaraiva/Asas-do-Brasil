using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BirdInfoDisplay : MonoBehaviour
{
    public GameObject birdInfoPanel;
    public TextMeshProUGUI nameLabel;
    public TextMeshProUGUI DescriptionLabel;
    public TextMeshProUGUI featherCostLabel;
    public TextMeshProUGUI foodCostLabel;
    public TextMeshProUGUI maxEggsLabel;
    public TextMeshProUGUI wingSizeLabel;
    //public TextMeshProUGUI featherGainLabel;
    


    private void Start()
    {
        HideBirdInfo();
    }

    public void ShowBirdInfo(Bird birdData)
    {
        nameLabel.text = "Nome: " + birdData.birdName;
        DescriptionLabel.text = "Descrição: " + birdData.description;
        featherCostLabel.text = "Custo de Penas: " + birdData.featherCost.ToString();
        foodCostLabel.text = "Custo de Comida: " + birdData.foodCost.ToString();
        maxEggsLabel.text = "Máximo de Ovos: " + birdData.maxEggs.ToString();
        wingSizeLabel.text = "Tamanho das Asas: " + birdData.wingSize.ToString();
        //featherGainLabel.text = "Ganho de Penas/segundo: " + birdData.featherGainPerSecond.ToString();

        birdInfoPanel.SetActive(true);
    }

    public void HideBirdInfo()
    {
        birdInfoPanel.SetActive(false);
    }
}
