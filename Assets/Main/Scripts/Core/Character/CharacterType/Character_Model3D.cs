using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Characters
{
    public class Character_Model3D : Character
    {
        public Character_Model3D(string name) : base(name)
        {
            Debug.Log($"Создание Character_Model3D персонажа: '{name}'");
        }
    }
}