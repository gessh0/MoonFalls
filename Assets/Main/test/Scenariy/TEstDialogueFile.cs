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

        //foreach (string line in lines)
        //{
        //    if (string.IsNullOrWhiteSpace(line)) 
        //        continue;

        //    DIALOGUE_LINES dl = DialogueParses.Parse(line);
            
        //    for (int i = 0;i<dl.commands.commands.Count;i++)
        //    {
        //        DL_COMMAND_DATA.Command command = dl.commands.commands[i];
        //        Debug.Log($"Команды [{i}] '{command.name}' аргумент [{string.Join(", ", command.arguments)}]");
        //    }
        //}
        DialogueSystem.instance.Say(lines);
    }
}
