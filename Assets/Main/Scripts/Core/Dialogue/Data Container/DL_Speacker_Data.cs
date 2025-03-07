using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;

namespace DIALOGUE
{
    public class DL_Speacker_Data
    {
        public string name, castName;

        public string displayname => castName != string.Empty ? castName : name;

        public Vector2 castPosition;
        public List<(int layer, string expression)> CastExpression { get; set; }

        private const string NAMECAST_ID = " as ";
        private const string POSITIONCAST_ID = " at ";
        private const string EXPRESSIONCAST_ID = " [";
        private const char AXISDELIMITER = ':';
        private const char EXPRESSIONLAYER_JOINER = ',';
        private const char EXPRESSIONLAYER_DELIMITER = ':';

        public DL_Speacker_Data(string rawSpeaker)
        {
            string pattern = @$"{NAMECAST_ID}|\s*{POSITIONCAST_ID}\s*|{EXPRESSIONCAST_ID.Insert(EXPRESSIONCAST_ID.Length - 1, @"\")}";
            MatchCollection mathes = Regex.Matches(rawSpeaker, pattern);

            castName = "";
            castPosition = Vector2.zero;
            CastExpression = new List<(int layer, string expression)>();

            if (mathes.Count == 0)
            {
                name = rawSpeaker;
                return;
            }

            int index = mathes[0].Index;
            name = rawSpeaker.Substring(0, index);

            for (int i = 0; i < mathes.Count; i++)
            {
                Match match = mathes[i];
                int startIndex = 0, endIndex = 0;

                if (match.Value.Trim() == NAMECAST_ID.Trim())
                {
                    startIndex = match.Index + NAMECAST_ID.Length;
                    endIndex = i < mathes.Count - 1 ? mathes[i + 1].Index : rawSpeaker.Length;
                    castName = rawSpeaker.Substring(startIndex, endIndex - startIndex).Trim();
                }
                else if (match.Value.Trim() == POSITIONCAST_ID.Trim())
                {
                    startIndex = match.Index + POSITIONCAST_ID.Length;
                    endIndex = i < mathes.Count - 1 ? mathes[i + 1].Index : rawSpeaker.Length;
                    string castPos = rawSpeaker.Substring(startIndex, endIndex - startIndex).Trim();

                    string[] axis = castPos.Split(AXISDELIMITER, System.StringSplitOptions.RemoveEmptyEntries);

                    float.TryParse(axis[0], out castPosition.x);

                    if (axis.Length > 1)
                        float.TryParse(axis[1], out castPosition.y);
                }
                else if (match.Value.Trim() == EXPRESSIONCAST_ID.Trim())
                {
                    startIndex = match.Index + EXPRESSIONCAST_ID.Length;
                    endIndex = i < mathes.Count - 1 ? mathes[i + 1].Index : rawSpeaker.Length;
                    string castExp = rawSpeaker.Substring(startIndex, endIndex - (startIndex + 1)).Trim();

                    CastExpression = castExp.Split(EXPRESSIONLAYER_JOINER)
                        .Select(x =>
                        {
                            var parts = x.Trim().Split(EXPRESSIONLAYER_DELIMITER);
                            return (int.Parse(parts[0]), parts[1]);
                        }).ToList();
                }
            }
        }
    }
}