﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Transitions/OnWin")]
public class TOnWin : ITransition
{
    public override bool Decide(StateManager a_controller)
    {
        if (BattleManager.Instance.enemyEntities.Count == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}