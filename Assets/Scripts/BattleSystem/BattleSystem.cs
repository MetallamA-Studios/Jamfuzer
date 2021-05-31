using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState
{
    Start,
    PlayerTurn,
    EnemyTurn,
    PlayerWin,
    PlayerLose
}

public class BattleSystem : MonoBehaviour
{
    public BattleState currentState;

    

    void StartCombat(PlayerProfile player, PlayerProfile[] enemies)
    {
        currentState = BattleState.Start;


    }

    

}
