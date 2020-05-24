using System;

namespace Lab6
{
    class CoupleMethod
    {
        private static bool DoYouLikeHim(double prob)
        {
            int randomNumber = UniqueRandom.Instance.Next(100);
            //Console.WriteLine($"{randomNumber} < {prob * 100} is {randomNumber < prob * 100}");
            return randomNumber < prob * 100;
        }

        private static CoupleAttribute getAttr(Human first, Human second)
        {
            foreach (CoupleAttribute attr in first)
            {
                if (attr.Pair == second.GetType().Name)
                {
                    //Console.WriteLine($"Pair = {attr.Pair}, Probability = {attr.Probability}, ChildType = {attr.ChildType}");
                    return attr;
                }
            }
            throw new Exception("Both in couple have the same gender, it`s sin`t good. )=");
        }

        public static IHasName Couple(Human first, Human second)
        {
            CoupleAttribute firstAttr = getAttr(first, second);
            CoupleAttribute secondAttr = getAttr(second, first);

            bool firstLike = DoYouLikeHim(firstAttr.Probability);
            bool secondLike = DoYouLikeHim(secondAttr.Probability);
            string name = "Default";

            if (firstLike && secondLike)
            {
                var method = first.GetType().GetMethods()[1];
                name = (string)method.Invoke(first, null);
            }
            else
            {
                throw new Exception($"No love 1 = {firstLike} 2 = {secondLike}");
            }

            Type type = Type.GetType("Lab6." + firstAttr.ChildType, true);
            object obj = Activator.CreateInstance(type, name);

            return (IHasName)obj;
        }
    }
    }

