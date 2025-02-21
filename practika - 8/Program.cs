using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practika___8
{
    internal class Program
    {
        static Random rd = new Random();
        static int health = 0;
        static int maxHealth = 0;
        static int gold =0; 
        static int potions = 0;
        static int arrows = 0;
        static void Main(string[] args)
        {
            int roomNumber = 0;
            InitializeGame();
            for (int i = 1; i < 14; i++)
            { 
                roomNumber = rd.Next();
                ProcessRoom(roomNumber);
            }


        }
        public static void ProcessRoom(int roomNumber) // обрабатывает событие в комнате
        {
            int monsterHP = 0;
            int monsterAttack = 0;
            switch (roomNumber)
                {
                    case 1:
                        FightMonster(monsterHP, monsterAttack);
                        break;
                    case 2:


                }
        }
        public static void InitializeGame()    // базовые настройки
        {
            health = 100;
            maxHealth = 100;
            gold = 10;
            potions = 2;
            arrows = 5;
        }
        public static void FightMonster(int monsterHP, int monsterAttack)    // монстр
        {
            Console.WriteLine($"Вы зашли в комнату с монстром у него {monsterHP = rd.Next(10, 40)}");

            while (health >= 0 && monsterHP >= 0)
            {
                int damege = 0;
                Console.WriteLine($"\nВаше здоровье: {health}, Стрелы: {arrows}, Зелья: {potions}");
                Console.WriteLine("Выберите действие: (1) Меч, (2) Лук, (3) Зелье");
                string action = Console.ReadLine();
                switch (action)
                {
                    case "1": // Меч 
                        Console.WriteLine($"Вы нанесли {damege = rd.Next(10, 20)}, а монстр вам {monsterAttack = rd.Next(8, 20)}");
                        health = health - monsterAttack;
                        monsterHP = monsterHP - damege;
                        break;

                    case "2": // Лук 
                        if (arrows > 0)
                        {
                            Console.WriteLine($"Вы нанесли {damege = rd.Next(5, 15)}, а монстр вам {monsterAttack = rd.Next(1, 15)}");
                            health = health - monsterAttack;
                            monsterHP = monsterHP - damege;
                            arrows--;
                            Console.WriteLine($"У вас осталось {arrows} стрел");
                        }
                        else
                        {
                            Console.WriteLine("У вас нет стрел!");
                            continue;
                        }
                        break;

                    case "3": // Зелье 
                        if (potions > 0)
                        {
                            health = health + 30;
                            potions = potions - 1;
                        }
                        if (potions == 0)
                            Console.WriteLine("Не хватило зелий");
                        break;
                }
            }
            if (health > 0) Console.WriteLine("Вы одалели монстра!");
            else Console.WriteLine("Вы умерли:(");
        }
        public static void OpenChest() // открытие сундука (обычного или проклятого). 
        {
            int sunduk = rd.Next(1, 4);
            Console.WriteLine($"Вы зашли в комнату с сундуком ");
            if (sunduk == 1) { potions++; Console.WriteLine("В сундуке было зелье"); }
            if (sunduk == 2) { gold = gold + 15; Console.WriteLine("В сундуке были монеты"); }
            if (sunduk == 3) { arrows++; Console.WriteLine("В сундуке были стрелы"); }
            if (sunduk == 4) { maxHealth -= 10; Console.WriteLine($"Cундук был проклятым теперь у вас {maxHealth} максимального HP"); }
        }


    }
}
