using System;

namespace ArtificialIntelligence
{
    class Miner : BaseGameEntity
    {
        State<Miner> currentState;

        public Location_Type Location { get; set; }
        public int GoldCarried { get; set; }
        public int MoneyInBank { get; set; }
        public int Thirst { get; set; }
        public int Fatigue { get; set; }

        /// <summary>
        /// Constructor for the Miner class.
        /// </summary>
        /// <param name="id">ID of the game entity.</param>
        public Miner(int id) : base(id)
        {
            GoldCarried = 0;
            MoneyInBank = 0;
            Thirst = 100;
            Fatigue = 100;
            currentState = DigForGold.Instance();
            Location = Location_Type.Mine;
        }

        /// <summary>
        /// Executes the current states update logic.
        /// </summary>
        public override void Update()
        {
            //execute logic for currentState state.
            currentState.Execute(this);
        }

        /// <summary>
        /// Change the Miner State.
        /// </summary>
        /// <param name="newState">Miner State to change to.</param>
        public void ChangeState(State<Miner> newState)
        {
            //exit current state and change to new state.
            currentState.Exit(this, Location);

            //change the state.
            Location = newState.GetLocation();
            currentState = newState;

            //enter new state.
            currentState.Enter(this);
        }

    }
}
