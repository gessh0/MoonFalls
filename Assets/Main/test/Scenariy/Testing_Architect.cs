using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DIALOGUE;
namespace Testing
{
    public class Testing_Architect : MonoBehaviour
    {
        DialogueSystem ds;
        TextArchitect architect;

        public TextArchitect.BuildMethod bm = TextArchitect.BuildMethod.instant;

        string[] lines = new string[5]
        {
             "Рандомный диалог.",
            " Я просто не знаю что говорить.",
            " Как же хочется уехать с этого города.",
             "О боже это просто фонарный столб!",
            " Пойду кофе что ли выпью.."
        };
       
        void Start()
        {
            ds = DialogueSystem.instance;
            architect = new TextArchitect(ds.dialogueContainer.dialogueText);
            architect.buildMethod = TextArchitect.BuildMethod.fade;
            architect.speed = 0.5f;
        }

        
        void Update()
        {
            if (bm != architect.buildMethod)
            {
                architect.buildMethod = bm;
                architect.Stop();
            }

            if (Input.GetKeyDown(KeyCode.S))
                architect.Stop();

            string longline = "Это очень длинная строка я просто заполняю ей текстом потому что ну это просто текст, все любят текст больше текста богу текста, текст состоит из воды юхуу";
            if (Input.GetKeyUp(KeyCode.Space))
            {
                if (architect.isBuilding)
                {
                    if(!architect.hurryUp) 
                        architect.hurryUp = true;
                    else
                        architect.ForceComplete();
                }else
                    architect.Build(longline);
                //architect.Build(lines[Random.Range(0, lines.Length)]);
            }
            else if (Input.GetKeyUp(KeyCode.A))
            {
                architect.Append(longline);
                //architect.Append(lines[Random.Range(0, lines.Length)]);
            }
        }
    }
}
