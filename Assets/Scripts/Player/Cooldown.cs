using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Cooldown
{
    [SerializeField]
    private float cooldownTime;
    private float _nextUseSkill;

    public bool isCoolingDown => Time.time < _nextUseSkill;
    public void StartCooldown() => _nextUseSkill = Time.time + cooldownTime;
}

