using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIscript : MonoBehaviour
{
    //NavMesh
    public NavMeshAgent Agent;
    public Transform Player;
    public LayerMask WhatIsGround, WhatIsPlayer;
    
    //Attacking
    public float AttackFrame;
    public bool Attacked;
    
    //states
    public float sightrange, attackrange;
    public bool InSightRange, InAttackRange;

    private void Awake()
    {
    }
}
