using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Characters;

namespace Testing
{
    public class TestCharacters : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            Character Лиса = CharacterManager.instance.CreateCharacter("Лиса");
            Character Лойд = CharacterManager.instance.CreateCharacter("Лойд");
            Character Лойд2 = CharacterManager.instance.CreateCharacter("Лойд");
            Character Клаус = CharacterManager.instance.CreateCharacter("Клаус");
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}