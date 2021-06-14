using System;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.Utilities;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Net.Security;

namespace CarlWheezerMod.NPCs.CarlWheezer
{
    [AutoloadBossHead]
    public class CarlWheezer : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Carl Wheezer");
        }

        public override void SetDefaults()
        {
            npc.width = 1358;
            npc.height = 921;
            npc.value = 999000;
            npc.lifeMax = 3000000;
            npc.knockBackResist = 0f;
            npc.aiStyle = -1;
            npc.npcSlots = 15f;
            npc.scale = 0.6f;
            npc.buffImmune[31] = true;
            npc.buffImmune[36] = true;
            npc.buffImmune[144] = true;
            music = MusicID.Boss1;
            npc.boss = true;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath10;
            npc.noTileCollide = true;
            npc.noGravity = true;
            npc.lavaImmune = true;
            npc.defense = 100;
            npc.direction = -1;
        }

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            scale = 1.5f;
            return null;
        }

        public override bool PreAI()
        {
            Lighting.AddLight(new Vector2(npc.Center.X, npc.Center.Y - 15), 255 * 0.005f, 255 * 0.005f, 230 * 0.005f);
            if (Main.expertMode)
            {
                npc.damage = 300;
            }
            else
            {
                npc.damage = 150;
            }
            npc.TargetClosest(true);
            npc.spriteDirection = npc.direction;
            Player player = Main.player[npc.target];
            if (player.dead)
            {
                npc.active = false;
            }
            return true;
        }

        public override void AI()
        {
            Vector2 direction = Main.player[npc.target].Center - npc.Center;
            npc.TargetClosest(true);

            npc.netUpdate = true;
            Player P = Main.player[npc.target];

            if (Main.expertMode)
            {
                npc.ai[1]++;
            }

            if (npc.ai[1] == 1)
            {
                npc.lifeMax = 4200000;
                npc.life = 4200000;
            }

                if (Main.player[npc.target].position.X < npc.position.X + 1000)
                {
                    if (npc.velocity.X > -10) npc.velocity.X -= 1f;
                }

                if (Main.player[npc.target].position.X > npc.position.X + 1000)
                {
                    if (npc.velocity.X < 10) npc.velocity.X += 1f;
                }

                if (Main.player[npc.target].position.Y < npc.position.Y)
                {
                    if (npc.velocity.Y < 0)
                    {
                        if (npc.velocity.Y > -2) npc.velocity.Y -= 0.75f;
                    }
                    else npc.velocity.Y -= 0.3f;
                }

            if (Main.player[npc.target].position.Y > npc.position.Y)
            {
                if (npc.velocity.Y > 0)
                {
                    if (npc.velocity.Y < 2) npc.velocity.Y += 0.75f;
                }
                else npc.velocity.Y += 0.3f;
            }



            npc.ai[0]++;

            #region SicklePhase
            if (npc.ai[0] >= 120)
            {
                if (npc.ai[0] <= 240)
                {
                    if (Main.rand.Next(10) == 0)
                    {
                        float Speed = 15f;
                        Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                        int damage = 200;
                        int type = 44;
                        float rotation = (float)Math.Atan2(vector8.Y - (P.position.Y + (P.height * 0.5f)), vector8.X - (P.position.X + (P.width * 0.5f))) + MathHelper.ToRadians(-10);
                        int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                        Main.PlaySound(4, (int)npc.position.X, (int)npc.position.Y, 14);
                    }
                    if (Main.rand.Next(10) == 0)
                    {
                        float Speed = 15f;
                        Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                        int damage = 200;
                        int type = 44;
                        float rotation = (float)Math.Atan2(vector8.Y - (P.position.Y + (P.height * 0.5f)), vector8.X - (P.position.X + (P.width * 0.5f))) + MathHelper.ToRadians(-5);
                        int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                        Main.PlaySound(4, (int)npc.position.X, (int)npc.position.Y, 14);
                    }
                    if (Main.rand.Next(10) == 0)
                    {
                        float Speed = 15f;
                        Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                        int damage = 200;
                        int type = 44;
                        float rotation = (float)Math.Atan2(vector8.Y - (P.position.Y + (P.height * 0.5f)), vector8.X - (P.position.X + (P.width * 0.5f)));
                        int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                        Main.PlaySound(4, (int)npc.position.X, (int)npc.position.Y, 14);
                    }
                    if (Main.rand.Next(10) == 0)
                    {
                        float Speed = 15f;
                        Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                        int damage = 200;
                        int type = 44;
                        float rotation = (float)Math.Atan2(vector8.Y - (P.position.Y + (P.height * 0.5f)), vector8.X - (P.position.X + (P.width * 0.5f))) + MathHelper.ToRadians(5);
                        int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                        Main.PlaySound(4, (int)npc.position.X, (int)npc.position.Y, 14);
                    }
                    if (Main.rand.Next(10) == 0)
                    {
                        float Speed = 15f;
                        Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                        int damage = 200;
                        int type = 44;
                        float rotation = (float)Math.Atan2(vector8.Y - (P.position.Y + (P.height * 0.5f)), vector8.X - (P.position.X + (P.width * 0.5f))) + MathHelper.ToRadians(10);
                        int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                        Main.PlaySound(4, (int)npc.position.X, (int)npc.position.Y, 14);
                    }
                }
            }
            #endregion

            #region BombPhase
            if (npc.ai[0] == 320)
            {
                float Speed = 15f;
                Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                int damage = 200;
                int type = 75;
                float rotation = MathHelper.ToRadians(90);
                int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                Main.PlaySound(4, (int)npc.position.X, (int)npc.position.Y, 14);
            }
            if (npc.ai[0] == 320)
            {
                float Speed = 15f;
                Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                int damage = 200;
                int type = 75;
                float rotation = MathHelper.ToRadians(180);
                int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                Main.PlaySound(4, (int)npc.position.X, (int)npc.position.Y, 14);
            }
            if (npc.ai[0] == 320)
            {
                float Speed = 15f;
                Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                int damage = 200;
                int type = 75;
                float rotation = MathHelper.ToRadians(270);
                int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                Main.PlaySound(4, (int)npc.position.X, (int)npc.position.Y, 14);
            }
            if (npc.ai[0] == 320)
            {
                float Speed = 15f;
                Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                int damage = 200;
                int type = 75;
                float rotation = MathHelper.ToRadians(0);
                int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                Main.PlaySound(4, (int)npc.position.X, (int)npc.position.Y, 14);
            }

            if (npc.ai[0] == 330)
            {
                float Speed = 10f;
                Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                int damage = 200;
                int type = 75;
                float rotation = MathHelper.ToRadians(90);
                int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                Main.PlaySound(4, (int)npc.position.X, (int)npc.position.Y, 14);
            }
            if (npc.ai[0] == 330)
            {
                float Speed = 10f;
                Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                int damage = 200;
                int type = 75;
                float rotation = MathHelper.ToRadians(180);
                int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                Main.PlaySound(4, (int)npc.position.X, (int)npc.position.Y, 14);
            }
            if (npc.ai[0] == 330)
            {
                float Speed = 10f;
                Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                int damage = 200;
                int type = 75;
                float rotation = MathHelper.ToRadians(270);
                int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                Main.PlaySound(4, (int)npc.position.X, (int)npc.position.Y, 14);
            }
            if (npc.ai[0] == 330)
            {
                float Speed = 10f;
                Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                int damage = 200;
                int type = 75;
                float rotation = MathHelper.ToRadians(0);
                int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                Main.PlaySound(4, (int)npc.position.X, (int)npc.position.Y, 14);
            }

            if (npc.ai[0] == 340)
            {
                float Speed = 5f;
                Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                int damage = 200;
                int type = 75;
                float rotation = MathHelper.ToRadians(90);
                int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                Main.PlaySound(4, (int)npc.position.X, (int)npc.position.Y, 14);
            }
            if (npc.ai[0] == 340)
            {
                float Speed = 5f;
                Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                int damage = 200;
                int type = 75;
                float rotation = MathHelper.ToRadians(180);
                int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                Main.PlaySound(4, (int)npc.position.X, (int)npc.position.Y, 14);
            }
            if (npc.ai[0] == 340)
            {
                float Speed = 5f;
                Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                int damage = 200;
                int type = 75;
                float rotation = MathHelper.ToRadians(270);
                int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                Main.PlaySound(4, (int)npc.position.X, (int)npc.position.Y, 14);
            }
            if (npc.ai[0] == 340)
            {
                float Speed = 5f;
                Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                int damage = 200;
                int type = 75;
                float rotation = MathHelper.ToRadians(0);
                int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                Main.PlaySound(4, (int)npc.position.X, (int)npc.position.Y, 14);
            }
            #endregion

            #region TridentPhase
            if (npc.ai[0] >= 400)
            {
                if (npc.ai[0] <= 460)
                {
                    float Speed = 20f;
                    Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                    int damage = 200;
                    int type = 115;
                    float rotation = (float)Math.Atan2(vector8.Y - (P.position.Y + (P.height * 0.5f)), vector8.X - (P.position.X + (P.width * 0.5f)));
                    int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                    Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 12);
                }

                if (npc.ai[0] <= 460)
                {
                    float Speed = 15f;
                    Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                    int damage = 200;
                    int type = 115;
                    float rotation = (float)Math.Atan2(vector8.Y - (P.position.Y + (P.height * 0.5f)), vector8.X - (P.position.X + (P.width * 0.5f))) + MathHelper.ToRadians(10);
                    int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                    Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 12);
                }

                if (npc.ai[0] <= 460)
                {
                    float Speed = 15f;
                    Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                    int damage = 200;
                    int type = 115;
                    float rotation = (float)Math.Atan2(vector8.Y - (P.position.Y + (P.height * 0.5f)), vector8.X - (P.position.X + (P.width * 0.5f))) - MathHelper.ToRadians(10);
                    int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                    Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 12);
                }
            }
            #endregion

            #region BeamPhase
            if (npc.ai[0] >= 480)
            {
                if (npc.ai[0] <= 540)
                {
                    float Speed = 25f;
                    Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                    int damage = 200;
                    int type = 259;
                    float rotation = (float)Math.Atan2(vector8.Y - (P.position.Y + (P.height * 0.5f)), vector8.X - (P.position.X + (P.width * 0.5f))) + MathHelper.ToRadians(2); 
                    int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                    Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 12);
                }

                if (npc.ai[0] <= 540)
                {
                    float Speed = 25f;
                    Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                    int damage = 200;
                    int type = 259;
                    float rotation = (float)Math.Atan2(vector8.Y - (P.position.Y + (P.height * 0.5f)), vector8.X - (P.position.X + (P.width * 0.5f))) - MathHelper.ToRadians(2);
                    int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                    Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 12);
                }

                if (npc.ai[0] <= 540)
                {
                    float Speed = 20f;
                    Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                    int damage = 200;
                    int type = 259;
                    float rotation = MathHelper.ToRadians(180);
                    int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                    Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 12);
                }

                if (npc.ai[0] <= 540)
                {
                    float Speed = 20f;
                    Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                    int damage = 200;
                    int type = 259;
                    float rotation = MathHelper.ToRadians(0);
                    int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                    Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 12);
                }
            }
            #endregion

            if (npc.ai[0] >= 600)
            {
                npc.ai[0] = 0;
            }
        }


        public override void NPCLoot()
        {
            Gore.NewGore(npc.position, npc.velocity, 73, 5f);
            Gore.NewGore(npc.position, npc.velocity, 74, 5f);
            Gore.NewGore(npc.position, npc.velocity, 75, 5f);
            Gore.NewGore(npc.position, npc.velocity, 73, 5f);
            Gore.NewGore(npc.position, npc.velocity, 74, 5f);
            Gore.NewGore(npc.position, npc.velocity, 75, 5f);
            Gore.NewGore(npc.position, npc.velocity, 73, 5f);
            Gore.NewGore(npc.position, npc.velocity, 74, 5f);
            Gore.NewGore(npc.position, npc.velocity, 75, 5f);
            Gore.NewGore(npc.position, npc.velocity, 73, 5f);
            Gore.NewGore(npc.position, npc.velocity, 74, 5f);
            Gore.NewGore(npc.position, npc.velocity, 75, 5f);
            Gore.NewGore(npc.position, npc.velocity, 73, 5f);
            Gore.NewGore(npc.position, npc.velocity, 74, 5f);
            Gore.NewGore(npc.position, npc.velocity, 75, 5f);
        }

        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = ItemID.SuperHealingPotion;
        }
    }
}