namespace EF6TPCInheritance
{
    public class Cat : Pet
    {
        public int Lives { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()} and I have {Lives} lives left.";
        }
    }
}
