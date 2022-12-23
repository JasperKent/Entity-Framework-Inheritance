namespace EF7TPCInheritance
{
    public class Dog : Pet
    {
        public required string FavouriteBone { get; set; }

        public override string ToString() => $"{base.ToString()} and I like {FavouriteBone} bones.";
    }
}
