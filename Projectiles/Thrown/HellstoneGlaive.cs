using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TGEM.Projectiles.Thrown
{
    public class HellstoneGlaiveP : ModProjectile
    {

        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.Shuriken);
            projectile.name = "Hellstone Glaive";
            projectile.width = 22;       //projectile width
            projectile.height = 22;
            projectile.penetrate = 1;
            aiType = ProjectileID.Shuriken;
            projectile.ignoreWater = true;
            projectile.timeLeft = 6000;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
                target.AddBuff(24, 180, false);
        }

        public override void OnHitPvp(Player target, int damage, bool crit)
        {
            if (Main.rand.Next(3) == 0)
            {
                target.AddBuff(24, 180, false);
            }
        }
    }
    // This .cs file has 2 classes in it, which is totally fine. (What is important is that namespace+classname is unique. Remember that autoloaded textures follow the namespace+classname convention as well.)
    // This is an approach you can take to fit your organization style.
    public class HellstoneGlaive : ModItem
    {

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.Shuriken);
            item.damage = 30;
            item.shoot = mod.ProjectileType("HellstoneGlaiveP");
            item.name = "Hellstone Glaive";
            item.rare = 4;
            item.shootSpeed = 15f;
			item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(175, 1);
            recipe.AddTile(16);
            recipe.SetResult(this, 30);
            recipe.AddRecipe();
        }
    }
}
