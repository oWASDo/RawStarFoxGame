using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace Starfox
{
    public class MessageGUI : GUI
    {
        public MessageGUI(Vector3 position, Vector3 rotation, Vector3 scale) : base(position, rotation, scale)
        {
            AddBehaviour(new MessageGUIBehaviour(this));
            
        }
    }
}
