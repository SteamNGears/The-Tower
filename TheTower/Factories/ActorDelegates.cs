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
        }


        /**-------------------------------------SECTION for delegate methods ---------------------------------*/
        /**
         * Creates a floor actor
         * @see ActorFactory.actorMethod
         * @author Jakob Wilson
         * */
        public static Actor createFloor(XmlNode data)
        {
            Actor ret = new Floor("Floor", 0);
            ret.setImage(Image.FromFile(data.SelectSingleNode("image").Attributes["source"].Value));
            return ret;
        }


        /**
         * creates a wall actor
         * @see ActorFactory.actorMethod
         * @author Jakob Wilson
         * */
        public static Actor createWall(XmlNode data)
        {
            Actor ret = new Wall("Wall", 0);
            ret.setImage(Image.FromFile(data.SelectSingleNode("image").Attributes["source"].Value));
            return ret;
        }
    }
}
