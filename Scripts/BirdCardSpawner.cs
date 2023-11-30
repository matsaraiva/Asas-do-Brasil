using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirdCardSpawner : MonoBehaviour
{
    public GameObject[] cardPrefabs; // Matriz de prefabs de cartas disponíveis.
    public Transform content; // O Transform do content do ScrollView onde os botões serão colocados.

    //private int cardsSpawned = 0;

    // Função para spawnar uma única carta de forma aleatória.
    public void SpawnCard()
    {
        if (true)
        {
            // Escolhe aleatoriamente um prefab de carta da matriz.
            GameObject randomCardPrefab = cardPrefabs[Random.Range(0, cardPrefabs.Length)];

            // Instancia o prefab do botão da carta escolhido aleatoriamente.
            GameObject cardButton = Instantiate(randomCardPrefab, content);

            // Você pode personalizar o botão ou atribuir informações específicas às cartas aqui.
            // Por exemplo, definir texto, imagens, eventos de clique, etc.

            
        }
    }

    // Função para modificar a matriz de prefabs de cartas disponíveis durante o jogo.
    public void SetCardPrefabs(GameObject[] newCardPrefabs)
    {
        cardPrefabs = newCardPrefabs;
    }
}
