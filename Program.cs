using System;

namespace human
{
    class Program
    {
        static void Main(string[] args)
        {
            Samurai samurai = new Samurai("Samu");

            Spider spider = new Spider("Dy");
            spider.PoisonAttack(samurai);

            // wizard.Attack(ninja);
            // ninja.Steal(samurai1);
            // ninja.Get_away();

            // System.Console.WriteLine(ninja.ToString());
            // System.Console.WriteLine(samurai1.ToString());
            // System.Console.WriteLine(wizard.ToString());
            // System.Console.WriteLine(samurai2.ToString());

            // samurai1.Meditate();
            // samurai2.Death_blow(ninja);
            // Samurai.How_many();

            // wizard.Fireball(samurai1);
            // samurai2.Death_blow(wizard);
            // wizard.Heal();


        }
    }
}
