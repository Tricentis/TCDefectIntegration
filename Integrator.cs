using System;
using System.Collections.Generic;
using System.Text;

namespace TCDefectIntegration {

    public abstract class Integrator {

        protected Integrator() { }

        /// <summary>
        /// Creates a new Defect in the integrated ChangeRequest-System
        /// fills the fields by the supplied defectInfos and returns the new defect-id
        /// </summary>
        /// <param name="defectInfos">Dictionary of all available Infos (Key=Info-Label, Value = Info-Value)</param>
        /// <returns>the defect-id of the created defect</returns>
        public abstract string CreateDefect(Dictionary<string, string> defectInfos);

        /// <summary>
        /// Opens the Defect in the integrated ChangeRequest-Tool
        /// </summary>
        /// <param name="defectId">unique id of the defect to open</param>
        public abstract void OpenDefect(string defectId);

        /// <summary>
        /// Returns the State of the supplied defects
        /// </summary>
        /// <param name="defectIds">List of all defect-ids to return defect-states</param>
        /// <returns>Dictionary of strings, Key is defect-id, Value is defect-state</returns>
        public abstract Dictionary<string, string> GetStatesForDefects(List<string> defectIds);

        /// <summary>
        /// Returns Info of the supplied defects
        /// </summary>
        /// <param name="defectIds">List of all defect-ids to return defect-infos</param>
        /// <returns>Dictionary of strings, Key is defect-id, Value is defect-info</returns>
        public abstract Dictionary<string, string> GetInfosForDefects(List<string> defectIds);

        /// <summary>
        /// Returns a xml-string of Defect Details
        /// </summary>
        /// <param name="crqIds"></param>
        /// <returns></returns>
        public abstract string GetDefectDetails(List<string> crqIds);

    }

}
