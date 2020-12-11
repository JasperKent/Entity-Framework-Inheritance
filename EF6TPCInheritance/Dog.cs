namespace EF6TPCInheritance
{
    public class Dog : Pet
    {
        public string FavouriteBone { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()} and I like {FavouriteBone} bones.";
        }
    }
}
