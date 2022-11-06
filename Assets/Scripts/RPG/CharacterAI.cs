using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.RPG
{
    public abstract class CharacterAI : MonoBehaviour
    {
        public List<CharacterAction> Actions;
        public abstract CharacterAction GetNextAction();
        public abstract CharacterAction[] PeekNextActions(int amount);
    }
}
