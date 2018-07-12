using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VkCommands.Data.Impl
{
    public class User : IData
    {
        public override bool Equals(object obj)
        {
            return id.Equals(((User)obj).id) ? true : false;
        }

        private string id = string.Empty;
        private string sex = string.Empty;
        private string firstName = string.Empty;
        private string lastName = string.Empty;
        private string domain = string.Empty;
        private string bDate = string.Empty;
        private string city = string.Empty;
        private string hasChilds = string.Empty;
        private string nextIterationCriteria;
        private string family = string.Empty;
        private string mobileExists = string.Empty;
        private string isOnline = string.Empty;
        private string status = string.Empty;

        public string Id { get { return id; } set { id = value; } }
        public string Sex { get { return sex; } set { sex = value; } }
        public string FirstName { get { return firstName; } set { firstName = value; } }
        public string LastName { get { return lastName; } set { lastName = value; } }
        public string Domain { get { return domain; } set { domain = value; } }
        public string BDate { get { return bDate; } set { bDate = value; } }
        public string City { get { return city; } set { city = value; } }
        public string HasChilds { get { return hasChilds; } set { hasChilds = value; } }
        public string NextIterationCriteria
        {
            get { return nextIterationCriteria; }
            set { nextIterationCriteria = value; }
        }
        public string Family { get { return family; } set { family = value; } }
        public string MobileExists { get { return mobileExists; } set { mobileExists = value; } }
        public string IsOnline { get { return isOnline; } set { isOnline = value; } }
        public string Status { get { return status; } set { status = value; } }
    }
}
