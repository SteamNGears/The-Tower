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
     * The Map Factory
     * Creates a Grid that is filled with tiles, each with multiple actors using the CreateMap method
     * Actors area created by reading a tiled .tmx file and giving that data to the actorFactory(which is responsible for Actor Creation)
     * Once the tileset is created, each tile is cloned and placed in the appropriate tile in the grid, once the grid is complete, it can be returned
     * 
     * @author Jakob Wilson
     * */
    class MapFactory
    {
        /**
         * Creates a single grid from a Tiled .tmx file using the delegates specified in ActorFactory
         * @return Grid - the finished map
         * */
        public static Grid CreateMap(String filename)
        {
            
            List<Actor> actors = new List<Actor>();        /** Represents the tileset where 1 of each actor type is loaded in */

            XmlDocument doc = new XmlDocument();                                            //The xml document
            doc.Load(filename);                                                             //load the xml file
            XmlNodeList tmxTileSet = doc.DocumentElement.SelectNodes("/map/tileset/tile");  //parse the tileset

            Actor cur = null;                                               //The current actor we are adding to the list of actors
            foreach (XmlNode node in tmxTileSet)                            //delegate to ActorFactory for creation and store the finished tiles in the appropriate index in the tileset array
            {
                cur = ActorFactory.createActor(node);
                actors.Add(cur);//TODO: make a placeholder actor in case a definition is not in place

            }

            //Get the map and tile dimentions
            XmlNode dimentions = doc.DocumentElement.SelectSingleNode("/map");
            int mapWidth = Convert.ToInt32(dimentions.Attributes["width"].Value);
            int mapHeight = Convert.ToInt32(dimentions.Attributes["height"].Value);
            int tileWidth = Convert.ToInt32(dimentions.Attributes["tilewidth"].Value);
            int tileHeight = Convert.ToInt32(dimentions.Attributes["tileheight"].Value);

            
            //create the grid
            Grid ret = new Grid();
            ret.SetGrid(mapWidth,mapHeight);
            ret.setTileWidth(tileWidth);
            ret.setTileHeight(tileHeight);

            //temporary variables to hold the current x/y position(int pixels)
            int curx = 0;
            int cury = 0;

            
            XmlNodeList layers = doc.DocumentElement.SelectNodes("/map/layer");//the map layers
            XmlNodeList tiles;                                                  //the tiles in each that layer
            
            //create each later in the map and fill it with the actors defined in the xml using the ActorFactory
            foreach(XmlNode layer in layers)//for each layer
            {
                tiles = layer.SelectNodes("data/tile");//get all the tiles
                foreach (XmlNode tile in tiles)//for each tile
                {
                    //get the correct tile it belongs in and add the actor there
                    try
                    {ret.GetTile(curx / tileWidth, cury / tileHeight).AddActor(actors[Convert.ToInt32(tile.Attributes["gid"].Value) - 1].clone());}
                    catch (NullReferenceException e)
                    { MessageBox.Show("Could add actor because " + e.ToString()); }
                    
                    curx += tileWidth;
                    
                    //checks if we need to start a new line
                    if (curx >= mapWidth * tileWidth)
                    {
                        curx = 0;
                        cury += tileHeight;
                    }
                }
            }
            return ret; //return the funushed grid
        }
    }
}
