
namespace TheTower
{
    public interface TileComposite
    {
        void ApplyDamage(Attack atk);

        bool Contains(Tile that);
    }
}
