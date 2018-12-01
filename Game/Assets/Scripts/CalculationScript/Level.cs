using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.CalculationScript
{
    public class Level
    {
        public enum LevelEnum
        {
            easy,
            hard
        }

        public enum SignEnum
        {
            addition = '+',
            subtraction = '-',
            multiplication = '*',
            division = '/'
        }

        public static readonly Dictionary<LevelEnum, int> maxRangeOfLevel = new Dictionary<LevelEnum, int>
        {
            { LevelEnum.easy, 20},
            { LevelEnum.hard, 100}
        };
    }
}
