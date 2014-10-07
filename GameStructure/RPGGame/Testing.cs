using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPGGame.Weapons;
namespace RPGGame
{
    class Testing
    {

        public static void Main()
        {
            Enemy bot = new Enemy(1f, new EnemyWeapon( WeaponType.Body, 23.2f, 1f ));
            Player pesho = new Player(1f, new List<Weapon> { new PlayerWeapon(WeaponType.Knife, 50f, 10f)});
            bot.EnemyWeapon.UseWeapon();
            Console.WriteLine(bot.Health);
            pesho.MakeDamage(bot);
            
            // Console.WriteLine(bot.Health); 
            Console.WriteLine(bot.IsAlive());
            foreach(PlayerWeapon weapon in pesho.PlayerWeapons)
            {
                Console.WriteLine( weapon.Name );
            }
        }

    }
}
