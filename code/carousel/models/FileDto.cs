using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace carousel.models
{
    public class FileDto
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string LocalPath { get; set; }

        public FileDto(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
