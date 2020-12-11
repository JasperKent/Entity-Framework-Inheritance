using System.Collections.Generic;
using System.Text;

namespace EFInheritance
{
    public class Owner
    {
        public int Id { get; set; }

        public ICollection<Pet> Pets { get; set; }

        public override string ToString()
        {
            StringBuilder bob = new StringBuilder();

            foreach (var p in Pets)
                bob.AppendLine(p.ToString());

            return bob.ToString();
        }
    }
}
