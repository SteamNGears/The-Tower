using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TheTower
{
    static class ActorDelegates
    {
        /**------------------------------------- Sets up all actor delegates---------------------------------*/
        /**
         * Sets up all the actor delegates and adds them to the ActorFactory
         * @author Jakob Wilson
         * */
        public static void init()
        {
            ActorFactory.actorMethod floorDel = ActorDelegates.createFloor;//create the actorMethod delegate
            ActorFactory.addActorMethod("Floor", floorDel); //add it to the Actor Factory

            ActorFactory.actorMethod wallDel = ActorDelegates.createWall;
            ActorFactory.addActorMethod("Wall", wallDel);

            ActorFactory.actorMethod wraithDel = ActorDelegates.createWraith;
            ActorFactory.addActorMethod("Wraith", wraithDel);

            //ActorFactory.actorMethod hydraDel = ActorDelegates.createHydra;
            //ActorFactory.addActorMethod("Hydra", hydraDel);

            ActorFactory.actorMethod skeleDel = ActorDelegates.createSkeleton;
            ActorFactory.addActorMethod("Skeleton", skeleDel);

            ActorFactory.actorMethod vampDel = ActorDelegates.createVampireMonster;
            ActorFactory.addActorMethod("Vampire", vampDel);

            ActorFactory.actorMethod bombDel = ActorDelegates.createBomb;
            ActorFactory.addActorMethod("Bomb", bombDel);
        }


        /**-------------------------------------SECTION for delegate methods ---------------------------------*/
        #region Structures
        /**
         * Creates a floor actor
         * @see ActorFactory.actorMethod
         * @author Jakob Wilson
         * */
        public static Actor createFloor(XmlNode data)
        {
            Actor ret = new Floor("Floor",1);
            ret.setImage(Image.FromFile(data.SelectSingleNode("image").Attributes["source"].Value));
            return ret;
        }
        public static Actor createWall(XmlNode data)
        {
            Actor ret = new Wall("Wall",0);
            ret.setImage(Image.FromFile(data.SelectSingleNode("image").Attributes["source"].Value));
            return ret;
        }
        #endregion

        #region Creatures
        public static Actor createWraith(XmlNode data)
        {
            return new Wraith("Wraith", Image.FromFile(data.SelectSingleNode("image").Attributes["source"].Value));
        }
        public static Actor createBomb(XmlNode data)
        {
            return new Bomb("Bomb", Image.FromFile(data.SelectSingleNode("image").Attributes["source"].Value));
        }
        public static Actor createSkeleton(XmlNode data)
        {
            return new Skeleton("Skeleton", Image.FromFile(data.SelectSingleNode("image").Attributes["source"].Value));
        }
        public static Actor createVampireMonster(XmlNode data )
        {
            return new VampireMonster("Vampire", Image.FromFile(data.SelectSingleNode("image").Attributes["source"].Value));
        }

        /*
         *  **INCOMPLETED**
         * 
         *  create Hydra
         *  3 heads monster
         *  each head have it own attack point
         *  cut one head down and 50% chance it might grow back
         *  need to cut down all head to be killed         * 
         
        public static Actor createHydra(XmlNode data)
        {
            Pawn hydra = new Pawn("Hydra", 3, 5, 50, 10, 10);
            hydra.setImage(Image.FromFile(data.SelectSingleNode("image").Attributes["source"].Value));
            hydra.AddTag("Hydra");
            hydra.AddTag("Creature");
            hydra.AddTag("Collidable");


            return hydra;
        }*/
        #endregion
    }
}
