
using System.Collections;

namespace TheTower
{
    public class PotionBelt
    {

        private class ApPotion
        {

        }

        private class HealthPotion
        {

        }

        private ArrayList ApPotionList;
        private ArrayList HealthPotionList;
        public PotionBelt()
        {
            ApPotionList = new ArrayList(5);
            HealthPotionList = new ArrayList(5);
            for (int x = 0; x < 5; x++)
            {
                ApPotion AP_Potion = new ApPotion();
                HealthPotion H_Potion = new HealthPotion();
                ApPotionList.Add(AP_Potion);
                HealthPotionList.Add(H_Potion);
            }
        }
        public int GetApPotionList()
        {
            return ApPotionList.Count;
        }

        public int GetHealthPotionList()
        {
            return HealthPotionList.Count;
        }

        public void UseHealthPotion(Pawn actor)
        {
            if (HealthPotionList.Count > 0)
            {
                HealthPotionList.RemoveAt(0);
                actor.SetHealth(actor.MaxHealth);
            }
        }

        public void UseApPotion(Pawn actor)
        {
            if (ApPotionList.Count > 0)
            {
                ApPotionList.RemoveAt(0);
                actor.ResetAP();
            }
        }
    }
}
