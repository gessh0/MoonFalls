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
            Character ���� = CharacterManager.instance.CreateCharacter("����");
            Character ���� = CharacterManager.instance.CreateCharacter("����");
            Character ����2 = CharacterManager.instance.CreateCharacter("����");
            Character ����� = CharacterManager.instance.CreateCharacter("�����");
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}