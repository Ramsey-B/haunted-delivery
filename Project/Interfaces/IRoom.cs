using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    public interface IRoom
    {
        string Name { get; set; }
        string Description { get; set; }
        List<Item> Items { get; set; }
<<<<<<< HEAD

        Dictionary<string, Room> Exits { get; set; }

        void UseItem(Item item);

=======
        Dictionary<string, IRoom> Exits { get; set; }
>>>>>>> f7f666416832fed7dc2a1ee3d524f2e13f6385c5
    }
}
