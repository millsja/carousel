using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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

        public FileDto(string filePath)
        {
            this.Name = Path.GetFileName(filePath);
            this.LocalPath = filePath;
            this.Id = string.Empty;
        }

        public FileDto(string id, string name)
        {
            Id = id;
            Name = name;
        }

        [JsonConstructor]
        public FileDto()
        {
        }
    }
}
