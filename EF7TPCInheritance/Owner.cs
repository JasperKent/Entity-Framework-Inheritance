using System.Text;

namespace EF7TPCInheritance
{
    public class Owner
    {
        public int Id { get; set; }

        public required ICollection<Pet> Pets { get; set; }

        public override string ToString()
        {
            var bob = new StringBuilder();

            foreach (var p in Pets)
                bob.AppendLine(p.ToString());

            return bob.ToString();
        }
    }
}
