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
    public BattleState bs_currentState;

    public BattleSystemUI bsui_ui;
    #endregion

    private void Start()
    {
        bs_currentState = BattleState.Start;
    }


    void StartCombat(PlayerProfile player, PlayerProfile[] enemies)
    {
        bs_currentState = BattleState.Start;


    }

    

}
