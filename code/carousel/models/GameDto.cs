using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace carousel.models
{
    public class GameDto
    {
        public Guid Id { get; set; }
        public IList<FileDto> LocalFiles { get; set; }
        public string Name { get; set; }

        public GameDto(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
