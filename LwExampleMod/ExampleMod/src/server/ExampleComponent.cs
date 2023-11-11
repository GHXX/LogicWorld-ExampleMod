using LogicAPI.Server.Components;
using System;

namespace YOUR_NAME_OR_ALIAS_WITHOUT_SPACES_LwExampleMod.Server
{
    public class ExampleComponent : LogicComponent
    {
        protected override void Initialize() // useful for setup logic
        {
            base.Initialize();
        }

        // this is useful for not recomputing the logicupdate if a pin changes that has no effect on the output(s). In this case all pins can cause an output change, so i just set it to true
        public override bool InputAtIndexShouldTriggerComponentLogicUpdates(int inputIndex)
        {
            return true;
        }

        protected override void DoLogicUpdate() // contains the main logic of the component
        {
            uint inputNumber = 0;
            for (int i = 0; i < this.Inputs.Count; i++)
            {
                if (this.Inputs[i].On)
                {
                    inputNumber += 1u << i; // sum up all the inputs, scaled by their position, so in a way, read it as a binary number
                }
            }

            var outputNumber = (uint)Math.Sqrt(inputNumber);

            for (int i = 0; i < this.Outputs.Count; i++)
            {
                uint bitValue = outputNumber & (1u << i); // extract the current bit of the number
                this.Outputs[i].On = bitValue > 0; // if the current bit is larger than zero it is set
            }
        }

        public override void Dispose() // useful for Dispose'ing other objects that use unmanaged memory or stuff like Streams, network connections, etc. Generally you will not need this.
        {
            base.Dispose();
        }
    }
}