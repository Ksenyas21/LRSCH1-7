namespace Lab6
{
    
    [Couple(Pair = "Student", Probability = 0.2, ChildType ="Girl")]
    [Couple(Pair = "Botan", Probability = 0.5, ChildType = "Book")]
    sealed class SmartGirl : Human
    {
        public SmartGirl(string name) : base(name)
        {
        }
    }


}
