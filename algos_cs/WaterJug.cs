using System;
using System.Text;

namespace algos_cs
{
    public class WaterJug
    {
        public static int GetGreatestCommonDivisor(int a, int b)
        {
            if (b == 0)
                return a;
            return GetGreatestCommonDivisor(b, a % b);
        }  

        private static int FillFirstJug(int fromCapacity, List<ResultStep> outRes, int toCap)
        {
            int fromCap = fromCapacity;
            outRes.Add(new (new (-1, 1), new int[] { toCap, fromCap }));
            return fromCap;
        }

        private static int EmptySecondJug(List<ResultStep> outRes, int from)
        {
            int to = 0;
            outRes.Add(new (new (0, -1), new int[] { to, from }));
            return to;
        }

        private static bool DoesOneJugEqualsToTarget(int target, int from, int to)
        {
            return from == target || to == target;
        }

        private static int FindMaxAmountOfWater(int jug2, int from, int to)
        {
            return Math.Min(from, jug2 - to);
        }

        public static ResultStep[] PourWater(int jug1, int jug2, int target)
        {
            var steps = new List<ResultStep>();

            int from = jug1;
            int to = 0;
            steps.Add(new (new (-1, 1), new int[] { to, from }));

            while (!DoesOneJugEqualsToTarget(target, from, to))
            {
                int max = FindMaxAmountOfWater(jug2, from, to);
                to += max;
                from -= max;
                steps.Add(new (new (1, 0), new int[] { to, from }));

                if (DoesOneJugEqualsToTarget(target, from, to))
                    break;

                if (from == 0)
                    from = FillFirstJug(jug1, steps, to);

                if (to == jug2)
                    to = EmptySecondJug(steps, from);
            }

            return steps.ToArray();
        }

        public static ResultStep[]? FindPourOperations(int target, int[] capacities)
        {
            if (capacities.Length != 2)
                return null;

            Array.Sort(capacities);
            int jug1 = capacities[0];
            int jug2 = capacities[1];

            if (target > jug2)
                return null;

            if ((target % GetGreatestCommonDivisor(jug2, jug1)) != 0)
                return null;

            var steps = PourWater(jug1, jug2, target);
            var stepsReverse = PourWater(jug2, jug1, target);

            return (steps.Length <= stepsReverse.Length) ? steps : stepsReverse;
        }
    }

    public class ResultStep
    {
        public PourOperation Op { get; }
        public int[] State { get; }

        public ResultStep(PourOperation op, int[] state)
        {
            this.Op = op;
            this.State = state;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if (Op.Src < 0) sb.Append('*');
            else sb.Append(Op.Src);
            sb.Append(" -> ");
            if (Op.Dst < 0) sb.Append('*');
            else sb.Append(Op.Dst);
            sb.Append(" : ");
            sb.Append('(');
            for (int i = 0; i < State.Length; i++)
            {
                if (i > 0) sb.Append(',');
                sb.Append(State[i]);
            }
            sb.Append(')');
            return sb.ToString();
        }
    }

    public struct PourOperation
    {
        public int Src { get; }
        public int Dst { get; }

        public PourOperation(int src, int dst)
        {
            this.Src = src;
            this.Dst = dst;
        }

        public override string ToString()
        {
            return (Src < 0 ? "*" : Src.ToString()) + " -> " + (Dst < 0 ? "*" : Dst.ToString());
        }
    }
}
