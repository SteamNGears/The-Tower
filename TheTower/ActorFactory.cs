using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace TheTower
{
    /**
     *  A factory for creating actors. How the factory creates the Actor is defined in a map of delegates. 
     *  For example, it we read ab object from a .tmx file with Type "Wall", the delegate for creating a wall will be stored at actorMethods["Wall"]
     *  @author Jakob Wilson
     * */
    class ActorFactory
    {
        public delegate Actor actorMethod(XmlNode data);                                                        /** A delegate type for creating actors from xml data */
        private static Dictionary<String, actorMethod> actorMethods = new Dictionary<string,actorMethod>();     /**A map of delegates to hold all of the actor methods

        /**
         * Calls the appropriate delegate to create the actor. If no delegate can be found, throws an exception
         **/
        public static Actor createActor(XmlNode data)
        {
            XmlNodeList properties = data.SelectSingleNode("properties").SelectNodes("property");
            
            foreach(XmlNode property in properties)
            {
                if(property.Attributes["name"].Value == "Type")
                {
                   
                    try{
                    if (actorMethods[property.Attributes["value"].Value] != null)
                        return actorMethods[property.Attributes["value"].Value](data);
                    }catch( KeyNotFoundException e)
                    {

                        throw new Exception("Could not create actor because no delegate is defined. Error: " + e.ToString());
                    }
                }
            }
            
            throw new Exception("Could not find any \"Type\" property for tile " + data.Attributes["id"].Value);
        }

        /**
         * Adds an actor creation delegate to the list of delegates
         * Note: 
         * */
        public static void addActorMethod(String name, actorMethod a)
        {
            actorMethods.Add(name, a);
        }
        
    }
}
