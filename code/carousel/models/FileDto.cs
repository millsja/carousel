using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace carousel.models
{
    public class FileDto
    {
        public Guid Id { get; set; }

        /// <summary>
        /// key: computer guid
        /// value: path string
        /// 
        /// this dictionary contains a set of computers and the
        /// path for this file local to each machine
        /// </summary>
        public Dictionary<Guid, string> LocalPathDict { get; set; }

        public string Name { get; set; }

        public FileDto(string name)
        {
            Name = name;
        }
    }
}
