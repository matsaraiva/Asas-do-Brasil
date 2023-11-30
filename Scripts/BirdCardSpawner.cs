using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirdCardSpawner : MonoBehaviour
{
    public GameObject[] cardPrefabs; // Matriz de prefabs de cartas dispon�veis.
    public Transform content; // O Transform do content do ScrollView onde os bot�es ser�o colocados.

    //private int cardsSpawned = 0;

    // Fun��o para spawnar uma �nica carta de forma aleat�ria.
    public void SpawnCard()
    {
        if (true)
        {
            // Escolhe aleatoriamente um prefab de carta da matriz.
            GameObject randomCardPrefab = cardPrefabs[Random.Range(0, cardPrefabs.Length)];

            // Instancia o prefab do bot�o da carta escolhido aleatoriamente.
            GameObject cardButton = Instantiate(randomCardPrefab, content);

            // Voc� pode personalizar o bot�o ou atribuir informa��es espec�ficas �s cartas aqui.
            // Por exemplo, definir texto, imagens, eventos de clique, etc.

            
        }
    }

    // Fun��o para modificar a matriz de prefabs de cartas dispon�veis durante o jogo.
    public void SetCardPrefabs(GameObject[] newCardPrefabs)
    {
        cardPrefabs = newCardPrefabs;
    }
}
