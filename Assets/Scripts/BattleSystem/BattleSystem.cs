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
    #region Public Variables
    public BattleState currentState;
    #endregion


    void StartCombat(PlayerProfile player, PlayerProfile[] enemies)
    {
        currentState = BattleState.Start;


    }

    

}
