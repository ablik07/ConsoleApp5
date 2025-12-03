using System;
using System.Collections.Generic;

public class Game
{
    private Player player;
    private int turnCount;

    private List<Weapon> weapons = new List<Weapon>
    {
        new Weapon("Деревянный меч", 5),
        new Weapon("Стальной меч", 8),
        new Weapon("Огненный посох", 12)
    };

    private List<Armor> armors = new List<Armor>
    {
        new Armor("Кожаная броня", 3),
        new Armor("Кольчуга", 5),
        new Armor("Латные доспехи", 8)
    };

    public Game()
    {
        player = new Player(100);
        turnCount = 0;
    }

    public void Start()
    {
        Console.WriteLine("Добро пожаловать в текстовую RPG игру!");
        Console.WriteLine("Каждый ход вы встречаете сундук или врага.");
        Console.WriteLine("Каждые 10 ходов - босс!\n");

        while (player.HP > 0)
        {
            turnCount++;
            Console.WriteLine($"\n=== Ход {turnCount} ===");
            Console.WriteLine(player.GetStatus());

            if (player.IsFrozen)
            {
                Console.WriteLine("Вы заморожены и пропускаете ход!");
                player.IsFrozen = false;
                Continue();
                continue;
            }

            if (RandomClass.Next(2) == 0)
                OpenChest();
            else
                FightEnemy();

            if (turnCount % 10 == 0)
            {
                Console.WriteLine("\nПОЯВИЛСЯ БОСС!");
                FightBoss();
            }

            if (player.HP > 0)
                Continue();
        }

        Console.WriteLine($"\nИгра окончена! Вы продержались {turnCount} ходов!");
    }

    private void OpenChest()
    {
        Console.WriteLine("Вы нашли сундук!");
        Item item = RandomClass.Next(3) switch
        {
            0 => new HealthPotion(),
            1 => weapons[RandomClass.Next(weapons.Count)],
            _ => armors[RandomClass.Next(armors.Count)]
        };

        Console.WriteLine($"В сундуке: {item}");

        if (item is HealthPotion)
        {
            item.Use(player);
        }
        else
        {
            Console.WriteLine("\nВаша экипировка:");
            Console.WriteLine(player.GetEquipment());
            Console.WriteLine("\nВзять предмет? (д/н)");

            if (Console.ReadLine().ToLower() == "д")
            {
                item.Use(player);
                Console.WriteLine("Предмет экипирован!");
            }
        }
    }

    private void FightEnemy()
    {
        var enemy = EnemyFactory.CreateRegularEnemy();
        Console.WriteLine($"Вы встретили {enemy.Name}!");
        StartCombat(enemy);
    }

    private void FightBoss()
    {
        var boss = EnemyFactory.CreateBoss();
        Console.WriteLine($"Перед вами {boss.Name}!");
        StartCombat(boss);
    }

    private void StartCombat(Enemy enemy)
    {
        Console.WriteLine($"\n=== Бой с {enemy.Name} ===");

        while (enemy.IsAlive && player.HP > 0)
        {
            PlayerTurn(enemy);
            if (!enemy.IsAlive) break;
            EnemyTurn(enemy);
        }

        if (!enemy.IsAlive)
        {
            Console.WriteLine($"\nПобеда! Вы победили {enemy.Name}!");
        }
    }

    private void PlayerTurn(Enemy enemy)
    {
        Console.WriteLine("\nВаш ход:");
        Console.WriteLine("1 - Атаковать");
        Console.WriteLine("2 - Защищаться");
        Console.Write("Выберите действие: ");

        string choice = Console.ReadLine();
        if (choice == "1")
        {
            int damage = player.Attack;
            enemy.TakeDamage(damage);
            Console.WriteLine($"Вы нанесли {damage} урона!");
            Console.WriteLine($"{enemy.GetStatus()}");
        }
        else if (choice == "2")
        {
            Console.WriteLine("Вы готовитесь к защите...");
        }
        else
        {
            Console.WriteLine("Неверный выбор, пропускаете ход!");
        }
    }

    private void EnemyTurn(Enemy enemy)
    {
        Console.WriteLine($"\nХод {enemy.Name}:");

        int damage = enemy.CalculateDamage(player);
        int finalDamage = damage;

        if (player.TryDodge())
        {
            Console.WriteLine("Вы уклонились от атаки!");
        }
        else if (!enemy.IgnoreDefense)
        {
            finalDamage = player.CalculateBlockedDamage(damage);
            Console.WriteLine($"Вам нанесли {finalDamage} урона (было: {damage})");
        }
        else
        {
            Console.WriteLine($"Защита игнорирована! Урон: {finalDamage}");
        }

        player.TakeDamage(finalDamage);

        if (enemy.TryFreezePlayer())
        {
            player.IsFrozen = true;
            Console.WriteLine("Вас заморозили! Пропустите ход.");
        }

        Console.WriteLine($"{player.GetStatus()}");
    }

    private void Continue()
    {
        Console.WriteLine("\nНажмите любую клавишу...");
        Console.ReadKey();
    }
}