using System;

namespace human
{
    public class RandomEncounter
    {

        public void Encounter(Human[] allies, Monster[] enemies)
        {
            Random rand = new Random();
            Console.WriteLine("Random encounter! Enemies appeared!");
            int totallength = allies.Length + enemies.Length;
            object[] turns = new object[totallength];
            int i = 0;
            foreach (Human ally in allies)
            {
                turns[i] = ally;
                i++;
            }
            foreach (Monster enemy in enemies)
            {
                turns[i] = enemy;
                i++;
            }
            foreach (Monster enemy in enemies)
            {
                Console.WriteLine(enemy.name);
            }
            int turncount = 0;
            while (true)
            {
                Boolean allieswin = true;
                Boolean enemieswin = true;
                foreach (Monster enemy in enemies)
                {
                    if (enemy.health > 0)
                    {
                        allieswin = false;
                    }
                }
                foreach (Human ally in allies)
                {
                    if (ally.health > 0)
                    {
                        enemieswin = false;
                    }
                }
                if (allieswin == true)
                {
                    Console.WriteLine("You win! Commence victory theme!");
                    break;
                }
                if (enemieswin == true)
                {
                    Console.WriteLine("The allied party has died. Now the sacred crystals will never be collected, and darkness will forever rule throughout the land. Game Over.");
                    break;
                }
                int myturn = turncount % totallength;
                Console.WriteLine(myturn);
                if (turns[myturn] is Monster)
                {
                    Monster currenemy = turns[myturn] as Monster;
                    if (currenemy.health == 0)
                    {
                        turncount += 1;
                        continue;
                    }
                    Console.WriteLine("{0}'s turn!", currenemy.name);
                    int mytarget = 0;
                    while (true)
                    {
                        mytarget = rand.Next(0, allies.Length);
                        if (allies[mytarget].health > 0)
                        {
                            currenemy.Attack(allies[mytarget]);
                            break;
                        }
                    }
                    turns[myturn] = currenemy;
                }
                else if (turns[myturn] is Human)
                {
                    string command = "default";
                    string target = "default";
                    Monster mytarget = enemies[0];
                    if (turns[myturn] is Samurai)
                    {
                        Samurai turnplayer = turns[myturn] as Samurai;
                        if (turnplayer.health == 0)
                        {
                            turncount += 1;
                            continue;
                        }
                        while (true)
                        {
                            Boolean found = false;
                            Console.WriteLine("What will {0} do?", turnplayer.name);
                            command = Console.ReadLine();
                            if (command != "attack" && command != "deathblow" && command != "meditate")
                            {
                                Console.WriteLine("Invalid command.");
                                continue;
                            }
                            if (command != "meditate")
                            {
                                Console.WriteLine("Targeting what?");
                                target = Console.ReadLine();
                                foreach (Monster enemy in enemies)
                                {
                                    if (target == enemy.name)
                                    {
                                        mytarget = enemy;
                                        found = true;
                                        break;
                                    }
                                }
                                if (found == false)
                                {
                                    Console.WriteLine("Invalid target.");
                                    continue;
                                }
                            }
                            if (command == "attack")
                            {
                                turnplayer.Attack(mytarget);
                                if (turnplayer.poisoned > 0)
                                {
                                    turnplayer.health -= 5;
                                    turnplayer.poisoned--;
                                }
                                break;
                            }
                            else if (command == "deathblow")
                            {
                                turnplayer.Death_blow(mytarget);
                                if (turnplayer.poisoned > 0)
                                {
                                    turnplayer.health -= 5;
                                    turnplayer.poisoned--;
                                }
                                break;
                            }
                            else if (command == "meditate")
                            {
                                turnplayer.Meditate();
                                if (turnplayer.poisoned > 0)
                                {
                                    turnplayer.health -= 5;
                                    turnplayer.poisoned--;
                                }
                                break;
                            }
                        }
                    }
                    else if (turns[myturn] is Wizard)
                    {
                        Wizard turnplayer = turns[myturn] as Wizard;
                        if (turnplayer.health == 0)
                        {
                            turncount += 1;
                            continue;
                        }
                        while (true)
                        {
                            Boolean found = false;
                            Console.WriteLine("What will {0} do?", turnplayer.name);
                            command = Console.ReadLine();
                            if (command != "attack" && command != "fireball" && command != "heal")
                            {
                                Console.WriteLine("Invalid command.");
                                continue;
                            }
                            if (command != "heal")
                            {
                                Console.WriteLine("Targeting what?");
                                target = Console.ReadLine();
                                foreach (Monster enemy in enemies)
                                {
                                    if (target == enemy.name)
                                    {
                                        mytarget = enemy;
                                        found = true;
                                        break;
                                    }
                                }
                                if (found == false)
                                {
                                    Console.WriteLine("Invalid target.");
                                    continue;
                                }
                            }


                            if (command == "attack")
                            {
                                turnplayer.Attack(mytarget);
                                break;
                            }
                            else if (command == "fireball")
                            {
                                turnplayer.Fireball(mytarget);
                                break;
                            }
                            else if (command == "heal")
                            {
                                turnplayer.Heal();
                                break;
                            }
                        }
                    }
                    else if (turns[myturn] is Ninja)
                    {
                        Ninja turnplayer = turns[myturn] as Ninja;
                        if (turnplayer.health == 0)
                        {
                            turncount += 1;
                            continue;
                        }
                        while (true)
                        {
                            Boolean found = false;
                            Console.WriteLine("What will {0} do?", turnplayer.name);
                            command = Console.ReadLine();
                            if (command != "attack" && command != "steal" && command != "getaway")
                            {
                                Console.WriteLine("Invalid command.");
                                continue;
                            }
                            if (command != "getaway")
                            {
                                Console.WriteLine("Targeting what?");
                                target = Console.ReadLine();
                            }
                            foreach (Monster enemy in enemies)
                            {
                                if (target == enemy.name)
                                {
                                    mytarget = enemy;
                                    found = true;
                                    break;
                                }
                            }
                            if (found == false)
                            {
                                Console.WriteLine("Invalid target.");
                                continue;
                            }
                            if (command == "attack")
                            {
                                turnplayer.Attack(mytarget);
                                break;
                            }
                            else if (command == "steal")
                            {
                                turnplayer.Steal(mytarget);
                                break;
                            }
                            else if (command == "getaway")
                            {
                                turnplayer.Get_away();
                                Console.WriteLine("{} couldn't get away!", turnplayer.name);
                                break;
                            }
                        }
                    }
                    else
                    {
                        Human turnplayer = turns[myturn] as Human;
                        if (turnplayer.health == 0)
                        {
                            turncount += 1;
                            continue;
                        }
                        while (true)
                        {
                            Boolean found = false;
                            Console.WriteLine("What will {0} do?", turnplayer.name);
                            command = Console.ReadLine();
                            if (command != "attack")
                            {
                                Console.WriteLine("Invalid command.");
                                continue;
                            }
                            foreach (Monster enemy in enemies)
                            {
                                if (target == enemy.name)
                                {
                                    mytarget = enemy;
                                    found = true;
                                    break;
                                }
                            }
                            if (found == false)
                            {
                                Console.WriteLine("Invalid target.");
                                continue;
                            }
                            if (command == "attack")
                            {
                                turnplayer.Attack(mytarget);
                                break;
                            }
                        }
                    }

                }
                turncount += 1;
            }
        }

        public Monster[] Encountermake()
        {
            Random rand = new Random();
            int choice = rand.Next(0, 3);
            switch (choice)
            {
                case 0:
                    Skeleton Skeleton1 = new Skeleton("Skeleton1");
                    Skeleton Skeleton2 = new Skeleton("Skeleton2");
                    Spider Spider1 = new Spider("Spider1");
                    Monster[] en1 = new Monster[] { Skeleton1, Skeleton2, Spider1 };
                    return en1;
                case 1:
                    Spider Spider2 = new Spider("Spider1");
                    Spider Spider3 = new Spider("Spider2");
                    Monster[] en2 = new Monster[] { Spider2, Spider3 };
                    return en2;
                case 2:
                    Vampire Vampire1 = new Vampire("Vampire1");
                    Skeleton Skeleton3 = new Skeleton("Skeleton1");
                    Monster[] en3 = new Monster[] { Vampire1, Skeleton3 };
                    return en3;
                default:
                    return null;

            }
        }
    }
}