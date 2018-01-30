using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace Exam
{
    [DataContract]
    public class Employee
    {
        [DataMember]
        private Guid id;
        [DataMember]
        private string name;
        [DataMember]
        private string division;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Division
        {
            get { return division; }
            set { division = value; }
        }
        public Guid Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}
