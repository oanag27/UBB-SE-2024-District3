using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fancierProfile.Service
{
    internal class ExtraLinksService
    {
        private string link1;
        private string link2;

        public ExtraLinksService(string link1, string link2)
        {
            this.link1 = link1;
            this.link2 = link2;
        }
        public Boolean addNewLink(string newLink)
        {
            return true;
        }
        public Boolean removeLinks(string linkToDelete) {  return true; }
        public  Boolean updateLink(string newLink, int numberOfLink) { return true; }
    }
}
