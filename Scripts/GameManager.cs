using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool isGameStarted = true;
    private bool isGameOver = false;


    [SerializeField]
    private double timeLimit = 600.0f;

    private float roundTime = 15.0f;

    [SerializeField]
    private GameObject gameOverPanel;
    [SerializeField]
    private ResourceManager resourceManager;


    // Evento chamado quando o jogo come�a.
    public delegate void GameStartEventHandler();
    public static event GameStartEventHandler OnGameStart;

    // Evento chamado quando o jogo acaba.
    public delegate void GameOverEventHandler();
    public static event GameOverEventHandler OnGameOver;

    private void Update()
    {
        if (isGameStarted && !isGameOver)
        {
            timeLimit -= Time.deltaTime;
            if (timeLimit <= 0)
            {
                EndGame();
            }
        }

    }

    private void Start()
    {
        StartGame();
    }

    // Fun��o para iniciar o jogo.
    public void StartGame()
    {
        isGameStarted = true;

        Debug.Log("Jogo iniciado");

        //ganha 100 penas a cada 15 segundos

        InvokeRepeating("AddFeathers", roundTime, roundTime);

        // Chama eventos relacionados ao in�cio do jogo.
        OnGameStart?.Invoke();
    }

    // Fun��o para adicionar penas.
    public void AddFeathers()
    {
        resourceManager.AddFeathers(100);

        Debug.Log("100 penas adicionadas");
    }

    // Fun��o para encerrar o jogo.
    public void EndGame()
    {
        isGameOver = true;

        Time.timeScale = 0;//para o tempo

        gameOverPanel.SetActive(true);

        resourceManager.UpdatePointsUI();

        // Chama eventos relacionados ao fim do jogo.
        OnGameOver?.Invoke();
    }

    // Fun��o para reiniciar o jogo.
    public void RestartGame()
    {
        isGameStarted = false;
        isGameOver = false;
    }

    // Fun��o para verificar se o jogo come�ou.
    public bool IsGameStarted()
    {
        return isGameStarted;
    }

    // Fun��o para verificar se o jogo acabou.
    public bool IsGameOver()
    {
        return isGameOver;
    }
}
