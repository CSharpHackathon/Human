using System;

namespace human
{
    public class Wizard : Human{
        public Wizard(string name, int intelligence = 25, int health = 50)
            :base(name){
        }

        public void Heal(){
            this.health += intelligence * 10;
            System.Console.WriteLine("Healed by " + intelligence * 10 );
        }

        public void Fireball(Monster enemy){
            Random rand = new Random();
            int power = rand.Next(20, 51);
            enemy.health -= power;
            System.Console.WriteLine("Wizard shoots the fireball -> " + power + " Damages");
        }
    }
}