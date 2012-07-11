using System;

namespace ArtificialIntelligence
{
    abstract class BaseGameEntity
    {
        public int entityID { get; set; }
        public static int nextID { get; set; }

        /// <summary>
        /// Generic constructor for game entities.
        /// </summary>
        /// <param name="id">ID of the entity.</param>
        public BaseGameEntity(int id)
        {
            if (id > nextID - 1)
                entityID = id;
            else
                Console.WriteLine("Entity Already exists");
        }

        ~BaseGameEntity() { }

        public abstract void Update();
    }
}
