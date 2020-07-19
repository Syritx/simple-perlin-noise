using System;

namespace SIMPLE_PERLIN_NOISE
{
    class Perlin {
        public static float[] GenerateHeightMaps(int layers, int length, float intensity, int min, int max)
        {
            int area = length*length;
            float[] heightMaps = new float[area];

            for (int layer = 0; layer < layers; layer++) {
                for (int index = 0; index < area; index++)
                {
                    if (min > 0) min *= -1;

                    Random rMin = new Random();
                    Random rMax = new Random();
                    int newMin = rMin.Next(min, -1);
                    int newMax = rMax.Next(1, max);

                    Random randomIncrease = new Random();
                    float newHeight = randomIncrease.Next(newMin, newMax);
                    heightMaps[index] += (newHeight*intensity);
                }
            }

            return heightMaps;
        }
    }

    class MainClass
    {
        static int length = 10;
        static int layers = 10;
        static float intensity = .1f;

        static int min = 5, max = 5;
        static float[] heightMaps;

        public static void Main(string[] args)
        {
            // generating heightMaps
            heightMaps = Perlin.GenerateHeightMaps(layers, length, intensity, min, max);

            // printing the heightMaps
            int index = 0;
            for (int collum = 0; collum < length; collum++) {

                string perlinMapping = null;
                for (int row = 0; row < length; row++) {
                    perlinMapping += heightMaps[index].ToString("0.0 ");
                    index++;
                }

                Console.WriteLine(perlinMapping);
            }
        }
    }
}
