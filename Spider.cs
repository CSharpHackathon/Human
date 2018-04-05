using System;

namespace human
{
    public class Spider: Monster
    {
        public int poisonDuration = 0;
        public Spider(string name){
            this.name = name;
            this.strength = 4;
            this.intelligence = 4;
        }

        public void PoisonAttack(Human player){
            this.health -= 1;
            player.health = player.health - (strength * intelligence);
            System.Console.WriteLine("{this.name} attacked {player}. {(strength * intelligence)} damages made. Current health: {player.health}");
            poisonDuration--;
            player.poisoned += 3;
        }
    }
}