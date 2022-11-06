using System.Linq;

namespace Assets.Scripts.RPG.AI
{
    public class RepeatedActionAI : CharacterAI
    {
        public override CharacterAction GetNextAction()
        {
            return Actions.FirstOrDefault();
        }

        public override CharacterAction[] PeekNextActions(int amount)
        {
            return Enumerable.Repeat(Actions.FirstOrDefault(), amount).ToArray();
        }
    }
}
