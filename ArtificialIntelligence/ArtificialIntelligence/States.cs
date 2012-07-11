using System;

namespace ArtificialIntelligence
{    
    abstract class State<T>
    {
        public abstract State<T> Instance();

        public abstract Location_Type GetLocation();
        public abstract void Enter(T entity);
        public abstract void Execute(T entity);
        public abstract void Exit(T entity, Location_Type location);
         ~State(){}
    }
}
