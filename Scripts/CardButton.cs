using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class CardButton : MonoBehaviour
{
    public Bird birdData; // Referência ao script Bird associado ao prefab.
    public ResourceManager playerResourceManager; // Referência ao ResourceManager do jogador.

    public BirdInfoDisplay birdInfoDisplay; // Referência ao script BirdInfoDisplay.

    private Transform targetContent; // Transform do content onde o objeto será instanciado.

    private Transform greenContent; // Transform do content onde o objeto será instanciado.
    private Transform yellowContent;
    private Transform blueContent;

    private void Awake()
    {
        greenContent = GameObject.FindGameObjectWithTag("GreenContent").transform;
        yellowContent = GameObject.FindGameObjectWithTag("YellowContent").transform;
        blueContent = GameObject.FindGameObjectWithTag("BlueContent").transform;
        //seleciona o targetContent de acordo com a cor do pássaro
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
        // Verifique se as referências necessárias foram configuradas.
        if (birdData == null || playerResourceManager == null || targetContent == null)
        {
            Debug.LogWarning("BirdData, PlayerResourceManager, or TargetContent references not set.");
            return;
        }

        // Verifique se o jogador possui recursos suficientes para colocar o pássaro.
        //if (playerResourceManager.SpendFeathers(birdData.featherCost) && playerResourceManager.SpendFood(birdData.foodCost))
        if (playerResourceManager.AcquireBird(birdData.featherCost, birdData.foodCost, birdData.color, birdData.gameObject))
        {
            // O jogador possui recursos suficientes, então podemos colocar o pássaro no content.
            // mova esse objeto para o content
            transform.SetParent(targetContent);
            // GameObject birdObject = Instantiate(birdData.gameObject, targetContent);

            // Ajuste a posição e escala do objeto instanciado conforme necessário.
            //birdObject.transform.localPosition = Vector3.zero;
            //birdObject.transform.localScale = Vector3.one;

            // Atualize o valor máximo de ovos do jogador com o valor do pássaro.
            playerResourceManager.AddMaxEggs(birdData.maxEggs);

            // Atualize a pontuação do jogador com o valor do pássaro.
            playerResourceManager.AddPoints(birdData.pointValue);

            // Ativa o script BirdBehavior do pássaro.
            this.GetComponent<BirdBehavior>().enabled = true;

            // Destrua o botão após instanciar o objeto.
            //Destroy(gameObject);
        }
    }

    public void ShowBirdInfo()
    {
        // Exiba as informações do pássaro quando o mouse estiver sobre o botão.
        birdInfoDisplay.ShowBirdInfo(birdData);
    }

    public void HideBirdInfo()
    {
        // Oculte as informações do pássaro quando o mouse não estiver mais sobre o botão.
        birdInfoDisplay.HideBirdInfo();
    }
}
