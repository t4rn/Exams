using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Exam70_483.Definitions
{
    [XmlRoot("CompanyUser", Namespace = "http://user")]
    public class User
    {
        [XmlAttribute("ProspectId")]
        public Guid Id { get; set; }

        [XmlElement("Group")]
        public Group UserGroup { get; set; }

        [XmlIgnore]
        public int Amount { get; set; }
    }

    [System.FlagsAttribute()]
    public enum Group
    {
        Users = 1,
        Supervisors = 2,
        Managers = 4,
        Administrator = 8
    }
}
