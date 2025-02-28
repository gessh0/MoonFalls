using DIALOGUE;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestConversation : MonoBehaviour
{
    [SerializeField] private TextAsset fileToRead = null;
    void Start()
    {
        StartConversation();
    }


    void StartConversation()
    {
        List<string> lines = FileManager.ReadTextAsset(fileToRead);

        DialogueSystem.instance.Say(lines);
    }
}
