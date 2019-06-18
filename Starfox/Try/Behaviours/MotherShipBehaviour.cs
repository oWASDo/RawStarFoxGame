using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starfox
{
    public class MotherShipBehaviour : Behaviour
    {
        public MotherShipBehaviour(Actor owner) : base(owner)
        {

        }
        public override void Update()
        {
            if (position.Z <= Engine.PerspectiveCamera.Position3.Z - Variables.MotherShipOffset)
            {
                Actor other = new Actor();
                foreach (Actor item in Engine.CurrentLevel.GetActors(typeof(EnemyMotherShip)))
                {
                    if (item != Owner)
                    {
                        other = item;
                    }
                }
                if (other != null)
                {
                    SetPosition(new OpenTK.Vector3(0, Variables.MotherShipHight, other.Position.Z + Variables.MotherShipOffset * 2f));
                }
            }
        }
    }
}
