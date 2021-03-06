﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace gameEngine
{
    public class Enemy : Character 
    {
        int respandeTimer;
        const int maxRespondTimer = 60;

        Random random = new Random();
        SoundEffect eplosion;


        public Enemy() { }

        public Enemy(Vector2 inputPosition)
        {
            position = inputPosition;
        }

        public override void Initialize()
        {
            active = true;
            collidable = false;
            position.X = random.Next(0,1100);

            base.Initialize();
        }

        public override void Load(ContentManager content)
        {
            eplosion = content.Load<SoundEffect>("audio\\explosion");
            image = TextureLoader.Load("enemy", content);
            base.Load(content);
        }
        public override void Update(List<GameObject> objects, Map map)
        {
            //respandeTimer = maxRespondTimer;
            if(respandeTimer > 0)
            {
                respandeTimer--;
                if(respandeTimer <= 0)
                {
                    Initialize();
                }
            }
            base.Update(objects, map);
        }

        public override void bulletResponse()
        {
            Player.score++; 
            active = false;
            respandeTimer = maxRespondTimer;
            // play sound effect or
            eplosion.Play(.5f,-1,-1);
            base.bulletResponse();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {

            base.Draw(spriteBatch);
        }
    }
}
