using System;

public static class RandomClass
{
    private static Random random = new Random();

    public static int Next(int maxValue) => random.Next(maxValue);
    public static int Next(int minValue, int maxValue) => random.Next(minValue, maxValue);
    public static double NextDouble() => random.NextDouble();
    public static bool PercentChance(int percent) => random.Next(100) < percent;
    public static int NextInRange(int min, int max) => random.Next(min, max + 1);
}