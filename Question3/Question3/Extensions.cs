using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question3
{
    class Extensions
    {
        private List<string> extensionList;
        
        public Extensions()
        {
            extensionList = new List<string>();
        }
        public void addExtension(string extension)
        {
            extensionList.Add(extension);
        }

        public void removeExtension(string extension)
        {
            extensionList.Remove(extension);
        }

        public List<string> getExtensionList()
        {
            return extensionList;
        }
    }
}
