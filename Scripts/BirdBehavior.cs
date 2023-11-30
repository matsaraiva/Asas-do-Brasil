using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdBehavior : MonoBehaviour
{
    public Bird birdData; // Referência ao script Bird associado ao pássaro.
    public ResourceManager playerResourceManager; // Referência ao ResourceManager do jogador.

    [Tooltip("1 = Egg, 2 = Food, 3 = Feather")]
    public int SkillType = 0; // 1 = Egg, 2 = Food, 3 = Feather
    public int SkillValue; // Valor da skill
    public int SkillChance = 50; // Chance de ativar a skill 

    private void Start()
    {
        playerResourceManager = GameObject.Find("Player").GetComponent<ResourceManager>();

        // Inicia a rotina para conceder penas ao jogador.
        //InvokeRepeating("GrantFeathers", 1f, 1f); // Concede penas a cada 1 segundo (ajuste conforme necessário).
    }

    /*
    private void GrantFeathers()
    {
        if (birdData != null && playerResourceManager != null)
        {
            int feathersToGrant = birdData.featherGainPerSecond;
            playerResourceManager.AddFeathers(feathersToGrant);
        }
    }
    */

    public void ActivateSkill()
    {         
        // Chance de ativar a skill
        if (Random.Range(0, 100) <= SkillChance)
        {
            // Ativa a skill
            switch (SkillType)
            {
                case 1:
                    if (playerResourceManager)
                    {
                        playerResourceManager.AddEggs(SkillValue);
                    }
                    break;
                case 2:
                    if (playerResourceManager)
                    {
                        playerResourceManager.AddFood(SkillValue);
                    }
                    break;
                case 3:
                    if (playerResourceManager)
                    {
                        playerResourceManager.AddFeathers(SkillValue);
                    }
                    break;
                default:
                    break;
            }
        }

    }
}
