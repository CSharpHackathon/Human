using System;

namespace human
{
    class Ninja: Human{
        public Ninja(string name, int dexiterity = 170)
            :base(name){
        }

        public void Steal(object enemy){
            Attack2(enemy);
            this.health += 10;
            System.Console.WriteLine("{0} gained 10 health, going up to {1}!",this.name,this.health);
        }

        public void Get_away(){
            this.health -= 15;
            System.Console.WriteLine("Ninja got away health decresed by -15");
        }
    }
}
