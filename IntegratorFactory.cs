using System;
using System.Collections.Generic;
using System.Text;

namespace TCDefectIntegration {
    public static class IntegratorFactory {
        public static Integrator GetIntegrator() {
            return new SimulationIntegrator();
        }
    }
}
