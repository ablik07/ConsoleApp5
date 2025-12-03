public static class EnemyFactory
{
    public static Enemy CreateRegularEnemy()
    {
        return RandomClass.Next(4) switch
        {
            0 => new Goblin(),
            1 => new Skeleton(),
            2 => new Mage(),
            _ => new Slime()
        };
    }

    public static Enemy CreateBoss()
    {
        return RandomClass.Next(4) switch
        {
            0 => new BossGoblin(),
            1 => new BossSkeleton(),
            2 => new BossMage(),
            _ => new BossSkeleton2()
        };
    }
}