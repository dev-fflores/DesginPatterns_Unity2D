﻿using UnityEngine;

namespace Ships.Weapons
{
    [CreateAssetMenu(menuName = "Factory/Create ProjectileId", fileName = "ProjectileId")]
    public class ProjectileId : ScriptableObject
    {
        [SerializeField] private string _value;
        public string Value => _value;
    }
}