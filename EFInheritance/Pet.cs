namespace EFInheritance
{
    public abstract class Pet
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            return $"My name is {Name}";
        }
    }
}
