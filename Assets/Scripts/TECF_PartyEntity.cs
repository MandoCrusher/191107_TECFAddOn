﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TECF_PartyEntity : TECF_BattleEntity
{
    public TECF_PartyEntity() { entityType = eEntityType.PARTY; }

    [Tooltip("Which slot this party member corresponds to. Assigned by the BattleManager.")]
    public ePartySlot partySlot;

    [Tooltip("How high up to move the party frame when in the ready position.")]
    public float readyOffset = 50f;

    private void OnEnable()
    {
        EventManager.StartListening("OnPartyReady", OnPartyReady);
        EventManager.StartListening("PartyUnready", OnPartyUnready);
    }

    private void OnDisable()
    {
        EventManager.StopListening("OnPartyReady", OnPartyReady);
        EventManager.StopListening("PartyUnready", OnPartyUnready);
    }

    void OnPartyUnready(IEventInfo a_info)
    {
        PartyInfo partyInfo = a_info as PartyInfo;

        if (partyInfo != null && partyInfo.partySlot == partySlot)
        {
            // Reset position to default
            gameObject.transform.localPosition = Vector3.zero;
        }
    }

    void OnPartyReady(IEventInfo a_info)
    {
        PartyInfo partyInfo = a_info as PartyInfo;

        if (partyInfo != null && partyInfo.partySlot == partySlot)
        {
            // Update action panel data
            ReferenceManager.Instance.actionPanelName.text = battleProfile.entityName;

            // Visually move into ready position
            gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, readyOffset, gameObject.transform.localPosition.z);
        }
    }
}