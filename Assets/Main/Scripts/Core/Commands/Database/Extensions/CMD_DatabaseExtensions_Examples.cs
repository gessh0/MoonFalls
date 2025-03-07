using COMMANDS;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Testing
{
    public class CMD_DatabaseExtensions_Examples : CMD_DatabaseExtension
    {
        new public static void Extend(CommandDatabase database)
        {
            //action
            database.AddCommand("print", new Action(PrintDefaultMessage));
            database.AddCommand("print_1p", new Action<string>(PrintUsermessage));
            database.AddCommand("print_mp", new Action<string[]>(PrintLines));

            //lambda
            database.AddCommand("lambda", new Action(() => { Debug.Log("Сообщение в консоль с помощью лямбды"); }));
            database.AddCommand("lambda_1p", new Action<string>((arg) => { Debug.Log($"Юзер лог лямбда:{arg}"); }));
            database.AddCommand("lambda_mp", new Action<string[]>((args) => { Debug.Log(string.Join(",", args)); }));

            //coroutine
            database.AddCommand("process", new Func<IEnumerator>(SimpleProcess));
            database.AddCommand("process_1p", new Func<string, IEnumerator>(LineProcess));
            database.AddCommand("process_mp", new Func<string[], IEnumerator>(MultiLineProcess));

            //special
            database.AddCommand("moveCharDemo", new Func<string, IEnumerator>(MoveCharacter));
        }

        private static void PrintDefaultMessage()
        {
            Debug.Log("Сообщение в консоль");
        }
        private static void PrintUsermessage(string message)
        {
            Debug.Log($"Сообещение юзерна: '{message}'");
        }

        private static void PrintLines(string[] lines)
        {
            int i = 1;
            foreach (string line in lines)
            {
                Debug.Log($"{i++}. '{line}'");
            }
        }

        private static IEnumerator SimpleProcess()
        {
            for (int i = 1; i <= 5; i++)
            {
                Debug.Log($"Процесс идёт..[{i}]");
                yield return new WaitForSeconds(1);
            }
        }
        private static IEnumerator LineProcess(string data)
        {
            if (int.TryParse(data, out int num))
            {
                for (int i = 1; i <= 5; i++)
                {
                    Debug.Log($"Процесс идёт..[{i}]");
                    yield return new WaitForSeconds(1);
                }
            }
        }

        private static IEnumerator MultiLineProcess(string[] data)
        {
            foreach (string line in data)
            {
                Debug.Log($"Процесс идёт..[{line}]");
                yield return new WaitForSeconds(0.5f);
            }
        }

        private static IEnumerator MoveCharacter(string direction)
        {
            bool left = direction.ToLower() == "left";

            Transform character = GameObject.Find("Image").transform;
            float moveSpeed = 15;

            float targetX = left ? -8 : 8;
            float currentX = character.position.x;

            while (Mathf.Abs(targetX - currentX) > 0.1f)
            {
                currentX = Mathf.MoveTowards(currentX, targetX, moveSpeed * Time.deltaTime);
                character.position = new Vector3(currentX, character.position.y, character.position.z);
                yield return null;
            }
        }
    }
}