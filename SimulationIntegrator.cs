using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using TCDefectIntegration.Issues;

namespace TCDefectIntegration {

    public class SimulationIntegrator : Integrator {

        public SimulationIntegrator() { }

        public override string CreateDefect(Dictionary<string, string> defectInfos) {
            // simulate by using the time-tick
            long simulId = (long)(DateTime.Now.Ticks / 10000);
            return simulId.ToString();
        }

        public override void OpenDefect(string defectId) {
            MessageBox.Show(defectId);
        }

        private static string[] SimulationResults = new string[] { "open", "tested OK", "tested Failed", "submitted", "not accepted" };

        public override Dictionary<string, string> GetStatesForDefects(List<string> defectIds) {
            Dictionary<string, string> retVal = new Dictionary<string, string>();
            int i = 0;
            foreach (string crqId in defectIds) {
                int indx;
                int dummy = Math.DivRem(i, SimulationResults.Length, out indx);
                retVal[crqId] = SimulationResults[indx];
                i++;
            }
            return retVal;
        }

        public override Dictionary<string, string> GetInfosForDefects(List<string> defectIds) {
            Dictionary<string, string> retVal = new Dictionary<string, string>();
            foreach (string crqId in defectIds) {
                retVal[crqId] = "Name for '"+ crqId + "'";
            }
            return retVal;
        }

        public override string GetDefectDetails(List<string> crqIds) {
            //The value of the Type property must be "Defect" or "FeatureRequest"
            var details = new IssueDetails {
                new IssueDetail {
                    ID = "TOS-1234",
                    Name = "Crash when submitting order",
                    State = "Open",
                    Type = "Defect",
                    Severity = 12
                },
                new IssueDetail {
                    ID = "TOS-4321",
                    Name = "Order description must be improved",
                    State = "Open",
                    Type = "FeatureRequest",
                    Severity = 5
                }
            };

            var stringBuilder = new StringBuilder();
            using (var xmlWriter = XmlWriter.Create(stringBuilder, new XmlWriterSettings { NewLineOnAttributes = true, Indent = true })) {
                xmlWriter.WriteStartElement("IssueDetails");
                xmlWriter.WriteAttributeString("xmlns", "xsi", null, @"http://www.w3.org/2001/XMLSchema-instance");
                xmlWriter.WriteAttributeString("xmlns", "xsd", null, @"http://www.w3.org/2001/XMLSchema");
                foreach (var detail in details) {
                    xmlWriter.WriteStartElement("IssueDetail");
                    xmlWriter.WriteElementString("Type", detail.Type);
                    xmlWriter.WriteElementString("State", detail.State);
                    xmlWriter.WriteElementString("ID", detail.ID);
                    xmlWriter.WriteElementString("Name", detail.Name);
                    xmlWriter.WriteElementString("Severity", detail.Severity.ToString());
                    xmlWriter.WriteEndElement();
                }
                xmlWriter.WriteEndElement();
            }
            return stringBuilder.ToString();
        }
    }
}
