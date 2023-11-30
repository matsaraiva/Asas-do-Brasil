using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class CardButton : MonoBehaviour
{
    public Bird birdData; // Refer�ncia ao script Bird associado ao prefab.
    public ResourceManager playerResourceManager; // Refer�ncia ao ResourceManager do jogador.

    public BirdInfoDisplay birdInfoDisplay; // Refer�ncia ao script BirdInfoDisplay.

    private Transform targetContent; // Transform do content onde o objeto ser� instanciado.

    private Transform greenContent; // Transform do content onde o objeto ser� instanciado.
    private Transform yellowContent;
    private Transform blueContent;

    private void Awake()
    {
        greenContent = GameObject.FindGameObjectWithTag("GreenContent").transform;
        yellowContent = GameObject.FindGameObjectWithTag("YellowContent").transform;
        blueContent = GameObject.FindGameObjectWithTag("BlueContent").transform;
        //seleciona o targetContent de acordo com a cor do p�ssaro
        if (birdData.color == "Green")
        {
            targetContent = greenContent;
        }
        else if (birdData.color == "Yellow")
        {
            targetContent = yellowContent;
        }
        else if (birdData.color == "Blue")
        {
            targetContent = blueContent;
        }

        playerResourceManager = GameObject.Find("Player").GetComponent<ResourceManager>();
        
    }

    private void Start()
    {
        birdInfoDisplay = GameObject.FindGameObjectWithTag("BirdInfoDisplay").GetComponent<BirdInfoDisplay>();
    }

    public void SpawnPrefabInOtherScrollView()
    {
        // Verifique se as refer�ncias necess�rias foram configuradas.
        if (birdData == null || playerResourceManager == null || targetContent == null)
        {
            Debug.LogWarning("BirdData, PlayerResourceManager, or TargetContent references not set.");
            return;
        }

        // Verifique se o jogador possui recursos suficientes para colocar o p�ssaro.
        //if (playerResourceManager.SpendFeathers(birdData.featherCost) && playerResourceManager.SpendFood(birdData.foodCost))
        if (playerResourceManager.AcquireBird(birdData.featherCost, birdData.foodCost, birdData.color, birdData.gameObject))
        {
            // O jogador possui recursos suficientes, ent�o podemos colocar o p�ssaro no content.
            // mova esse objeto para o content
            transform.SetParent(targetContent);
            // GameObject birdObject = Instantiate(birdData.gameObject, targetContent);

            // Ajuste a posi��o e escala do objeto instanciado conforme necess�rio.
            //birdObject.transform.localPosition = Vector3.zero;
            //birdObject.transform.localScale = Vector3.one;

            // Atualize o valor m�ximo de ovos do jogador com o valor do p�ssaro.
            playerResourceManager.AddMaxEggs(birdData.maxEggs);

            // Atualize a pontua��o do jogador com o valor do p�ssaro.
            playerResourceManager.AddPoints(birdData.pointValue);

            // Ativa o script BirdBehavior do p�ssaro.
            this.GetComponent<BirdBehavior>().enabled = true;

            // Destrua o bot�o ap�s instanciar o objeto.
            //Destroy(gameObject);
        }
    }

    public void ShowBirdInfo()
    {
        // Exiba as informa��es do p�ssaro quando o mouse estiver sobre o bot�o.
        birdInfoDisplay.ShowBirdInfo(birdData);
    }

    public void HideBirdInfo()
    {
        // Oculte as informa��es do p�ssaro quando o mouse n�o estiver mais sobre o bot�o.
        birdInfoDisplay.HideBirdInfo();
    }
}
