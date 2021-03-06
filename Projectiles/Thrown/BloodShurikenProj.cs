using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace TGEM.Projectiles.Thrown {
public class BloodShurikenProj : ModProjectile
{
	public override void SetDefaults()
	{
		projectile.name = "Blood Shuriken";
		projectile.width = 20;
		projectile.height = 20;
		projectile.aiStyle = 2;
		projectile.penetrate = 3;
		projectile.thrown = true;
		projectile.friendly = true;
	}
	
	public override void Kill(int timeLeft)
        {
        	if (Main.rand.Next(3) == 0)
        	{
        		Item.NewItem((int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height, mod.ItemType("BloodShuriken"));
        	}
			for (int i = 0; i < 5; i++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 5);
				Main.dust[dust].scale = 1.5f;
				Main.dust[dust].noGravity = true;
			}
			Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y);
        }
		
	public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
	{
			Player player = Main.player[projectile.owner];
			player.HealEffect(1);
			player.statLife += 1;
	}
}
}	