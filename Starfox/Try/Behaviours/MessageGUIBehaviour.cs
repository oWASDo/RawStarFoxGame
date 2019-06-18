using OpenTK;
using System;
using Aiv.Audio;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starfox
{
    public class MessageGUIBehaviour : Behaviour
    {
        private Vector3 vec;
        private Random random;
        private AudioSource audio;
        private bool tutorial;
        private float time;
        private float timeLimit;
        private float time1;
        private float timeLimit1;
        private float time2;
        private float timeLimit2;
        private int index;
        private bool tutorial1;
        private bool once;

        public MessageGUIBehaviour(Actor owner) : base(owner)
        {
            random = new Random(DateTime.Now.Minute);
            vec = new Vector3(0.45f, 0.2f, Engine.ZNear);
            audio = new AudioSource();
            tutorial = true;
            SetScale(Vector3.One * 0.1f);
            index = 0;
            time = 0;
            time1 = 0;
            timeLimit1 = random.Next(10, 20);
            tutorial1 = false;
            time2 = 0;
            once = true;
        }
        public override void Update()
        {
            if (tutorial)
            {
                if (!tutorial1)
                {
                    Visible = true;
                    ChangeMaterial(MaterialLibrary.GetMaterial("Capa"), 0);
                    audio.Play(SoundLibrary.GetSound("UseWasd"));
                    timeLimit2 = SoundLibrary.GetSound("UseWasd").Duration + Engine.DeltaTime;
                    timeLimit = timeLimit2;
                    time = 0;
                    tutorial1 = true;
                }
                else if (tutorial1 && time2 >= timeLimit2)
                {
                    Visible = true;
                    ChangeMaterial(MaterialLibrary.GetMaterial("Capa"), 0);
                    audio.Play(SoundLibrary.GetSound("UseSpaceBar"));
                    timeLimit2 = SoundLibrary.GetSound("UseSpaceBar").Duration + Engine.DeltaTime;
                    timeLimit = timeLimit2;
                    time = 0;
                    tutorial = false;
                }
            }
            time2 += Engine.DeltaTime;
            if (Variables.Hitted && !Variables.Dead && !tutorial)
            {
                Visible = true;
                if (!audio.IsPlaying)
                {
                    int n = random.Next(0, 1);
                    if (n == 0)
                    {
                        int nu = random.Next(0, 3);
                        if (nu == 0)
                        {
                            ChangeMaterial(MaterialLibrary.GetMaterial("Simone"), 0);
                            audio.Play(SoundLibrary.GetSound("WeHitMe"));
                            timeLimit = SoundLibrary.GetSound("WeHitMe").Duration;
                            time = 0;
                        }
                        if (nu == 1)
                        {
                            ChangeMaterial(MaterialLibrary.GetMaterial("Fulvio"), 0);
                            audio.Play(SoundLibrary.GetSound("WeHitUs"));
                            timeLimit = SoundLibrary.GetSound("WeHitUs").Duration;
                            time = 0;
                        }
                        if (nu == 2)
                        {
                            ChangeMaterial(MaterialLibrary.GetMaterial("Fulvio"), 0);
                            audio.Play(SoundLibrary.GetSound("HaWeHitUs"));
                            timeLimit = SoundLibrary.GetSound("HaWeHitUs").Duration;
                            time = 0;
                        }
                    }
                    tutorial = false;
                }
                Variables.Hitted = false;
            }
            if (!audio.IsPlaying && !tutorial)
            {
                time1 += Engine.DeltaTime;
                if (time1 >= timeLimit1 && !Variables.Dead)
                {
                    Visible = true;
                    ChangeMaterial(MaterialLibrary.GetMaterial("Capa"), 0);
                    timeLimit = SoundLibrary.GetSound("BarrelRoll").Duration;
                    audio.Play(SoundLibrary.GetSound("BarrelRoll"));
                    timeLimit1 = random.Next(10, 20);
                    time1 = 0;
                    time = 0;
                }
            }
            if (Variables.Dead && once)
            {
                int n = random.Next(0, 50);
                if (n >= 25)
                {
                    audio.Volume = 3f;
                    audio.Play(SoundLibrary.GetSound("No0"));
                    timeLimit = SoundLibrary.GetSound("No0").Duration;
                    audio.Volume = 1f;
                }
                else
                {
                    audio.Volume = 3f;
                    audio.Play(SoundLibrary.GetSound("No1"));
                    timeLimit = SoundLibrary.GetSound("No1").Duration;
                    audio.Volume = 1f;
                }
                once = false;
            }
            if (Variables.MissileReady)
            {
                Visible = true;
                ChangeMaterial(MaterialLibrary.GetMaterial("Fulvio"), 0);
                audio.Play(SoundLibrary.GetSound("MissileReady"));
                timeLimit = SoundLibrary.GetSound("MissileReady").Duration;
                time = 0;
                Variables.MissileReady = false;
            }
            time += Engine.DeltaTime;
            if (time >= timeLimit)
            {
                Visible = false;
            }
            vec = new Vector3(0.45f, 0.2f, -Engine.ZNear);
            SetPosition(Engine.PerspectiveCamera.Position3 + vec);
        }
    }
}

