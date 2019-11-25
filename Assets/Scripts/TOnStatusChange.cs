﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Transitions/OnStatusChange")]
public class TOnStatusChange : ITransition
{
    public eStatusEffect targetStatus;

    TECF_BattleEntity _entity;
    eStatusEffect _startStatus;

    public override void Initialise(StateManager a_controller)
    {
        base.Initialise(a_controller);

        _entity          = a_controller.GetComponent<TECF_BattleEntity>();
        _startStatus     = _entity.currentStatus;
    }

    public override bool Decide(StateManager a_controller)
    {
        // Changed to target status, time to transition
        if (_entity.currentStatus == targetStatus)
        {
            return true;
        }

        return false;
    }
}
