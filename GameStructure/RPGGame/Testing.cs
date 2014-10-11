using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPGGame.Creatures;
using RPGGame.Places;
using RPGGame.Weapons;
namespace RPGGame
{
    class Testing
    {

        public static void Main()
        {
            List<EnemyWeapon> weapons = new List<EnemyWeapon>();
            weapons.Add(new EnemyWeapon(WeaponType.Body, 105, 1));
            Console.WriteLine(weapons[0].Damage);
            changeGunCharacteristics(70, weapons[0]);
            Console.WriteLine(weapons[0].Damage);

            // Enemy bot = new Enemy(1f, weapons[0]);
            // Player pesho = new Player(1f, new List<Weapon> { new PlayerWeapon(WeaponType.Knife, 50f, 10f)});
            // bot.EnemyWeapon.UseWeapon();
            // Console.WriteLine(bot.Health);
            // pesho.MakeDamage(bot);

            //// Console.WriteLine(bot.Health); 
            // Console.WriteLine(bot.IsAlive());
            // foreach(PlayerWeapon weapon in pesho.PlayerWeapons)
            // {
            //     Console.WriteLine( weapon.Name );
            // }
        }

        public static void changeGunCharacteristics(float damage, EnemyWeapon gun)
        {
            gun.Damage += damage;
        }
    }
}
