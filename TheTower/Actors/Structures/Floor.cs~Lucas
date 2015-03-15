
namespace TheTower
{
    /**
     * Lucas Salom
     * Structure Subclass - Floor
     * No Collision
     */
    public class Floor : Structure
    {
        public Floor(string name, int id)
            : base(name, id)
        {
            this.AddTag("Floor");
        }

        public override Actor clone()
        {
            Actor ret = new Floor(this.Name, this.ID);
            ret.setImage(this.Img);
            return ret;
        }
    }
}
