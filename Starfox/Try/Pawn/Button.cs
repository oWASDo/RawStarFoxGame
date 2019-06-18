using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace Starfox
{
    public class Button : Sprite2
    {
        public Button(Vector3 position, Vector3 rotation, Vector3 scale) : base(position, rotation, scale)
        {
            //AddMaterial()
            //AddBehaviour(new Button_Behaviour(this));
        }
    }
    public class ExitButton : Button
    {
        public ExitButton(Vector3 position, Vector3 rotation, Vector3 scale) : base(position, rotation, scale)
        {
            AddMaterial(MaterialLibrary.GetMaterial("Exit"));
            AddBehaviour(new ExitBehaviour(this));
        }
    }
    public class StartButton : Button
    {
        public StartButton(Vector3 position, Vector3 rotation, Vector3 scale) : base(position, rotation, scale)
        {
            AddMaterial(MaterialLibrary.GetMaterial("Start"));
            AddBehaviour(new StartBehaviour(this));
        }
    }
}
