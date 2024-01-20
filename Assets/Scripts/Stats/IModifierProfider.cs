using System.Collections.Generic;

namespace RPG.Stats
{
    public interface IModifierProfider
    {
        IEnumerable<float> GetAdditiveModifier(Stat stat);
    }
}