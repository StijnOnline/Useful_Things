using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StijnUtility.BehaviourTree {
    class InverterNode : DecoratorNode {

        public override Status process() {
            Status s = child.process();
            if(s == Status.Running)
                return Status.Running;
            else if(s == Status.Failure)
                return Status.Succes;
            else
                return Status.Failure;
        }
    }
}
