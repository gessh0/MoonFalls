using UnityEngine;
using Characters;
using TMPro;

namespace DIALOGUE
{
    [CreateAssetMenu(fileName ="Dialogue System Configuration", menuName = "Dialogue System/Dialogue Configuration Asset")]
    public class DialogueSystemConfigurationSO : ScriptableObject
    {
        public CharacterCondigSO characterConfigurationAsset;

        public Color defaultTextColor = Color.white;
        public TMP_FontAsset defaultFont;
    }
}