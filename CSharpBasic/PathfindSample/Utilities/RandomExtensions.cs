

namespace PathfindSample.Utilities
{
    static class RandomExtensions
    {
        public static void Shuffle(this Random random, Coord[] coords)
        {
            int n = coords.Length;

            for (int i = 0; i < n - 1; i++)
            {
                int j = random.Next(i, n);

                if (j != i)
                {
                    Coord temp = coords[i];
                    coords[i] = coords[j];
                    coords[j] = temp;
                }
            }
        }
    }
}
