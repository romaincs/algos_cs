namespace algos_cs
{
    public class Fibonnaci
    {
        int[] suite;

        public Fibonnaci(int nb)
        {
            suite = new int[nb];
        }

        public string Generate()
        {
            int cpt = 0;
            while(cpt < suite.Length)
                calculate(cpt++);

            return string.Join("", suite);
        }

        private void calculate(int cpt)
        {
            if (cpt == 0 || cpt == 1)
                suite[cpt] = cpt;
            else
                suite[cpt] += suite[cpt - 1] + suite[cpt - 2];
        }
    }
}
