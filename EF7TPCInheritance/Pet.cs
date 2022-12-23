namespace EF7TPCInheritance
{
    public abstract class Pet
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public override string ToString() => $"My name is {Name}";
    }
}
