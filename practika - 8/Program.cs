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
        static int gold = 0;
        static int potions = 0;
        static int arrows = 0;
        static int damegeMin = 10;
        static int damegeMax = 20;
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
                    OpenChest();
                    break;
                case 3:
                    VisitAltar();
                    break;
                case 4:
                    VisitMerchant();
                    break;
                case 5:
                    MeetDarkMage();
                    break;


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
                ShowStats();
                int damege = 0;
                Console.WriteLine("Выберите действие: (1) Меч, (2) Лук, (3) Зелье");
                string action = Console.ReadLine();
                switch (action)
                {
                    case "1": // Меч 
                        Console.WriteLine($"Вы нанесли {damege = rd.Next(damegeMin, damegeMax)}, а монстр вам {monsterAttack = rd.Next(8, 20)}");
                        health = health - monsterAttack;
                        monsterHP = monsterHP - damege;
                        break;

                    case "2": // Лук 
                        if (arrows > 0)
                        {
                            Console.WriteLine($"Вы нанесли {damege = rd.Next(damegeMin, damegeMax)}, а монстр вам {monsterAttack = rd.Next(1, 15)}");
                            health = health - monsterAttack;
                            monsterHP = monsterHP - damege;
                            arrows--;
                        }
                        else
                        {
                            Console.WriteLine("У вас нет стрел!");
                            continue;
                        }
                        break;

                    case "3": // Зелье 
                        UsePotion();
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
        public static void VisitMerchant() // покупка предметов у торговца.
        {
            bool bOOL = true;
            if (gold > 4)
            {
                while (bOOL)
                {
                    int torg = 0;
                    Console.WriteLine($"Вы попали к торговцу.\n Нажмите 2 если хотите преобрести зелье.\n 1 если хотите преобрестиесли стрелы.\n 0 если не хотите ничего преобретать.");
                    torg = Convert.ToInt32(Console.ReadLine());
                    if (torg == 2)
                    {
                        gold -= 10;
                        potions++;
                        Console.WriteLine($"Вы успешно преобрели зелье у вас {potions} зелий и {gold} золота");
                    }
                    if (torg == 1)
                    {
                        gold += 5;
                        arrows += 3;
                        Console.WriteLine($"Вы успешно преобрели 3 стрелы у вас {arrows} стрел и {gold} золота");
                    }
                    if (torg == 0)
                        bOOL = false;
                }
            }
            else { Console.WriteLine($"Вы попали к торговцу, но у вас нет денег или места."); }
        }
        public static void VisitAltar() // усиление персонажа за золото.
        {
            Console.Write("Вы попали к алтарю");
            if (gold >= 10)
            {
                Console.WriteLine("Вы можете пожертвовать 10 золота и получить\n - Увеличить урон меча на 5 \n - Восстановить 20 HP.\n Если хотите пожертвовать нажмите 1 если не хотите нажмите 0");
                int vibor = Convert.ToInt32(Console.ReadLine());
                if (vibor == 1)
                {
                    gold -= 10;
                    damegeMax += 5;
                    damegeMin += 5;
                    if (health <= maxHealth - 20)
                        health += 20;
                    else
                        health = maxHealth;
                }
            }
            else
                Console.WriteLine("У вас нет денег Вы бомж Идите работать");
        }
        public static void MeetDarkMage() // взаимодействие с таинственным магом.
        {
            Console.WriteLine("Вы попали к магу и он предлагает сделку: жертвуй 10 HP, чтобы получить 2 зелья и 5 стрел.\n Нажмите 1 если согласны если нет то 0");
            int vibor = Convert.ToInt32(Console.ReadLine());
            if (vibor == 1 && health > 10)
            {
                health -= 10;
                potions += 2;
                arrows += 5;
            }
            else if (vibor == 1 && health <= 10)
                Console.WriteLine("У вас не достаточно HP Маг изчез");
        }
        public static void UsePotion() // восстановление здоровья. 
        {
            if (potions > 0)
            {
                health = health + 30;
                potions = potions - 1;
            }
            if (potions == 0)
                Console.WriteLine("Не хватило зелий");
        }
        public static void ShowStats() // вывод характеристик игрока.
        {
            Console.WriteLine($"\nВаше здоровье: {health}\n Стрелы: {arrows}\n Зелья: {potions}\n Золота: {gold}\n Максимум здоровья: {maxHealth}\n Максимум урон мечём: {damegeMax}\n Минимум урон мечём: {damegeMin}");
        }

    }
}
