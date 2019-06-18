using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starfox
{
    public class Button_Behaviour : Behaviour
    {
        public bool click;
        public Button_Behaviour(Actor owner) : base(owner)
        {
            click = false;
        }
        public override void Update()
        {
            bool one = Engine.MousePosition.X >= position.X;
            bool two = Engine.MousePosition.X <= position.X + (scale.X * scale.X);
            bool three = Engine.MousePosition.Y >= position.Y;
            bool four = Engine.MousePosition.Y <= position.Y + (scale.Y * scale.Y);
            if (one && two && three && four && Engine.MouseLeft)
            {
                click = true;
            }
            else
                click = false;

        }
    }
    public class ExitBehaviour : Button_Behaviour
    {
        public ExitBehaviour(Actor owner) : base(owner)
        {
            click = false;
        }
        public override void Update()
        {
            base.Update();
            if (click)
            {
                Engine.Opened = false;
            }

        }
    }
    public class StartBehaviour : Button_Behaviour
    {
        public StartBehaviour(Actor owner) : base(owner)
        {
        }
        public override void Update()
        {
            base.Update();
            if (click)
            {
                Engine.ChangeLevel(1);
            }
        }
    }
}
