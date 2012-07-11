using System;

namespace ArtificialIntelligence
{
    class DigForGold : State<Miner>
    {
        private static DigForGold _instance;

        public override State<Miner> Instance()
        {
            if (_instance == null)
            {
                _instance = new DigForGold();
            }
            return _instance;
        }

        public override Location_Type GetLocation()
        {
            return Location_Type.Mine;
        }

        public override void Enter(Miner entity)
        {
            Console.WriteLine(entity.ToString() + ": Going to the mine.");
        }

        public override void Execute(Miner entity)
        {
            Console.WriteLine(entity.ToString() + " is at the " + entity.Location);
            Console.WriteLine(entity.ToString() + ": Digging for Gold.");
            Console.WriteLine(entity.ToString() + ": Picking up Gold.");

            entity.GoldCarried++;
            entity.Fatigue -= 5;
            entity.Thirst -= 10;

            if (entity.GoldCarried > 10)
                entity.ChangeState(DepositGold.Instance);
            else if (entity.Thirst <= 10)
                entity.ChangeState(GoBarAndDrink.Instance);
            else if (entity.Fatigue < 15)
                entity.ChangeState(GoHomeAndRest.Instance);
        }

        public override void Exit(Miner entity, Location_Type location)
        {
            Console.WriteLine(entity.ToString() + ": Done digging, going to " + location.ToString());
        }
    }

    class GoHomeAndRest : State<Miner>
    {
        private static GoHomeAndRest _instance;

        public override State<Miner> Instance()
        {
            if (_instance == null)
            {
                _instance = new GoHomeAndRest();
            }
            return _instance;
        }

        public override Location_Type GetLocation()
        {
            return Location_Type.Home;
        }

        public override void Enter(Miner entity)
        {
            Console.WriteLine(entity.ToString() + ": Good day of work, heading home.");
        }

        public override void Execute(Miner entity)
        {
            Console.WriteLine(entity.ToString() + " is at the " + entity.Location);
            Console.WriteLine(entity.ToString() + ": Zzzzz");

            entity.Fatigue += 25;

            if (entity.Fatigue >= 100)
            {
                entity.Fatigue = 100;

                if (entity.GoldCarried > 10)
                    entity.ChangeState(DepositGold.Instance);
                else if (entity.Thirst <= 10)
                    entity.ChangeState(GoBarAndDrink.Instance);
                else
                    entity.ChangeState(DigForGold.Instance);
            }
        }

        public override void Exit(Miner entity, Location_Type location)
        {
            Console.WriteLine(entity.ToString() + ": All rested and ready, heading to the " + location.ToString());

            base.Exit(entity, location);
        }
    }

    class DepositGold : State<Miner>
    {
        private static DepositGold _instance;

        public override State<Miner> Instance()
        {
            if (_instance == null)
            {
                _instance = new DepositGold();
            }
            return _instance;
        }

        public override Location_Type GetLocation()
        {
            return Location_Type.Bank;
        }

        public override void Enter(Miner entity)
        {
            Console.WriteLine(entity.ToString() + ": Just got to the bank.");
        }

        public override void Execute(Miner entity)
        {
            Console.WriteLine(entity.ToString() + " is at the " + entity.Location);
            Console.WriteLine(entity.ToString() + ": Depositing my hard earned gold.");
            Console.WriteLine(entity.ToString() + " Deposited: " + entity.GoldCarried.ToString() + " in the bank.");

            entity.MoneyInBank += entity.GoldCarried;
            entity.GoldCarried = 0;
            entity.Fatigue -= 10;
            entity.Thirst -= 3;

            Console.WriteLine(entity.ToString() + " has " + entity.MoneyInBank.ToString() + " in the bank.");

            if (entity.Fatigue <= 10)
                entity.ChangeState(GoHomeAndRest.Instance);
            else if (entity.Thirst < 10)
                entity.ChangeState(GoBarAndDrink.Instance);
            else
                entity.ChangeState(DigForGold.Instance);
        }

        public override void Exit(Miner entity, Location_Type location)
        {
            Console.WriteLine(entity.ToString() + ": Done depositing heading to: " + location.ToString());
        }
    }

    class GoBarAndDrink : State<Miner>
    {
        private static GoBarAndDrink _instance;

        public override State<Miner> Instance()
        {
            if (_instance == null)
            {
                _instance = new GoBarAndDrink();
            }
            return _instance;
        }

        public override Location_Type GetLocation()
        {
            return Location_Type.Bar;
        }

        public override void Enter(Miner entity)
        {
            Console.WriteLine(entity.ToString() + ": Fuck im thirsty. Bar keep!");
        }

        public override void Execute(Miner entity)
        {
            Console.WriteLine(entity.ToString() + " is at the " + entity.Location);
            Console.WriteLine(entity.ToString() + ": One large whisky please!");

            entity.Thirst = 100;
            entity.Fatigue -= 5;

            if (entity.GoldCarried > 10)
                entity.ChangeState(DepositGold.Instance);
            else if (entity.Fatigue < 15)
                entity.ChangeState(GoHomeAndRest.Instance);
            else
                entity.ChangeState(DigForGold.Instance);
        }

        public override void Exit(Miner entity, Location_Type location)
        {
            Console.WriteLine(entity.ToString() + ": That first be quenched, heading to: " + location.ToString());
        }
    }
}
