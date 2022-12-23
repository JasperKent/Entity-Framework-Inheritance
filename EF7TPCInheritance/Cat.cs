namespace EF7TPCInheritance
{
    public class Cat : Pet
    {
        public int Lives { get; set; }

        public override string ToString() => $"{base.ToString()} and I have {Lives} lives left.";
    }
}
