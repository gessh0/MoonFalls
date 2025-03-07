    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace DIALOGUE
{
    public class DialogueSystem : MonoBehaviour
    {
        [SerializeField]private DialogueSystemConfigurationSO _config;
        public DialogueSystemConfigurationSO config => _config;

        public DialogueContainer dialogueContainer = new DialogueContainer();
        private ConversationManager conversationManager ;
        private TextArchitect architect;

        public static DialogueSystem instance { get; private set; }

        public delegate void DialogueSystemEvent();
        public event DialogueSystemEvent onUserPropt_Next;

        public bool isRunningConversation => conversationManager.isRunning;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                Initialize(); // Вызываем инициализацию
            }
            else
            {
                DestroyImmediate(gameObject);
            }
        }

        bool _initialized = false;

        private void Initialize()
        {
            if (_initialized)
                return;

            if (dialogueContainer.dialogueText == null)
            {
                Debug.LogError("dialogueText не назначен в DialogueContainer.");
                return;
            }

            architect = new TextArchitect(dialogueContainer.dialogueText);
            conversationManager = new ConversationManager(architect);

            _initialized = true;
            Debug.Log("DialogueSystem инициализирован.");
        }

        public void OnUserPrompt_Next()
        {
            onUserPropt_Next?.Invoke();
        }

        public void ShowSpeakerName(string speakerName = "") 
        {
            if (speakerName != "Автор")
                dialogueContainer.nameContainer.Show(speakerName);
            else
                HideSpeakerName();
        }
        public void HideSpeakerName() => dialogueContainer.nameContainer.Hide();

        public void Say(string speaker, string dialogue)
        {
            List<string> conversation = new List<string>() { $"{speaker} \"{dialogue}\"" };
            Say(conversation);
        }

        public void Say(List<string> conversation)
        {
            conversationManager.StartConversation(conversation);
        }
    }
}